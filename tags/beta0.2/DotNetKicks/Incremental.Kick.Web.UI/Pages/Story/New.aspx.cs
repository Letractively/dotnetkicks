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

namespace Incremental.Kick.Web.UI.Pages.Story {
    public partial class New : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.IsMemberPage = true;
            this.Title = this.HostProfile.SiteTitle + " - submit a new story";
            this.Caption = "Submit a story";
            this.PageName = UrlFactory.PageName.SubmitStory;
            this.DisplayAds = false;
        }

        protected void Page_Load(object sender, EventArgs e) {



        }
    }
}
