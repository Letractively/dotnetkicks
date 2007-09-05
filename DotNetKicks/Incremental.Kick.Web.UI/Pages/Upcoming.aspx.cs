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
            this.DisplayAds = true;
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
                switch (this.UrlParameters.StoryListSortBy)
                {
                    case Incremental.Kick.Common.Enums.StoryListSortBy.Today:
                        this.StoryList.DataBind(StoryCache.GetAllStoriesToday(false, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
                        this.Paging.RecordCount = StoryCache.GetStoryCount(this.HostProfile.HostID, false);
                        this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Home) + "/upcoming/popular/today";
                        break;
                    case Incremental.Kick.Common.Enums.StoryListSortBy.ThisWeek:
                        this.StoryList.DataBind(StoryCache.GetAllStoriesThisWeek(false, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
                        this.Paging.RecordCount = StoryCache.GetStoryCount(this.HostProfile.HostID, false);
                        this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Home) + "/upcoming/popular/thisweek";
                        break;
                }
            }
            else
            {
                this.StoryList.DataBind(StoryCache.GetCategoryStories(this.UrlParameters.CategoryID, false, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
                this.Paging.RecordCount = StoryCache.GetCategoryStoryCount(this.UrlParameters.CategoryID, false, this.HostProfile.HostID);
                string test = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategoryNewStories, this.UrlParameters.CategoryIdentifier);
                this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategoryNewStories, this.UrlParameters.CategoryIdentifier);
            }

        }
    }
}
