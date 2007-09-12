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
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.Tag {
    public partial class ViewAll : Incremental.Kick.Web.Controls.KickUIPage {
        protected void Page_Init(object sender, EventArgs e) {
            this.Caption = "Everyones tags";
            this.Title = this.HostProfile.SiteTitle + " : " + this.Caption;
            this.PageName = UrlFactory.PageName.ViewTags;
            this.DisplayAds = false;
        }
        
        protected void Page_Load(object sender, EventArgs e) {
            this.TagCloud.DataBind(TagCache.GetHostTags(this.HostProfile.HostID));
        }
    }
}
