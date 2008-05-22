using System;
using System.Web.Security;
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls {
    public class Gravatar : KickWebControl {

        public Gravatar() { }

        public Gravatar(User user, int size) {
            this._user = user;
            this._size = size;
        }

        public Gravatar(int userID, int size) {
            this._user = UserCache.GetUser(userID);
            this._size = size;
        }
        
        private User _user;
        public User User {
            get { return _user; }
            set { _user = value; }
        }

        private int _size = 16;
        public int Size {
            get { return _size; }
            set { _size = value; }
        }
        
        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            if (this.User.UseGravatar) {
                string gravatarHash = FormsAuthentication.HashPasswordForStoringInConfigFile(this._user.GravatarEmail, "MD5").ToLower();
                writer.Write(@"<img src=""/gravatar/{0}/{1}"" alt=""{2}"" class=""userGravatar photo"" width=""{1}"" height=""{1}"" />", gravatarHash, this._size, this.User.Username);
            } else {
                writer.Write(@"<img src=""/static/images/cache/defaultgravatars/gravatar_{0}.jpg"" alt=""{1}"" class=""userGravatar"" width=""{0}"" height=""{0}"" />", this._size, this.User.Username);
            }
        }

        public string GravatarUrl() {
            return GravatarUrl(null);
        }

        public string GravatarUrl(Host host) {
            string root = "";
            if (host != null)
                root = host.RootUrl;

            if (this.User.UseGravatar) {
                string gravatarHash = FormsAuthentication.HashPasswordForStoringInConfigFile(this._user.GravatarEmail, "MD5").ToLower();
                return String.Format("{0}/gravatar/{1}/{2}", root, gravatarHash, this._size);
            } else {
                return String.Format("{0}/static/images/cache/defaultgravatars/gravatar_{1}.jpg", root, this._size);
            }
        }
    }
}
