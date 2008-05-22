using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick;


namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class EditProfile : Incremental.Kick.Web.Controls.KickUserProfilePage {
        protected void Page_Init(object sender, EventArgs e) {
            if (this.KickUserProfile.UserID != this.UserProfile.UserID)
                this.NotAuthorisedRedirect();

            this.PageName = UrlFactory.PageName.UserProfile;
            this.ProfileEditor1.DataBind(this.UserProfile);
            this.UserProfileHeader.User = this.UserProfile;
        }
    }
}