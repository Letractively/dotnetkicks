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

namespace Incremental.Kick.Web.UI.Pages.Chats {
    public partial class Room : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Title = this.HostProfile.SiteTitle + " - Chat Room (todo: add chat name)";
            //this.PageName = UrlFactory.PageName.SubmitStory;
            this.DisplayAds = false;
            this.DisplaySideAds = false;
            this.DisplayAnnouncement = false;
        }

        protected void Page_Load(object sender, EventArgs e) {
            Shoutbox.DataBind((ShoutCache.GetLatestShouts(HostProfile.HostID, this.UrlParameters.ChatID.Value)));
        }
    }
}