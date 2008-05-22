using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Incremental.Kick.Search;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.UI.Controls.Admin
{
    public partial class Search : Incremental.Kick.Web.Controls.KickUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }


        
        private void LoadData()
        {
            SearchSettings searchSettings = new SearchSettings();
            lblBaseDirectory.Text = searchSettings.SearchBaseDirectory;
            lblRecrawlRate.Text = searchSettings.SearchUpdateInterval.ToString();
            lblLastCrawl.Text = searchSettings.SearchLastCrawl.ToString("F");

            Dictionary<string, Host> hosts = HostCache.Hosts;
            rptDeleteIndex.DataSource = hosts;
            rptDeleteIndex.DataBind();
        }

        protected void btnDeleteIndex_Click(object sender, EventArgs e)
        {
            //this method wil only work if the index process is not currently
            //running
            Button button = (Button)sender;
            string cmdArg = button.CommandArgument;

            SearchQuery sq = new SearchQuery();
            if (!sq.DeleteIndex(Int32.Parse(cmdArg)))
                lblDeleteOutput.Text = "Index not deleted, the index is being crawled. Try again in a minute";
            else
                lblDeleteOutput.Text = "Index has been deleted";
        }
    }
}