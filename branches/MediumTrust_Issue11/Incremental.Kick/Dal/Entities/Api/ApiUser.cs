using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal.Entities.Api {
    public class ApiUser {
        public ApiUser() {}

        public ApiUser(string username, string profileUrl, string avatarUrl) {
            this._username = username;
            this._profileUrl = profileUrl;
            this._avatarUrl = avatarUrl;
        }

        private string _username;
        public string Username {
            get { return _username; }
            set { _username = value; }
        }

        private string _profileUrl;
        public string ProfileUrl {
            get { return _profileUrl; }
            set { _profileUrl = value; }
        }

        private string _avatarUrl;
        public string AvatarUrl {
            get { return _avatarUrl; }
            set { _avatarUrl = value; }
        }
    }
}
