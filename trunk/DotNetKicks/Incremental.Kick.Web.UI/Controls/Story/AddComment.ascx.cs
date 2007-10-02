using System;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Controls
{
    public partial class AddComment : KickUserControl
    {
        private int _storyID;

        protected string LoginUrl
        {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.Login, Request.Path); }
        }

        protected string RegisterUrl
        {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.Register); }
        }

        public void DataBind(int storyID)
        {
            _storyID = storyID;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(KickPage.IsAuthenticated)
            {
                AddCommentPanel.Visible = true;
                LoginToCommentPanel.Visible = false;
            }
            else
            {
                AddCommentPanel.Visible = false;
                LoginToCommentPanel.Visible = true;
            }
        }

        protected void AddComment_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Comment.Text = Comment.Text.Trim();

                int commentID =
                    Dal.Comment.CreateComment(KickPage.HostProfile.HostID, _storyID, KickPage.KickUserProfile, Comment.Text);

                //now clear the cache for this story (NOTE: in the future, we can just update the cache too)
                StoryCache.RemoveStory(_storyID, KickPage.UrlParameters.StoryIdentifier);

                Response.Redirect(
                    UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, KickPage.UrlParameters.StoryIdentifier,
                                         KickPage.UrlParameters.CategoryIdentifier, commentID));
            }
        }

        protected void CommentLength_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 4 && args.Value.Length <= 2500;
        }
    }
}