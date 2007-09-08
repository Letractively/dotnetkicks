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

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class LoginSwitch : Incremental.Kick.Web.Controls.KickPage {
        protected void Page_Init(object sender, EventArgs e) {
            if (this.KickUserProfile.IsGeneratedPassword) {
                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.ChangePassword));
            } else {
                // TODONE: get the URL from the querystring. 
                // No need to check if the querystring parameter is null or empty
                // because if it is the root url is returned
                Response.Redirect(Request.QueryString["url"]);

                /*Response.Write(HttpUtility.UrlDecode(Request["AA"]));
                Response.Write(this.Request.QueryString + "<br/>");
                Response.Write(this.Request.RawUrl + "<br/>");*/
            }

        }
    }
}
