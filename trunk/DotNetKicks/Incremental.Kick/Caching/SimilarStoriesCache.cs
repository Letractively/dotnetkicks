using System;
using System.Collections.Generic;
using System.Text;

using Incremental.Kick.Dal;
using Incremental.Kick.Search;

namespace Incremental.Kick.Caching
{
    public class SimilarStoriesCache
    {

        public static StoryCollection GetSimilarStoryCollection(int hostId, int storyId)
        {
            string cacheKey = string.Format("SimilarStoryCollection_{0}_{1}",
                                            storyId,
                                            hostId);

            CacheManager<string, StoryCollection> cache = GetSimilarStoriesCache();
            StoryCollection results = cache[cacheKey];
            if (results == null)
            {
                SimilarStories similarStories = new SimilarStories();
                results = similarStories.Find(hostId, storyId);

                if (results != null)
                {
                    cache.Insert(cacheKey, results, CacheHelper.CACHE_DURATION_IN_SECONDS);
                }
            }

            return results;
        }


        private static CacheManager<string, StoryCollection> GetSimilarStoriesCache()
        {
            return CacheManager<string, StoryCollection>.GetInstance();
        }
    }
}
