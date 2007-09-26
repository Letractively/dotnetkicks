using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls
{
    public class StoryDynamicImage : HtmlControl
    {
        private readonly Host _hostProfile;
        private readonly string _url;
        private string backgroundColor;
        private string borderColor;
        private string countBackgroundColor;
        private string countForegroundColor;
        private string foregroundColor;

        public StoryDynamicImage(string url, Host hostProfile)
        {
            _url = url;
            _hostProfile = hostProfile;
        }

        public string BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        public string BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        public string CountBackgroundColor
        {
            get { return countBackgroundColor; }
            set { countBackgroundColor = value; }
        }

        public string CountForegroundColor
        {
            get { return countForegroundColor; }
            set { countForegroundColor = value; }
        }

        public string ForegroundColor
        {
            get { return foregroundColor; }
            set { foregroundColor = value; }
        }

        public string ImageUrl
        {
            get
            {
                return
                    string.Format(
                        "{0}/Services/Images/KickItImageGenerator.ashx?url={1}&border={2}&fgcolor={3}&bgcolor={4}&cfgcolor={5}&cbgcolor={6}",
                        _hostProfile.RootUrl, HttpUtility.UrlPathEncode(_url), borderColor, foregroundColor, backgroundColor,
                        countForegroundColor, countBackgroundColor);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteLine(@"<a href=""{0}/kick/?url={1}""><img src=""{2}"" border=""0"" alt=""kick it on {3}"" /></a>",
                             _hostProfile.RootUrl, HttpUtility.UrlPathEncode(_url), ImageUrl, _hostProfile.SiteTitle);
        }
    }
}