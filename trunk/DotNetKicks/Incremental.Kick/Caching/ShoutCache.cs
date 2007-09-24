using System;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching {
    public class ShoutCache {

        public static ShoutCollection GetLatestShouts(int hostID) {
            return GetLatestShouts(hostID, null, 1, 100);
        }

        public static ShoutCollection GetLatestShouts(int hostID, string username) {
            return GetLatestShouts(hostID, UserCache.GetUserID(username), 1, 50);
        }

        private static ShoutCollection GetLatestShouts(int hostID, int pageIndex, int pageSize) {
            return GetLatestShouts(hostID, null, pageIndex, pageSize);
        }

        private static ShoutCollection GetLatestShouts(int hostID, int? toUserID, int pageIndex, int pageSize) {
            string cacheKey = GetCacheKey(hostID, toUserID, pageIndex, pageSize);

            CacheManager<string, ShoutCollection> cache = GetShoutCache();

            ShoutCollection shouts = cache[cacheKey];
            if (shouts == null) {
                shouts = Shout.GetPage(hostID, toUserID, pageIndex, pageSize);
                cache.Insert(cacheKey, shouts, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return shouts;
        }

        public static void Remove(int hostID) {
            Remove(hostID, null, 1, 50);
        }

        public static void Remove(int hostID, string username) {
            Remove(hostID, UserCache.GetUserID(username), 1, 50);
        }

        private static void Remove(int hostID, int pageIndex, int pageSize) {
            Remove(hostID, null, pageIndex, pageSize);
        }
        private static void Remove(int hostID, int? toUserID, int pageIndex, int pageSize) {
            GetShoutCache().Remove(GetCacheKey(hostID, toUserID, pageIndex, pageSize));
        }

        private static string GetCacheKey(int hostID, int pageIndex, int pageSize) {
            return GetCacheKey(hostID, null, pageIndex, pageSize);
        }
        private static string GetCacheKey(int hostID, int? toUserID, int pageIndex, int pageSize) {
            return String.Format("ShoutsCollection_{0}_{1}_{2}_{3}", hostID, toUserID, pageIndex, pageSize);
        }

        private static CacheManager<string, ShoutCollection> GetShoutCache() {
            return CacheManager<string, ShoutCollection>.GetInstance();
        }
    }
}
