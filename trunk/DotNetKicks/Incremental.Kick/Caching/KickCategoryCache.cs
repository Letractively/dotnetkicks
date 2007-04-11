using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching
{
    //TODO: implement category dictionary?
    public class KickCategoryCache
    {
        public static short GetCategoryID(string categoryIdentifier, int hostID)
        {
            foreach (KickCategory category in GetCategories(hostID))
            {
                if (category.CategoryIdentifier == categoryIdentifier)
                    return category.CategoryID;
            }

            throw new ApplicationException("Invalid CategoryIdentifier:" + categoryIdentifier);
        }

        public static string GetCategoryIdentifier(short categoryID, int hostID)
        {
            foreach (KickCategory category in GetCategories(hostID))
            {
                if (category.CategoryID == categoryID)
                    return category.CategoryIdentifier;
            }

            throw new ApplicationException("Invalid CategoryID:" + categoryID);
        }

        public static string GetCategoryName(short categoryID, int hostID)
        {
            foreach (KickCategory category in GetCategories(hostID))
            {
                if (category.CategoryID == categoryID)
                    return category.Name;
            }

            throw new ApplicationException("Invalid CategoryID:" + categoryID);
        }

        public static KickCategoryCollection GetCategories(int hostID)
        {
            CacheManager<string, KickCategoryCollection> categoryCache = GetCache();
            string cacheKey = String.Format("KickCategories_{0}", hostID);
            KickCategoryCollection categories = categoryCache[cacheKey];

            if (categories == null)
            {
                categories = new KickCategoryCollection();
                categories.LoadAndCloseReader(KickCategory.FetchByParameter(KickCategory.Columns.HostID, hostID));
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                categoryCache.Insert(cacheKey, categories, 500); //TODO: GJ: cache duration from config
            }

            return categories;
        }

        private static CacheManager<string, KickCategoryCollection> GetCache()
        {
            return CacheManager<string, KickCategoryCollection>.GetInstance();
        }
    }
}

