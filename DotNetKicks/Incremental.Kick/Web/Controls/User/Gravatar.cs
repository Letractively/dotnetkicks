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
            writer.Write(@"<img src=""/Services/Images/ViewGravitar.ashx?gravatar_id={0}&size={1}"" width=""{1}"" height=""{1}"" />", FormsAuthentication.HashPasswordForStoringInConfigFile(Email, "MD5").ToLower(), this._size.ToString());
        }
    }
}
