using System.Security.Principal;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Security.Principal {
    
    public class AnonymousKickPrincipal : KickPrincipal {
        public AnonymousKickPrincipal(IIdentity identity, User userProfile) : base(identity, userProfile) { }
    }
}
