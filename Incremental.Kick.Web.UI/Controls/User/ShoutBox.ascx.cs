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
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.UI.Controls {
    public partial class ShoutBox : Incremental.Kick.Web.Controls.KickUserControl {
        private int? _toUserID;
        private ShoutCollection _shouts = new ShoutCollection();

        public void DataBind(ShoutCollection shouts) {
            _shouts = shouts;
            this.ShoutList.DataBind(_shouts);
        }

        public void DataBind(ShoutCollection shouts, int toUserID) {
            this.DataBind(shouts);
            this._toUserID = toUserID;
        }

        public int MostRecentShoutID {
            get {
                if (this._shouts.Count > 0)
                    return this._shouts[0].ShoutID;
                else
                    return 0;
            }
        }
           
        
        protected void Page_Load(object sender, EventArgs e) {
            this.SaySomethingPanel.Visible = this.KickPage.IsAuthenticated;
        }

        public string JavaScriptChatID {
            get {
                if (this.KickPage.UrlParameters.ChatID.HasValue)
                    return this.KickPage.UrlParameters.ChatID.ToString();
                else
                    return "null";
            }
        }
    }
}