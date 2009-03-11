using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// Renders an alert bar to the user
    /// </summary>
    public class UserAlerts : KickWebControl
    {
        IList<string> alertMessages;

        public UserAlerts()
        {
            alertMessages = new List<string>();
        }

        public void AddAlertMessage(string alertMessage)
        {
            alertMessages.Add(alertMessage);
        }

        public void AddAlertMessage(IList<string> alertMessages)
        {
            if (alertMessages != null)
            {
                foreach (string alertMessage in alertMessages)
                {
                    this.alertMessages.Add(alertMessage);
                }
            }
        }


        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (alertMessages.Count == 0)
                return;

            writer.Write("<div class=\"WebSiteAlert flash flash-information\">");
            writer.Write("<div class=\"flashLeft\"><ul>");

            foreach (string alert in alertMessages)
            {
                writer.Write("<li>{0}</li>", alert);
            }

            writer.Write("</ul></div>");
            writer.Write("<div class=\"flashRight\"><a href=\"#\" id=\"alertClose\" title=\"Dismiss this alert\">Dismiss</a>");
            writer.Write("</div>");
            writer.Write("<div style=\"clear:both;\"></div></div>");
        }
    }
}
