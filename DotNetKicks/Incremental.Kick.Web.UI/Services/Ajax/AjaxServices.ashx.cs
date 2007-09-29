using Jayrock.JsonRpc;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Caching;
using Incremental.Common.Web.Helpers;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    //NOTE: GJ: we are now using Jayrock for Ajax services. Please see http://jayrock.berlios.de/ for more info
    public class AjaxServices : KickJsonRpcHandler {

        #region Shout Box

        [JsonRpcMethod("addShout")]
        public string AddShout(string message) {
            DemandUserAuthentication();
            Shout.AddShout(KickUserProfile, HostProfile.HostID, message);
            return GetLatestShouts();
        }

        [JsonRpcMethod("addShoutForUser")]
        public string AddShoutForUser(string message, string username) {
            DemandUserAuthentication();
            Shout.AddShout(KickUserProfile, HostProfile.HostID, message, username);
            return GetLatestShoutsForUser(username);
        }

        [JsonRpcMethod("getLatestShouts")]
        public string GetLatestShouts() {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(HostProfile.HostID)));
        }

        [JsonRpcMethod("getLatestShoutsForUser")]
        public string GetLatestShoutsForUser(string username) {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(HostProfile.HostID, username)));
        }

        #endregion

        #region KickSpy!
        [JsonRpcMethod("getSpyHtml")]
        public string GetSpyHtml() {
            UserActionList userActionList = new UserActionList(UserActionCache.GetLatestUserActions(HostProfile.HostID));
            userActionList.ShowModeratorActions = KickUserProfile.IsModerator;
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
            DemandUserAuthentication();
            if (isKick)
                return UserCache.KickStory(storyID, KickUserProfile.UserID, HostProfile.HostID);
            else
                return UserCache.UnKickStory(storyID, KickUserProfile.UserID, HostProfile.HostID);
        }

        [JsonRpcMethod("tagStory")]
        public string TagStory(int storyID, string tagString) {
            DemandUserAuthentication();
            WeightedTagList tags = TagBR.AddUserStoryTags(tagString, KickUserProfile, storyID, HostProfile.HostID);
            UserEditableTagList userTagList = new UserEditableTagList();
            userTagList.DataBind(tags, storyID, KickUserProfile.Username);
            return ControlHelper.RenderControl(userTagList);
        }

        [JsonRpcMethod("unTagStory")]
        public void UnTagStory(int storyID, int tagID) {
            DemandUserAuthentication();
            StoryUserHostTag.Destroy(storyID, KickUserProfile.UserID, HostProfile.HostID, tagID);
        }

        [JsonRpcMethod("getUserStoryTags")]
        public string GetUserStoryTags(int storyID) {
            DemandUserAuthentication();
            WeightedTagList tags = Tag.FetchUserStoryTags(KickUserProfile.UserID, storyID).ToWeightedTagList();
            UserEditableTagList userTagList = new UserEditableTagList();
            userTagList.DataBind(tags, storyID, KickUserProfile.Username);
            return ControlHelper.RenderControl(userTagList);
        }

        [JsonRpcMethod("reportAsSpam")]
        public void ReportAsSpam(int storyID) {
            DemandUserAuthentication();
            StoryBR.IncrementSpamCount(storyID);
        }

        [JsonRpcMethod("moderatorMarkAsSpam")]
        public void ModeratorMarkAsSpam(int storyID) {
            DemandModeratorRole();
            StoryBR.MarkAsSpam(storyID, HostProfile.HostID, KickUserProfile);
        }

        #endregion

        #region User

        [JsonRpcMethod("checkUsernameExists")]
        public bool CheckUsernameExists(string username) {
            return Incremental.Kick.Dal.User.FetchByParameter(Incremental.Kick.Dal.User.Columns.Username, username).Read() || 
                   ReservedUsername.FetchByParameter(ReservedUsername.Columns.Username, username).Read();
        }

        [JsonRpcMethod("checkEmailExists")]
        public bool CheckEmailExists(string email) {
            return Incremental.Kick.Dal.User.FetchByParameter(Incremental.Kick.Dal.User.Columns.Email, email).Read();
        }

        #endregion
    }
}
