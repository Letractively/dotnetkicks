using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// Kick WebControl
    /// The base class for most webcontrols of this project
    /// </summary>
    public class KickWebControl : System.Web.UI.WebControls.WebControl
    {
        /// <summary>
        /// Gets the kick page.
        /// </summary>
        /// <value>The kick page.</value>
        public KickPage KickPage
        {
            get { return (KickPage)base.Page; }
        }
    }
}
