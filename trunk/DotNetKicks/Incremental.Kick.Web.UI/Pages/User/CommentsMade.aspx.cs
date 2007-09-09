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

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class CommentsMade : Incremental.Kick.Web.Controls.KickUserProfilePage {
        protected void Page_Init(object sender, EventArgs e) {
            this.PageName = UrlFactory.PageName.UserComments;
        }

        protected void Page_Load(object sender, EventArgs e) {
            //TODO Will need to modify the Comment & CommentList web controls to show related story
            this.UserProfileHeader.User = this.UserProfile;
            Incremental.Kick.Dal.CommentCollection commentTable = StoryCache.GetUserComments(this.UrlParameters.UserIdentifier, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize);
            this.CommentList.DisplayStoryTitle = true;
            this.CommentList.DataBind(commentTable);
            this.Paging.RecordCount = StoryCache.GetUserCommentsCount(this.UrlParameters.UserIdentifier, this.HostProfile.HostID);
            this.Paging.PageNumber = UrlParameters.PageNumber;
            this.Paging.PageSize = UrlParameters.PageSize;
            this.Paging.BaseUrl = UrlFactory.CreateUrl(this.PageName, this.UrlParameters.UserIdentifier);
        }
    }
}