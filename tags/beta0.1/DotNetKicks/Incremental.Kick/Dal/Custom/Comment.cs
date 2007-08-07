using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal
{
    public partial class Comment
    {
        public static CommentCollection FetchCommentsByStoryID(int storyID)
        {
            return Story.FetchByID(storyID).CommentRecords();
        }

       
    }
}
