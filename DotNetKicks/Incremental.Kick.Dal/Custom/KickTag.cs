using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;
using System.Data;

namespace Incremental.Kick.Dal
{
    public partial class KickTag
    {
        public static KickTag FetchTagByIdentifier(string tagIdentifier)
        {
            return KickTag.FetchTagByParemeter(KickTag.Columns.TagIdentifier, tagIdentifier);
        }

        public static KickTag FetchTagByParemeter(string columnName, object value)
        {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            KickTagCollection t = new KickTagCollection();
            t.Load(KickUser.FetchByParameter(columnName, value));
            return t[0];
        }

        public static KickTagCollection FetchTags(int hostID, DateTime createdOnLower, DateTime createdOnUpper)
        {
            //NOTE: GJ: DataReader is throwing an exception, using DataTable instead (for now)
            KickTagCollection tags = new KickTagCollection();
            tags.Load(SPs.GetKickTagsByHostIDAndCreatedOnRange(hostID, createdOnLower, createdOnUpper).GetDataSet().Tables[0]);
            return tags;
        }

        public static KickTagCollection FetchTags(int userID, int hostID)
        {
            //NOTE: GJ: DataReader is throwing an exception, using DataTable instead (for now)
            KickTagCollection tags = new KickTagCollection();
            tags.Load(SPs.GetKickTagsByUserIDAndHostID(userID, hostID).GetDataSet().Tables[0]);
            return tags;
        }

        public static KickTagCollection FetchStoryTags(int storyID)
        {
            //NOTE: GJ: DataReader is throwing an exception, using DataTable instead (for now)
            KickTagCollection tags = new KickTagCollection();

            //TODO: GJ: implement
            //tags.Load(SPs.GetKickTagsByStoryID(storyID).GetDataSet().Tables[0]);
            return tags;
        }

        public static KickTagCollection FetchUserTags(int userID)
        {
            //NOTE: GJ: DataReader is throwing an exception, using DataTable instead (for now)
            KickTagCollection tags = new KickTagCollection();
            //TODO: GJ: implement
            //tags.Load(SPs.GetKickTagsByUserID(userID).GetDataSet().Tables[0]);
            return tags;
        }

    }
}
