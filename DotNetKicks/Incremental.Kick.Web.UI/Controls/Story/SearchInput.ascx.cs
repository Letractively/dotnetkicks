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

namespace Incremental.Kick.Web.UI.Controls.Story
{
    public partial class SearchInput : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearchTerm.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnSearch.UniqueID + "').click();return false;}} else {return true}; ");

            chkUserSearch.Visible = Page.User.Identity.IsAuthenticated;

            if (!IsPostBack)
            {
                string query = Request["q"];
                if (!string.IsNullOrEmpty(query))
                {
                    txtSearchTerm.Text = query;
                }

                bool isUserSearch = false;

                string userSearch = Request["user"];
                bool.TryParse(userSearch, out isUserSearch);
                chkUserSearch.Checked = isUserSearch;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearchTerm.Text;
            if (!string.IsNullOrEmpty(query))
            {
                Response.Redirect(string.Format("~/search?q={0}&user={1}&page=1", Server.UrlEncode(query), chkUserSearch.Checked));
            }
        }
    }
}