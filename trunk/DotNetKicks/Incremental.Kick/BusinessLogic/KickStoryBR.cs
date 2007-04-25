using System;
using System.Web;
using Incremental.Kick.Dal;
using Incremental.Kick.Helpers;
using System.Text.RegularExpressions;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.BusinessLogic
{
    public class StoryBR
    {
        public static string AddStory(int hostID, string title, string description, string url, short categoryID, User user)
        {
            if (user.IsBanned)
                return GetStoryIdentifier(title); //to stop the spammers

            return AddStory(hostID, title, description, url, categoryID, user.UserID, user.Username, user.AdsenseID);
        }


        public static string AddStory(int hostID, string title, string description, string url, short categoryID, int userID, string username, string adsenseID)
        {
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
            story.KickCount = 1;
            story.SpamCount = 0;
            story.ViewCount = 0;
            story.CommentCount = 0;
            story.IsPublished = false;
            story.IsSpam = false;
            story.AdsenseID = adsenseID;
            story.Save();


            //now auto-kick it
            //Kick_StoryKickBR.Story(storyDS.Kick_Story[0].StoryID, userID, hostID);

            System.Diagnostics.Trace.WriteLine("AddStory: " + title);

            //TODO: GJ: trackback
            //now send a trackback ping
            /*HostProfile hostProfile = HostCache.GetHostProfile(hostID);
            string storyUrl = hostProfile.RootUrl + "/" + CategoryCache.GetCategoryIdentifier(categoryID, hostID) + "/" +
                storyDS.Kick_Story[0].StoryIdentifier;
            TrackbackHelper.SendTrackbackPing_Begin(url, title, storyUrl, "You've been kicked (a good thing) - Trackback from " + hostProfile.SiteTitle, hostProfile.SiteTitle);
            */

            return story.StoryIdentifier;
        }

        public static string GetStoryIdentifier(string title)
        {
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
            while (iteration < 10)
            {
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

        public static StoryKick AddStoryKick(int storyID, int userID, int hostID)
        {
            StoryKick storyKick = new StoryKick();
            storyKick.StoryID = storyID;
            storyKick.UserID = userID;
            storyKick.HostID = hostID;
            storyKick.Save();
            return storyKick;
        }

        public static void DeleteStoryKick(int storyID, int userID, int hostID)
        {
            throw new NotImplementedException();
            //TODO: GJ: Delete by ids
        }

        public static void PublishStoryProcess()
        {
            throw new NotImplementedException();
            //promote stories to the various hosts homepages
           /* foreach (string hostKey in HostCache.HostProfiles.Keys)
            {
                HostProfile hostProfile = HostCache.HostProfiles[hostKey];
                Trace.Write("Pub: Processing " + hostProfile.HostName);

                //get unkicked stories within the maximumStoryAgeInHours
                DateTime startDate = DateTime.Now.AddHours(-hostProfile.Publish_MinimumStoryAgeInHours);
                DateTime endDate = DateTime.Now.AddHours(-hostProfile.Publish_MaximumStoryAgeInHours);

                //now get a dataset containing all these (NOTE: perf: we could use paging here to reduce the memory footprint)
                Kick_StoryDataSet storyDS = storyBR.GetStoriesByIsKickedHostIDAndPostedDateTime(false, hostProfile.HostID, endDate, startDate);
                Trace.Write("Pub: There are now " + storyDS.Kick_Story.Count + " candidate stories.");

                //pass 1: remove any weak candidate stories
                for (int i = 0; i < storyDS.Kick_Story.Count; i++)
                {
                    Kick_StoryRow story = storyDS.Kick_Story[i];
                    if (IsWeakStory(story, hostProfile))
                    {
                        //remove it from the dataset
                        Trace.Write("Pub: Removing story " + story.StoryID);
                        storyDS.Kick_Story[i].Delete();
                    }
                    else
                    {
                        //Debug.Write("Pub: Keeping story " + story.StoryID);
                    }
                }
                storyDS.AcceptChanges();

                Trace.Write("Pub: There are now " + storyDS.Kick_Story.Count + " candidate stories.");

                //pass 2: calculate scores for each story
                SortedList<int, int> storyScoreList = new SortedList<int, int>();
                foreach (Kick_StoryRow story in storyDS.Kick_Story)
                {
                    storyScoreList[GetStoryScore(story, hostProfile)] = story.StoryID;
                }

                //pass 3: should the top story be published?
                if (storyScoreList.Count > 0)
                {
                    for (int i = 0; i < hostProfile.Publish_MaximumSimiltanousStoryPublishCount; i++)
                    {
                        if (storyScoreList.Count > i)
                        {

                            int storyIndex = storyScoreList.Count - 1 - i; //we have to work backwards as the lowest are first
                            if (storyScoreList.Keys[storyIndex] >= hostProfile.Publish_MinimumStoryScore)
                            {
                                //publish this story
                                Trace.Write("Pub: Publishing storyID:" + storyScoreList.Values[storyIndex]);
                                PublishStory(storyScoreList.Values[storyIndex]);
                            }
                        }
                    }
                }
            }*/
        }

        public static void IncrementStoryCommentCount(int storyID)
        {
            Story story = Story.FetchByID(storyID);
            story.CommentCount++;
            story.Save();
        }

        public static void IncrementSpamCount(int storyID)
        {
            Story story = Story.FetchByID(storyID);
            story.SpamCount++;
            story.Save();
        }

        public static void IncrementViewCount(int storyID, short viewCount)
        {
            Story story = Story.FetchByID(storyID);
            story.ViewCount += viewCount;
            story.Save();
        }

        public static void DeleteStory(int storyID, int hostID)
        {
            //NOTE: GJ: why do we care about the host?
            Story story = Story.FetchByID(storyID);
            if (story.HostID != hostID)
                throw new ArgumentException("The story does not belong to the host");
            else
                Story.Delete(storyID);
        }

        private static bool IsWeakStory(Story story, Host host)
        {
            if ((story.KickCount < host.Publish_MinimumStoryKickCount) || (story.CommentCount < host.Publish_MinimumStoryCommentCount))
                return true;

            //TODO: check the average kicks and comments per hour
            //TODO: check the view count

            return false;
        }


        private static int GetStoryScore(Story story, Host host)
        {
            int score = 0;
            score += story.KickCount * host.Publish_KickScore;
            score += story.CommentCount * host.Publish_CommentScore;
            System.Diagnostics.Trace.WriteLine("Pub: Score of [" + score + "] for storyID " + story.StoryID);
            return score;
        }

        public static void PublishStory(int storyID)
        {
            Story story = Story.FetchByID(storyID);
            story.IsPublished = true;
            story.PublishedOn = DateTime.Now;
        }

        public static int GetStoryCount(int hostID, bool isPublished, DateTime startDate, DateTime endDate)
        {
            //return StoryDao.GetStoryCount(hostID, isPublished, startDate, endDate);

           // Story.CreateQuery().GetCount(Story.Schema.Name, k
            throw new NotImplementedException();
        }

        public static int GetTaggedStoryCount(string tagIdentifier, int hostID)
        {
            //return StoryDao.GetStoryCount(TagCache.GetTagID(tagIdentifier), hostID);
            throw new NotImplementedException();
        }

        public static Story GetUserKickedStories(int userID, int hostID, int pageNumber, int pageSize)
        {
            //return Kick_StoryDAO.GetUserKickedStories(userID, hostID, pageNumber, pageSize);
            throw new NotImplementedException();
        }

        public static Story GetTaggedStories(string tagIdentifier, int hostID, int pageNumber, int pageSize)
        {
            //return StoryDao.GetTaggedStories(TagCache.GetTagID(tagIdentifier), hostID, pageNumber, pageSize);
            throw new NotImplementedException();
        }

        public static Story GetTaggedStories(int tagID, int hostID, int pageNumber, int pageSize)
        {
            //return StoryDao.GetTaggedStories(tagID, hostID, pageNumber, pageSize);
            throw new NotImplementedException();
        }

        public static Story GetUserTaggedStories(string tagIdentifier, int userID, int hostID, int pageNumber, int pageSize)
        {
            //return StoryDao.GetUserTaggedStories(TagCache.GetTagID(tagIdentifier), userID, hostID, pageNumber, pageSize);
            throw new NotImplementedException();
        }

        public static Story GetUserTaggedStories(int tagID, int userID, int hostID, int pageNumber, int pageSize)
        {
            //return StoryDao.GetUserTaggedStories(tagID, userID, hostID, pageNumber, pageSize);
            throw new NotImplementedException();
        }

        public static int GetUserTaggedStoryCount(string tagIdentifier, int userID, int hostID)
        {
            //return StoryDao.GetUserTaggedStoryCount(TagCache.GetTagID(tagIdentifier), userID, hostID);
            throw new NotImplementedException();
        }

        public static Story GetPopularStories(int hostID, StoryListSortBy sortBy, int pageNumber, int pageSize)
        {
            //return StoryDao.GetPopularStories(hostID, GetStartDate(sortBy), DateTime.Now, pageNumber, pageSize);
            throw new NotImplementedException();
        }

        public static int GetPopularStoriesCount(int hostID, StoryListSortBy sortBy)
        {
            //return StoryDao.GetPopularStoriesCount(hostID, GetStartDate(sortBy), DateTime.Now);
            throw new NotImplementedException();
        }

        private static DateTime GetStartDate(StoryListSortBy sortBy)
        {
            switch (sortBy)
            {
                case StoryListSortBy.Today:
                    return DateTime.Now.AddDays(-1);
                case StoryListSortBy.PastWeek:
                    return DateTime.Now.AddDays(-7);
                case StoryListSortBy.PastTenDays:
                    return DateTime.Now.AddDays(-10);
                case StoryListSortBy.PastMonth:
                    return DateTime.Now.AddDays(-31);
                case StoryListSortBy.PastYear:
                    return DateTime.Now.AddDays(-365);
                default:
                    throw new ArgumentException("Invalid sortBy");
            }
        }
    }
}
