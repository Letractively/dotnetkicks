using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls
{
    public class StoryDynamicImage : HtmlControl
    {
        private readonly Host _hostProfile;
        private readonly string _url;

        public StoryDynamicImage(string url, Host hostProfile)
        {
            _url = HttpUtility.UrlEncode(url);
            _hostProfile = hostProfile;
        }

        /// <summary>
        /// Gets the image URL client side format string.
        /// </summary>
        /// <value>The image URL client side format string.</value>
        public string ImageUrlClientSideFormatString
        {
            get { return ImageUrl + "{0}{1}{2}{3}{4}"; }
        }

        /// <summary>
        /// Gets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string ImageUrl
        {
            get { return string.Format("{0}/Services/Images/KickItImageGenerator.ashx?url={1}", _hostProfile.RootUrl, _url); }
        }

        /// <summary>
        /// Gets the link href.
        /// </summary>
        /// <value>The link href.</value>
        public string LinkHref
        {
            get { return string.Format("{0}/kick/?url={1}", _hostProfile.RootUrl, _url); }
        }

        /// <summary>
        /// Gets the HTML code for the client side string.
        /// </summary>
        /// <value>The HTML code client side format string.</value>
        public string HtmlCodeClientSideFormatString
        {
            get
            {
                return
                    string.Format("<a href=\"{0}\"><img src=\"{{0}}\" border=\"0\" alt=\"kick it on {1}\" /></a>", LinkHref,
                                  _hostProfile.SiteTitle);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteLine(HtmlCodeClientSideFormatString, ImageUrl);
        }
    }
}