using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Incremental.Kick.Web.UI {
    public class Global : System.Web.HttpApplication {

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {
            object ff = HttpContext.Current.Request.Cookies;

            Incremental.Kick.Web.Security.SecurityManager.SetPrincipal();
        }

        protected void Application_Start(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}