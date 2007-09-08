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

            writer.Write(@"<div class=""UsersWhoKicked"">");

            if (_users.Count == 0) {
                writer.Write("Hmm...no users have kicked this story yet? Not possible. Must be a bug, sorry.");
            } else {
                UserLink userLink = new UserLink();
                foreach (User user in _users) {
                    userLink.DataBind(user);
                    userLink.RenderControl(writer);
                    writer.Write(" - ");
                }
            }

            writer.Write("</div><br/>");
        }
    }
}
