using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Common.Web.Helpers {
    public class ControlHelper {

        public static string RenderControl(System.Web.UI.Control control) {
            StringBuilder html = new StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(html);
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stringWriter);
            control.RenderControl(htmlWriter);
            return html.ToString();
        }
    }
}