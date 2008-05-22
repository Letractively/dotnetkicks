using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Caching {
    public class TagCache {
        public static WeightedTagList GetHostTags(int hostID) {
            return GetHostTags(hostID, 100);
        }

        public static WeightedTagList GetHostTags(int hostID, double maximumDaysOld) {
            return GetHostTags(hostID, DateTime.Now.AddDays(-maximumDaysOld), DateTime.Now);
        }

        public static WeightedTagList GetHostTags(int hostID, DateTime createdOnLower, DateTime createdOnUpper) {
            string cacheKey = GetCacheKey("HostTags", hostID, createdOnLower, createdOnUpper);
            CacheManager<string, WeightedTagList> tagCache = GetWeightedTagListCache();

            WeightedTagList tags = tagCache[cacheKey];

            if (tags == null) {
                tags = Tag.FetchTags(hostID, createdOnLower, createdOnUpper).ToWeightedTagList();
                //TODO: GJ: sort by alpha
                tagCache.Insert(cacheKey, tags, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return tags;
        }

        public static WeightedTagList GetTopHostTags(int hostID, int numberOfTags) {
            string cacheKey = String.Format("TopHostTags_{0}_{1}", hostID, numberOfTags);
            CacheManager<string, WeightedTagList> tagCache = GetWeightedTagListCache();

            WeightedTagList tags = tagCache[cacheKey];

            if (tags == null) {
                tags = GetHostTags(hostID);
                tags.Sort(new WeightedTagList.UsageCountComparer());
                tags = tags.GetTopTags(numberOfTags);
                tags.Sort(new WeightedTagList.AlphabeticalComparer());
                tagCache.Insert(cacheKey, tags, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return tags;
        }

        public static WeightedTagList GetUserTags(string userIdentifier) {
            return GetUserTags(UserCache.GetUserID(userIdentifier));
        }

        public static WeightedTagList GetUserHostTags(string userIdentifier, int hostID) {
            return GetUserHostTags(UserCache.GetUserID(userIdentifier), hostID);
        }

        public static WeightedTagList GetUserHostTags(int userID, int hostID) {
            string cacheKey = String.Format("UserHostTags_{0}_{1}", userID, hostID);
            CacheManager<string, WeightedTagList> tagCache = GetWeightedTagListCache();

            WeightedTagList tags = tagCache[cacheKey];
            if (tags == null) {
                tags = Tag.FetchTags(userID, hostID).ToWeightedTagList();
                //TODO: GJ: sort by alpha
                tagCache.Insert(cacheKey, tags, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return tags;
        }


        public static WeightedTagList GetStoryTags(int storyID) {
            string cacheKey = GetCacheKey("StoryTags", storyID);
            CacheManager<string, WeightedTagList> tagCache = GetWeightedTagListCache();

            WeightedTagList tags = tagCache[cacheKey];

            if (tags == null) {
                tags = Tag.FetchStoryTags(storyID).ToWeightedTagList();
                //TODO: GJ: sort by alpha
                tagCache.Insert(cacheKey, tags, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return tags;
        }

        public static int? GetTagID(string tagIdentifier) {
            string cacheKey = GetCacheKey("TagID", tagIdentifier);
            CacheManager<string, int?> tagCache = GetTagIDCache();

            int? tagID = tagCache[cacheKey];

            if (tagID == null) {
                Tag tag = Tag.FetchTagByIdentifier(tagIdentifier);
                if (tag != null) {
                    tagID = tag.TagID;
                    tagCache.Insert(cacheKey, tagID.Value, CacheHelper.CACHE_DURATION_IN_SECONDS);
                }
            }

            return tagID;
        }

        public static WeightedTagList GetUserTags(int userID) {
            string cacheKey = GetCacheKey("UserTags", userID);
            CacheManager<string, WeightedTagList> tagCache = GetWeightedTagListCache();

            WeightedTagList tags = tagCache[cacheKey];

            if (tags == null) {
                tags = Tag.FetchUserTags(userID).ToWeightedTagList();
                //TODO: GJ: sort by alpha
                tagCache.Insert(cacheKey, tags, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return tags;
        }


        private static string GetCacheKey(string prefix, object identifier) {
            return String.Format("{0}_{1}", prefix, identifier);
        }

        private static string GetCacheKey(string prefix, int id, DateTime startDate, DateTime endDate) {
            return String.Format("{0}_{1}_{2}_{3}", prefix, id, CacheHelper.DateTimeToCacheKey(startDate), CacheHelper.DateTimeToCacheKey(endDate));
        }

        private static CacheManager<string, TagCollection> GetTagCollectionCache() {
            return CacheManager<string, TagCollection>.GetInstance();
        }

        private static CacheManager<string, WeightedTagList> GetWeightedTagListCache() {
            return CacheManager<string, WeightedTagList>.GetInstance();
        }

        private static CacheManager<string, int?> GetTagIDCache() {
            return CacheManager<string, int?>.GetInstance();
        }
    }
}
