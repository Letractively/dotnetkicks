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
            if (Request.PhysicalPath.EndsWith(".aspx") || Request.PhysicalPath.EndsWith(".axd"))
                Incremental.Kick.Web.Security.SecurityManager.SetPrincipal();
        }

        protected void Application_Error(object sender, EventArgs e) {
            System.Diagnostics.Debug.WriteLine("Application_Error:" + Context.Error.GetBaseException().ToString());
            if(!this.Request.Url.ToString().Contains("http://localhost")) 
                Response.Redirect("~/error");
        }

        protected void Application_Start(object sender, EventArgs e) {
            System.Diagnostics.Debug.WriteLine("Started");
        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}