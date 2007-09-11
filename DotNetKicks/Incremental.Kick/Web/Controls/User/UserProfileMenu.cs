using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Common.Enums;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class UserProfileMenu : KickWebControl {
        public UserProfileMenu() { }
        public UserProfileMenu(string caption) {
            this.Caption = caption;
        }
        
        private string _caption = "";
        public string Caption {
            get { return this._caption; }
            set { this._caption = value; }
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<table class=""SimpleTable""><tr><td>");

            this.RenderLink(UrlFactory.PageName.UserProfile, "Profile", writer);
            this.RenderLink(UrlFactory.PageName.UserKickedStories, "Kicked", writer);
            this.RenderLink(UrlFactory.PageName.UserSubmittedStories, "Submitted", writer);
            this.RenderLink(UrlFactory.PageName.UserComments, "Comments", writer);
            this.RenderLink(UrlFactory.PageName.UserTags, "Tags", writer);
            this.RenderLink(UrlFactory.PageName.UserFriends, "Friends", writer);

            writer.WriteLine(@"</div>");
            writer.WriteLine(@"</td><td align=""right"">{0}</td></tr></table>", this.KickPage.SubCaption);
        }

        private void RenderLink(UrlFactory.PageName pageName, string caption, HtmlTextWriter writer) {
            string url = UrlFactory.CreateUrl(pageName, this.KickPage.UrlParameters.UserIdentifier);
            string cssClass = "PopularStoryHeaderLink";

            if (pageName == this.KickPage.PageName)
                cssClass += " PopularStoryHeaderLinkSelected";

            writer.WriteLine(@"<a href=""{0}"" class=""{1}"">{2}</a>", url, cssClass, caption);
        }
    }
}
