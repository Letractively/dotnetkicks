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
            string userUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewUser, this._username);

            writer.WriteLine(@"<a href=""{0}"">{1}</a>", userUrl, this._username);
           //old: writer.WriteLine(@"<a href=""#"">{1}</a>", userUrl, this._username);

        }
    }
}
