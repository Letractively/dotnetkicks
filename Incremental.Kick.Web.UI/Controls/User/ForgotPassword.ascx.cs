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

namespace Incremental.Kick.Web.UI.Controls
{
    public partial class ForgotPassword : Incremental.Kick.Web.Controls.KickUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetPassword_Click(object sender, EventArgs e)
        {
            //send an email to the user
            try
            {
                Incremental.Kick.Dal.User userTable = UserBR.GetUserByEmail(this.Email.Text.Trim());


                //send a mail to the user with a link to change the password
                UserBR.SendPasswordResetEmail(userTable.UserID, this.KickPage.HostProfile);
                ConfirmationMessageLabel.Text = "An email has been sent to " + this.Email.Text + ", please check you mail.";

            }
            catch (Exception)
            {
                ErrorMessageLabel.Text = "Sorry, we have no account with that email address";
            }
        }
    }
}