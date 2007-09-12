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

namespace Incremental.Kick.Web.UI.Templates.Default {
    public partial class TopMenu : Incremental.Kick.Web.Controls.KickUserControl {
        protected string BlogLink {
            get {
                if (!String.IsNullOrEmpty(this.KickPage.HostProfile.BlogUrl))
                    return String.Format(@"<a href=""{0}"" target=""_blank"">blog</a>", this.KickPage.HostProfile.BlogUrl);
                else
                    return "";
            }
        }
    }
}