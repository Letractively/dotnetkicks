using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Helpers;
using Incremental.Kick.Caching;

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

            writer.WriteLine(@"<div class=""Comment {0}"">", alternativeCssClass);

            //when displaying user comments
            //need to show which story they commented on
            if (_displayStoryTitle)
            {
                string publishedHtml = "";
                if (this._comment.Story.IsPublishedToHomepage)
                    publishedHtml = "published " + DateHelper.ConverDateToTimeAgo(this._comment.Story.PublishedOn) + ", ";

                //story title
                writer.Write(@"<div class=""storyTitle""><a href=""{0}"">{1}</a> <a href=""{0}""><img src=""{2}/external.png"" width=""10"" height=""10"" border=""0""/></a></div><div class=""storySubmitted"">{3} submitted by",
                        this._comment.Story.Url, this._comment.Story.Title, this.KickPage.StaticIconRootUrl, publishedHtml);

                //submitted by
                UserLink storySubmitterUserLink = new UserLink();
                storySubmitterUserLink.DataBind(UserCache.GetUserByUsername(this._comment.Story.Username));
                storySubmitterUserLink.RenderControl(writer);
                writer.WriteLine("</div><br/>");

            }
            writer.WriteLine(@"<div class=""CommentText"">{0}</div>
                    <div class=""CommentAuthor"">posted by ", this._comment.CommentX);

            UserLink userLink = new UserLink();
            userLink.DataBind(UserCache.GetUserByUsername(this._comment.Username));
            userLink.RenderControl(writer);

            writer.WriteLine(@"{0}</div></div>", DateHelper.ConverDateToTimeAgo(this._comment.CreatedOn));
        }
    }
}
