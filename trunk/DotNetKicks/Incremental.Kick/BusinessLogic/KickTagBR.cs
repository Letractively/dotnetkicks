using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.DataAccess;
using SubSonic;

namespace Incremental.Kick.BusinessLogic
{
    public class KickTagBR
    {
        /*public static TagList GetOrInsertTags(string tagString, KickUserProfile user)
        {
            List<string> rawTags = TagHelper.DistillTagInput(tagString, user);

            TagList tags = new TagList();
            Kick_TagBR tagBR = new Kick_TagBR();
            Kick_TagDataSet newTagDS = new Kick_TagDataSet();
            foreach (string tag in rawTags)
            {
                //TODO: GJ: get from cache
                Kick_TagTable kickTagTable = tagBR.GetTagByTagIdentifier(tag).Kick_Tag;

                if (kickTagTable.Count == 0)
                {
                    newTagDS.Kick_Tag.AddRow(tag);
                }
                else
                {
                    tags.Add(new Tag(kickTagTable[0].TagID, kickTagTable[0].TagIdentifier, 1));
                }
            }

            //now add any new tags (note: if we are calling the cache, we need to ensure that these are not in the db)
            newTagDS = tagBR.Persist(newTagDS);
            foreach (Kick_TagRow tagRow in newTagDS.Kick_Tag.Rows)
            {
                tags.Add(new Tag(tagRow.TagID, tagRow.TagIdentifier, 1));
            }

            return tags;
        }*/

        
/*
        public TagList GetUserTags(int userID)
        {
            return KickTagDao.GetUserTags(userID);
        }

        public TagList GetUserHostTags(int userID, int hostID)
        {
            return KickTagDao.GetUserHostTags(userID, hostID);
        }

        public TagList GetStoryTags(int storyID)
        {
            return KickTagDao.GetStoryTags(storyID);
        }

        public TagList AddUserStoryTags(string tagString, KickUserProfile user, int storyID, int hostID)
        {
            TagList tags = Kick_TagBR.GetOrInsertTags(tagString, user);

            Kick_StoryUserHostTagDataSet userStoryTagsDS = new Kick_StoryUserHostTagDataSet();
            foreach (Tag tag in tags)
            {
                userStoryTagsDS.Kick_StoryUserHostTag.AddRow(storyID, user.UserID, hostID, tag.TagID, DateTime.Now);
                StoryCache.ClearUserTaggedStories(tag.TagName, user.UserID, storyID);
            }

            userStoryTagsDS = this.Persist(userStoryTagsDS);

            return tags;
        }

        public TagList GetUserStoryTags(int userID, int storyID)
        {
            TagList tags = new TagList();

            return KickTagDao.GetUserStoryTags(userID, storyID);
        }

        public static void DeleteTag(int storyID, int userID, int hostID, int tagID)
        {
            new Kick_StoryUserHostTagDAO().DeleteByID(storyID, userID, hostID, tagID);
        }*/
    }
}
