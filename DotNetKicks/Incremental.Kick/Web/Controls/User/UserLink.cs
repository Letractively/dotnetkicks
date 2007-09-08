using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class UserLink : KickWebControl {
        private string _username;

        public void DataBind(string username) {
            this._username = username;
        }
        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<a href=""{0}"">{1}</a>", UrlFactory.CreateUrl(UrlFactory.PageName.UserProfile, this._username), this._username);
        }
    }
}
