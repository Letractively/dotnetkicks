using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public abstract class JavaScriptFeedHandler : IHttpHandler {

        protected Host _hostProfile;
        protected StoryCollection _stories;

        protected abstract void GetStoryData(HttpContext context);

        public virtual void ProcessRequest(HttpContext context) {
            this._hostProfile = HostCache.GetHost(HostHelper.GetHostAndPort(context.Request.Url));
            this.GetStoryData(context);

            int storyCount =
                Math.Min(
                    !string.IsNullOrEmpty(context.Request["count"]) ? Convert.ToUInt16(context.Request["count"]) : _stories.Count,
                    _stories.Count);

            context.Response.ContentType = "text/javascript";

            this.WriteJavaScriptLine(@"<div class=""KickStoryList"">", context);
            foreach (Story story in this._stories.GetRange(0, storyCount)) {
                this.WriteJavaScriptLine(@"<div class=""KickStory"">", context);
                this.WriteJavaScriptLine(String.Format(@"<a href=""{0}"">{1}</a>",
                    UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, CategoryCache.GetCategory(story.CategoryID, this._hostProfile.HostID).CategoryIdentifier, this._hostProfile),
                    story.Title), context);
                this.WriteJavaScriptLine(@"</div>", context);
            }

            this.WriteJavaScriptLine(@"</div>", context);
        }

        protected void WriteJavaScriptLine(string html, HttpContext context) {
            context.Response.Write("document.write('" + html.Replace("'", @"\'") + "');\n");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }   
}
