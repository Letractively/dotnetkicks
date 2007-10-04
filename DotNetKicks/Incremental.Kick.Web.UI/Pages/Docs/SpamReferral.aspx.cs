using System;
using Incremental.Kick.Web.Controls;

namespace Incremental.Kick.Web.UI.Pages.Docs
{
    public partial class SpamReferral : KickUIPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = HostProfile.SiteTitle + " - access blocked";
        }
    }
}
