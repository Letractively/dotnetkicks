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

namespace Incremental.Kick.Web.UI.Templates.NewDefault
{
    public partial class MasterPage : Incremental.Kick.Web.Controls.KickMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.hypSiteTitle.NavigateUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Home);
            this.hypSiteTitle.Text = this.KickPage.HostProfile.SiteTitle;
            this.litSiteTagLine.Text = this.KickPage.HostProfile.TagLine;
        }

        private string BuildHyperlink(string href, string text)
        {
            return string.Concat("<a href=\"", href, "\">", text, "</a>");
        }
        protected string BlogLink
        {
            get
            {
                if (!String.IsNullOrEmpty(this.KickPage.HostProfile.BlogUrl))
                    return String.Format(@"<a href=""{0}"" target=""_blank"">blog</a>", this.KickPage.HostProfile.BlogUrl);
                else
                    return "";
            }

        }
    }
}