using System;
using Incremental.Kick.Dal;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.BusinessLogic {
    //NOTE: GJ: at some point I will be moving much of this logic into the SubSonic models
    public class CommentBR {

        public static int CreateComment(int storyID, int userID, string username, string comment) {
            comment = System.Web.HttpUtility.HtmlEncode(comment);

            if (comment.Length > 4000)
                comment = comment.Substring(0, 4000);

            //TODO: add a word filter (a series of RegExs)
            comment = comment.Replace("\n", "<br/>");

            Comment Comment = new Comment();
            Comment.StoryID = storyID;
            Comment.UserID = userID;
            Comment.Username = username;
            //TODO: GJ: rename comment as it is the same as the table name
            Comment.CommentX = comment;
            Comment.Save();


            //TODO: Increment
            //now increase the comment count on the story
            //Kick_StoryBR.IncrementStoryCommentCount(storyID);

            return Comment.CommentID;
        }
    }
}
