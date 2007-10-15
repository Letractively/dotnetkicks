using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching
{
    public class BlockedReferralCache
    {
        private static string GetCacheKey(int hostID)
        {
            return string.Format("BlockedReferrals_{0}", hostID);
        }

        private static CacheManager<string, BlockedReferralCollection> GetBlockedReferralCache()
        {
            return CacheManager<string, BlockedReferralCollection>.GetInstance();
        }

        public static BlockedReferralCollection GetBlockedReferrals(int hostID)
        {
            CacheManager<string, BlockedReferralCollection> cache = GetBlockedReferralCache();

            string key = GetCacheKey(hostID);

            if(cache[key] == null)
                cache.Insert(key, new BlockedReferralCollection().Load(), 3600);

            return cache[key];
        }
    }
}
