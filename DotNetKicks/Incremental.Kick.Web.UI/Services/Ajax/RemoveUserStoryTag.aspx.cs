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
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    public partial class RemoveUserStoryTag : Incremental.Kick.Web.Controls.KickApiPage {
        protected void Page_Load(object sender, EventArgs e) {
            int storyID = int.Parse(Request["storyID"]);
            int tagID = int.Parse(Request["tagID"]);

            if (this.IsAuthenticated) {
                //TODO: GJ: delete the tag
                //new Kick_StoryUserHostTagBR().DeleteByID(

                //TagList tags = new Kick_StoryUserHostTagBR().AddUserStoryTags(tagString, this.KickUserProfile.UserID, storyID, this.HostProfile.HostID);
                //UserEditableTagList userTagList = new UserEditableTagList();
                //userTagList.DataBind(tags, storyID);
                //this.Controls.Add(userTagList);
                StoryUserHostTag.Destroy(storyID, this.KickUserProfile.UserID, this.HostProfile.HostID, tagID);
            } else {
                throw new ApplicationException();
            }
        }
    }
}
