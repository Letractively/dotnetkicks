using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Common.Enums;
using SubSonic;

namespace Incremental.Kick.Dal
{
    public partial class Comment
    {
        public static CommentCollection FetchCommentsByStoryID(int storyID)
        {
            return Story.FetchByID(storyID).CommentRecords();
        }

        public static int GetUserCommentsCount(int userID, int hostID)
        {
            //TODO .AND(Comment.Columns.HostID, hostID)
            //HACK there's no HOST ID for comments
            Query query = new Query(Comment.Schema).WHERE(Comment.Columns.UserID, userID);
            return (int)query.GetCount(Comment.Columns.CommentID);
        }

        public static CommentCollection GetUserComments(int userID, int hostID, int pageNumber, int pageSize) {
            CommentCollection comments = new CommentCollection();
            comments.Load(SPs.Kick_GetPagedCommentsByUserIDAndHostID(userID, hostID, pageNumber, pageSize).GetReader());
            return comments;
        }

    }
}
