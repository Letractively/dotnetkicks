using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class UserLink : KickWebControl {
        private User _user;

        public void DataBind(User user) {
            this._user = user;
        }
        protected override void Render(HtmlTextWriter writer) {
            writer.Write(@"<span class=""user""><a href=""{0}"">", UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this._user.Username));
            if (this._user.UseGravatar) {
                new Gravatar(this._user, 16).RenderControl(writer);
                writer.Write(" ");
            }
            
            writer.Write(@"{0}</a></span>", this._user.Username);
        }
    }
}