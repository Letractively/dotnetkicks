using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching; 

namespace Incremental.Kick.Web.UI.Pages.Story {
    public partial class ViewOrAdd : Incremental.Kick.Web.Controls.KickPage {
        protected void Page_Load(object sender, EventArgs e) {
            //TODO: GJ: decode url

            string url = Request["url"].Trim();
            string title = Request["title"];

            if (String.IsNullOrEmpty(title)) {
                title = "";
            }

            title = title.Trim();

            //TODO: GJ: we could improve performance here (better story cache)
            Incremental.Kick.Dal.Story story = Incremental.Kick.Dal.Story.FetchStoryByUrl(url);

            if (story == null) {
                this.Response.Redirect("~/submit/?url=" + HttpUtility.UrlEncode(url) + "&title=" + HttpUtility.UrlEncode(title));
            } else {
                //TODO: GJ: should we auto kick???
                this.Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, CategoryCache.GetCategory(story.CategoryID, this.HostProfile.HostID).CategoryIdentifier));
            }
        }
    }
}
