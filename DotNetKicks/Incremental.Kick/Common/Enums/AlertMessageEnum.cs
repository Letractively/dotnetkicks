using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Common.Enums
{
    /// <summary>
    /// Defines the type of alert message to display to the user
    /// </summary>
    /// <remarks>
    /// Add other alerts here with the correct supporting entry in the
    /// database table Kick_AlertMessage
    /// </remarks>
    public enum AlertMessageEnum
    {
        NewFriendRequest = 1,
        ProfileShoutComment = 2
    }
}
