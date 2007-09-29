using System;

namespace Incremental.Kick.Web.UI.Controls.Admin {
    public partial class AdminMenu : Web.Controls.KickUserControl {
        protected void Page_Load(object sender, EventArgs e) {
            KickPage.DemandAdministratorRole();
        }
    }
}