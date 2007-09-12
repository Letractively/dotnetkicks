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

public partial class Services_Ajax_KickIt : Incremental.Kick.Web.Controls.KickApiPage {
    protected void Page_Load(object sender, EventArgs e) {
        int storyID = int.Parse(Request["storyID"]);
        bool isKick = bool.Parse(Request["isKick"]);
        int userID = this.KickUserProfile.UserID;

        System.Diagnostics.Debug.WriteLine(String.Format("Ajax.KickIt({0}, {1}) by [{2}]", storyID, isKick, userID));
        
        if (this.IsAuthenticated) {
            if (isKick) {
                Response.Write(UserCache.KickStory(storyID, userID, this.HostProfile.HostID));
            } else {
                Response.Write(UserCache.UnKickStory(storyID, userID, this.HostProfile.HostID));
            }
        } else {
            Response.Write("");
        }

    }
}
