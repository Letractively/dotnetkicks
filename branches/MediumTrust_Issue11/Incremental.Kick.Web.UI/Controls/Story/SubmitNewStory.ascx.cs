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
using Incremental.Kick.Caching;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Web.Helpers;
using Incremental.Common.Web.Helpers;

namespace Incremental.Kick.Web.UI.Controls {

    public partial class SubmitNewStory : Incremental.Kick.Web.Controls.KickUserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!this.Page.IsPostBack) {
                Category.DataSource = CategoryCache.GetCategories(this.KickPage.HostProfile.HostID);
                Category.DataTextField = "Name";
                Category.DataValueField = "CategoryID";
                Category.DataBind();


                this.Url.Text = Request.QueryString["url"];
                this.Title.Text = Request.QueryString["title"];
                if (this.Title.Text.Length > 70) {
                    this.Title.Text = this.Title.Text.Substring(0, 70);
                }

                if (this.Title.Text.Length > 0)
                    TitleNoteLabel.Text = "NOTE: Is this title correct?";

                this.Description.Text = Request.QueryString["description"];

                if (this.Url.Text.Length == 0)
                    this.Url.Focus();
                else if (this.Title.Text.Length == 0)
                    this.Title.Focus();
                else
                    this.Description.Focus();
            }
        }

        protected void SubmitStory_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                short categoryID = short.Parse(this.Category.SelectedValue);
                string storyIdentifier = StoryBR.AddStory(this.KickPage.HostProfile.HostID, this.Title.Text, this.Description.Text, this.Url.Text,
                    categoryID, this.KickPage.KickUserProfile);

                NewStoryPanel.Visible = false;
                SuccessPanel.Visible = true;

                string categoryName = CategoryCache.GetCategory(categoryID, this.KickPage.HostProfile.HostID).CategoryIdentifier;
                UpcomingStoryQueue.NavigateUrl = UrlFactory.CreateUrl(UrlFactory.PageName.NewStories);
                UpcomingStoryQueue.Text = "upcoming queue";
                StoryLink.NavigateUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, storyIdentifier, categoryName);

                LiveImage.Text = ControlHelper.RenderControl(new Incremental.Kick.Web.Controls.StoryDynamicImage(HttpUtility.UrlPathEncode(this.Url.Text), this.KickPage.HostProfile));
            }
        }

        protected string NewStoryUrl {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.SubmitStory); }
        }

        protected string ToolsUrl {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.Tools); }
        }
    }
}