using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using SubSonic.Sugar;
using System.Web;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls {
    public class SpyItemList : KickWebControl {
        private Spy _spy;
        private bool _renderContainer = false;
        public bool RenderContainer {
            get { return _renderContainer; }
            set { _renderContainer = value; }
        }

        public SpyItemList() { }
        public SpyItemList(Spy spy) {
            this.DataBind(spy);
        }

        public void DataBind(Spy spy) {
            this._spy = spy;
        }
        
        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            if (_renderContainer)
                writer.WriteLine(@"<div id=""spyItemList"">");

            foreach (SpyItem item in this._spy.AllItems) {
                User user = UserCache.GetUser(item.UserID);
                if (!user.IsBanned) {
                    writer.WriteLine(@"<div class=""spyItem"">");
                    new UserLink(item.UserID).RenderControl(writer);
                    writer.WriteLine(@" <span class=""spyItemMessage"">{0}</span>:", item.Message);
                    writer.WriteLine(@" <span style=""font-size:smaller"">({0})</span>:", Dates.ReadableDiff(item.CreatedOn, DateTime.Now));
                    writer.WriteLine("</div>");
                }
            }
            
            if (_renderContainer)
                writer.WriteLine(@"</div>");
        }
    }
}
