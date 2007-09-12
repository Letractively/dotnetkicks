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
using Incremental.Kick.BusinessLogic;

public partial class Services_Ajax_ReportAsSpam : Incremental.Kick.Web.Controls.KickApiPage {
    protected void Page_Load(object sender, EventArgs e) {
        int storyID = int.Parse(Request["storyID"]);
        int userID = this.KickUserProfile.UserID;

        System.Diagnostics.Debug.WriteLine(String.Format("Ajax.ReportAsSpam({0}) by [{1}]", storyID, userID));

        if (this.IsAuthenticated) {
            StoryBR.IncrementSpamCount(storyID);
        }

        Response.Write("");
    }
}
