using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Security.Principal {
    public class AuthenticatedKickPrincipal : KickPrincipal {
        public AuthenticatedKickPrincipal(IIdentity identity, User user) : base(identity, user) { }
    }
}
