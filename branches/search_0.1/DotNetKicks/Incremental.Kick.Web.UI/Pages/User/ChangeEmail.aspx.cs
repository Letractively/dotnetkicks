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
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.User
{
	public partial class ChangeEmail : Incremental.Kick.Web.Controls.KickUIPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.IsMemberPage = true;
            this.Caption = "Change your email";
            this.Title = this.HostProfile.SiteTitle + " - " + this.Caption;
            this.PageName = UrlFactory.PageName.ChangeEmail;
            this.DisplayAds = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
