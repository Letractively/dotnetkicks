using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls {
    public class KickUserControl : System.Web.UI.UserControl {
        public KickUIPage KickPage {
            get { return (KickUIPage)base.Page; }
        }
    }
}
