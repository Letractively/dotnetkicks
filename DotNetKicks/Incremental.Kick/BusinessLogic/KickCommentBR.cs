using System;
using Incremental.Kick.DataAccess;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.BusinessLogic
{
    public class KickCommentBR
    {

        public static int CreateComment(int storyID, int userID, string username, string comment)
        {
            comment = System.Web.HttpUtility.HtmlEncode(comment);

            if (comment.Length > 4000)
                comment = comment.Substring(0, 4000);

            //TODO: add a word filter (a series of RegExs)
            comment = comment.Replace("\n", "<br/>");

            KickComment kickComment = new KickComment();
            kickComment.StoryID = storyID;
            kickComment.UserID = userID;
            kickComment.Username = username;
            kickComment.Comment = comment;
            kickComment.Save();


            //TODO: Increment
            //now increase the comment count on the story
            //Kick_StoryBR.IncrementStoryCommentCount(storyID);

            return kickComment.CommentID;
        }
    }
}
