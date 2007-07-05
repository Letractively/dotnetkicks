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
using Incremental.Kick.Web.Security;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Controls {
    public partial class Login : Incremental.Kick.Web.Controls.KickUserControl {
        public string RootUrl {
            get { return this.ResolveUrl("~/"); }
        }

        protected void Page_Load(object sender, EventArgs e) {
            this.Username.Focus();
        }

        protected void LogIn_Click(object sender, EventArgs e) {
            if (SecurityManager.Login(Username.Text, Password.Text, RememberMe.Checked)) {
                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.LoginSwitch, FormsAuthentication.GetRedirectUrl(Username.Text, RememberMe.Checked)));
            } else {
                InvalidLogin.Visible = true;
            }
        }
    }
}
