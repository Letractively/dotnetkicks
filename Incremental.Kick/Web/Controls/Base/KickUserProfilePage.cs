using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls {
    public class KickUserProfilePage : KickUIPage {
        private Dal.User _userProfile = null;
        public Dal.User UserProfile {
            get {
                if (_userProfile == null)
                    _userProfile = UserCache.GetUserByUsername(this.UrlParameters.UserIdentifier);
                return _userProfile;
            }
        }
        protected override void OnInit(EventArgs e) {
            this.Caption = this.UrlParameters.UserIdentifier;
            this.Title = this.HostProfile.SiteTitle + " : " + this.Caption;
            this.RssFeedUrl = UrlFactory.CreateUrl(UrlFactory.PageName.UserKickedStoriesRss, this.UrlParameters.UserIdentifier);
            this.DisplayAds = false;

            base.OnInit(e);
        }
    }
}
