using System;
using Incremental.Kick.Web.Controls;

namespace Incremental.Kick.Web.UI.Controls
{
    public partial class KickItImagePersonalization : KickUserControl
    {
        private string storyUrl;
        private StoryDynamicImage liveImage;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            liveImage = new StoryDynamicImage(storyUrl, KickPage.HostProfile);
        }

        public StoryDynamicImage LiveImage
        {
            get { return liveImage; }
        }

        public string StoryUrl
        {
            get { return storyUrl; }
            set { storyUrl = value; }
        }
    }
}