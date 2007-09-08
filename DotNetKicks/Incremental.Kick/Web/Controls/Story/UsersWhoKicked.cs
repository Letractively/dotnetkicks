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

namespace Incremental.Kick.Web.Controls
{
    public class UsersWhoKicked : KickWebControl
    {

        private UserCollection _users;

        public void DataBind(UserCollection users)
        {
            this._users = users;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<br /><div class=""PageSmallCaption"">Users who kicked this story:</div>");

            sb.Append(@"<div class=""UsersWhoKicked"">");

            if(_users.Count == 0)
            {
                sb.Append("Hmm...no users have kicked this story yet? Not possible. Must be a bug, sorry.");
            }
            else
            {
                int count = _users.Count;

                for (int i = 0; i < count; i++)
                {
                    string anchor = "<a href=\"{0}\" title=\"Views {1}\">{1}</a>";
                    string username = _users[i].Username;
                    string url = UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, username); 
                    sb.Append(String.Format(anchor,url,username));

                    if (i + 1 != count) sb.Append(", ");
                }
               
            }

            sb.Append("</div><br/>");
            writer.WriteLine(sb.ToString());

        }
    }
}
