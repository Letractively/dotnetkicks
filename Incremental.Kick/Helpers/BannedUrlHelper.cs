using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using System.Text.RegularExpressions;

namespace Incremental.Kick.Helpers
{
    public static class BannedUrlHelper
    {
        static BannedUrlHelper() { }

        /// <summary>
        /// Determines whether a url matches a banned url.
        /// </summary>
        /// <param name="url">The URL to check</param>
        /// <param name="hostId">The host id.</param>
        /// <returns>
        /// 	<c>true</c> if the url is banninated; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUrlBanninated(string url, int hostId)
        {
            BannedUrlPatternCollection coll = BannedUrlPatternCache.GetBannedUrlPatterns(hostId);
            foreach (BannedUrlPattern p in coll)
            {
                if (Regex.IsMatch(url, p.BannedUrlRegex)) return true;
            }
            return false;
        }
    }
}
