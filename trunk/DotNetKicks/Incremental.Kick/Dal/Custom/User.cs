using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Incremental.Kick.Dal {
    public partial class User {
        public static User FetchUserByUsername(string username) {
            return User.FetchUserByParameter(User.Columns.Username, username);
        }

        public static User FetchUserByParameter(string columnName, object value) {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            UserCollection f = new UserCollection();
            f.Load(User.FetchByParameter(columnName, value));
            return f[0];
        }

        public bool IsNewMember {
            get { return this.CreatedOn.AddDays(1) > DateTime.Now; }
        }

        public bool HasAdSense {
            get { return !String.IsNullOrEmpty(this.AdsenseID); }
        }

        public bool IsInRole(string role) {
            foreach (string r in this.Roles.Split("|".ToCharArray())) {
                if (role == r)
                    return true;
            }

            return false;
        }

        public bool IsUser {
            get { return this.IsInRole("user"); }
        }

        public bool IsPowerUser {
            get { return this.IsInRole("poweruser"); }
        }

        public bool IsModerator {
            get { return this.IsInRole("moderator"); }
        }

        public bool IsDebugger {
            get { return this.IsInRole("debugger"); }
        }

        public bool IsAdministrator {
            get { return this.IsInRole("administrator"); }
        }

        public bool IsHostModerator(string hostName) {
            return IsModerator || this.IsInRole(hostName + ":moderator");
        }

        public bool HasRoles(List<string> roles) {
            foreach (string role in roles)
                if (!this.IsInRole(role))
                    return false;
            return true;
        }
    }
}
