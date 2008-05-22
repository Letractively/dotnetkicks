using System.Collections;
using System.Text;

namespace Incremental.Kick.Web.UI.Controls
{
    using System;
    using Caching;
    using Kick.Helpers;
    using Web.Controls;
    using Helpers;

    public partial class AddComment : KickUserControl
    {
        private int _storyID;

        protected const int MinLength = 4;
        protected const int MaxLength = 2500;

        protected string LoginUrl
        {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.Login, Request.Path); }
        }

        protected static string RegisterUrl
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

                StringBuilder emoticons = new StringBuilder();

                foreach(DictionaryEntry emoticon in TextHelper.Emoticons)
                    emoticons.AppendFormat("<img src=\"{0}/{1}\" border=\"0\" style=\"cursor:pointer;\" onclick=\"insertEmoticonCode('{2}');\" title=\"{2} {3}\" />",
                                           KickPage.StaticEmoticonsRootUrl, emoticon.Value, emoticon.Key,
                                           emoticon.Value.ToString().Substring(0, emoticon.Value.ToString().LastIndexOf("."))).
                        Append("  ");

                Emoticons.InnerHtml = emoticons.ToString();
            }

            bool authenticated = KickPage.IsAuthenticated;
            AddCommentPanel.Visible = authenticated;
            LoginToCommentPanel.Visible = !authenticated;
        }

        protected void AddComment_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string comment = TextHelper.EncodeAndReplaceComment(Comment.Text);

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