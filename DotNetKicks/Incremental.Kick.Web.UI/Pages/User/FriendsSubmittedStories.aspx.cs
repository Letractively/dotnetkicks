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

namespace Incremental.Kick.Web.UI.Pages.User
{
    public partial class FriendsSubmittedStories :  Incremental.Kick.Web.Controls.KickUserProfilePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.PageName = UrlFactory.PageName.FriendsSubmittedStories;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserProfileHeader.User = this.UserProfile;
            this.StoryListControl.NoStoriesCaption = string.Format("Friends of {0} have not submitted any stories.", this.UrlParameters.UserIdentifier);
            this.StoryListControl.Title = "Stories submitted by friends of " + this.UrlParameters.UserIdentifier;
            this.StoryListControl.DataBind(StoryCache.GetFriendsSubmittedStories(this.UrlParameters.UserIdentifier, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize));
            this.Paging.RecordCount = StoryCache.GetFriendsSubmittedStoriesPageCount  (this.UrlParameters.UserIdentifier, this.HostProfile.HostID, this.UrlParameters.PageSize);
            this.Paging.PageNumber = UrlParameters.PageNumber;
            this.Paging.PageSize = UrlParameters.PageSize;
            this.Paging.BaseUrl = UrlFactory.CreateUrl(this.PageName, this.UrlParameters.UserIdentifier);
        }
    }
}
