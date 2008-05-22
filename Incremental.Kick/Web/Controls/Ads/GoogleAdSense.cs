using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Incremental.Kick.Web.Controls
{
    [ToolboxData("<{0}:GoogleAdSense runat=server></{0}:GoogleAdSense>")]
    public class GoogleAdSense : KickHtmlControl
    {
        private string _adSenseId;
        private int _width = 160;
        private int _height = 600;

        /// <summary>
        /// Gets or sets the ad sense id.
        /// </summary>
        /// <value>The ad sense id.</value>
        public string AdSenseId
        {
            get { return _adSenseId; }
            set { _adSenseId = value; }
        }

        private string _adFormat = "160x600_as";

        /// <summary>
        /// Gets or sets the ad format.
        /// </summary>
        /// <value>The ad format.</value>
        public string AdFormat
        {
            get { return _adFormat; }
            set
            {
                _adFormat = value;
                if (_adFormat == "160x600_as")
                {
                    _width = 160;
                    _height = 600;
                }
                else if (_adFormat == "728x90_as")
                {
                    _width = 728;
                    _height = 90;
                }
            }
        }

        /// <summary>
        /// Renders the contents of the control to the specified writer. 
        /// This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"></see> that 
        /// represents the output stream to render HTML content on the client.</param>
        protected override void Render(HtmlTextWriter writer)
        {

            writer.Write("<script type=\"text/javascript\"><!--");
            writer.Write("google_ad_client = ");
            writer.Write(_adSenseId + ";");

            writer.Write("google_ad_width = ");
            writer.Write(_width + ";");
            writer.Write("google_ad_height = ");
            writer.Write(_height + ";");
            writer.Write("google_ad_format = \"");
            writer.Write(_adFormat + "\";");


            writer.Write("google_ad_type = \"text\";");
            writer.Write("google_ad_channel =\"\";");
            writer.Write("google_color_border = \"#FFFFFF\";");
            writer.Write("google_color_bg = \"#FFFFFF\";");
            writer.Write("google_color_link = \"#0066CC\";");
            writer.Write("google_color_url = \"000000\";");
            writer.Write("google_color_text = \"000000\";");
            writer.Write("//--></script>");
            writer.Write("<script type=\"text/javascript\" src=\"http://pagead2.googlesyndication.com/pagead/show_ads.js\"></script>");


        }



    }
}
