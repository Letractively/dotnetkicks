using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.Api
{
    public partial class GenerateKey : Incremental.Kick.Web.Controls.KickUIPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.HostProfile.SiteTitle + " API : Generate Key";
            this.Caption = this.Title;
            this.PageName = UrlFactory.PageName.ApiGenerateKey;
            this.DisplayAds = false;

            //default is not user
            if (!this.KickUserProfile.IsGuest)
            {
                this.mvGenerateKey.SetActiveView(viewShowKey);
                //this.txtApiKey.Text = this.KickUserProfile.ApiKey.ToString();
                //TODO need to update DAL with ApiKey field from user profile
            }

        }

        /// <summary>
        /// Handles the Click event of the butGenerateNewKey control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void butGenerateNewKey_Click(object sender, EventArgs e)
        {
            Guid newKey = Guid.NewGuid();
            //TODO need to update DAL with ApiKey field from user profile
            //this.KickUserProfile.ApiKey = newKey;
            this.KickUserProfile.Save();
            this.mvGenerateKey.SetActiveView(viewShowKey);
            //this.txtApiKey.Text = this.KickUserProfile.ApiKey.ToString(); 
            //TODO need to update DAL with ApiKey field from user profile
        }
    }
}
