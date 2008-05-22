using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Security.Principal {
    public abstract class KickPrincipal : GenericPrincipal, IKickPrincipal {
        private User _userProfile;
        public User KickUserProfile { get { return _userProfile; } }

        public KickPrincipal(IIdentity identity, User userProfile)
            : base(identity, userProfile.Roles.Split('|')) {
            this._userProfile = userProfile;
        }
    }
}