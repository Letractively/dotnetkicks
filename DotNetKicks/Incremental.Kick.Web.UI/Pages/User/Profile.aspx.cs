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
using Incremental.Kick.Web.Helpers;
using Incremental.Kick;
using Incremental.Kick.Caching;


namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class Profile : Incremental.Kick.Web.Controls.KickUserProfilePage {

        private Dal.User _userProfile = null;
        public Dal.User UserProfile {
            get {
                if (_userProfile == null)
                    _userProfile = UserCache.GetUserByUsername(this.UrlParameters.UserIdentifier);
                return _userProfile;
            }
        }


        protected void Page_Init(object sender, EventArgs e) {
            this.PageName = UrlFactory.PageName.UserProfile;
            this.Profile1.DataBind(this.UserProfile);
        }
    }
}