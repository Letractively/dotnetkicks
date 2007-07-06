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
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    public partial class GetUserStoryTags : Incremental.Kick.Web.Controls.KickApiPage {
        protected void Page_Load(object sender, EventArgs e) {
            int storyID = int.Parse(Request["storyID"]);

            if (this.IsAuthenticated) {
                //TODO: GJ: get user story tags (cached?)
                WeightedTagList tags = Tag.FetchUserStoryTags(this.KickUserProfile.UserID, storyID).ToWeightedTagList();

                UserEditableTagList userTagList = new UserEditableTagList();

                userTagList.DataBind(tags, storyID);
                this.Controls.Add(userTagList);
            } else {

                Response.Write("login or signup to tag this story");
            }
        }
    }
}