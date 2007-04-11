using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal
{
    public partial class KickComment
    {
        public static KickCommentCollection FetchCommentsByStoryID(int storyID)
        {
            return KickStory.FetchByID(storyID).KickCommentRecords();
        }

       
    }
}
