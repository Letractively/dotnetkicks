using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// Kick MasterPage
    /// </summary>
    public class KickMasterPage : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Gets the kick page.
        /// </summary>
        /// <value>The kick page.</value>
        public KickUIPage KickPage
        {
            get { return (KickUIPage)base.Page; }
        }
    }
}
