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
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.BusinessLogic;


namespace Incremental.Kick.Web.UI.Pages.User
{
    public partial class Friends : Incremental.Kick.Web.Controls.KickUserProfilePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.PageName = UrlFactory.PageName.UserFriends;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserProfileHeader.User = this.UserProfile;
            this.FriendList.DataBind(this.UserProfile.Friends);
            this.FriendByList.DataBind(this.UserProfile.FriendsBy);
        }
    }
}
