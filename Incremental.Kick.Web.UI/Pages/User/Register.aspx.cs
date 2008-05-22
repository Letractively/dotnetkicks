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

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class Register : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Caption = "Join the " + this.HostProfile.SiteTitle + " community";
            this.Title = this.Caption;
            this.PageName = UrlFactory.PageName.Register;
            this.DisplayAds = false;
        }
    }
}