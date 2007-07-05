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
    public partial class Redirect : Incremental.Kick.Web.Controls.KickUIPage {

        protected void Page_Load(object sender, EventArgs e) {
            Incremental.Kick.Dal.Story story = StoryCache.GetStory(this.UrlParameters.StoryIdentifier);
            System.Diagnostics.Trace.WriteLine("Redirecting to " + story.Url);
            this.Response.Redirect(story.Url);
        }
    }
}