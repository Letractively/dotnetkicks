using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Helpers {
    public class DateHelper {

        public static string ConverDateToTimeAgo(DateTime dateTime) {

            TimeSpan timeSpan = DateTime.Now - dateTime;

            StringBuilder descriptiveDate = new StringBuilder();

            if (timeSpan.Days > 0) {
                descriptiveDate.Append(timeSpan.Days + " day");
                if (timeSpan.Days != 1)
                    descriptiveDate.Append("s");
            }

            if ((descriptiveDate.Length == 0) && (timeSpan.Hours > 0)) {
                descriptiveDate.Append(timeSpan.Hours + " hour");
                if (timeSpan.Hours != 1)
                    descriptiveDate.Append("s");
            }

            if (descriptiveDate.Length == 0) {
                descriptiveDate.Append(timeSpan.Minutes + " minute");
                if (timeSpan.Minutes != 1)
                    descriptiveDate.Append("s");
            }

            descriptiveDate.Append(" ago");

            return descriptiveDate.ToString();
        }

    }
}
