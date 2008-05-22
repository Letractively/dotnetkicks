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
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Pages.Docs {
    public partial class EarnMoney : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Title = "Earn money with " + this.HostProfile.SiteTitle;
            this.Caption = this.Title;
            this.PageName = UrlFactory.PageName.EarnMoney;
            this.DisplayAds = false;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                if (this.IsAuthenticated) {
                    this.AuthenticatedPanel.Visible = true;
                    this.AnonymousPanel.Visible = false;
                    this.AdSenseID.Text = this.KickUserProfile.AdsenseID;
                } else {
                    this.AuthenticatedPanel.Visible = false;
                    this.AnonymousPanel.Visible = true;
                }
            }
        }
        protected void UpdateAdSenseID_Click(object sender, EventArgs e) {

            UserBR.UpdateAdSenseID(this.KickUserProfile.UserID, this.AdSenseID.Text);

            UpdateAdSenseID.Text = "Your AdSense ID has been updated.";
        }
    }
}
