using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Incremental.Kick.Web.Controls {
    public class RssFeedIcon : KickHtmlControl {
        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"
                <span class=""RssFeedIcon"">
                    <a href=""{0}"">
                    <img src=""{1}/rss.jpg"" alt=""Subscribe to this feed"" width=""16"" height=""16""border=""0"" />
                    </a>
                </span>
            ", this.KickUIPage.RssFeedUrl, this.KickUIPage.StaticIconRootUrl);
        }
    }
}
