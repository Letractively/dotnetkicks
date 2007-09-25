using System;

namespace Incremental.Kick.Web.UI {
    public class Global : System.Web.HttpApplication {

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {
            if (Request.PhysicalPath.EndsWith(".aspx") || 
                Request.PhysicalPath.EndsWith(".axd") ||
                Request.PhysicalPath.EndsWith(".ashx"))
                Incremental.Kick.Web.Security.SecurityManager.SetPrincipal();
        }

        protected void Application_Error(object sender, EventArgs e) {
            System.Diagnostics.Debug.WriteLine("Application_Error:" + Context.Error.GetBaseException());
            
            // Redirect to error page only if not running locally and if it's not an ajax call
            if (!Request.Url.ToString().ToLower().Contains("http://localhost") && 
                !Request.Url.ToString().ToLower().Contains("/services/ajax")) 
                Response.Redirect("~/error");
        }
    }
}