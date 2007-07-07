using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Caching {
    public class CacheHelper {
        public static string DateTimeToCacheKey(DateTime date) {
            return date.Hour.ToString() + "_" + date.Day.ToString() + "_" + date.Month.ToString() + "_" + date.Year.ToString();
        }

        public const int CACHE_DURATION_IN_SECONDS = 300; //TODO: GJ: add fine grained cache configuration per host
    }
}
