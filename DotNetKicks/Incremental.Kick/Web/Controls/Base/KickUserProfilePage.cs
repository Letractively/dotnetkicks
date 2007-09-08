using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class KickUserProfilePage : KickUIPage {
        protected override void OnInit(EventArgs e) {
            this.Caption = this.UrlParameters.UserIdentifier;
            this.Title = this.HostProfile.SiteTitle + " : " + this.Caption;
            this.RssFeedUrl = UrlFactory.CreateUrl(UrlFactory.PageName.UserKickedStoriesRss, this.UrlParameters.UserIdentifier);
            this.DisplayAds = false;

            base.OnInit(e);
        }
    }
}
