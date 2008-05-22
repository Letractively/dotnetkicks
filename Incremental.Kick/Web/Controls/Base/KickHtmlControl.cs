using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls {
    public class KickHtmlControl : System.Web.UI.HtmlControls.HtmlControl {
        public KickPage KickPage {
            get { return (KickPage)base.Page; }
        }

        public KickUIPage KickUIPage {
            get { return (KickUIPage)base.Page; }
        }
    }
}
