using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Common.Enums;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Pages
{
    public partial class Upcoming : Incremental.Kick.Web.Controls.KickUIPage
    {
        protected Upcoming()
        {
            this.DisplayAds = false;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Title = this.HostProfile.SiteTitle + " - " + this.HostProfile.TagLine + ".";
            this.Caption = "Upcoming popular stories";
            this.PageName = UrlFactory.PageName.NewStories;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Paging.PageNumber = UrlParameters.PageNumber;
            this.Paging.PageSize = UrlParameters.PageSize;

            if (!this.UrlParameters.CategoryIdentifierSpecified)
            {
                this.StoryList.DataBind(StoryCache.GetPopularStories(this.HostProfile.HostID, false, this.UrlParameters.StoryListSortBy, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
                this.Paging.RecordCount = StoryCache.GetPopularStoriesCount(this.HostProfile.HostID, false, this.UrlParameters.StoryListSortBy);
                this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Home) + "/upcoming/popular/" + this.UrlParameters.StoryListSortBy.ToString().ToLower();
            }
            else
            {
                this.StoryList.DataBind(StoryCache.GetCategoryStories(this.UrlParameters.CategoryID, false, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
                this.Paging.RecordCount = StoryCache.GetCategoryStoryCount(this.UrlParameters.CategoryID, false, this.HostProfile.HostID);
                string test = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategoryNewStories, this.UrlParameters.CategoryIdentifier);
                this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategoryNewStories, this.UrlParameters.CategoryIdentifier);
            }

            switch (this.UrlParameters.StoryListSortBy)
            {
                case StoryListSortBy.Today:
                    this.PageName = UrlFactory.PageName.UpcomingToday;
                    break;
                case StoryListSortBy.PastWeek:
                    this.PageName = UrlFactory.PageName.UpcomingWeek;
                    break;
                default:
                    this.PageName = UrlFactory.PageName.NewStories;
                    break;
            }

        }
    }
}
