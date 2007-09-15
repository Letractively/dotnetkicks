using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick;
using Incremental.Kick.Caching;


namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class Profile : Incremental.Kick.Web.Controls.KickUserProfilePage {
        protected void Page_Init(object sender, EventArgs e) {
            this.PageName = UrlFactory.PageName.UserProfile;
            this.Profile1.DataBind(this.UserProfile);
            this.UserProfileHeader.User = this.UserProfile;
            this.FriendList.DataBind(this.UserProfile.Friends);
            this.FriendByList.DataBind(this.UserProfile.FriendsBy);
            this.UserAdmin.DataBind(this.UserProfile);
            this.Shoutbox.DataBind((ShoutCache.GetLatestShouts(this.HostProfile.HostID, this.UrlParameters.UserIdentifier)));

        }
    }
}