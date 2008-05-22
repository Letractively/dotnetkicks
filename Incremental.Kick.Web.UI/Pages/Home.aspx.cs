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
using SubSonic.Sugar;

namespace Incremental.Kick.Web.UI.Pages {
    public partial class Home : Incremental.Kick.Web.Controls.KickUIPage {
        protected Home() {
            //this.IsCachedPage = true;
            this.DisplayAds = false; //TODO: GJ: set to true and watch the millions pour in!!!
        }

        protected void Page_Init(object sender, EventArgs e) {
            this.Title = this.HostProfile.SiteTitle + " - " + this.HostProfile.TagLine + ".";
            this.Caption = "Latest popular stories";
            this.PageName = UrlFactory.PageName.Home;

            if (string.IsNullOrEmpty(this.HostProfile.FeedBurnerMainRssFeedUrl))
                this.RssFeedUrl = UrlFactory.CreateUrl(UrlFactory.PageName.HomeRss);
            else
                this.RssFeedUrl = this.HostProfile.FeedBurnerMainRssFeedUrl;
        }

        protected void Page_Load(object sender, EventArgs e) {
            switch (this.UrlParameters.StoryListSortBy) {
                case StoryListSortBy.RecentlyPromoted:
                    this.PopularStoryNavigator.DataBind(StoryCache.GetAllStories(true, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize), StoryCache.GetStoryCount(this.HostProfile.HostID, true));
                    break;
                default:
                    this.PopularStoryNavigator.DataBind(StoryCache.GetPopularStories(this.HostProfile.HostID, true, this.UrlParameters.StoryListSortBy, this.UrlParameters.PageNumber, this.UrlParameters.PageSize), StoryCache.GetPopularStoriesCount(this.HostProfile.HostID, true, this.UrlParameters.StoryListSortBy));
                    break;
            }

            switch (this.UrlParameters.StoryListSortBy) 
            {
                case StoryListSortBy.Today:
                    this.PageName = UrlFactory.PageName.PopularToday;
                    break;
                case StoryListSortBy.PastWeek:
                    this.PageName = UrlFactory.PageName.PopularWeek;
                    break;
                case StoryListSortBy.PastTenDays:
                    this.PageName = UrlFactory.PageName.PopularTenDays;
                    break;
                case StoryListSortBy.PastMonth:
                    this.PageName = UrlFactory.PageName.PopularMonth;
                    break;
                case StoryListSortBy.PastYear:
                    this.PageName = UrlFactory.PageName.PopularYear;
                    break;
            }

            //this.SubCaption = String.Format(@"<a href=""{0}"" class=""highlight"">View {1} >></a>", UrlFactory.CreateUrl(UrlFactory.PageName.NewStories), Strings.Pluralize(StoryCache.GetUpcomingStoryCount(this.HostProfile), "upcoming stories"));
            this.SubCaption = String.Format(@"<a href=""{0}"" class=""highlight"">View {1} >></a>", UrlFactory.CreateUrl(UrlFactory.PageName.NewStories), String.Format("{0:#,###}", StoryCache.GetUpcomingStoryCount(this.HostProfile)) + " upcoming stories");
            //String.Format("{0:#,###}", StoryCache.GetUpcomingStoryCount(this.HostProfile))
        }
    }
}
