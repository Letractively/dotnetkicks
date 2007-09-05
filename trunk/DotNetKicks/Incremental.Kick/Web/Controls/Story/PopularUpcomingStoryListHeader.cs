using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.Web.Controls
{
    public class PopularUpcomingStoryListHeader : PopularStoryListHeader
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.KickPage.UrlParameters.StoryListSortBy = StoryListSortBy.JustAdded;

            writer.WriteLine(@"<table class=""SimpleTable""><tr><td>");
            writer.WriteLine(@"<div class=""PopularStoryListHeader"">Sort By: ", this.KickPage.StaticIconRootUrl);
            
            this.RenderLink(StoryListSortBy.JustAdded, "Latest Upcoming Stories", writer);
            this.RenderLink(StoryListSortBy.Today, "Top Today", writer);

            if (this.KickPage.KickUserProfile.IsAdministrator)
                this.RenderLink(StoryListSortBy.PastTenDays, "Past Ten Days", writer);

            writer.WriteLine(@"</div>");
            writer.WriteLine(@"</td><td align=""right"">{0}</td></tr></table>", this.KickPage.SubCaption);
        }

        protected new void RenderLink(StoryListSortBy linkSortBy, string caption, HtmlTextWriter writer)
        {
            string url = this.KickPage.HostProfile.RootUrl + "/upcoming";
            string cssClass = "PopularStoryHeaderLink";
            string javaScript = "";
            string sortByText = linkSortBy.ToString().ToLower();

            if (linkSortBy != StoryListSortBy.JustAdded)
                url += "/popular/" + sortByText;

            if (linkSortBy == this.KickPage.UrlParameters.StoryListSortBy)
                cssClass += " PopularStoryHeaderLinkSelected";

            //if (this.UseAjaxLinks)
            //    javaScript += String.Format(@"onclick=""PopularStoryHeader_GetPopularStories('{0}', this);return false;"" ", sortByText);

            string testString = string.Format(@"<a id=""StoryListHeader_{0}"" href=""{1}"" {2} class=""{3}"">{4}</a>", sortByText, url, javaScript, cssClass, caption);
            writer.WriteLine(@"<a id=""StoryListHeader_{0}"" href=""{1}"" {2} class=""{3}"">{4}</a>", sortByText, url, javaScript, cssClass, caption);
        }
    }
}
