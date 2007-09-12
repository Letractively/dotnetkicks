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

namespace Incremental.Kick.Web.UI.Pages.Docs {
    public partial class JavaScriptFeeds : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Title = "Add " + this.HostProfile.SiteTitle + " news to your site";
            this.Caption = this.Title;
            this.PageName = UrlFactory.PageName.JavaScriptFeeds;
            this.DisplayAds = false;
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}