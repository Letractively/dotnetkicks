using System;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class LoginSwitch : Incremental.Kick.Web.Controls.KickPage {
        protected void Page_Init(object sender, EventArgs e) {
            if (this.KickUserProfile.IsGeneratedPassword) {
                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.ChangePassword));
            } else {
                // No need to check if the querystring parameter is null or empty
                // because if it is the root url is returned
                Response.Redirect(Request.QueryString["url"]);
            }
        }
    }
}