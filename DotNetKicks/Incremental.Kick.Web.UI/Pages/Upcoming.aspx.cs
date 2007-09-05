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
using Incremental.Kick.Common.Enums;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Pages {
    public partial class Upcoming : Incremental.Kick.Web.Controls.KickUIPage {
        protected Upcoming() {
            this.DisplayAds = true;
        }

        protected void Page_Init(object sender, EventArgs e) {
            this.Title = this.HostProfile.SiteTitle + " - " + this.HostProfile.TagLine + ".";
            this.Caption = "Upcoming popular stories";
            this.PageName = UrlFactory.PageName.NewStories;
        }

        protected void Page_Load(object sender, EventArgs e) {
           
        }
    }
}
