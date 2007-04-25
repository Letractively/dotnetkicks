using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Incremental.Kick.Dal
{
    public partial class User
    {
        public static User FetchUserByUsername(string username)
        {
            return User.FetchUserByParameter(User.Columns.Username, username);
        }

        public static User FetchUserByParameter(string columnName, object value)
        {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            UserCollection f = new UserCollection();
            f.Load(User.FetchByParameter(columnName, value));
            return f[0];
        }
    }
}
