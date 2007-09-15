using System;
using Incremental.Kick.Dal;
using Incremental.Kick.Helpers;
using Incremental.Kick.Caching;
using System.Security;

namespace Incremental.Kick.BusinessLogic {
    //NOTE: GJ: at some point I will be moving much of this logic into the SubSonic models
    public class CommentBR {

        public static int CreateComment(int hostID, int storyID, int userID, User user, string comment) {
            if (user.IsBanned)
                throw new SecurityException("A banned user can not post a comment");

            comment = System.Web.HttpUtility.HtmlEncode(comment);

            if (comment.Length > 4000)
                comment = comment.Substring(0, 4000);

            //TODO: add a word filter (a series of RegExs)
            comment = TextHelper.Urlify(comment);
            comment = comment.Replace("\n", "<br/>");

            Comment newComment = new Comment();
            newComment.HostID = hostID;
            newComment.StoryID = storyID;
            newComment.UserID = user.UserID;
            newComment.Username = user.Username;
            //TODO: GJ: rename comment as it is the same as the table name
            newComment.CommentX = comment;
            newComment.Save();

            StoryBR.IncrementStoryCommentCount(storyID);
            SpyCache.GetSpy(hostID).Comment(userID, newComment.CommentID, storyID);


            return newComment.CommentID;
        }
    }
}
