using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using SubSonic;

namespace Incremental.Kick.Caching
{
    class BannedUrlPatternCache
    {
        private static string GetCacheKey(int hostID)
        {
            return string.Format("BannedUrlPatterns{0}", hostID);
        }

        private static CacheManager<string, BannedUrlPatternCollection> GetBannedUrlPatternCache()
        {
            return CacheManager<string, BannedUrlPatternCollection>.GetInstance();
        }

        public static BannedUrlPatternCollection GetBannedUrlPatterns(int hostID)
        {
            CacheManager<string, BannedUrlPatternCollection> cache = GetBannedUrlPatternCache();

            string key = GetCacheKey(hostID);

            if (cache[key] == null)
            {
                Query BannedUrlPatternQuery = BannedUrlPattern.CreateQuery().WHERE(BannedUrlPattern.Columns.HostId, hostID).OR(BannedUrlPattern.Columns.HostId, Comparison.Is, null);

                BannedUrlPatternCollection BannedUrlPatterns = new BannedUrlPatternCollection();
                BannedUrlPatterns.LoadAndCloseReader(BannedUrlPatternQuery.ExecuteReader());

                cache.Insert(key, BannedUrlPatterns, 3600);
            }

            return cache[key];
        }
    }
}
