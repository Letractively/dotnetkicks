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

namespace Incremental.Kick.Web.UI.Controls {

    public partial class ChangePassword : Incremental.Kick.Web.Controls.KickUserControl {

        public bool RequiresOldPassword {
            get { return !this.KickPage.KickUserProfile.IsGeneratedPassword; }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (this.RequiresOldPassword)
                OldPassword.Focus();
            else
                NewPassword.Focus();
        }

        protected void ChangePassword_Click(object sender, EventArgs e) {
            if (this.RequiresOldPassword) {
                //check if the old password matches
                try {
                    UserBR.AuthenticateUser(this.KickPage.KickUserProfile.Username, OldPassword.Text);
                } catch {
                    InvalidPassword.Visible = true;
                }
            }

            //update the password for the current user
            UserBR.UpdatePassword(this.KickPage.KickUserProfile.UserID, NewPassword.Text, this.KickPage.HostProfile);

            this.SuccessPanel.Visible = true;
            this.ChangePasswordPanel.Visible = false;
        }

    }
}