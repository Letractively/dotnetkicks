using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.Web.Controls {
    public class UpcomingStoryListHeader : KickWebControl {
        private string _caption = "";
        public string Caption {
            get { return this._caption; }
            set { this._caption = value; }
        }

        private bool _useAjaxLinks = false;
        public bool UseAjaxLinks {
            get { return this._useAjaxLinks; }
            set { this._useAjaxLinks = value; }
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<table class=""SimpleTable""><tr><td>");
            writer.WriteLine(@"<div class=""PopularStoryListHeader"">Sort By: ", this.KickPage.StaticIconRootUrl);

            this.RenderLink(StoryListSortBy.LatestUpcoming, "Latest Upcoming Stories", writer);
            this.RenderLink(StoryListSortBy.Today, "Top Today", writer);
            this.RenderLink(StoryListSortBy.PastWeek, "This Week ", writer);

            writer.WriteLine(@"</div>");
            writer.WriteLine(@"</td><td align=""right"">{0}</td></tr></table>", this.KickPage.SubCaption);
        }

        private void RenderLink(StoryListSortBy linkSortBy, string caption, HtmlTextWriter writer) {
            string url = "";
            string cssClass = "PopularStoryHeaderLink";
            string javaScript = "";
            string sortByText = linkSortBy.ToString().ToLower();

            if (linkSortBy == StoryListSortBy.LatestUpcoming)
                url += "/upcoming";
            if (linkSortBy != StoryListSortBy.LatestUpcoming)
                url += "/upcoming/popular/" + sortByText;

            if (linkSortBy == this.KickPage.UrlParameters.StoryListSortBy)
                cssClass += " PopularStoryHeaderLinkSelected";

            writer.WriteLine(@"<a id=""StoryListHeader_{0}"" href=""{1}"" {2} class=""{3}"">{4}</a>", sortByText, url, javaScript, cssClass, caption);
        }
    }
}
