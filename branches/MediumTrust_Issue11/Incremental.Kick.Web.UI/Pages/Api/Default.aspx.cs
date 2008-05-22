using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.Api
{
    public partial class Default : Incremental.Kick.Web.Controls.KickUIPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.HostProfile.SiteTitle + " API";
            this.Caption = this.Title;
            this.PageName = UrlFactory.PageName.ApiOverview;
            this.DisplayAds = false;
        }
    }
}
