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
using Incremental.Kick.Web.Controls;
using Incremental.Common.Web.Helpers;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    public partial class AddUserStoryTags : Incremental.Kick.Web.Controls.KickApiPage {
        protected void Page_Load(object sender, EventArgs e) {
            int storyID = int.Parse(Request["storyID"]);
            string tagString = HttpUtility.UrlDecode(Request["tags"]);

            if (this.IsAuthenticated) {
                WeightedTagList tags = TagBR.AddUserStoryTags(tagString, this.KickUserProfile, storyID, this.HostProfile.HostID);

                UserEditableTagList userTagList = new UserEditableTagList();
                userTagList.DataBind(tags, storyID);
                this.Controls.Add(userTagList);
            } else {
                throw new ApplicationException();
            }
        }
    }
}