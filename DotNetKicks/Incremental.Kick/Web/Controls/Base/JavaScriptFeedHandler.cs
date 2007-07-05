using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
//using Incremental.Kick.Common.Entities;
//using Incremental.Kick.Common.DataSets.Tables;
//using Incremental.Kick.Common.DataSets.Rows;
//using Incremental.Kick.Caching;
//using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    //public abstract class JavaScriptFeedHandler : IHttpHandler {

    //    protected HostProfile _hostProfile;
    //    protected Kick_StoryTable _storyTable;

    //    protected abstract void GetStoryData(HttpContext context);

    //    public virtual void ProcessRequest(HttpContext context) {
    //        this._hostProfile = HostCache.GetHostProfile(HostHelper.GetHostAndPort(context.Request.Url));
    //        this.GetStoryData(context);
            
    //        context.Response.ContentType = "text/javascript";

            

    //        this.WriteJavaScriptLine(@"<div class=""KickStoryList"">", context);
    //        foreach (Kick_StoryRow story in this._storyTable) {
    //            this.WriteJavaScriptLine(@"<div class=""KickStory"">", context);
    //            this.WriteJavaScriptLine(String.Format(@"<a href=""{0}"">{1}</a>",
    //                UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, CategoryCache.GetCategoryIdentifier(story.CategoryID, this._hostProfile.HostID), this._hostProfile),
    //                story.Title), context);
    //            this.WriteJavaScriptLine(@"</div>", context);
    //        }

    //        this.WriteJavaScriptLine(@"</div>", context);   
    //    }

    //    protected void WriteJavaScriptLine(string html, HttpContext context) {
    //        context.Response.Write("document.write('" + html + "');\n");
    //    }

    //    public bool IsReusable {
    //        get {
    //            return false;
    //        }
    //    }
   // }


    
}
