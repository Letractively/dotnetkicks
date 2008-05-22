using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;
using System.Data;

namespace Incremental.Kick.Dal {
    public partial class Tag {
        public static Tag FetchTagByIdentifier(string tagIdentifier) {
            return Tag.FetchTagByParameter(Tag.Columns.TagIdentifier, tagIdentifier);
        }

        public static Tag FetchTagByParameter(string columnName, object value) {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            TagCollection t = new TagCollection();
            t.Load(Tag.FetchByParameter(columnName, value));
            if (t.Count == 0)
                return null;
            else
                return t[0];
        }

        public static TagCollection FetchTags(int hostID, DateTime createdOnLower, DateTime createdOnUpper) {
            TagCollection tags = new TagCollection();
            tags.Load(SPs.Kick_GetTagsByHostIDAndCreatedOnRange(hostID, createdOnLower, createdOnUpper).GetReader());
            return tags;
        }

        public static TagCollection FetchTags(int userID, int hostID) {
            TagCollection tags = new TagCollection();
            tags.Load(SPs.Kick_GetTagsByUserIDAndHostID(userID, hostID).GetReader());
            return tags;
        }

        public static TagCollection FetchStoryTags(int storyID) {
            TagCollection tags = new TagCollection();
            tags.LoadAndCloseReader(SPs.Kick_GetTagsByStoryID(storyID).GetReader());
            return tags;
        }

        public static TagCollection FetchUserTags(int userID) {
            TagCollection tags = new TagCollection();
            tags.Load(SPs.Kick_GetTagsByUserID(userID).GetReader());
            return tags;
        }

         public static TagCollection FetchUserStoryTags(int userID, int storyID) {
            TagCollection tags = new TagCollection();
            tags.Load(SPs.Kick_GetTagsByUserIDAndStoryID(userID, storyID).GetReader());
            return tags;
        }
    }
}
