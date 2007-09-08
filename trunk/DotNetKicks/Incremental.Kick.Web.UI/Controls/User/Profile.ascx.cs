using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Controls {
    public partial class Profile : Incremental.Kick.Web.Controls.KickUserControl {
        private User _userProfile;
        public User UserProfile {
            get { return _userProfile; }
        }
        public void DataBind(User userProfile) {
            this._userProfile = userProfile;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (this._userProfile.UseGravatar) {
                this.gravatar.Visible = true;
                this.gravatar.Email = this._userProfile.GravatarEmail;
            }
        }
    }
}