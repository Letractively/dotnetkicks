using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Dal.Entities {
   
     public class KickUserProfileOLD {
        //TODO: clean up this class
        //TODO: do we need an is authenticated?

        public int UserID;
        public string Username;
        public string Email;
        public string[] Roles = new string[0];
        public bool IsValidated;
        public bool IsBanned;
        public bool IsGeneratedPassword;
        public string AdSenseID;
        public DateTime CreatedDateTime;

        public bool IsNew {
            get {
                if (this.CreatedDateTime.AddDays(1) > DateTime.Now)
                    return true;
                else
                    return false;
            }
        }

        public bool HasAdSense {
            get { return !String.IsNullOrEmpty(this.AdSenseID); }
        }

        public bool IsInRole(string role) {
            foreach (string r in this.Roles) {
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
       
        public KickUserProfileOLD() {
            this.UserID = 0;
            this.Username = "Anonymous";
            this.Email = "";
            this.AdSenseID = "";
            this.IsBanned = false;
            this.IsGeneratedPassword = false;
            this.CreatedDateTime = new DateTime();
        }

         public KickUserProfileOLD(User user) {
            this.UserID = user.UserID;
            this.Username = user.Username;
            this.Email = user.Email;
            this.AdSenseID = user.AdsenseID;
            this.Roles = user.Roles.Split("|".ToCharArray());
            this.IsValidated = user.IsValidated;
            this.IsBanned = user.IsBanned;
            this.IsGeneratedPassword = user.IsGeneratedPassword;
            this.CreatedDateTime = user.CreatedOn;
        }

    }
}
