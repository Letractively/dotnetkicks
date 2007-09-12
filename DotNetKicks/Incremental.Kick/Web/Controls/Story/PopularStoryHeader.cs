using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.Web.Controls {
    public class PopularStoryListHeader : KickWebControl {

        private string _caption = "";
        public string Caption {
            get { return this._caption; }
            set { this._caption = value; }
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<table class=""SimpleTable""><tr><td>");
            writer.WriteLine(@"<div class=""PopularStoryListHeader"">Sort By: ", this.KickPage.StaticIconRootUrl);

            this.RenderLink(StoryListSortBy.RecentlyPromoted, "Latest Stories", writer);
            this.RenderLink(StoryListSortBy.Today, "Top Today", writer);
            this.RenderLink(StoryListSortBy.PastWeek, "This Week", writer);

            if(this.KickPage.KickUserProfile.IsAdministrator)
                this.RenderLink(StoryListSortBy.PastTenDays, "Past Ten Days", writer);
            
            this.RenderLink(StoryListSortBy.PastMonth, "This Month", writer);
            this.RenderLink(StoryListSortBy.PastYear, "This Year", writer);

            writer.WriteLine(@"</div>");
            writer.WriteLine(@"</td><td align=""right"">{0}</td></tr></table>", this.KickPage.SubCaption);
        }

        private void RenderLink(StoryListSortBy linkSortBy, string caption, HtmlTextWriter writer) {
            string url = "/";
            string cssClass = "PopularStoryHeaderLink";
            string javaScript = "";
            string sortByText = linkSortBy.ToString().ToLower();

            if(linkSortBy != StoryListSortBy.RecentlyPromoted)
                url += "popular/" + sortByText;

            if(linkSortBy == this.KickPage.UrlParameters.StoryListSortBy)
                cssClass += " PopularStoryHeaderLinkSelected";
            
            writer.WriteLine(@"<a id=""StoryListHeader_{0}"" href=""{1}"" {2} class=""{3}"">{4}</a>", sortByText, url, javaScript, cssClass, caption);
        }
    }
}
