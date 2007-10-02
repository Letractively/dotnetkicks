using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.Caching {
    public class StoryCache {

        public static void RemoveStory(int storyID, string storyIdentifier) {
            GetStoryCache().Remove(GetStoryCacheKey(storyIdentifier));
            GetCommentCollectionCache().Remove(GetCommentCacheKey(storyID));
        }

        public static Story GetStory(string storyIdentifier, int hostID) {
            string cacheKey = GetStoryCacheKey(storyIdentifier);
            CacheManager<string, Story> storyCache = GetStoryCache();

            Story story = storyCache[cacheKey];

            if (story == null) {
                story = Story.FetchStoryByIdentifier(storyIdentifier);
                if (story != null)
                    storyCache.Insert(cacheKey, story, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            if (hostID != story.HostID)
                throw new ArgumentException("The story does not belong to the host");

            return story;
        }

        private static string GetStoryCacheKey(string storyIdentifier) {
            return String.Format("Story_{0}", storyIdentifier); ;
        }

        public static CommentCollection GetComments(int storyID) {
            string cacheKey = GetCommentCacheKey(storyID);
            CacheManager<string, CommentCollection> commentCache = GetCommentCollectionCache();

            CommentCollection comments = commentCache[cacheKey];

            if (comments == null) {
                comments = Comment.FetchCommentsByStoryID(storyID);
                commentCache.Insert(cacheKey, comments, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return comments;
        }

        private static string GetCommentCacheKey(int storyID) {
            return String.Format("CommentCollection_{0}", storyID);
        }


        public static StoryCollection GetAllStories(bool isPublished, int hostID, int pageNumber, int pageSize) {
            pageSize = TrimPageSize(pageSize);
            string cacheKey = String.Format("StoryCollection_{0}_{1}_{2}_{3}", isPublished, hostID, pageNumber, pageSize);

            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();

            StoryCollection stories = storyCache[cacheKey];
            if (stories == null) {
                stories = Story.GetStoriesByIsPublishedAndHostID(isPublished, hostID, pageNumber, pageSize);
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }

        public static StoryCollection GetPopularStories(int hostID, bool isPublished, StoryListSortBy sortBy, int pageNumber, int pageSize) {
            pageSize = TrimPageSize(pageSize);
            string cacheKey = String.Format("StoryCollection_{0}_{1}_{2}_{3}_{4}", hostID, isPublished, sortBy, pageNumber, pageSize);

            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();

            StoryCollection stories = storyCache[cacheKey];
            if (stories == null) {
                stories = Story.GetPopularStories(hostID, isPublished, sortBy, pageNumber, pageSize);
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }


            return stories;
        }

        public static int TrimPageSize(int pageSize) {
            if (pageSize > 200)
                pageSize = 200;
            return pageSize;
        }

        public static int GetPopularStoriesCount(int hostID, bool isPublished, StoryListSortBy sortBy) {
            string cacheKey = String.Format("Kick_PopularStoryCount_{0}_{1}_{2}", hostID, isPublished, sortBy);
            CacheManager<string, int?> countCache = GetCountCache();

            int? count = countCache[cacheKey];
            if (count == null) {
                count = Story.GetPopularStoriesCount(hostID, isPublished, sortBy);
                countCache.Insert(cacheKey, count, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        public static StoryCollection GetUserKickedStories(string userIdentifier, int hostID, int pageNumber, int pageSize) {
            string cacheKey = String.Format("Kick_StoryTable_UserKicked_{0}_{1}_{2}_{3}", userIdentifier, hostID, pageNumber, pageSize);

            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();

            StoryCollection stories = storyCache[cacheKey];

            if (stories == null) {
                stories = Story.GetUserKickedStories(UserCache.GetUserID(userIdentifier), hostID, pageNumber, pageSize);
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }

        public static StoryCollection GetFriendsKickedStories(string userIdentifier, int hostID, int pageNumber, int pageSize) {
            string cacheKey = String.Format("Kick_StoryTable_FriendsKicked_{0}_{1}_{2}_{3}", userIdentifier, hostID, pageNumber, pageSize);

            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();

            StoryCollection stories = storyCache[cacheKey];

            if (stories == null) {
                stories = Story.GetFriendsKickedStories(UserCache.GetUserID(userIdentifier), hostID, pageNumber, pageSize);
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }
        public static int GetFriendsKickedStoriesCount(string userIdentifier, int hostID) {
            string cacheKey = String.Format("Kick_Story_FriendsKickedCount_{0}_{1}", userIdentifier, hostID);
            CacheManager<string, int?> countCache = GetCountCache();

            int? count = countCache[cacheKey];
            if (count == null) {
                count = Story.GetFriendsKickedStoriesCount(UserCache.GetUserID(userIdentifier), hostID);
                countCache.Insert(cacheKey, count, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }
        public static StoryCollection GetFriendsSubmittedStories(string userIdentifier, int hostID, int pageNumber, int pageSize) {
            string cacheKey = String.Format("Kick_StoryTable_FriendsSubmitted_{0}_{1}_{2}_{3}", userIdentifier, hostID, pageNumber, pageSize);

            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();

            StoryCollection stories = storyCache[cacheKey];

            if (stories == null) {
                stories = Story.GetFriendsSubmittedStories(UserCache.GetUserID(userIdentifier), hostID, pageNumber, pageSize);
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }
        public static int GetFriendsSubmittedStoriesCount(string userIdentifier, int hostID) {
            string cacheKey = String.Format("Kick_Story_FriendsSubmittedCount_{0}_{1}", userIdentifier, hostID);
            CacheManager<string, int?> countCache = GetCountCache();

            int? count = countCache[cacheKey];
            if (count == null) {
                count = Story.GetFriendsSubmittedStoriesCount(UserCache.GetUserID(userIdentifier), hostID);
                countCache.Insert(cacheKey, count, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        public static int GetUserKickedStoriesCount(string userIdentifier, int hostID) {
            string cacheKey = String.Format("Kick_Story_UserKickedCount_{0}_{1}", userIdentifier, hostID);
            CacheManager<string, int?> countCache = GetCountCache();

            int? count = countCache[cacheKey];
            if (count == null) {
                count = Story.GetUserKickedStoriesCount(UserCache.GetUserID(userIdentifier), hostID);
                countCache.Insert(cacheKey, count, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        public static StoryCollection GetUserSubmittedStories(string userIdentifier, int hostID, int pageNumber, int pageSize) {
            string cacheKey = String.Format("Kick_StoryTable_UserSubmitted_{0}_{1}_{2}_{3}", userIdentifier, hostID, pageNumber, pageSize);
            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();

            StoryCollection stories = storyCache[cacheKey];

            if (stories == null) {
                stories = Story.GetUserSubmittedStories(UserCache.GetUserID(userIdentifier), hostID, pageNumber, pageSize);
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }

        public static int GetUserSubmittedStoriesCount(string userIdentifier, int hostID) {
            string cacheKey = String.Format("Kick_Story_UserSubmittedCount_{0}_{1}", userIdentifier, hostID);
            CacheManager<string, int?> countCache = GetCountCache();

            int? count = countCache[cacheKey];
            if (count == null) {
                count = Story.GetUserSubmittedStoriesCount(UserCache.GetUserID(userIdentifier), hostID);
                countCache.Insert(cacheKey, count, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        public static CommentCollection GetUserComments(string userIdentifier, int hostID, int pageNumber, int pageSize) {
            string cacheKey = GetUserCommentsCacheKey(userIdentifier, hostID, pageNumber, pageSize);
            CacheManager<string, CommentCollection> commentCache = GetCommentCollectionCache();

            CommentCollection comments = commentCache[cacheKey];

            if (comments == null) {
                comments = Comment.GetUserComments(UserCache.GetUserID(userIdentifier), hostID, pageNumber, pageSize);
                if (comments != null)
                    commentCache.Insert(cacheKey, comments, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return comments;
        }
        public static int GetUserCommentsCount(string userIdentifier, int hostID) {
            string cacheKey = String.Format("Kick_Story_UserCommentsCount_{0}_{1}", userIdentifier, hostID);
            CacheManager<string, int?> countCache = GetCountCache();

            int? count = countCache[cacheKey];
            if (count == null) {
                count = Comment.GetUserCommentsCount(UserCache.GetUserID(userIdentifier), hostID);
                countCache.Insert(cacheKey, count, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        private static string GetUserCommentsCacheKey(string userIdentifier, int hostID, int pageNumber, int pageSize) {
            return String.Format("UserCommentCollection_{0}_{1}_{2}_{3}", userIdentifier, hostID, pageNumber, pageSize);
        }

        //NOTE: GJ: this will be depreciated in favour of tagging
        public static StoryCollection GetCategoryStories(short categoryID, bool isKicked, int hostID, int pageNumber, int pageSize) {
            return GetTaggedStories(CategoryCache.GetCategory(categoryID, hostID).CategoryIdentifier, hostID, pageNumber, pageSize);
        }
        //NOTE: GJ: this will be depreciated in favour of tagging
        public static int GetCategoryStoryCount(short categoryID, bool isKicked, int hostID) {
            return GetTaggedStoryCount(CategoryCache.GetCategory(categoryID, hostID).CategoryIdentifier, hostID);
        }

        public static StoryCollection GetTaggedStories(string tagIdentifier, int hostID, int pageNumber, int pageSize) {
            string cacheKey = String.Format("Kick_TaggedStoryTable_{0}_{1}_{2}_{3}", tagIdentifier, hostID, pageNumber, pageSize);

            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();

            StoryCollection stories = storyCache[cacheKey];

            if (stories == null) {
                stories = Story.GetTaggedStories(TagCache.GetTagID(tagIdentifier), hostID, pageNumber, pageSize);
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }

        public static int GetTaggedStoryCount(string tagIdentifier, int hostID) {
            string cacheKey = String.Format("Kick_TaggedStoryCount_{0}_{1}", tagIdentifier, hostID);
            CacheManager<string, int?> countCache = GetCountCache();

            int? count = countCache[cacheKey];
            if (count == null) {
                count = Story.GetTaggedStoryCount(TagCache.GetTagID(tagIdentifier), hostID);
                countCache.Insert(cacheKey, count, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        public static void ClearUserTaggedStories(string tagIdentifier, int userID, int hostID) {
            //TODO: GJ: refactor: the cache keys are used below too
            GetStoryCollectionCache().Remove(String.Format("Kick_UserTaggedStoryTable_{0}_{1}_{2}_{3}", tagIdentifier, userID, hostID, 1));
            GetCountCache().Remove(String.Format("Kick_UserTaggedStoryCount_{0}_{1}_{2}", tagIdentifier, userID, hostID));
        }

        public static StoryCollection GetUserTaggedStories(string tagIdentifier, int userID, int hostID, int pageNumber, int pageSize) {
            string cacheKey = String.Format("Kick_UserTaggedStoryTable_{0}_{1}_{2}_{3}", tagIdentifier, userID, hostID, pageNumber);

            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();

            StoryCollection stories = storyCache[cacheKey];

            if (stories == null) {
                stories = Story.GetUserTaggedStories(TagCache.GetTagID(tagIdentifier), userID, hostID, pageNumber, pageSize);
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }

        public static int GetUserTaggedStoryCount(string tagIdentifier, int userID, int hostID) {
            string cacheKey = String.Format("Kick_UserTaggedStoryCount_{0}_{1}_{2}", tagIdentifier, userID, hostID);
            CacheManager<string, int?> countCache = GetCountCache();

            int? count = countCache[cacheKey];
            if (count == null) {
                count = Story.GetUserTaggedStoryCount(TagCache.GetTagID(tagIdentifier), userID, hostID);
                countCache.Insert(cacheKey, count, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }


        public static int GetUpcomingStoryCount(Host host) {
            return GetStoryCount(host.HostID, false, DateTime.Now.AddHours(-host.Publish_MaximumStoryAgeInHours), DateTime.Now);
        }

        public static int GetStoryCount(int hostID, bool isPublished) {
            string cacheKey = String.Format("Kick_StoryCount_{0}_{1}", isPublished, hostID);
            CacheManager<string, int?> storyCountCache = GetCountCache();

            int storyCount;
            if (storyCountCache.ContainsKey(cacheKey)) {
                storyCount = storyCountCache[cacheKey].Value;
            } else {
                storyCount = Story.GetStoryCount(hostID, isPublished);
                storyCountCache.Insert(cacheKey, storyCount, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return storyCount;
        }

        public static int GetStoryCount(int hostID, bool isPublished, DateTime startDate, DateTime endDate) {
            string cacheKey = String.Format("Kick_StoryCount_{0}_{1}_{2}_{3}", isPublished, hostID, CacheHelper.DateTimeToCacheKey(startDate), CacheHelper.DateTimeToCacheKey(endDate));
            CacheManager<string, int?> storyCountCache = GetCountCache();

            int storyCount;
            if (storyCountCache.ContainsKey(cacheKey)) {
                storyCount = storyCountCache[cacheKey].Value;
            } else {
                storyCount = Story.GetStoryCount(hostID, isPublished, startDate, endDate);
                storyCountCache.Insert(cacheKey, storyCount, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return storyCount;
        }

        private static CacheManager<string, StoryCollection> GetStoryCollectionCache() {
            return CacheManager<string, StoryCollection>.GetInstance();
        }

        private static CacheManager<string, Story> GetStoryCache() {
            return CacheManager<string, Story>.GetInstance();
        }

        private static CacheManager<string, CommentCollection> GetCommentCollectionCache() {
            return CacheManager<string, CommentCollection>.GetInstance();
        }

        private static CacheManager<string, int?> GetCountCache() {
            return CacheManager<string, int?>.GetInstance();
        }
    }
}
