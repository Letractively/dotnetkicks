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

namespace Incremental.Kick.Web.UI.Pages.Docs {
    public partial class InProgress : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Load(object sender, EventArgs e) {
            this.DisplayAds = false;
            this.Title = this.HostProfile.SiteTitle + " - are we there yet?";
            this.Caption = "Work in progress.";
        }
    }
}