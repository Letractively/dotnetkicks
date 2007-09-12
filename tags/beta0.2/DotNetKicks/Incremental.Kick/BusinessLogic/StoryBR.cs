using System;
using System.Web;
using Incremental.Kick.Dal;
using Incremental.Kick.Helpers;
using System.Text.RegularExpressions;
using Incremental.Kick.Common.Enums;
using Incremental.Kick.Caching;
using System.Diagnostics;
using System.Collections.Generic;
using SubSonic;

namespace Incremental.Kick.BusinessLogic {
    //NOTE: GJ: at some point I will be moving much of this logic into the SubSonic models
    public class StoryBR {

        public static string AddStory(int hostID, string title, string description, string url, short categoryID, User user) {
            if (user.IsBanned)
                return GetStoryIdentifier(title); //to stop the spammers

            return AddStory(hostID, title, description, url, categoryID, user.UserID, user.Username, user.AdsenseID);
        }


        public static string AddStory(int hostID, string title, string description, string url, short categoryID, int userID, string username, string adsenseID) {
            //TODO: improve the validation
            string storyIdentifier = GetStoryIdentifier(title);

            if (description.Length > 2500)
                description = description.Substring(0, 2500);

            url = url.Trim();
            if (url.Length > 980)
                throw new Exception("The url is too long");

            title = HttpUtility.HtmlEncode(title);
            description = HttpUtility.HtmlEncode(description);

            Story story = new Story();
            story.HostID = hostID;
            story.StoryIdentifier = storyIdentifier;
            story.Title = title;
            story.Description = description;
            story.Url = url;
            story.CategoryID = categoryID;
            story.UserID = userID;
            story.Username = username;
            story.KickCount = 0;
            story.SpamCount = 0;
            story.ViewCount = 0;
            story.CommentCount = 0;
            story.IsPublishedToHomepage = false;
            story.IsSpam = false;
            story.AdsenseID = adsenseID;
            story.PublishedOn = DateTime.Now;
            story.Save();


            UserCache.KickStory(story.StoryID, userID, hostID);

            System.Diagnostics.Trace.WriteLine("AddStory: " + title);

            //now send a trackback ping
            Host host = HostCache.GetHost(hostID);
            string storyUrl = host.RootUrl + "/" + CategoryCache.GetCategory(categoryID, hostID).CategoryIdentifier + "/" + story.StoryIdentifier;
            TrackbackHelper.SendTrackbackPing_Begin(url, title, storyUrl, "You've been kicked (a good thing) - Trackback from " + host.SiteTitle, host.SiteTitle);

            return story.StoryIdentifier;
        }

        public static string GetStoryIdentifier(string title) {
            title = Regex.Replace(title, @"[^\w\s]", "_");
            title = title.Replace(" ", "_");
            while (Regex.Match(title, "__").Success)
                title = Regex.Replace(title, "__", "_");

            if (title.Substring(0, 1) == "_")
                title = title.Substring(1, title.Length - 1);

            if (title.Substring(title.Length - 1, 1) == "_")
                title = title.Substring(0, title.Length - 1);

            string identifier = title;

            //ensure that it is unique in the database     
            //NOTE: we could use a datestamp to make it unique
            int iteration = 0;
            while (iteration < 10) {
                if (iteration > 0)
                    identifier = title + "_" + iteration;

                StoryCollection stories = new StoryCollection();
                stories.LoadAndCloseReader(Story.FetchByParameter(Story.Columns.StoryIdentifier, identifier));

                if (stories.Count == 0)
                    return identifier;

                iteration++;
            }

            throw new Exception("The story identifier [" + title + "] was not unique");
        }



        public static StoryKick AddStoryKick(int storyID, int userID, int hostID) {
            StoryKick storyKick = new StoryKick();
            storyKick.StoryID = storyID;
            storyKick.UserID = userID;
            storyKick.HostID = hostID;
            storyKick.Save();
            return storyKick;
        }

        public static void DeleteStoryKick(int storyID, int userID, int hostID) {
            StoryKick.Destroy(storyID, userID, hostID);
        }

        public static void PublishStoryProcess() {
            // promote stories to the various hosts homepages
            foreach (string hostKey in HostCache.Hosts.Keys) {
                Host host = HostCache.Hosts[hostKey];
                Trace.Write("Pub: Processing " + host.HostName);

                //get unkicked stories within the maximumStoryAgeInHours
                DateTime startDate = DateTime.Now.AddHours(-host.Publish_MinimumStoryAgeInHours);
                DateTime endDate = DateTime.Now.AddHours(-host.Publish_MaximumStoryAgeInHours);

                //now get a dataset containing all these (NOTE: perf: we could use paging here to reduce the memory footprint)
                StoryCollection stories = Story.GetStoriesByIsPublishedAndHostIDAndPublishedDate(host.HostID, false, endDate, startDate);
                Trace.Write("Pub: There are now " + stories.Count + " candidate stories.");

                //pass 1: remove any weak candidate stories 
                StoryCollection candidateStories = new StoryCollection();
                foreach (Story story in stories) {
                    if (!IsWeakStory(story, host))
                        candidateStories.Add(story);
                }

                Trace.Write("Pub: There are now " + candidateStories.Count + " candidate stories.");

                //pass 2: calculate scores for each story
                SortedList<int, int> storyScoreList = new SortedList<int, int>();
                foreach (Story story in candidateStories) {
                    storyScoreList[GetStoryScore(story, host)] = story.StoryID;
                }

                //pass 3: should the top story be published?
                if (storyScoreList.Count > 0) {
                    for (int i = 0; i < host.Publish_MaximumSimultaneousStoryPublishCount; i++) {
                        if (storyScoreList.Count > i) {
                            int storyIndex = storyScoreList.Count - 1 - i; //we have to work backwards as the lowest are first
                            if (storyScoreList.Keys[storyIndex] >= host.Publish_MinimumStoryScore) {
                                //publish this story
                                Trace.Write("Pub: Publishing storyID:" + storyScoreList.Values[storyIndex]);
                                PublishStory(storyScoreList.Values[storyIndex]);
                            }
                        }
                    }
                }
            }
        }

        public static int IncrementStoryCommentCount(int storyID) {
            Story story = Story.FetchByID(storyID);
            story.CommentCount++;
            story.Save();
            return story.CommentCount;
        }

        public static int IncrementSpamCount(int storyID) {
            Story story = Story.FetchByID(storyID);
            story.SpamCount++;
            story.Save();
            return story.SpamCount;
        }

        public static int IncrementViewCount(int storyID) {
            return IncrementViewCount(storyID, 1);
        }

        public static int IncrementViewCount(int storyID, short delta) {
            Story story = Story.FetchByID(storyID);
            story.ViewCount += delta;
            story.Save();
            return story.ViewCount;
        }

        public static int IncrementKickCount(int storyID) {
            return IncrementKickCount(storyID, 1);
        }

        public static int DecrementKickCount(int storyID) {
            return IncrementKickCount(storyID, -1);
        }

        public static int IncrementKickCount(int storyID, short delta) {
            Story story = Story.FetchByID(storyID);
            story.KickCount += delta;
            story.Save();
            return story.KickCount;
        }

        public static void DeleteStory(int storyID, int hostID) {
            Story story = Story.FetchByID(storyID);
            if (story.HostID != hostID)
                throw new ArgumentException("The story does not belong to the host");
            else
                Story.Delete(storyID);
        }

        private static bool IsWeakStory(Story story, Host host) {
            if ((story.KickCount < host.Publish_MinimumStoryKickCount) || (story.CommentCount < host.Publish_MinimumStoryCommentCount))
                return true;

            //TODO: check the average kicks and comments per hour
            //TODO: check the view count

            return false;
        }


        private static int GetStoryScore(Story story, Host host) {
            int score = 0;
            score += story.KickCount * host.Publish_KickScore;
            score += story.CommentCount * host.Publish_CommentScore;
            System.Diagnostics.Trace.WriteLine("Pub: Score of [" + score + "] for storyID " + story.StoryID);
            return score;
        }

        public static void PublishStory(int storyID) {
            Story story = Story.FetchByID(storyID);
            story.IsPublishedToHomepage = true;
            story.PublishedOn = DateTime.Now;
            story.Save();
        }

        public static int GetStoryCount(int hostID, bool isPublished, DateTime startDate, DateTime endDate) {
            return Story.GetStoryCount(hostID, isPublished, startDate, endDate);
        }

        public static int GetTaggedStoryCount(string tagIdentifier, int hostID) {
            return Story.GetTaggedStoryCount(TagCache.GetTagID(tagIdentifier), hostID);
        }

        internal static bool DoesStoryKickNotExist(int storyID, int userID, int hostID) {
            return !DoesStoryKickExist(storyID, userID, hostID);
        }

        internal static bool DoesStoryKickExist(int storyID, int userID, int hostID) {
            Query query = new Query(StoryKick.Schema).WHERE(StoryKick.Columns.StoryID, storyID).AND(StoryKick.Columns.UserID, userID).AND(StoryKick.Columns.HostID, hostID);
            return query.GetCount(StoryKick.Columns.StoryKickID) == 1;
        }
    }
}
