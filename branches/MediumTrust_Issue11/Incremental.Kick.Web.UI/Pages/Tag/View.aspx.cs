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
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Pages.Tag {
    public partial class View : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Caption = "Stories recently tagged with '" + this.UrlParameters.TagIdentifier + "'";
            this.Title = this.HostProfile.SiteTitle + " : " + this.Caption;
            this.PageName = UrlFactory.PageName.ViewTag;
            this.DisplayAds = true;
            this.RssFeedUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewTagRss, this.UrlParameters.TagIdentifier);
        }

        protected void Page_Load(object sender, EventArgs e) {
            this.StoryList.DataBind(StoryCache.GetTaggedStories(this.UrlParameters.TagIdentifier, this.HostProfile.HostID,  this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
            this.Paging.RecordCount = StoryCache.GetTaggedStoryCount(this.UrlParameters.TagIdentifier, this.HostProfile.HostID);
            this.Paging.PageNumber = UrlParameters.PageNumber;
            this.Paging.PageSize = UrlParameters.PageSize;
            this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewTag, HttpUtility.UrlEncode(this.UrlParameters.TagIdentifier));
        }
    }
}