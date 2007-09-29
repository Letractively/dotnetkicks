using System.Web.UI;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class UserList : KickWebControl {
        private UserCollection _users;

        public UserList() { }
        public UserList(UserCollection users) {
            DataBind(users);
        }

        public void DataBind(UserCollection users) {
            _users = users;
        }

        protected override void Render(HtmlTextWriter writer) {
           writer.Write(@"<div class=""Users"">");

            if (_users.Count == 0) {
                writer.Write("No users");
            } else {
                UserLink userLink = new UserLink();
                int totalUserCount = _users.Count;
                for (int i = 0; i < totalUserCount; i++)
                {
                    userLink.DataBind(_users[i]);
                    userLink.RenderControl(writer);
                    if(i < totalUserCount - 1)
                        writer.Write(" - ");
                }
            }

            writer.Write("</div>");
        }
    }
}
