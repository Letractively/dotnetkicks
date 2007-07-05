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

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class Logout : Incremental.Kick.Web.Controls.KickPage {

        protected void Page_Init(object sender, EventArgs e) {
            //TODO: call SecurityManager.Logout with the security token
            FormsAuthentication.SignOut();
            Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.Home));
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}
