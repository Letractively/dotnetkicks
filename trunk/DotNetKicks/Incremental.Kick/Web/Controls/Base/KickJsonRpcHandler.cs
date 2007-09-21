using System;
using System.Collections.Generic;
using System.Text;
using Jayrock.JsonRpc.Web;
using Incremental.Kick.Dal;
using Incremental.Kick.Security.Principal;
using System.Security;

namespace Incremental.Kick.Web.Controls {
    public class KickJsonRpcHandler : JsonRpcHandler {

        private User _userProfile;
        public User KickUserProfile {
            get {
                if (this._userProfile == null) {
                    this._userProfile = ((IKickPrincipal)base.User).KickUserProfile;
                }
                return this._userProfile;
            }
        }

        public bool IsAuthenticated {
            get { return this.User.Identity.IsAuthenticated; }
        }

        public void DemandUserAuthentication() {
            if (!IsAuthenticated)
                throw new SecurityException("You must be logged in to perform this operation");
        }
    }
}
