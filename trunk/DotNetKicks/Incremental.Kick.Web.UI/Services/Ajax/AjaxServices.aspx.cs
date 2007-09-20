using System;
using System.Web;
using AjaxPro;
using Incremental.Common.Web.Helpers;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Helpers;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    //NOTE: GJ: All our new Ajax services will go here
    public partial class AjaxServices : KickApiPage {
        #region "Shout Box"

        //NOTE: GJ: Work in progress - lots of refactoring needed
        [AjaxMethod]
        public string AddShout(int hostID, string message) {
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

        [AjaxMethod]
        public string AddShoutForUser(int hostID, string message, string username) {
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

        [AjaxMethod]
        public string GetLatestShouts(int hostID) {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID)));
        }

        [AjaxMethod]
        public string GetLatestShoutsForUser(int hostID, string username) {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID, username)));
        }

        #endregion

        #region KickSpy!

        [AjaxMethod]
        public string GetSpyHtml(int hostID) {
            UserActionList userActionList = new UserActionList(UserActionCache.GetLatestUserActions(hostID));
            this.Controls.Add(userActionList);
            return ControlHelper.RenderControl(userActionList);
        }

        #endregion

        #region Story

        [AjaxMethod]
        public string FetchKickedStoryUrlByUrl(string url) {
            Story story = Story.FetchStoryByUrl(url);
            return story != null 
                    ? UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, story.Category.CategoryIdentifier)
                    : null;
        }

        #endregion
    }
}