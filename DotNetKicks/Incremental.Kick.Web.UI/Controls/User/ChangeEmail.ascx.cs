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
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Controls
{
	public partial class ChangeEmail : Incremental.Kick.Web.Controls.KickUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Email.Focus();
			CurrentEmail.Text = this.KickPage.KickUserProfile.Email;
        }

        protected void btnChangeEmail_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ChangeEmailPanel.Visible = false;
				if (!String.IsNullOrEmpty(Email.Text))
                {
                    Incremental.Kick.Dal.User userTable = UserBR.GetUserByEmail(Email.Text.Trim());

					if (userTable == null)
					{
						Kick.Helpers.EmailHelper.SendChangedEmailEmail(Email.Text, this.KickPage.KickUserProfile.Username, this.KickPage.KickUserProfile.Email, this.KickPage.HostProfile);
						SuccessPanel.Visible = true;
					}
					else
						FailedPanel.Visible = true;
                }
            }
        }
    }
}