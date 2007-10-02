namespace Incremental.Kick.Web.UI.Controls
{
    using System;
    using Incremental.Kick.Caching;
    using Incremental.Kick.Helpers;
    using Incremental.Kick.Web.Controls;
    using Incremental.Kick.Web.Helpers;

    public partial class AddComment : KickUserControl
    {
        private int _storyID;

        protected const int MinLength = 4;
        protected const int MaxLength = 2500;

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
            if (!IsPostBack)
            {
                CommentLength.Text = string.Format(CommentLength.Text,
                    MinLength.ToString("N0"), MaxLength.ToString("N0"));
            }

            bool authenticated = KickPage.IsAuthenticated;
            AddCommentPanel.Visible = authenticated;
            LoginToCommentPanel.Visible = !authenticated;
        }

        protected void AddComment_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string comment = Comment.Text.Trim();

            comment = TextHelper.EncodeAndReplaceComment(comment);
            comment = TextHelper.ReplaceEmoticons(comment, KickPage.StaticEmoticonsRootUrl);

            int commentID =
                Dal.Comment.CreateComment(KickPage.HostProfile.HostID, _storyID, KickPage.KickUserProfile, comment);

            //now clear the cache for this story (NOTE: in the future, we can just update the cache too)
            StoryCache.RemoveStory(_storyID, KickPage.UrlParameters.StoryIdentifier);

            Response.Redirect(
                UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, KickPage.UrlParameters.StoryIdentifier,
                                     KickPage.UrlParameters.CategoryIdentifier, commentID));
        }

        protected void CommentLength_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string value = (args.Value ?? string.Empty).Trim();
            args.IsValid = value.Length >= MinLength && value.Length <= MaxLength;
        }
    }
}