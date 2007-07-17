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
using Incremental.Kick.Web.Helpers.Rss;
using Rss;

public partial class Services_Feeds_Rss_MainFeed : Incremental.Kick.Web.Controls.KickRssPage {
        
    protected void Page_Load(object sender, EventArgs e) {
        if (string.IsNullOrEmpty(this.HostProfile.FeedBurnerMainRssFeedUrl) || Request.QueryString["Redirect" ]== "0") {
            this.RenderRssChannel(StoryDataTableToRss.ConvertToRssChannel(
            StoryCache.GetAllStories(true, this.HostProfile.HostID, 1, 25),
            this.HostProfile.SiteTitle, "the latest published stories from " + this.HostProfile.SiteTitle, this.HostProfile.RootUrl + "/", this.HostProfile));
        } else {
            Response.Redirect(this.HostProfile.FeedBurnerMainRssFeedUrl);
        }
    }
}
