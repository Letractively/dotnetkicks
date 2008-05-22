using System;
using Incremental.Kick.Dal;
using Incremental.Kick.Dal.Entities.Api;
using System.Collections.Generic;

namespace Incremental.Kick.Caching {
    public class ShoutCache {

        private static int DEFAULT_CACHE_ITEM_SIZE = 100;

        public static ShoutCollection GetLatestShouts(int hostID) {
            return GetLatestShouts(hostID, null, null);
        }

        public static ShoutCollection GetLatestShouts(int hostID, string username) {
            return GetLatestShouts(hostID, username, null);
        }

        public static ShoutCollection GetLatestShouts(int hostID, int chatID) {
            return GetLatestShouts(hostID, null, chatID);
        }

        public static ShoutCollection GetLatestShouts(int hostID, string username, int? chatID) {
            return GetLatestShouts(hostID, username, chatID, 1);
        }

        public static ShoutCollection GetLatestShouts(int hostID, string username, int? chatID, int pageIndex) {
            int? userID;
            if (String.IsNullOrEmpty(username))
                userID = null;
            else
                userID = UserCache.GetUserID(username);

            return GetLatestShouts(hostID, userID, chatID, pageIndex, DEFAULT_CACHE_ITEM_SIZE);
        }

        private static ShoutCollection GetLatestShouts(int hostID, int pageIndex, int pageSize) {
            return GetLatestShouts(hostID, null, null, pageIndex, pageSize);
        }

        private static ShoutCollection GetLatestShouts(int hostID, int? toUserID, int? chatID, int pageIndex, int pageSize) {
            string cacheKey = GetCacheKey(hostID, toUserID, chatID, pageIndex, pageSize);

            CacheManager<string, ShoutCollection> cache = GetShoutCache();

            ShoutCollection shouts = cache[cacheKey];
            if (shouts == null) {
                shouts = Shout.GetPage(hostID, toUserID, chatID, pageIndex, pageSize);
                cache.Insert(cacheKey, shouts, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return shouts;
        
        }

        public static ShoutCollection GetDeltaShouts(int hostID, string username, int? chatID, int lastReceivedShoutID) {
            //TODO: GJ: PERFORMANCE: we should check a token in the cache before retreiving the full list. 
            //                       This would remove the need to retreive a full page of shouts from the cache just to check the newest ID
            ShoutCollection deltaShouts = new ShoutCollection();
            ShoutCollection latestShouts = GetLatestShouts(hostID, username, chatID);

            if (latestShouts.Count > 0 && latestShouts[0].ShoutID > lastReceivedShoutID) {
                foreach (Shout shout in latestShouts) {
                    if (shout.ShoutID > lastReceivedShoutID)
                        deltaShouts.Add(shout);
                }
            }

            return deltaShouts;
        } 

        public static void Remove(int hostID) {
            Remove(hostID, null, null, 1, DEFAULT_CACHE_ITEM_SIZE);
        }

        public static void Remove(int hostID, string username) {
            Remove(hostID, UserCache.GetUserID(username), null, 1, DEFAULT_CACHE_ITEM_SIZE);
        }

        public static void Remove(int hostID, int chatID) {
            Remove(hostID, null, chatID, 1, DEFAULT_CACHE_ITEM_SIZE);
        }

        public static void Remove(int hostID, int? toUserID, int? chatID) {
            Remove(hostID, toUserID, chatID, 1, DEFAULT_CACHE_ITEM_SIZE);
        }

        private static void Remove(int hostID, int pageIndex, int pageSize) {
            Remove(hostID, null, null, pageIndex, pageSize);
        }
        private static void Remove(int hostID, int? toUserID, int? chatID, int pageIndex, int pageSize) {
            GetShoutCache().Remove(GetCacheKey(hostID, toUserID, chatID, pageIndex, pageSize));
        }

        private static string GetCacheKey(int hostID, int pageIndex, int pageSize) {
            return GetCacheKey(hostID, null, null, pageIndex, pageSize);
        }
        private static string GetCacheKey(int hostID, int? toUserID, int? chatID, int pageIndex, int pageSize) {
            return String.Format("ShoutsCollection_{0}_{1}_{2}_{3}_{4}", hostID, toUserID, chatID, pageIndex, pageSize);
        }

        private static CacheManager<string, ShoutCollection> GetShoutCache() {
            return CacheManager<string, ShoutCollection>.GetInstance();
        }
    }
}
