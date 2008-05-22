using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Helpers {
    public class HostHelper {
        public static string GetHostName(Uri uri) {
            //if (uri.Host.Substring(0, 4) == "www.")
            //    return uri.Host.Substring(4, uri.Host.Length - 4);
            //else
            //    return uri.Host;

           //NOTE: GJ: remove any subdomains
            string[] segments = uri.Host.Split(".".ToCharArray());
            if (segments.Length >= 2) {
                //System.Diagnostics.Trace.WriteLine(segments[segments.Length - 2] + "." + segments[segments.Length - 1]);

                return segments[segments.Length - 2] + "." + segments[segments.Length - 1];
            } else {
                //System.Diagnostics.Trace.WriteLine("segments.Length:" + segments.Length);

                return uri.Host;
            }
        }

        public static string GetHostAndPort(Uri uri) {
            //System.Diagnostics.Trace.WriteLine(GetHostName(uri) + ":" + uri.Port);

            
            return GetHostName(uri) + ":" + uri.Port;
        }
    }

}
