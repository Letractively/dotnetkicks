using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Incremental.Kick.Web.Controls {
    public class GoogleWideSkyscraper : KickHtmlControl {
        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"
            <script type=""text/javascript""><!--
                google_ad_client = ""{0}"";
                google_ad_width = 160;
                google_ad_height = 600;
                google_ad_format = ""160x600_as"";
                google_ad_type = ""text_image"";
                google_ad_channel ="""";
                google_color_border = ""F0FEF1"";
                google_color_bg = ""F0FEF1"";
                google_color_link = ""0066CC"";
                google_color_url = ""000000"";
                google_color_text = ""000000"";
            //--></script>
            <script type=""text/javascript""
              src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">
            </script>
            ", this.KickUIPage.AdSenseID);
        }
    }
}
