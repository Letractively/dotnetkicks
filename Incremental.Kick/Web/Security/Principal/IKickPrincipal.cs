using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Runtime.Serialization;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Security.Principal {
    public interface IKickPrincipal : IPrincipal {
        User KickUserProfile { get; }
    }
}