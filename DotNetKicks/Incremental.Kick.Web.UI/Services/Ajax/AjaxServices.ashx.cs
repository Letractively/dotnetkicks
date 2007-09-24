using System;
using Jayrock.JsonRpc.Web;
using Jayrock.JsonRpc;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Caching;
using Incremental.Common.Web.Helpers;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using System.Web;
using Incremental.Kick.Helpers;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    //NOTE: GJ: we are now using Jayrock for Ajax services. Please see http://jayrock.berlios.de/ for more info
    public class AjaxServices : KickJsonRpcHandler {

        #region Shout Box

        [JsonRpcMethod("addShout")]
        public string AddShout(string message) {
            this.DemandUserAuthentication();
            Shout.AddShout(this.KickUserProfile, this.HostProfile.HostID, message);
            return GetLatestShouts();
        }

        [JsonRpcMethod("addShoutForUser")]
        public string AddShoutForUser(string message, string username) {
            this.DemandUserAuthentication();
            Shout.AddShout(this.KickUserProfile, this.HostProfile.HostID, message, username);
            return GetLatestShoutsForUser(username);
        }

        [JsonRpcMethod("getLatestShouts")]
        public string GetLatestShouts() {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(this.HostProfile.HostID)));
        }

        [JsonRpcMethod("getLatestShoutsForUser")]
        public string GetLatestShoutsForUser(string username) {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(this.HostProfile.HostID, username)));
        }

        #endregion

        #region KickSpy!
        [JsonRpcMethod("getSpyHtml")]
        public string GetSpyHtml() {
            UserActionList userActionList = new UserActionList(UserActionCache.GetLatestUserActions(this.HostProfile.HostID));
            userActionList.ShowModeratorActions = this.KickUserProfile.IsModerator;
            return ControlHelper.RenderControl(userActionList);
        }
        #endregion

        #region Story

        [JsonRpcMethod("fetchKickedStoryUrlByUrl")]
        public string FetchKickedStoryUrlByUrl(string url) {
            Story story = Story.FetchStoryByUrl(url);
            return story != null
                    ? UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, story.Category.CategoryIdentifier)
                    : null;
        }

        [JsonRpcMethod("kickStory")]
        public int KickStory(int storyID, bool isKick) {
            this.DemandUserAuthentication();
            if (isKick)
                return UserCache.KickStory(storyID, this.KickUserProfile.UserID, this.HostProfile.HostID);
            else
                return UserCache.UnKickStory(storyID, this.KickUserProfile.UserID, this.HostProfile.HostID);
        }

        [JsonRpcMethod("tagStory")]
        public string TagStory(int storyID, string tagString) {
            this.DemandUserAuthentication();
            WeightedTagList tags = TagBR.AddUserStoryTags(tagString, this.KickUserProfile, storyID, this.HostProfile.HostID);
            UserEditableTagList userTagList = new UserEditableTagList();
            userTagList.DataBind(tags, storyID, this.KickUserProfile.Username);
            return ControlHelper.RenderControl(userTagList);
        }

        [JsonRpcMethod("unTagStory")]
        public void UnTagStory(int storyID, int tagID) {
            this.DemandUserAuthentication();
            StoryUserHostTag.Destroy(storyID, this.KickUserProfile.UserID, this.HostProfile.HostID, tagID);
        }

        [JsonRpcMethod("getUserStoryTags")]
        public string GetUserStoryTags(int storyID) {
            this.DemandUserAuthentication();
            WeightedTagList tags = Tag.FetchUserStoryTags(this.KickUserProfile.UserID, storyID).ToWeightedTagList();
            UserEditableTagList userTagList = new UserEditableTagList();
            userTagList.DataBind(tags, storyID, this.KickUserProfile.Username);
            return ControlHelper.RenderControl(userTagList);
        }

        [JsonRpcMethod("reportAsSpam")]
        public void ReportAsSpam(int storyID) {
            this.DemandUserAuthentication();
            StoryBR.IncrementSpamCount(storyID);
        }

        [JsonRpcMethod("moderatorMarkAsSpam")]
        public void ModeratorMarkAsSpam(int storyID) {
            this.DemandModeratorRole();
            StoryBR.MarkAsSpam(storyID, this.HostProfile.HostID, this.KickUserProfile);
        }

        #endregion

        #region User

        [JsonRpcMethod("checkUsernameExists")]
        public bool CheckUsernameExists(string username) {
            return Incremental.Kick.Dal.User.FetchByParameter(Incremental.Kick.Dal.User.Columns.Username, username).Read();
        }

        [JsonRpcMethod("checkEmailExists")]
        public bool CheckEmailExists(string email) {
            return Incremental.Kick.Dal.User.FetchByParameter(Incremental.Kick.Dal.User.Columns.Email, email).Read();
        }

        #endregion
    }
}
