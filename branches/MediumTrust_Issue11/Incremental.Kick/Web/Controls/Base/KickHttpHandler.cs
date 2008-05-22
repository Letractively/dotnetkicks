using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Incremental.Kick.Dal;
using Incremental.Kick.Security.Principal;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class KickHttpHandler : IHttpHandler {

        public HttpContext Context; //TODO: property

        public virtual void ProcessRequest(HttpContext context) {
            this.Context = context;
        }

        public virtual bool IsReusable {
            get { return false; }
        }

        public string HostName {
            get { return HostHelper.GetHostName(this.Context.Request.Url); }
        }

        private Host _hostProfile;
        public Host HostProfile {
            get {
                if (this._hostProfile == null) {
                    this._hostProfile = HostCache.GetHost(HostHelper.GetHostAndPort(this.Context.Request.Url));
                }

                return this._hostProfile;
            }
        }

        private User _userProfile;
        public User KickUserProfile {
            get {
                if (this._userProfile == null) {
                    this._userProfile = ((IKickPrincipal)this.Context.User).KickUserProfile;
                }
                return this._userProfile;
            }
        }

    }
}
