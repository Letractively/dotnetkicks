using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Incremental.Kick.DataAccess
{
    public partial class KickUser
    {
        public static KickUser FetchUserByUsername(string username)
        {
            return KickUser.FetchUserByParameter(KickUser.Columns.Username, username);
        }

        public static KickUser FetchUserByParameter(string columnName, object value)
        {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            KickUserCollection f = new KickUserCollection();
            f.Load(KickUser.FetchByParameter(columnName, value));
            return f[0];
        }
    }
}
