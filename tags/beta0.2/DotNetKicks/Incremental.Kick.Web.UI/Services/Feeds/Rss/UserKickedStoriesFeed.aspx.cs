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

public partial class Services_Feeds_Rss_UserKickedStoriesFeed : Incremental.Kick.Web.Controls.KickRssPage {
    protected void Page_Load(object sender, EventArgs e) {
        this.RenderRssChannel(StoryDataTableToRss.ConvertToRssChannel(
           StoryCache.GetUserKickedStories(this.UrlParameters.UserIdentifier, this.HostProfile.HostID, 1, 25),
           this.HostProfile.SiteTitle + " : Stories kicked by " + this.UrlParameters.UserIdentifier, "Stories kicked by " + this.UrlParameters.UserIdentifier,
           this.HostProfile.RootUrl + "/", this.HostProfile));
    }
}
