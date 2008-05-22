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
using System.Security;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.Web.UI.Services.Ajax.Moderator {
    public partial class DeleteStory : Incremental.Kick.Web.Controls.KickApiPage {
        protected void Page_Load(object sender, EventArgs e) {
            int storyID = int.Parse(Request["storyID"]);

            System.Diagnostics.Debug.WriteLine(String.Format("Ajax.DeleteStory({0}) by [{1}]", storyID, this.KickUserProfile.Username));

            if(!this.IsHostModerator) {
                throw new SecurityException("");
            }

            EmailHelper.SendStoryDeletedEmail(Story.FetchByID(storyID), this.HostProfile);

            StoryBR.DeleteStory(storyID, this.HostProfile.HostID);
        }
    }
}

