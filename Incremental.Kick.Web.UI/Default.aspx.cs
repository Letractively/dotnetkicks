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

namespace Incremental.Kick.Web.UI {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            Server.Transfer("~/Pages/Home.aspx"); //TEMP: only for dev environment
        }
    }
}
