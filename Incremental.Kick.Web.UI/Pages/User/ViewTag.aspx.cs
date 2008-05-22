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
    public partial class ViewTag : Incremental.Kick.Web.Controls.KickUserProfilePage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Caption = "Stories tagged '" + this.UrlParameters.TagIdentifier + "' by " + this.UrlParameters.UserIdentifier;
            this.Title = this.HostProfile.SiteTitle + " : " + this.Caption;
            this.PageName = UrlFactory.PageName.UserTag;
        }


        protected void Page_Load(object sender, EventArgs e) {
            this.UserProfileHeader.User = this.UserProfile;
            this.StoryList.DataBind(StoryCache.GetUserTaggedStories(this.UrlParameters.TagIdentifier, this.KickUserProfile.UserID, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
            this.Paging.RecordCount = StoryCache.GetUserTaggedStoryCount(this.UrlParameters.TagIdentifier, this.KickUserProfile.UserID, this.HostProfile.HostID);
            this.Paging.PageNumber = UrlParameters.PageNumber;
            this.Paging.PageSize = UrlParameters.PageSize;
            this.Paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.UserTag, this.KickUserProfile.Username, HttpUtility.UrlEncode(this.UrlParameters.TagIdentifier));
        }
    }
}

