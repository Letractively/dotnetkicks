using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.BusinessLogic {
    //NOTE: GJ: at some point I will be moving much of this logic into the SubSonic models
    public class TagBR {
        /*public static TagList GetOrInsertTags(string tagString, UserProfile user)
        {
            List<string> rawTags = TagHelper.DistillTagInput(tagString, user);

            TagList tags = new TagList();
            Kick_TagBR tagBR = new Kick_TagBR();
            Kick_TagDataSet newTagDS = new Kick_TagDataSet();
            foreach (string tag in rawTags)
            {
                //TODO: GJ: get from cache
                Kick_TagTable TagTable = tagBR.GetTagByTagIdentifier(tag).Kick_Tag;

                if (TagTable.Count == 0)
                {
                    newTagDS.Kick_Tag.AddRow(tag);
                }
                else
                {
                    tags.Add(new Tag(TagTable[0].TagID, TagTable[0].TagIdentifier, 1));
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
                    return TagDao.GetUserTags(userID);
                }

                public TagList GetUserHostTags(int userID, int hostID)
                {
                    return TagDao.GetUserHostTags(userID, hostID);
                }

                public TagList GetStoryTags(int storyID)
                {
                    return TagDao.GetStoryTags(storyID);
                }

                public TagList AddUserStoryTags(string tagString, UserProfile user, int storyID, int hostID)
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

                    return TagDao.GetUserStoryTags(userID, storyID);
                }

                public static void DeleteTag(int storyID, int userID, int hostID, int tagID)
                {
                    new Kick_StoryUserHostTagDAO().DeleteByID(storyID, userID, hostID, tagID);
                }*/
        public static void DeleteTag(int storyID, int p, int p_3, int tagID) {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
