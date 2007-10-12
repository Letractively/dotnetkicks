using System;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.Docs
{
    public partial class EarnMoney : KickUIPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Title = "Earn money with " + HostProfile.SiteTitle;
            Caption = Title;
            PageName = UrlFactory.PageName.EarnMoney;
            DisplayAds = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                if(IsAuthenticated)
                {
                    AuthenticatedPanel.Visible = true;
                    AnonymousPanel.Visible = false;
                    AdSenseIDTextBox.Text = KickUserProfile.AdsenseID;
                }
                else
                {
                    AuthenticatedPanel.Visible = false;
                    AnonymousPanel.Visible = true;
                }
        }

        protected void UpdateAdSenseID_Click(object sender, EventArgs e)
        {
            UserBR.UpdateAdSenseID(KickUserProfile.UserID, AdSenseIDTextBox.Text);

            UpdateAdSenseID.Text = "Your AdSense ID has been updated.";
        }
    }
}