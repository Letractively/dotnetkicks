namespace Incremental.Kick.Web.UI {
    
    #region Imports

    using System;
    using System.Globalization;
    using System.Web;
    using System.Web.Hosting;
    using Debug = System.Diagnostics.Debug;
    using HttpStatusCode = System.Net.HttpStatusCode;

    #endregion

    public class Global : System.Web.HttpApplication {

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {
            if (Request.PhysicalPath.EndsWith(".aspx") || 
                Request.PhysicalPath.EndsWith(".axd") ||
                Request.PhysicalPath.EndsWith(".ashx"))
                Incremental.Kick.Web.Security.SecurityManager.SetPrincipal();
        }

        protected void Application_Error(object sender, EventArgs e) {
            const string docsPath = "~/Pages/Docs/";
            const string defaultErrorPagePath = docsPath + "Error.aspx";
            const string errorPagePathFormat = docsPath + "Error{0}.aspx";

            Exception error = Server.GetLastError();
            Debug.WriteLine("Application_Error: " + error.GetBaseException());

            if (!Context.IsCustomErrorEnabled ||
                Request.Url.ToString().ToLowerInvariant().Contains("/services/ajax"))
                return;

            string errorPagePath = defaultErrorPagePath;
            int statusCode = (int) HttpStatusCode.InternalServerError;

            HttpException httpError = error as HttpException;
            if (httpError != null) 
            {
                statusCode = httpError.GetHttpCode();

                string customPage = string.Format(errorPagePathFormat, 
                    statusCode.ToString(CultureInfo.InvariantCulture));

                if (HostingEnvironment.VirtualPathProvider.FileExists(customPage))
                    errorPagePath = customPage;
            }

            Server.Execute(errorPagePath);

            // Server.Execute resets the status code so we need to restore
            // the actual error once it is done.
            Response.StatusCode = statusCode;

            Server.ClearError();
        }
    }
}