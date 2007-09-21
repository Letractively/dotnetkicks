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

        //NOTE: GJ: Work in progress - lots of refactoring needed
        [JsonRpcMethod("addShout")]
        public string AddShout(int hostID, string message) {
            this.DemandUserAuthentication();
                
            if (!String.IsNullOrEmpty(message))
                //TODO: GJ: move to model and add some regex replacements (links are good, line breaks become <br>)
                if (!KickUserProfile.IsBanned) {
                    Shout shout = new Shout();
                    shout.HostID = hostID;
                    message = HttpUtility.HtmlEncode(message);
                    message = TextHelper.Urlify(message);
                    shout.Message = message.Replace("\n", "<br/>");
                    shout.FromUserID = KickUserProfile.UserID;
                    shout.Save();
                    ShoutCache.Remove(hostID);

                    UserAction.RecordShout(hostID, KickUserProfile);
                }
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID)));
        }

        [JsonRpcMethod("addShoutForUser")]
        public string AddShoutForUser(int hostID, string message, string username) {
            this.DemandUserAuthentication();

            if (!String.IsNullOrEmpty(message))
                //TODO: GJ: move to model and add some regex replacements (links are good, line breaks become <br>)
                if (!KickUserProfile.IsBanned) {
                    Shout shout = new Shout();
                    shout.HostID = hostID;
                    message = HttpUtility.HtmlEncode(message);
                    message = TextHelper.Urlify(message);
                    shout.Message = message.Replace("\n", "<br/>");
                    User forUser = UserCache.GetUserByUsername(username);
                    shout.ToUserID = forUser.UserID;
                    shout.FromUserID = KickUserProfile.UserID;
                    shout.Save();
                    ShoutCache.Remove(hostID, username);

                    UserAction.RecordShout(hostID, KickUserProfile, forUser);
                }
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID, username)));
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
