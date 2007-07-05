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
using Incremental.Kick.Common.Exceptions;

namespace Incremental.Kick.Web.UI.Controls {
    public partial class Register : Incremental.Kick.Web.Controls.KickUserControl {
        protected void Page_Load(object sender, EventArgs e) {
            this.Username.Focus();
        }
        protected void CreateAccount_Click(object sender, EventArgs e) {
            try {
                UserBR.CreateUser(Username.Text, Email.Text, ReceiveEmailNewsletter.Checked, this.KickPage.HostProfile);
                this.KickPage.Caption = "Thank you";
                RegisterPanel.Visible = false;
                SuccessPanel.Visible = true;
            } catch (KickUsernameAlreadyExistsException) {
                UsernameNotUniqueMessage.Visible = true;
            } catch (KickEmailAlreadyExistsException) {
                EmailNotUniqueMessage.Visible = true;
            }
        }
    }
}
