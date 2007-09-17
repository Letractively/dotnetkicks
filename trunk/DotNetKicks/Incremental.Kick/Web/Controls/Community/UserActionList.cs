using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using SubSonic.Sugar;
using System.Web;
using Incremental.Kick.Caching;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class UserActionList : KickWebControl {
        private UserActionCollection _userActions;
        private bool _renderContainer = false;
        public bool RenderContainer {
            get { return _renderContainer; }
            set { _renderContainer = value; }
        }

        public UserActionList() { }
        public UserActionList(UserActionCollection userActions) {
            this.DataBind(userActions);
        }

        public void DataBind(UserActionCollection userActions) {
            this._userActions = userActions;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            if (_renderContainer)
                writer.WriteLine(@"<div id=""userActionList"">");

            if (_userActions.Count == 0)
                writer.Write("<em>No actions</em>");

            foreach (UserAction userAction in _userActions) {
                if (userAction.UserID != null) { //TODO: GJ: support no user actions
                    User user = UserCache.GetUser(userAction.UserID.Value);
                    if (!user.IsBanned) {
                        writer.WriteLine(@"<div class=""userAction userAction{0}"">", userAction.UserActionType.ToString());
                        new UserLink(user).RenderControl(writer);
                        writer.WriteLine(@" <span class=""spyItemMessage"">{0}</span>:", userAction.Message);
                        writer.WriteLine(@" <span style=""font-size:smaller"">({0})</span>:", Dates.ReadableDiff(userAction.CreatedOn, DateTime.Now));
                        writer.WriteLine("</div>");
                    }
                }
            }

            if (_renderContainer)
                writer.WriteLine(@"</div>");
        }
    }
}
