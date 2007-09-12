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
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Pages.Community {
    public partial class WhoIsOnline : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Load(object sender, EventArgs e) {
            this.DisplayAds = false;
            this.Title = this.HostProfile.SiteTitle + " : Who is online?";
            this.PageName = UrlFactory.PageName.CommunityWhoIsOnline;
            this.UserOnlineList.DataBind(UserCache.GetOnlineUsers(30, this.HostProfile.HostID));
            this.UserTodayList.DataBind(UserCache.GetOnlineUsers(1440, this.HostProfile.HostID));
        }
    }
}
