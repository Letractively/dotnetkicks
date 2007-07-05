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
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class ResetPassword : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Caption = "Your password has been reset";
            this.Title = this.Caption;
           // this.PageName = UrlFactory.PageName.Register;
            this.DisplayAds = false;
        }
        
        protected void Page_Load(object sender, EventArgs e) {
            
            string username = this.Request.QueryString["username"];

            //if the username and hash are correct, send a generated password
            Incremental.Kick.Dal.User user = UserBR.GetUserByUsername(username);

            int hash = int.Parse(this.Request.QueryString["hash"]);
            int expectedHash = user.LastActiveOn.Ticks.GetHashCode();
            if (hash != expectedHash) {
                throw new ApplicationException("Invalid hash for ResetPassword, [" + expectedHash.ToString() + "] was expected");
            }

            UserBR.ResetPassword(user.UserID, this.HostProfile);
        }
    }   
}

