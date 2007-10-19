using Jayrock.JsonRpc;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Caching;
using Incremental.Common.Web.Helpers;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.BusinessLogic;
using System;
using System.Collections.Generic;
using Incremental.Kick.Dal.Entities.Api;
using System.Web.UI;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    //NOTE: GJ: we are now using Jayrock for Ajax services. Please see http://jayrock.berlios.de/ for more info
    public class AjaxServices : KickJsonRpcHandler {

        #region Shout Box

        [JsonRpcMethod("addShout")]
        public DeltaShoutsHtml AddShout(string message, string toUsername, int chatID, int lastReceivedShoutID) {
            DemandUserAuthentication();
            Shout.AddShout(KickUserProfile, HostProfile.HostID, message, toUsername, ToNullable(chatID));
            return GetDeltaShouts(toUsername, chatID, lastReceivedShoutID);
        }

        [JsonRpcMethod("getDeltaShouts")]
        public DeltaShoutsHtml GetDeltaShouts(string toUsername, int chatID, int lastReceivedShoutID) {
            ShoutCollection shouts = ShoutCache.GetDeltaShouts(HostProfile.HostID, toUsername, ToNullable(chatID), lastReceivedShoutID);
                DeltaShoutsHtml deltaShoutsHtml = new DeltaShoutsHtml();

            if (shouts.Count > 0) {
                ShoutList shoutList = new ShoutList(shouts);
                shoutList.ShowTime = false;
                deltaShoutsHtml.Html = ControlHelper.RenderControl(shoutList);
                deltaShoutsHtml.LatestShout = shouts[0].ToApi(this.HostProfile);
            }
            return deltaShoutsHtml;
        }

        public class DeltaShoutsHtml {
            public ApiShout LatestShout;
            public string Html;
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

        [JsonRpcMethod("saveColorPreferences")]
        public void SaveColorPreferences(string kickItTextColor, string kickItBackgroundColor, string kickCountTextColor, string kickCountBackgroundColor, string borderColor)
        {
            if(!KickUserProfile.IsGuest)
            {
                KickUserProfile.KickItTextColor = kickItTextColor;
                KickUserProfile.KickItBackgroundColor = kickItBackgroundColor;
                KickUserProfile.KickCountTextColor = kickCountTextColor;
                KickUserProfile.KickCountBackgroundColor = kickCountBackgroundColor;
                KickUserProfile.KickImageBorderColor = borderColor;

                KickUserProfile.Save();
            }
        }

        #endregion
    }
}
