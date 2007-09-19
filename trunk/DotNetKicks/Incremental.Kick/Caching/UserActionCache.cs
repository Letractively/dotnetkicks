using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching {
    public class UserActionCache {
        
        public static UserActionCollection GetLatestUserActions(int hostID) {
            return GetLatestUserActions(hostID, 1, 200, null, null, null, null);
        }

        public static UserActionCollection GetLatestUserActions(int hostID, int pageIndex, int pageSize, int? userID, Nullable<UserAction.ActionType> userActionType, int? storyID, int? chatID) {
            string cacheKey = GetCacheKey(hostID, pageIndex, pageSize, userID, userActionType, storyID, chatID);

            CacheManager<string, UserActionCollection> cache = GetUserActionCache();

            UserActionCollection userActions = cache[cacheKey];
            if (userActions == null) {
                userActions = UserAction.FetchCollection(hostID, pageIndex, pageSize, userID, userActionType, storyID, chatID);
                cache.Insert(cacheKey, userActions, 60, System.Web.Caching.CacheItemPriority.NotRemovable);
            }

            return userActions;
        }


        private static string GetCacheKey(int hostID, int pageIndex, int pageSize, int? userID, Nullable<UserAction.ActionType> userActionType, int? storyID, int? chatID) {
            return String.Format("ShoutsCollection_{0}_{1}_{2}_{3}_{4}_{5}_{6}", hostID, pageIndex, pageSize, userID, userActionType, storyID, chatID);
        }
        private static CacheManager<string, UserActionCollection> GetUserActionCache() {
            return CacheManager<string, UserActionCollection>.GetInstance();
        }
    }
}
