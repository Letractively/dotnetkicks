using System;
using System.Web.Security;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class Gravatar : KickWebControl {

        public Gravatar() { }
        public Gravatar(User user, int size) {
            this._user = user;
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
                writer.Write(@"<img src=""/gravatar/{0}/{1}"" alt=""{2}"" class=""userGravatar"" width=""{1}"" height=""{1}"" />", gravatarHash, this._size, this.User.Username);
            } else {
                writer.Write(@"<img src=""/static/images/cache/defaultgravatars/gravatar_{0}.jpg"" alt=""{1}"" class=""userGravatar"" width=""{0}"" height=""{0}"" />", this._size, this.User.Username);
            }
        }
    }
}
