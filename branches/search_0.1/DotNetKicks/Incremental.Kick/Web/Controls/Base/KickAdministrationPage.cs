using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls {
    public class KickAdministrationPage : KickUIPage {
        protected override void OnInit(EventArgs e) {
            this.RequiresAdministratorRole();
            this.DisplayAds = false;
            this.DisplaySideAds = false;

            base.OnInit(e);
        }
    }
}
