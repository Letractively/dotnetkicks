using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching {
    //TODO: implement category dictionary?
    public class CategoryCache {
        public static Category GetCategory(string categoryIdentifier, int hostID) {
            foreach (Category category in GetCategories(hostID)) {
                if (category.CategoryIdentifier == categoryIdentifier)
                    return category;
            }

            return Category.UnknownCategory;
        }

        public static Category GetCategory(short categoryID, int hostID) {
            foreach (Category category in GetCategories(hostID)) {
                if (category.CategoryID == categoryID)
                    return category;
            }

            return Category.UnknownCategory;
        }

        public static Category GetCategoryByIdentifier(string categoryIdentifier, int hostID) {
            foreach (Category category in GetCategories(hostID)) {
                if (category.CategoryIdentifier == categoryIdentifier)
                    return category;
            }

            return Category.UnknownCategory;
        }



        public static CategoryCollection GetCategories(int hostID) {
            CacheManager<string, CategoryCollection> categoryCache = GetCache();
            string cacheKey = String.Format("KickCategories_{0}", hostID);
            CategoryCollection categories = categoryCache[cacheKey];

            if (categories == null) {
                categories = new CategoryCollection();
                SubSonic.OrderBy orderBy = SubSonic.OrderBy.Asc(Category.Columns.Name);
                categories.LoadAndCloseReader(Category.FetchByParameter(Category.Columns.HostID, hostID, orderBy));
                categoryCache.Insert(cacheKey, categories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return categories;
        }

        private static CacheManager<string, CategoryCollection> GetCache() {
            return CacheManager<string, CategoryCollection>.GetInstance();
        }
    }
}

