using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal
{
    public partial class UserAlertMessageViewCollection
    {
        public IList<string> DisplayAlertMessages()
        {
            IList<string> alerts = new List<string>();

            this.ForEach(delegate (UserAlertMessageView uam){
                if (uam.AlertCount > 1)
                {
                    alerts.Add(uam.MultipleAlertText.Replace("[count]", uam.AlertCount.ToString()));                
                }
                else
                {
                    alerts.Add(uam.SingleAlertText.Replace("[count]", uam.AlertCount.ToString()));
                }
            });

            return alerts;
        }
    }
}
