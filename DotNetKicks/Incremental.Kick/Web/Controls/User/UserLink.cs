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
            writer.Write(@"<span class=""User"">");
            if (this._user.UseGravatar) {
                Gravatar gravatar = new Gravatar();
                gravatar.Size = 16;
                gravatar.Email = this._user.GravatarEmail;
                gravatar.RenderControl(writer);
            }
            
            writer.Write(@" <a href=""{0}"">{1}</a></span>", UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this._user.Username), this._user.Username);
        }
    }
}
