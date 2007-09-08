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
        public static CommentCollection FetchCommentsByUser(int userId)
        {
            return Comment.FetchCommentsByParameter(Comment.Columns.UserID, userId);
        }

        public static CommentCollection FetchCommentsByIdentifier(string commentIdentifier)
        {
            return Comment.FetchCommentsByParameter(Comment.Columns.CommentID, commentIdentifier);
        }

        public static CommentCollection FetchCommentsByParameter(string columnName, object value)
        {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            CommentCollection t = new CommentCollection();
            t.Load(Comment.FetchByParameter(columnName, value));
            return t;
        }
        public static int GetUserCommentsCount(int userID, int hostID)
        {
            //TODO .AND(Comment.Columns.HostID, hostID)
            //HACK there's no HOST ID for comments
            Query query = new Query(Comment.Schema).WHERE(Comment.Columns.UserID, userID);
            return (int)query.GetCount(Comment.Columns.CommentID);
        }

    }
}
