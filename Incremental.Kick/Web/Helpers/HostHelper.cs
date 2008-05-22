using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Helpers {
    public class HostHelper {
        public static string GetHostName(Uri uri) {
            if(uri.Host.StartsWith("www."))
                return uri.Host.Substring(4, uri.Host.Length-4);
            else
                return uri.Host;
        }

        public static string GetHostAndPort(Uri uri) {
            return GetHostName(uri) + ":" + uri.Port;
        }
    }
}
