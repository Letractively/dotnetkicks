using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Common.Enums;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class UserProfileHeader : KickWebControl {

        public UserProfileHeader() { }
        public UserProfileHeader(User user) {
            this.User = user;
        }
        
        private User _user;
        public User User {
            get { return this._user; }
            set { this._user = value; }
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<table class=""vcard""><tr><td width=""50""><div style=""display:none"" class=""fn"">" + this.User.Username + "</div>");
            new Gravatar(this.User, 50).RenderControl(writer);
            writer.WriteLine("</td><td>");

            UserProfileMenu menu = new UserProfileMenu(this.User.Username);
            this.Controls.Add(menu);
            menu.RenderControl(writer);
            writer.WriteLine("</td></tr></table>");
            writer.WriteLine("<br />");
        }
    }
}
