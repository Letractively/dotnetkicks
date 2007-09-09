using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;
using Incremental.Kick.Helpers;
using Incremental.Kick.Dal.Entities;
using System.Web;

namespace Incremental.Kick.Web.Controls {
    public class UsersWhoKicked : KickWebControl {

        private UserCollection _users;

        public void DataBind(UserCollection users) {
            this._users = users;
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.Write(@"<br /><div class=""PageSmallCaption"">Users who kicked this story:</div>");
            new UserList(_users).RenderControl(writer);
        }
    }
}
