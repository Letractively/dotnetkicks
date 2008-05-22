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

namespace Incremental.Kick.Web.UI.Scripts {
    public partial class Constants : System.Web.UI.Page {
        protected string RootUrl {
            get { return this.ResolveUrl("~"); }
        }

        protected string IsUserAuthenticated {
            get { return this.User.Identity.IsAuthenticated.ToString().ToLower(); }
        }
    }
}