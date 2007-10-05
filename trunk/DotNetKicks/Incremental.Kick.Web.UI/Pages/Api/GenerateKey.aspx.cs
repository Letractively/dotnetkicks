using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.Api
{
    public partial class GenerateKey : Incremental.Kick.Web.Controls.KickUIPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.HostProfile.SiteTitle + " API : Generate Key";
            this.Caption = this.Title;
            this.PageName = UrlFactory.PageName.ApiGenerateKey;
            this.DisplayAds = false;
        }
    }
}
