using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls {
    public class KickWebControl : System.Web.UI.WebControls.WebControl {
        public KickPage KickPage {
            get { return (KickPage)base.Page; }
        }
    }
}
