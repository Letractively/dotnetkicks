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
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Controls.Admin {
    public partial class Tasks : Incremental.Kick.Web.Controls.KickUserControl {
        protected void Page_Load(object sender, EventArgs e) {
           this.KickPage.DemandAdministratorRole();
        }

        protected void RunStoryPublisher_Click(object sender, EventArgs e) {
            StoryBR.PublishStoryProcess();
        }
    }
}