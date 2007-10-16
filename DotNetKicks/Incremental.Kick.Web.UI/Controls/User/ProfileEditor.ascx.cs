using System;
using System.Web.UI.WebControls;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Controls
{
    public partial class ProfileEditor : Web.Controls.KickUserControl
    {
        private User _userProfile;

        public User UserProfile
        {
            get { return _userProfile; }
        }

        public void DataBind(User userProfile)
        {
            _userProfile = userProfile;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                UseGravatar.Checked = UserProfile.UseGravatar;
                GravatarCustomEmail.Text = UserProfile.GravatarCustomEmail;
                Location.Text = UserProfile.Location;
                WebsiteURL.Text = UserProfile.WebsiteURL;
                BlogUrl.Text = UserProfile.BlogURL;
                BlogFeedUrl.Text = UserProfile.BlogFeedURL;
                UserEmail.Text = UserProfile.Email;
                AppearOnline.Checked = UserProfile.AppearOnline;
                ShowStoryThumbnail.Checked = UserProfile.ShowStoryThumbnail;
                ShowEmoticons.Checked = UserProfile.ShowEmoticons;
            }
        }

        protected void UpdateProfile_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UserProfile.UseGravatar = UseGravatar.Checked;
                UserProfile.GravatarCustomEmail = GravatarCustomEmail.Text;
                UserProfile.Location = Location.Text;
                UserProfile.WebsiteURL = WebsiteURL.Text;
                UserProfile.BlogURL = BlogUrl.Text;
                UserProfile.BlogFeedURL = BlogFeedUrl.Text;
                UserProfile.AppearOnline = AppearOnline.Checked;
                UserProfile.ShowStoryThumbnail = ShowStoryThumbnail.Checked;
                UserProfile.ShowEmoticons = ShowEmoticons.Checked;
                UserProfile.Save();

                UserCache.RemoveUser(UserProfile.UserID);

                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.UserProfile, UserProfile.Username));
            }
        }

        protected void EmailExists_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !User.FetchByParameter(User.Columns.Email, args.Value).Read();
        }
    }
}