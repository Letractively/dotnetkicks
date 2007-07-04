using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls {
    public class KickMasterPage : System.Web.UI.MasterPage {
        public KickUIPage KickPage {
            get { return (KickUIPage)base.Page; }
        }
    }
}
