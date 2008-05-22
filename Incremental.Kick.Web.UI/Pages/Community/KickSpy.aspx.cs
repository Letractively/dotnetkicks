using System;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.Community {
    public partial class KickSpy : Web.Controls.KickUIPage {
        protected void Page_Load(object sender, EventArgs e) {
            DisplayAds = false;
            DisplaySideAds = false;
            Title = HostProfile.SiteTitle + " : Kick Spy!";
            PageName = UrlFactory.PageName.KickSpy;

            UserOnlineList.DataBind(UserCache.GetOnlineUsers(30, HostProfile.HostID, KickUserProfile));

            Shoutbox.DataBind((ShoutCache.GetLatestShouts(HostProfile.HostID)));
        }
    }
}