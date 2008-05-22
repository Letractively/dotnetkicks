using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Dal;
using Incremental.Kick.Helpers;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class Comment : KickWebControl {
        private Incremental.Kick.Dal.Comment _comment;
        private bool _useAlternativeStyle;

        public void DataBind(Incremental.Kick.Dal.Comment comment, bool useAlternativeStyle) {
            this._comment = comment;
            this._useAlternativeStyle = useAlternativeStyle;
        }

        public void DataBind(Incremental.Kick.Dal.Comment comment) {
            this._comment = comment;
        }

        public bool DisplayStoryTitle
        {
            get { return _displayStoryTitle; }
            set { _displayStoryTitle = value; }
        }
        private bool _displayStoryTitle = false;

        protected override void Render(HtmlTextWriter writer) {
            string alternativeCssClass = "";
            if (this._useAlternativeStyle)
                alternativeCssClass = "CommentAlt";

            writer.WriteLine(@"<a name=""Comment_{0}""></a><div class=""Comment {0}"">", this._comment.CommentID, alternativeCssClass);

            //when displaying user comments
            //need to show which story they commented on
            if (_displayStoryTitle)
            {
                //build local URL to story
                Category category = CategoryCache.GetCategory(this._comment.Story.CategoryID, this.KickPage.HostProfile.HostID);
                string categoryIdentifier = category.CategoryIdentifier;
                string kickStoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, this._comment.Story.StoryIdentifier, categoryIdentifier);

                //story title
                writer.Write(@"<div class=""storyTitle""><a href=""{0}#Comment_{1}"">{2}</a></div><br/>",
                        kickStoryUrl, this._comment.CommentID, this._comment.Story.Title);


            }
            writer.WriteLine(@"<div class=""CommentText"">{0}</div>
                    <div class=""CommentAuthor"">posted by ", this._comment.CommentX);

            UserLink userLink = new UserLink();
            userLink.DataBind(UserCache.GetUserByUsername(this._comment.Username));
            userLink.RenderControl(writer);

            writer.WriteLine(@" {0}</div></div>", DateHelper.ConverDateToTimeAgo(this._comment.CreatedOn));
        }
    }
}
