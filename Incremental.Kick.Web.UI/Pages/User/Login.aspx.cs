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
using Incremental.Kick.Web.Security;

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class Login : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Title = "Login to " + this.HostProfile.SiteTitle;
            this.PageName = UrlFactory.PageName.Login;
            this.DisplayAds = false;
        }
    }
}