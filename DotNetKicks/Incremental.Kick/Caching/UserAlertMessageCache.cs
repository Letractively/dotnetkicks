using System;
using System.Collections.Generic;
using System.Text;

using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching
{
    public class UserAlertMessageCache
    {
        public static UserAlertMessageViewCollection GetUserAlerts(int userId)
        {
            string key = GetCacheKey(userId);

            CacheManager<string, UserAlertMessageViewCollection> cache = GetUserAlertMessageCache();

            UserAlertMessageViewCollection alerts = cache[key];

            if (alerts == null && userId != 0)
            {
                User user = User.FetchByID(userId);
                alerts = user.AlertMessages();
                cache.Insert(key, alerts, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return alerts;
        }           

        public static void RemoveUser(int userId)
        {
            GetUserAlertMessageCache().Remove(GetCacheKey(userId));
        }

        private static string GetCacheKey(int userId)
        {
            return String.Format("UserAlertMessage_{0}", userId);
        }

        private static CacheManager<string, UserAlertMessageViewCollection> GetUserAlertMessageCache()
        {
            return CacheManager<string, UserAlertMessageViewCollection>.GetInstance();
        }
    }
}
