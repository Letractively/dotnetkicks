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

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class ViewTags : Incremental.Kick.Web.Controls.KickUserProfilePage {
        protected void Page_Init(object sender, EventArgs e) {
            this.PageName = UrlFactory.PageName.UserTags;
        }


        protected void Page_Load(object sender, EventArgs e) {
            this.UserProfileHeader.User = this.UserProfile;
            this.TagCloud.DataBind(TagCache.GetUserHostTags(this.UrlParameters.UserIdentifier, this.HostProfile.HostID));
        }
    }
}

