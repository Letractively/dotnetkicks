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
    public partial class ViewKickedStories : Incremental.Kick.Web.Controls.KickUIPage {

        protected void Page_Init(object sender, EventArgs e) {
            this.Caption = "Latest " + CategoryCache.GetCategory(this.UrlParameters.CategoryID, this.HostProfile.HostID).Name + " stories";
            this.Title = this.HostProfile.SiteTitle + " - " + this.Caption;
            this.PageName = UrlFactory.PageName.ViewCategory;
            this.RssFeedUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategoryRss, this.UrlParameters.CategoryIdentifier);
        }

        protected void Page_Load(object sender, EventArgs e) {
            this.StoryList.DataBind(StoryCache.GetCategoryStories(this.UrlParameters.CategoryID, true, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
            this.Paging.RecordCount = StoryCache.GetCategoryStoryCount(this.UrlParameters.CategoryID, true, this.HostProfile.HostID);
            this.Paging.PageNumber = UrlParameters.PageNumber;
            this.Paging.PageSize = UrlParameters.PageSize;
            this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, this.UrlParameters.CategoryIdentifier);
        }
    }
}