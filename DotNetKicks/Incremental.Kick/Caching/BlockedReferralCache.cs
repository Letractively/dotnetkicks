using System;
using System.Data;
using Incremental.Kick.Dal;
using SubSonic;

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

            if (cache[key] == null)
            {
                Query blockedReferralQuery = BlockedReferral.CreateQuery().WHERE(BlockedReferral.Columns.HostID, hostID).OR(BlockedReferral.Columns.HostID, Comparison.Is, null);

                BlockedReferralCollection blockedReferrals = new BlockedReferralCollection();
                blockedReferrals.LoadAndCloseReader(blockedReferralQuery.ExecuteReader());

                cache.Insert(key, blockedReferrals, 3600);
            }

            return cache[key];
        }
    }
}
