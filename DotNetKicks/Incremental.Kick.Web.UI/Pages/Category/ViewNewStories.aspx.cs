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
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.Category {
    public partial class ViewNewStories : Incremental.Kick.Web.Controls.KickUIPage {
        //NOTE: GJ: this page will be depreciated in favour of tagging
        protected void Page_Init(object sender, EventArgs e) {
            if (!this.UrlParameters.CategoryIdentifierSpecified) {
                this.Caption = "Upcoming stories";
                this.Title = this.HostProfile.SiteTitle + " - " + this.Caption;
            } else {
                this.Caption = "Upcoming " + CategoryCache.GetCategory(this.UrlParameters.CategoryID, this.HostProfile.HostID).Name + " stories";
                this.Title = this.HostProfile.SiteTitle + " - " + this.Caption;
            }

            this.PageName = UrlFactory.PageName.ViewCategoryNewStories;
            this.RssFeedUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategoryNewStoriesRss, this.UrlParameters.CategoryIdentifier);

            this.DisplayAds = false;
        }

        protected void Page_Load(object sender, EventArgs e) {
            this.Paging.PageNumber = UrlParameters.PageNumber;
            this.Paging.PageSize = UrlParameters.PageSize;

            if (this.UrlParameters.StoryListSortBy == Incremental.Kick.Common.Enums.StoryListSortBy.RecentlyPromoted)
                this.UrlParameters.StoryListSortBy = Incremental.Kick.Common.Enums.StoryListSortBy.LatestUpcoming;

            if (!this.UrlParameters.CategoryIdentifierSpecified) {
                this.StoryList.DataBind(StoryCache.GetAllStories(false, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
                this.Paging.RecordCount = StoryCache.GetStoryCount(this.HostProfile.HostID, false);
                this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Home) + "/upcoming";
            } else {
                this.StoryList.DataBind(StoryCache.GetCategoryStories(this.UrlParameters.CategoryID, false, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
                this.Paging.RecordCount = StoryCache.GetCategoryStoryCount(this.UrlParameters.CategoryID, false, this.HostProfile.HostID);
                this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategoryNewStories, this.UrlParameters.CategoryIdentifier);
            }
        }
    }
}
