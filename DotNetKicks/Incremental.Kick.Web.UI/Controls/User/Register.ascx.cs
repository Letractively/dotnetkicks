using System;
using System.Web.UI.WebControls;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Controls;

namespace Incremental.Kick.Web.UI.Controls
{
    public partial class Register : KickUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Username.Focus();
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                UserBR.CreateUser(Username.Text, Email.Text, ReceiveEmailNewsletter.Checked, KickPage.HostProfile);
                KickPage.Caption = "Thank you";
                RegisterPanel.Visible = false;
                SuccessPanel.Visible = true;
            }
        }

        protected void UsernameExists_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Username is valid only if it has not taken yet AND if it's not one of the reserved usernames
            args.IsValid = !User.FetchByParameter(User.Columns.Username, args.Value).Read() &&
                           !ReservedUsername.FetchByParameter(ReservedUsername.Columns.Username, args.Value).Read();
        }

        protected void EmailExists_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !User.FetchByParameter(User.Columns.Email, args.Value).Read();
        }
    }
}