using System;
using System.Web.UI;
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;
using Incremental.Kick.Helpers;
using Incremental.Kick.Web.Helpers;
using SubSonic.Sugar;

namespace Incremental.Kick.Web.Controls {
    public class Comment : KickWebControl {
        private Dal.Comment _comment;
        private bool _useAlternativeStyle;

        public void DataBind(Dal.Comment comment, bool useAlternativeStyle) {
            _comment = comment;
            _useAlternativeStyle = useAlternativeStyle;
        }

        public void DataBind(Dal.Comment comment) {
            _comment = comment;
        }

        public bool DisplayStoryTitle
        {
            get { return _displayStoryTitle; }
            set { _displayStoryTitle = value; }
        }

        private bool _displayStoryTitle = false;

        protected override void Render(HtmlTextWriter writer) {
            if (_comment.IsSpam)
                _comment.CommentX = "<em>[comment removed]</em>";

            string alternativeCssClass = "";
            if (_useAlternativeStyle)
                alternativeCssClass = "CommentAlt";

            writer.WriteLine(@"<a name=""Comment_{0}""></a><div class=""Comment {0}"">", _comment.CommentID, alternativeCssClass);

            //when displaying user comments
            //need to show which story they commented on
            if (_displayStoryTitle)
            {
                //build local URL to story
                Category category = CategoryCache.GetCategory(_comment.Story.CategoryID, KickPage.HostProfile.HostID);
                string categoryIdentifier = category.CategoryIdentifier;
                string kickStoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, _comment.Story.StoryIdentifier, categoryIdentifier);

                //story title
                writer.Write(@"<div class=""storyTitle""><a href=""{0}#Comment_{1}"">{2}</a></div><br />",
                        kickStoryUrl, _comment.CommentID, _comment.Story.Title);
            }

            writer.WriteLine(@"<div class=""CommentText"">{0}</div>
                    <div class=""CommentAuthor"">posted by ", KickPage.KickUserProfile.ShowEmoticons ? TextHelper.ReplaceEmoticons(_comment.CommentX, KickPage.StaticEmoticonsRootUrl) : _comment.CommentX);

            UserLink userLink = new UserLink();
            userLink.DataBind(UserCache.GetUser(_comment.UserID));
            userLink.RenderControl(writer);

            writer.WriteLine(@" {0}</div></div>", Dates.ReadableDiff(_comment.CreatedOn, DateTime.Now));
        }
    }
}
