using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class StoryDynamicImage : HtmlControl {

        private string _url;
        private Host _hostProfile;
        public StoryDynamicImage(string url, Host hostProfile) {
            this._url = url;
            this._hostProfile = hostProfile;
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<a href=""{0}/kick/?url={1}""><img src=""{0}/Services/Images/KickItImageGenerator.ashx?url={1}"" border=""0"" alt=""kick it on {2}"" /></a>",
                this._hostProfile.RootUrl, HttpUtility.UrlPathEncode(this._url), this._hostProfile.SiteTitle);
        }
       
    }
}
