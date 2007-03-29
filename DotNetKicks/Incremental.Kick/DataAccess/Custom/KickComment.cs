using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.DataAccess
{
    public partial class KickComment
    {
        public static KickComment FetchCommentByStoryID(int storyID)
        {
            return KickComment.FetchCommentByParemeter(KickComment.Columns.StoryID, storyID);
        }

        public static KickComment FetchCommentByParemeter(string columnName, object value)
        {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            KickCommentCollection c = new KickCommentCollection();
            c.Load(KickComment.FetchByParameter(columnName, value));
            return c[0];
        }
    }
}
