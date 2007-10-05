using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Helpers {
    public class HostHelper {
        public static string GetHostName(Uri uri) {
           //NOTE: GJ: This needs to be fixed up with a RegEx, there are a number of failing tests to demonstrate how it should work
           //The GetHostName should return the full host minus the 'www.'. This is so www.dotnetkicks.com:80 and dotnetkicks.com:80 will resolve to the same Host row in the db. When I wrote this I just needed to get it working with my site, and obviously hacked this together.

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
            return GetHostName(uri) + ":" + uri.Port;
        }
    }

}
