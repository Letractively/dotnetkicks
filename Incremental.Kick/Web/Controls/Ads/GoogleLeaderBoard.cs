using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Incremental.Kick.Web.Controls {
    public class GoogleLeaderboard : KickHtmlControl {
        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"
            <div id=""topAds"">

            <script type=""text/javascript""><!--
                google_ad_client = ""{0}"";
                google_ad_width = 728;
                google_ad_height = 90;
                google_ad_format = ""728x90_as"";
                google_ad_type = ""text"";
                google_ad_channel ="""";
                google_color_border = ""FFFFFF"";
                google_color_bg = ""FFFFFF"";
                google_color_link = ""0066CC"";
                google_color_url = ""000000"";
                google_color_text = ""000000"";
            //--></script>
            <script type=""text/javascript""
              src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">
            </script>
            </div>
            ", this.KickUIPage.AdSenseID);
        }
    }
}
