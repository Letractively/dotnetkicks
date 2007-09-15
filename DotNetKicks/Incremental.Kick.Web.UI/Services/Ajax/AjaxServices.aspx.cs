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
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;
using Incremental.Common.Web.Helpers;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    //NOTE: GJ: All out new Ajax services will go here
    public partial class AjaxServices : KickApiPage {

        #region "Shout Box"
        //NOTE: GJ: Work in progress - lots of refactoring needed
        [AjaxPro.AjaxMethod]
        public string AddShout(int hostID, string message) {
            if (!String.IsNullOrEmpty(message)) {
                //TODO: GJ: move to model and add some regex replacements (links are good, line breaks become <br>)
                if (!this.KickUserProfile.IsBanned) {
                    Shout shout = new Shout();
                    shout.HostID = hostID;
                    message = System.Web.HttpUtility.HtmlEncode(message);
                    message = TextHelper.Urlify(message);
                    shout.Message = message.Replace("\n", "<br/>");
                    shout.FromUserID = this.KickUserProfile.UserID;
                    shout.Save();
                    ShoutCache.Remove(hostID);

                    SpyCache.GetSpy(hostID).Shout(this.KickUserProfile, shout.Message);
                }
            }
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID)));
        }

        [AjaxPro.AjaxMethod]
        public string AddShoutForUser(int hostID, string message, string username) {
            if (!String.IsNullOrEmpty(message)) {
                //TODO: GJ: move to model and add some regex replacements (links are good, line breaks become <br>)
                if (!this.KickUserProfile.IsBanned) {
                    Shout shout = new Shout();
                    shout.HostID = hostID;
                    message = System.Web.HttpUtility.HtmlEncode(message);
                    message = TextHelper.Urlify(message);
                    shout.Message = message.Replace("\n", "<br/>");
                    User forUser = UserCache.GetUserByUsername(username);
                    shout.ToUserID = forUser.UserID;
                    shout.FromUserID = this.KickUserProfile.UserID;
                    shout.Save();
                    ShoutCache.Remove(hostID, username);

                    SpyCache.GetSpy(hostID).Shout(this.KickUserProfile, shout.Message, forUser);

                }
            }
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID, username)));
        }

        [AjaxPro.AjaxMethod]
        public string GetLatestShouts(int hostID) {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID)));
        }

        [AjaxPro.AjaxMethod]
        public string GetLatestShoutsForUser(int hostID, string username) {
            return ControlHelper.RenderControl(new ShoutList(ShoutCache.GetLatestShouts(hostID, username)));
        }
        #endregion

    }
}
