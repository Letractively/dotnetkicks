using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching
{
    public class TagCache
    {
        public static TagCollection GetHostTags(int hostID)
        {
            return GetHostTags(hostID, 100);
        }

        public static TagCollection GetHostTags(int hostID, double maximumDaysOld)
        {
            return GetHostTags(hostID, DateTime.Now.AddDays(-maximumDaysOld), DateTime.Now);
        }

        public static TagCollection GetHostTags(int hostID, DateTime createdOnLower, DateTime createdOnUpper)
        {
            string cacheKey = GetCacheKey("HostTags", hostID, createdOnLower, createdOnUpper);
            CacheManager<string, TagCollection> tagCache = GetTagCollectionCache();

            TagCollection tags = tagCache[cacheKey];

            if (tags == null)
            {
                tags = Tag.FetchTags(hostID, createdOnLower, createdOnUpper);
                //TODO: GJ: sort by alpha
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                tagCache.Insert(cacheKey, tags, 500); //TODO: config
            }

            return tags;
        }

        public static TagCollection GetTopHostTags(int hostID, int numberOfTags)
        {
            string cacheKey = String.Format("TopHostTags_{0}_{1}", hostID, numberOfTags);
            CacheManager<string, TagCollection> tagCache = GetTagCollectionCache();

            TagCollection tags = tagCache[cacheKey];

            if (tags == null)
            {
                tags = GetHostTags(hostID);
                //TODO: GJ: sort by usagecount, get top x, then sort by alpha
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                tagCache.Insert(cacheKey, tags, 500); //TODO: config
            }

            return tags;
        }

        public static TagCollection GetUserTags(string userIdentifier)
        {
            return GetUserTags(UserCache.GetUserID(userIdentifier));
        }

        public static TagCollection GetUserHostTags(string userIdentifier, int hostID)
        {
            return GetUserHostTags(UserCache.GetUserID(userIdentifier), hostID);
        }

        public static TagCollection GetUserHostTags(int userID, int hostID)
        {
            string cacheKey = String.Format("UserHostTags_{0}_{1}", userID, hostID);
            CacheManager<string, TagCollection> tagCache = GetTagCollectionCache();

            TagCollection tags = tagCache[cacheKey];
            if (tags == null)
            {
                tags = Tag.FetchTags(userID, hostID);
                //TODO: GJ: sort by alpha
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                tagCache.Insert(cacheKey, tags, 500); //TODO: config
            }

            return tags;
        }


        public static TagCollection GetStoryTags(int storyID)
        {
            string cacheKey = GetCacheKey("StoryTags", storyID);
            CacheManager<string, TagCollection> tagCache = GetTagCollectionCache();

            TagCollection tags = tagCache[cacheKey];

            if (tags == null)
            {
                tags = Tag.FetchStoryTags(storyID);
                //TODO: GJ: sort by alpha
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                tagCache.Insert(cacheKey, tags, 500); //TODO: config
            }

            return tags;
        }

        public static int GetTagID(string tagIdentifier)
        {
            string cacheKey = GetCacheKey("TagID", tagIdentifier);
            CacheManager<string, int?> tagCache = GetTagIDCache();

            int? tagID = tagCache[cacheKey];

            if (tagID == null)
            {
                tagID = Tag.FetchTagByIdentifier(tagIdentifier).TagID;
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                tagCache.Insert(cacheKey, tagID.Value, 500); //TODO: config
            }

            return tagID.Value;
        }

        public static TagCollection GetUserTags(int userID)
        {
            string cacheKey = GetCacheKey("UserTags", userID);
            CacheManager<string, TagCollection> tagCache = GetTagCollectionCache();

            TagCollection tags = tagCache[cacheKey];

            if (tags == null)
            {
                tags = Tag.FetchUserTags(userID);
                //TODO: GJ: sort by alpha
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                tagCache.Insert(cacheKey, tags, 500); //TODO: config
            }

            return tags;
        }


        private static string GetCacheKey(string prefix, object identifier)
        {
            return String.Format("{0}_{1}", prefix, identifier);
        }

        private static string GetCacheKey(string prefix, int id, DateTime startDate, DateTime endDate)
        {
            return String.Format("{0}_{1}_{2}_{3}", prefix, id, CacheHelper.DateTimeToCacheKey(startDate), CacheHelper.DateTimeToCacheKey(endDate));
        }

        private static CacheManager<string, TagCollection> GetTagCollectionCache()
        {
            return CacheManager<string, TagCollection>.GetInstance();
        }

        private static CacheManager<string, int?> GetTagIDCache()
        {
            return CacheManager<string, int?>.GetInstance();
        }
    }
}
