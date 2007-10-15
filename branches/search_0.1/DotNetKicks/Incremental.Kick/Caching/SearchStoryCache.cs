using System;
using System.Collections.Generic;
using System.Text;

using Incremental.Kick.Dal;
using Incremental.Kick.Search;

namespace Incremental.Kick.Caching
{
    public class SearchStoryCache
    {
        /// <summary>
        /// Searches the index for stories kicked by a given user
        /// </summary>
        /// <param name="query"></param>
        /// <param name="username"></param>
        /// <param name="hostId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static StoryCollection GetStoryCollectionSearchResultsByUser(string query, string username, int hostId, int page, int pageSize)
        {
            string cacheKey = string.Format("SearchUserStoryCollection_{0}_{1}_{2}_{3}_{4}", CleanUpQuery(query), hostId, page, pageSize, username);
            string cacheCountKey = string.Format("SearchUserStoryCollectionCount_{0}_{1}_{2}", CleanUpQuery(query), hostId, username);

            CacheManager<string, StoryCollection> cache = GetSearchStoryCollectionCache();
            StoryCollection results = cache[cacheKey];
            if (results == null)
            {
                int totalNumberResults = 0;
                SearchQuery searchQuery = new SearchQuery();
                results = searchQuery.SearchIndex(hostId, query, username, page, pageSize, out totalNumberResults);

                if (results != null)
                {
                    cache.Insert(cacheKey, results, CacheHelper.CACHE_DURATION_IN_SECONDS);
                }

                //add to the cache containing the search results counts, we dont want to have to call the 
                //the search twice since we already have this value in this method call.
                CacheManager<string, int?> cacheCount = GetSearchStoryCountCache();
                if (cacheCount.ContainsKey(cacheCountKey))
                    cacheCount.Remove(cacheCountKey);

                cacheCount.Insert(cacheCountKey, totalNumberResults, CacheHelper.CACHE_DURATION_IN_SECONDS);

            }

            return results;
        }



        /// <summary>
        /// Searches the complete index for matches
        /// </summary>
        /// <param name="query"></param>
        /// <param name="hostId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static StoryCollection GetStoryCollectionSearchResults(string query, int hostId, int page, int pageSize)
        {
            string cacheKey = string.Format("SearchStoryCollection_{0}_{1}_{2}_{3}", CleanUpQuery(query), hostId, page, pageSize);
            string cacheCountKey = string.Format("SearchStoryCollectionCount_{0}_{1}", CleanUpQuery(query), hostId);


            CacheManager<string, StoryCollection> cache = GetSearchStoryCollectionCache();
            StoryCollection results = cache[cacheKey];
            if (results == null)
            {
                int totalNumberResults = 0;
                SearchQuery searchQuery = new SearchQuery();
                results = searchQuery.SearchIndex(hostId, query, page, pageSize, out totalNumberResults);

                if (results != null)
                {
                    cache.Insert(cacheKey, results, CacheHelper.CACHE_DURATION_IN_SECONDS);
                }

                //add to the cache containing the search results counts, we dont want to have to call the 
                //the search twice

                CacheManager<string, int?> cacheCount = GetSearchStoryCountCache();
                if (cacheCount.ContainsKey(cacheCountKey))
                    cacheCount.Remove(cacheCountKey);

                cacheCount.Insert(cacheCountKey, totalNumberResults, CacheHelper.CACHE_DURATION_IN_SECONDS);
                
            }

            return results;
        }


        public static int GetStoryCollectionSearchResultsCountByUser(string query, string username, int hostId, int page, int pageSize)
        {
            string cacheKey = string.Format("SearchUserStoryCollectionCount_{0}_{1}_{2}", CleanUpQuery(query), hostId, username);

            CacheManager<string, int?> cache = GetSearchStoryCountCache();
            int searchResultsCount;

            if (cache.ContainsKey(cacheKey))
            {
                searchResultsCount = cache[cacheKey].Value;
            }
            else
            {
                //call the search to populate the count cache
                GetStoryCollectionSearchResultsByUser(query, username, hostId, page, pageSize);
                searchResultsCount = cache[cacheKey].Value;
            }

            return searchResultsCount;
        }


        /// <summary>
        /// Gets a count of the number of results reutrned for a given page and query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="hostId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int GetStoryCollectionSearchResultsCount(string query, int hostId, int page, int pageSize)
        {
            string cacheKey = string.Format("SearchStoryCollectionCount_{0}_{1}", CleanUpQuery(query), hostId);

            CacheManager<string, int?> cache = GetSearchStoryCountCache();
            int searchResultsCount;

            if (cache.ContainsKey(cacheKey))
            {
                searchResultsCount = cache[cacheKey].Value;
            }
            else
            {
                //call the search to populate the count cache
                GetStoryCollectionSearchResults(query, hostId, page, pageSize);
                searchResultsCount = cache[cacheKey].Value;
            }

            return searchResultsCount;
        }


        private static string CleanUpQuery(string query)
        {
            StringBuilder cleanup = new StringBuilder();

            foreach (Char c in query)
            {
                if (Char.IsWhiteSpace(c))
                    cleanup.Append("-");
                else
                    cleanup.Append(c);
            }

            return cleanup.ToString();
        }


        private static CacheManager<string, StoryCollection> GetSearchStoryCollectionCache()
        {
            return CacheManager<string, StoryCollection>.GetInstance();
        }


        private static CacheManager<string, int?> GetSearchStoryCountCache()
        {
            return CacheManager<string, int?>.GetInstance();
        }
    }
}
