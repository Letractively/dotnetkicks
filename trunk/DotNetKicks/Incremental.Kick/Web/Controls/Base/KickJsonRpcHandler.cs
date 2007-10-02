using System;
using System.Collections.Generic;
using System.Text;
using Jayrock.JsonRpc.Web;
using Incremental.Kick.Dal;
using Incremental.Kick.Security.Principal;
using System.Security;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class KickJsonRpcHandler : JsonRpcHandler {

        //TODO: GJ: refactor - the profile code is duplicated in KickPage
        private User _userProfile;
        public User KickUserProfile {
            get {
                if (this._userProfile == null) {
                    this._userProfile = ((IKickPrincipal)base.User).KickUserProfile;
                }
                return this._userProfile;
            }
        }

        private Host _hostProfile;
        public Host HostProfile {
            get {
                if (this._hostProfile == null) {
                    this._hostProfile = HostCache.GetHost(HostHelper.GetHostAndPort(this.Request.Url));
                }

                return this._hostProfile;
            }
        }

        public bool IsAuthenticated {
            get { return this.User.Identity.IsAuthenticated; }
        }

        public void DemandUserAuthentication() {
            if (!IsAuthenticated)
                throw new SecurityException("You must be logged in to perform this operation");
        }

        public void DemandModeratorRole() {
            if (!this.KickUserProfile.IsModerator)
                throw new SecurityException("You must be a moderator in to perform this operation");
        }


        //Jayrock doesn't support nullable types
        public int? ToNullable(int value) {
            if (value == 0)
                return null;
            else 
                return value;
        }
    }
}
