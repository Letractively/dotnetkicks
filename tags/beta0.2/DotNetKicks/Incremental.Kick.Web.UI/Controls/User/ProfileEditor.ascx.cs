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
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Controls {
    public partial class ProfileEditor : Incremental.Kick.Web.Controls.KickUserControl {
        private User _userProfile;
        public User UserProfile {
            get { return _userProfile; }
        }
        public void DataBind(User userProfile) {
            this._userProfile = userProfile;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                this.UseGravatar.Checked = this.UserProfile.UseGravatar;
                this.GravatarCustomEmail.Text = this.UserProfile.GravatarCustomEmail;
                this.Location.Text = this.UserProfile.Location;
                this.WebsiteURL.Text = this.UserProfile.WebsiteURL;
                this.BlogUrl.Text = this.UserProfile.BlogURL;
                this.BlogFeedUrl.Text = this.UserProfile.BlogFeedURL;
                this.UserEmail.Text = this.UserProfile.Email;
            }
        }

        protected void UpdateProfile_Click(object sender, EventArgs e) {
            this.UserProfile.UseGravatar = this.UseGravatar.Checked;
            this.UserProfile.GravatarCustomEmail = this.GravatarCustomEmail.Text;
            this.UserProfile.Location = this.Location.Text;
            this.UserProfile.WebsiteURL = this.WebsiteURL.Text;
            this.UserProfile.BlogURL = this.BlogUrl.Text;
            this.UserProfile.BlogFeedURL = this.BlogFeedUrl.Text;
            this.UserProfile.Save();

            UserCache.RemoveUser(this.UserProfile.UserID);
            this.Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.UserProfile, this.UserProfile.Username));
        }
    }
}