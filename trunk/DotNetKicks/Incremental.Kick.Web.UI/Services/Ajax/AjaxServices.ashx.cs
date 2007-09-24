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

namespace Incremental.Kick.Web.UI.Services.Ajax {
    //NOTE: GJ: we are now using Jayrock for Ajax services. Please see http://jayrock.berlios.de/ for more info
    public class AjaxServices : KickJsonRpcHandler {

        #region Shout Box

        [JsonRpcMethod("addShout")]
        public string AddShout(int hostID, string message) {
            this.DemandUserAuthentication();
            Shout.AddShout(this.KickUserProfile, hostID, message);
            return GetLatestShouts(hostID);
        }

        [JsonRpcMethod("addShoutForUser")]
        public string AddShoutForUser(int hostID, string message, string username) {
            this.DemandUserAuthentication();
            Shout.AddShout(this.KickUserProfile, hostID, message, username);
            return GetLatestShoutsForUser(hostID, username);
        }

        [JsonRpcMethod("getLatestShouts")]
        public string GetLatestShouts(int hostID) {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID)));
        }

        [JsonRpcMethod("getLatestShoutsForUser")]
        public string GetLatestShoutsForUser(int hostID, string username) {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID, username)));
        }

        #endregion

        #region KickSpy!
        [JsonRpcMethod("getSpyHtml")]
        public string GetSpyHtml(int hostID) {
            UserActionList userActionList = new UserActionList(UserActionCache.GetLatestUserActions(hostID));
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
