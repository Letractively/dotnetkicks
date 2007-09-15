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

namespace Incremental.Kick.Web.UI.Pages.Community {
    public partial class KickSpy : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Load(object sender, EventArgs e) {
            this.DisplayAds = false;
            this.DisplaySideAds = false;
            this.Title = this.HostProfile.SiteTitle + " : Kick Spy";
            this.PageName = UrlFactory.PageName.WhoIsOnline;

            this.Shoutbox.DataBind((ShoutCache.GetLatestShouts(this.HostProfile.HostID)));
        }
    }
}