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

namespace Incremental.Kick.Web.UI.Services.Feeds.Rss {
    public partial class TagFeed : Incremental.Kick.Web.Controls.KickRssPage {
        protected void Page_Load(object sender, EventArgs e) {
            this.RenderRssChannel(StoryDataTableToRss.ConvertToRssChannel(
               StoryCache.GetTaggedStories(this.UrlParameters.TagIdentifier, this.HostProfile.HostID, 1, 25),
               this.HostProfile.SiteTitle + " - Stories tagged with " + this.UrlParameters.TagIdentifier, "the latest stories tagged with '" + this.UrlParameters.TagIdentifier + "' from " + this.HostProfile.SiteTitle,
               this.HostProfile.RootUrl + "/", this.HostProfile));
        }
    }
}
