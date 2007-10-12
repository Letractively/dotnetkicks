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
using System.Security;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.UI.Controls {
    public partial class UserAdmin : Incremental.Kick.Web.Controls.KickUserControl {
        private User _user;
        public void DataBind(User user) {
            _user = user;
        }
        
        protected void Page_Load(object sender, EventArgs e) {
            this.Visible = this.KickPage.KickUserProfile.IsModerator;

            this.BanUser.Visible = !this._user.IsBanned;
            this.UnBanUser.Visible = this._user.IsBanned;
        }

        protected void BanUser_Click(object sender, EventArgs e) {
            this.KickPage.DemandModeratorRole();

            this._user.Ban(this.KickPage.KickUserProfile, this.KickPage.HostProfile);
            this.KickPage.Reload();
        }

        protected void UnBanUser_Click(object sender, EventArgs e) {
            this.KickPage.DemandModeratorRole();

            this._user.UnBan(this.KickPage.KickUserProfile, this.KickPage.HostProfile);
            this.KickPage.Reload();
        }
    }
}