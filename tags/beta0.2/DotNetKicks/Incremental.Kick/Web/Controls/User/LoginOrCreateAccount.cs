using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class LoginOrCreateAccount : KickHtmlControl {

        protected override void Render(HtmlTextWriter writer) {

            writer.WriteLine(@"Please <a href=""{0}"">login</a> or <a href=""{1}"">signup</a>.", UrlFactory.CreateUrl(UrlFactory.PageName.Login), UrlFactory.CreateUrl(UrlFactory.PageName.Register));


        }
    }
}
