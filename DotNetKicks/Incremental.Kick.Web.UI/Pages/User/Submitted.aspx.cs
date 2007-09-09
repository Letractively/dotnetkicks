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
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Pages.User
{
    public partial class Submitted : Incremental.Kick.Web.Controls.KickUIPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.Title = this.HostProfile.SiteTitle + " : Stories submitted by " + this.UrlParameters.UserIdentifier;
            this.Caption = this.UrlParameters.UserIdentifier;
            this.PageName = UrlFactory.PageName.ViewUser;
            this.DisplayAds = true;
            //TODO need to update rss feed below
            //this.RssFeedUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewUserRss, this.UrlParameters.UserIdentifier);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.StoryListControl.Title = "Stories submitted by " + this.UrlParameters.UserIdentifier;
            this.StoryListControl.DataBind(StoryCache.GetUserSubmittedStories(this.UrlParameters.UserIdentifier, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
            this.Paging.RecordCount = StoryCache.GetUserSubmittedStoriesCount(this.UrlParameters.UserIdentifier, this.HostProfile.HostID);
            this.Paging.PageNumber = UrlParameters.PageNumber;
            this.Paging.PageSize = UrlParameters.PageSize;
            this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewUser, this.UrlParameters.UserIdentifier);
        }

    }
}
