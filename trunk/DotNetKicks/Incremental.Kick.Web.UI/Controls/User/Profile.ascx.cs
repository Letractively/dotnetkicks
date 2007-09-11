using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
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

        }

        protected void lnkAddFriend_Click(object sender, EventArgs e)
        {
            this.KickPage.KickUserProfile.AddFriend(this.UserProfile.UserID);
        }
        protected void lnkRemoveFriend_Click(object sender, EventArgs e)
        {
            this.KickPage.KickUserProfile.RemoveFriend(this.UserProfile.UserID);
        }
    }
}