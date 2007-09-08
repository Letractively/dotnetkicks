//Gravatar control by Sean Kearney : http://www.carknee.com/archive/2007/03/13/asp-net-gravatar-control.aspx

using System;
using System.Web.Security;

namespace Incremental.Kick.Web.Controls {
    public class Gravatar : System.Web.UI.WebControls.Image {
        #region Rating property
        public enum GravatarRating { G, PG, R, X }
        private GravatarRating _Rating = GravatarRating.G;
        [System.ComponentModel.DefaultValue("G")]
        public GravatarRating Rating {
            get { return _Rating; }// get
            set { _Rating = value; }// set
        }

        #endregion

        #region Size property
        private int _Size = 80;
        /// <summary>
        /// An optional "size" parameter may follow that specifies the desired width and height of the gravatar. Valid values are from 1 to 80 inclusive. Any size other than 80 will cause the original gravatar image to be downsampled using bicubic resampling before output.
        /// </summary>
        public int Size {
            get {
                if (_Size <= 0)
                    return 80;
                if (_Size > 80)
                    return 80;
                return _Size;
            }
            set {
                _Size = value;
                base.Width = value;
                base.Height = value;
            }// set
        }// property
        #endregion

        #region Email property
        private string _Email;
        public string Email {
            get { return _Email; }// get
            set { _Email = value; }// set
        }// property

        #endregion

        #region DefaultImageUrl property
        private string _DefaultImageUrl;

        public string DefaultImageUrl {
            get { return _DefaultImageUrl; }// get
            set { _DefaultImageUrl = value; }// set
        }// property

        #endregion

        #region Hide some members
        new private string ImageUrl { get { return String.Empty; } }
        /// Gravatar only supports a size property
        new private int Width { get { return Size; } }
        new private int Height { get { return Size; } }
        #endregion

        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            System.Text.StringBuilder image = new System.Text.StringBuilder();
            image.Append("http://www.gravatar.com/avatar.php?");
            image.Append("gravatar_id=");
            image.Append(FormsAuthentication.HashPasswordForStoringInConfigFile(Email, "MD5").ToLower());
            image.Append("&rating=");
            image.Append(Rating.ToString());
            image.Append("&size=");
            image.Append(Size.ToString());

            if (!String.IsNullOrEmpty(DefaultImageUrl)) {
                image.Append("&default=");
                image.Append(System.Web.HttpUtility.UrlEncode(DefaultImageUrl));
            }

            base.ImageUrl = image.ToString();
            base.Render(writer);
        }
    }
}
