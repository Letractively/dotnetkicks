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
            //NOTE: GJ: DataReader is throwing an exception, using DataTable instead (for now)
            TagCollection tags = new TagCollection();
            tags.Load(SPs.GetKickTags_ByHostIDAndCreatedOnRange(hostID, createdOnLower, createdOnUpper).GetDataSet().Tables[0]);
            return tags;
        }

        public static TagCollection FetchTags(int userID, int hostID) {
            //NOTE: GJ: DataReader is throwing an exception, using DataTable instead (for now)
            TagCollection tags = new TagCollection();
            tags.Load(SPs.GetKickTags_ByUserIDAndHostID(userID, hostID).GetDataSet().Tables[0]);
            return tags;
        }

        public static TagCollection FetchStoryTags(int storyID) {
            //NOTE: GJ: DataReader is throwing an exception, using DataTable instead (for now)
            TagCollection tags = new TagCollection();

            //TODO: GJ: implement
            //tags.Load(SPs.GetTagsByStoryID(storyID).GetDataSet().Tables[0]);
            return tags;
        }

        public static TagCollection FetchUserTags(int userID) {
            //NOTE: GJ: DataReader is throwing an exception, using DataTable instead (for now)
            TagCollection tags = new TagCollection();
            //TODO: GJ: implement
            //tags.Load(SPs.GetTagsByUserID(userID).GetDataSet().Tables[0]);
            return tags;
        }

        

    }
}
