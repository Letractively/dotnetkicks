using System;
using System.Web.UI.WebControls;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.Web.UI.Controls
{
    public partial class SubmitNewStory : KickUserControl
    {
        protected static string NewStoryUrl
        {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.SubmitStory); }
        }

        protected static string ToolsUrl
        {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.Tools); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // In case a url is passed on the querystring check if the story 
                // already exists and in that case redirect the user to the story page
                string url = Request.QueryString["url"];

                if (!string.IsNullOrEmpty(url))
                {
                    Dal.Story story = Incremental.Kick.Dal.Story.FetchStoryByUrl(url.Trim());

                    if (story != null)
                        Response.Redirect(
                            UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier,
                                                 story.Category.CategoryIdentifier), true);
                }

                // Bind list of categories
                Category.DataSource = CategoryCache.GetCategories(KickPage.HostProfile.HostID);
                Category.DataBind();

                // Retrieve story information if story was submitted with the bookmarklet
                Url.Text = Request.QueryString["url"];
                Title.Text = Request.QueryString["title"];

                if (Title.Text.Length > 70)
                    Title.Text = Title.Text.Substring(0, 70);

                if (Title.Text.Length > 0)
                {
                    TitleNoteLabel.Text = "NOTE: Is this title correct?<br/>";
                    TitleNoteLabel.Visible = true;
                }

                Description.Text = Request.QueryString["description"];

                if (Url.Text.Length == 0)
                    Url.Focus();
                else if (Title.Text.Length == 0)
                    Title.Focus();
                else
                    Description.Focus();
            }
        }

        protected void SubmitStory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                short categoryID = short.Parse(Category.SelectedValue);
                string storyIdentifier =
                    StoryBR.AddStory(KickPage.HostProfile.HostID, Title.Text, Description.Text, Url.Text, categoryID,
                                     KickPage.KickUserProfile);

                NewStoryPanel.Visible = false;
                SuccessPanel.Visible = true;

                string categoryName = CategoryCache.GetCategory(categoryID, KickPage.HostProfile.HostID).CategoryIdentifier;
                UpcomingStoryQueue.NavigateUrl = UrlFactory.CreateUrl(UrlFactory.PageName.NewStories);
                UpcomingStoryQueue.Text = "upcoming queue";
                StoryLink.NavigateUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, storyIdentifier, categoryName);

                // Bind the story original url to the image customization user control
                KickItImagePersonalization.StoryUrl = Url.Text;
            }
        }


        protected void UrlCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {

            // Retrieve the story given the url
            Dal.Story story = Incremental.Kick.Dal.Story.FetchStoryByUrl(args.Value);

            // If the story already exists in the database
            if (story != null)
            {
                // Make page invalid
                args.IsValid = false;

                // Let user kick the existing story by providing a link to it
                UrlCheck.ErrorMessage =
                    string.Format("The story already exists. You might want to <a href=\"{0}\">kick it</a> instead.<br/>",
                                  UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier,
                                                       story.Category.CategoryIdentifier));
                return;
            }

            // check to see its bannination status
            bool banninated = BannedUrlHelper.IsUrlBanninated(args.Value, HostCache.GetHost(HostHelper.GetHostAndPort(Request.Url)).HostID);

            // If the url matches
            if (banninated)
            {
                // Make page invalid
                args.IsValid = false;

                // Let user kick the existing story by providing a link to it
                UrlCheck.ErrorMessage = "This URL cannot be submitted.<br/>";
            }
        }
    }
}