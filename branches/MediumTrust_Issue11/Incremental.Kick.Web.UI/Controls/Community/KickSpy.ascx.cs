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

namespace Incremental.Kick.Web.UI.Controls.Community {
    public partial class KickSpy : Incremental.Kick.Web.Controls.KickUserControl {
        protected void Page_Load(object sender, EventArgs e) {
            this.UserActionList.DataBind(UserActionCache.GetLatestUserActions(this.KickPage.HostProfile.HostID));
            this.UserActionList.ShowModeratorActions = this.KickPage.KickUserProfile.IsModerator;
        }   
    }
}