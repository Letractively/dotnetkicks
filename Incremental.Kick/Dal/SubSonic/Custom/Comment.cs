using SubSonic;
using System.Security;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Dal {
    public partial class Comment {
        public static CommentCollection FetchCommentsByStoryID(int storyID) {
            return Story.FetchByID(storyID).CommentRecords();
        }

        public static int GetUserCommentsCount(int userID, int hostID) {
            Query query = new Query(Schema).WHERE(Columns.UserID, userID).AND(Columns.HostID, hostID);
            return query.GetCount(Columns.CommentID);
        }

        public static CommentCollection GetUserComments(int userID, int hostID, int pageNumber, int pageSize) {
            CommentCollection comments = new CommentCollection();
            comments.Load(SPs.Kick_GetPagedCommentsByUserIDAndHostID(userID, hostID, pageNumber, pageSize).GetReader());
            return comments;
        }

        public static int CreateComment(int hostID, int storyID, User user, string comment) {
            if (user.IsBanned)
                throw new SecurityException("A banned user can not post a comment");

            if (comment.Length > 4000)
                comment = comment.Substring(0, 4000);

            Comment newComment = new Comment();
            newComment.HostID = hostID;
            newComment.StoryID = storyID;
            newComment.UserID = user.UserID;
            //TODO: GJ: rename comment as it is the same as the table name
            newComment.CommentX = comment;
            newComment.Save();

            StoryBR.IncrementStoryCommentCount(storyID);
            UserAction.RecordComment(hostID, user, Story.FetchByID(storyID), newComment.CommentID);
            return newComment.CommentID;
        }

    }
}
