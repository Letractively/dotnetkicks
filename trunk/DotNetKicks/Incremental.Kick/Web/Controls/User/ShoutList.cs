using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using SubSonic.Sugar;
using System.Web;

namespace Incremental.Kick.Web.Controls {
    public class ShoutList : KickWebControl {
        private ShoutCollection _shouts;
        private bool _renderContainer = false;
        public bool RenderContainer {
            get { return _renderContainer; }
            set { _renderContainer = value; }
        }

        private bool _showTime = true;
        public bool ShowTime {
            get { return _showTime; }
            set { _showTime = value; }
        }

        public ShoutList() { }
        public ShoutList(ShoutCollection shouts) {
            this.DataBind(shouts);
        }

        public void DataBind(ShoutCollection shouts) {
            this._shouts = shouts;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            if (_renderContainer)
                writer.WriteLine(@"<div id=""shoutList"">");

            for (int i = 0; i < this._shouts.Count; i++) {
                Shout shout = this._shouts[i];
                if (shout.IsSpam)
                    shout.Message = "<em>[shout removed]</em>";

                writer.WriteLine(@"<div class=""shout"">");
                new UserLink(shout.FromUserID).RenderControl(writer);
                writer.WriteLine(" said ");
                if(_showTime)
                    writer.WriteLine(@"<span style=""font-size:smaller"">({0})</span>:", Dates.ReadableDiff(shout.CreatedOn, DateTime.Now));
                
                writer.WriteLine(@"<div class=""shoutMessage"">{0}</div>", shout.Message);
                writer.WriteLine("</div>");
            }

            if (_renderContainer)
                writer.WriteLine(@"</div>");
        }
    }
}
