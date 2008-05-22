using System;
using System.Collections.Generic;
using System.Text;
using Rss;
namespace Incremental.Kick.Web.Controls {
    public class KickRssPage : KickPage {
        public void RenderRssChannel(RssChannel rssChannel) {
            RssFeed rssFeed = new RssFeed();
           

            rssFeed.Channels.Add(rssChannel);
            this.Response.ContentType = "text/xml";

            rssFeed.Write(this.Response.OutputStream);
            this.Response.End();
        }
    }
}
