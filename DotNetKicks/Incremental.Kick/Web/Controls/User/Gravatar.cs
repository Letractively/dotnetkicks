using System;
using System.Web.Security;

namespace Incremental.Kick.Web.Controls {
    public class Gravatar : KickWebControl {

        private string _email;
        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        private int _size;
        public int Size {
            get { return _size; }
            set { _size = value; }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            writer.Write(@"<span class=""Gravatar Hidden"">{0}</span>", FormsAuthentication.HashPasswordForStoringInConfigFile(Email, "MD5").ToLower() + "," + this._size.ToString());
        }
    }
}
