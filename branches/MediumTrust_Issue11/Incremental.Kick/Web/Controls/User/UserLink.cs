using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls {
    public class UserLink : KickWebControl {
        private User _user;

        public UserLink() { }
        public UserLink(int userID) {
            this.DataBind(UserCache.GetUser(userID));
        }
        public UserLink(User user) {
            this.DataBind(user);
        }

        public void DataBind(User user) {
            this._user = user;
        }
        protected override void Render(HtmlTextWriter writer) {
            string cssClass = "user";
            if (this._user.IsBanned)
                cssClass += " bannedUser";
            else if (this._user.IsAdministrator)
                cssClass += " administratorUser";
            else if (this._user.IsModerator)
                cssClass += " moderatorUser";
            else if (this._user.IsNewMember)
                cssClass += " newUser";

            writer.Write(@"<span class=""{0}""><a href=""{1}"" rel=""friend"">", cssClass, UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this._user.Username));
            if (this._user.UseGravatar) {
                new Gravatar(this._user, 16).RenderControl(writer);
                writer.Write(" ");
            }

            writer.Write(@"{0}</a></span>", this._user.Username);
        }
    }
}