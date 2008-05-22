using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// Kick UserControl
    /// The base class for most user controls of the project
    /// </summary>
    public class KickUserControl : System.Web.UI.UserControl
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
