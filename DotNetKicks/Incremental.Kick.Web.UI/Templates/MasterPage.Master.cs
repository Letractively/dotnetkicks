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

namespace Incremental.Kick.Web.UI.Templates {
    public partial class MasterPage : Incremental.Kick.Web.Controls.KickMasterPage {
        protected void Page_Load(object sender, EventArgs e) 
        {
            
            if (this.KickPage.KickUserProfile.IsBanned)
                AddWebSiteAlertMessage("flash flash-information", "NOTE: Your account has been BANNED. This is probably due to submitting spam to the site. Please contact us if you feel that this is in error.");

            //can add more web site alerts
            //such as system status/offline/scheduled outages
            //or chat sessions etc.

        }

        /// <summary>
        /// Adds a web site alert message.
        /// Adds the message to the top of the page
        /// All messages include the CSS Class "WebSiteAlert"
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        /// <param name="message">The message.</param>
        /// <remarks>To use more than one CssClass separate by space</remarks>
        private void AddWebSiteAlertMessage(string cssClass, string message)
        {
            Panel pnlWebSiteAlert = new Panel();
            pnlWebSiteAlert.CssClass = string.Concat("WebSiteAlert ", cssClass);
            Literal litBannedUserAlert = new Literal();
            litBannedUserAlert.Text = message;
            pnlWebSiteAlert.Controls.Add(litBannedUserAlert);
            this.phWebSiteAlert.Controls.Add(pnlWebSiteAlert);
        }




    }
}
