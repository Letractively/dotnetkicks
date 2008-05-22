using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.BusinessLogic {
    //NOTE: GJ: at some point I will be moving much of this logic into the SubSonic models
    public class TagBR {

        public static WeightedTagList GetOrInsertTags(string tagString) {
            return GetOrInsertTags(tagString, false);
        }
        
        public static WeightedTagList GetOrInsertTags(string tagString, bool isAdministrator) {
            List<string> rawTags = TagHelper.DistillTagInput(tagString, isAdministrator);

            WeightedTagList tags = new WeightedTagList();
            TagCollection newTags = new TagCollection();
            foreach (string tagIdentifier in rawTags) {
                //TODO: GJ: get from cache
                Tag tag = Tag.FetchTagByIdentifier(tagIdentifier);

                if (tag == null) {
                    tag = new Tag();
                    tag.TagIdentifier = tagIdentifier;
                    newTags.Add(tag);
                } else {
                    tags.Add(new WeightedTag(tag.TagID, tag.TagIdentifier, 1));
                }
            }

            // newTags.BatchSave(); //TODO: GJ: does BatchSave update identity colums after save?

            foreach (Tag newTag in newTags) {
                newTag.Save(); //TODO: GJ: does BatchSave update identity colums after save?
                tags.Add(new WeightedTag(newTag.TagID, newTag.TagIdentifier, 1));
            }

            return tags;
        }



        public WeightedTagList GetUserTags(int userID) {
            //return TagDao.GetUserTags(userID);
            return new WeightedTagList();
        }

        public WeightedTagList GetUserHostTags(int userID, int hostID) {
            // return TagDao.GetUserHostTags(userID, hostID);
            return new WeightedTagList();

        }

        public WeightedTagList GetStoryTags(int storyID) {
            //return TagDao.GetStoryTags(storyID);
            return new WeightedTagList();

        }

        public static WeightedTagList AddUserStoryTags(string tagString, User user, int storyID, int hostID) {
            WeightedTagList tags = GetOrInsertTags(tagString, user.IsAdministrator);

            StoryUserHostTagCollection storyUserHostTags = new StoryUserHostTagCollection();
            foreach (WeightedTag tag in tags) {
                StoryUserHostTag storyUserHostTag = new StoryUserHostTag(); //TODO: GJ: move to WeightedTag.ToStoryUserHostTag()
                storyUserHostTag.StoryID = storyID;
                storyUserHostTag.HostID = hostID;
                storyUserHostTag.UserID = user.UserID;
                storyUserHostTag.TagID = tag.TagID;
                storyUserHostTags.Add(storyUserHostTag);
                StoryCache.ClearUserTaggedStories(tag.TagName, user.UserID, storyID);
            }

            storyUserHostTags.BatchSave();

            UserAction.RecordTag(hostID, user, Story.FetchByID(storyID), tags);

            //when a user adds a tag, we need to mark the story as updated
            //so update the index during the incremental crawl
            Story story = Story.FetchByID(storyID);
            story.UpdatedOn = DateTime.Now;
            story.Save();

            return tags;
        }
    }
}
