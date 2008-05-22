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

namespace Incremental.Kick.Web.UI.Pages.Story
{
    public partial class Zeitgeist :  Incremental.Kick.Web.Controls.KickUIPage 
    {
        protected Zeitgeist()
        {
            //this.IsCachedPage = true;
            this.DisplayAds = false; //TODO: GJ: set to true and watch the millions pour in!!!
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Title = this.HostProfile.SiteTitle + " - " + this.HostProfile.TagLine + ".";
            this.Caption = "Zeitgeist";
            this.PageName = UrlFactory.PageName.Zeitgeist;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ZeitgeistList.DataBind(this.HostProfile.HostID, null, null);
            this.ZeitgeistList.DataBind(this.HostProfile.HostID, this.UrlParameters.Year, this.UrlParameters.Month, this.UrlParameters.Day);
        }
    }
}
