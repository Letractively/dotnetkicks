using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Web;
using System.Web.Hosting;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Web.Security;
using Incremental.Kick.Search;

using log4net;

namespace Incremental.Kick.Web.UI
{
    public class Global : HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if(Request.PhysicalPath.EndsWith(".aspx") || Request.PhysicalPath.EndsWith(".axd") ||
               Request.PhysicalPath.EndsWith(".ashx"))
                SecurityManager.SetPrincipal();
        }


        protected void Application_Start(object sender, EventArgs e)
        {
            //create a new search index
            log4net.Config.XmlConfigurator.Configure();
            SearchUpdate update = SearchUpdate.Instance;            
        }

        protected void Application_End(object sender, EventArgs e)
        {
            SearchUpdate.Instance.Dispose();
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            // If the referrer url is marked as blocked then redirect the user to another location
            // Check only pages referred by some website, pages referred by external hosts, and requests for .aspx pages
            if (Request.UrlReferrer != null && Request.UrlReferrer.Host != Request.Url.Host && Request.PhysicalPath.EndsWith(".aspx"))
            {
                BlockedReferralCollection blockedReferrals =
                    BlockedReferralCache.GetBlockedReferrals(HostCache.GetHost(HostHelper.GetHostAndPort(Request.Url)).HostID);
                if(blockedReferrals.Exists(
                       delegate(BlockedReferral referral) { return Request.UrlReferrer.Host.Contains(referral.BlockedReferralHostname); }))
                    Server.Transfer("~/Pages/Docs/SpamReferral.aspx");
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            const string docsPath = "~/Pages/Docs/";
            const string defaultErrorPagePath = docsPath + "Error.aspx";
            const string errorPagePathFormat = docsPath + "Error{0}.aspx";

            Exception error = Server.GetLastError();
            Debug.WriteLine("Application_Error: " + error.GetBaseException());

            if(!Context.IsCustomErrorEnabled || Request.Url.ToString().ToLowerInvariant().Contains("/services/ajax"))
                return;

            string errorPagePath = defaultErrorPagePath;
            int statusCode = (int) HttpStatusCode.InternalServerError;

            HttpException httpError = error as HttpException;
            if(httpError != null)
            {
                statusCode = httpError.GetHttpCode();

                string customPage = string.Format(errorPagePathFormat, statusCode.ToString(CultureInfo.InvariantCulture));

                if(HostingEnvironment.VirtualPathProvider.FileExists(customPage))
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
