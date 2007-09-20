using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Common.Enums;
using SubSonic;

namespace Incremental.Kick.Caching
{
    /// <summary>
    /// Cache used by the Zeitgeist 
    /// </summary>
    public class ZeitgeistCache
    {

        /// <summary>
        /// Gets the most kicked stories.
        /// </summary>
        /// <param name="hostID">The host ID.</param>
        /// <param name="storyCount">The story count.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static StoryCollection GetMostKickedStories(int hostID, int storyCount, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_MostKicked_{0}_{1}_{2}_{3}_{4}", hostID, storyCount, year, month, day);
            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();
            StoryCollection stories = storyCache[cacheKey];

            if (stories == null)
            {
                Query qry = new Query(Story.Schema);
                qry.Top = storyCount.ToString();
                qry.OrderBy = OrderBy.Desc(Story.Columns.KickCount);
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                qry.AddWhere(Story.Columns.KickCount, Comparison.GreaterOrEquals, 1);
                stories = new StoryCollection();
                stories.LoadAndCloseReader(Story.FetchByQuery(qry));
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }


        /// <summary>
        /// Gets the most commented on stories.
        /// </summary>
        /// <param name="hostID">The host ID.</param>
        /// <param name="storyCount">The story count.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static StoryCollection GetMostCommentedOnStories(int hostID, int storyCount, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_MostCommentedOn_{0}_{1}_{2}_{3}_{4}", hostID, storyCount, year, month, day);
            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();
            StoryCollection stories = storyCache[cacheKey];

            if (stories == null)
            {
                Query qry = new Query(Story.Schema);
                qry.Top = storyCount.ToString();
                qry.OrderBy = OrderBy.Desc(Story.Columns.CommentCount);
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                qry.AddWhere(Story.Columns.CommentCount, Comparison.GreaterOrEquals, 1);
                stories = new StoryCollection();
                stories.LoadAndCloseReader(Story.FetchByQuery(qry));
                storyCache.Insert(cacheKey, stories, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return stories;
        }

        /// <summary>
        /// Gets the story collection cache.
        /// </summary>
        /// <returns></returns>
        private static CacheManager<string, StoryCollection> GetStoryCollectionCache()
        {
            return CacheManager<string, StoryCollection>.GetInstance();
        }

        /// <summary>
        /// Gets the starting date for the Zeitgeist query
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        private static DateTime StartingDate(int year, int? month, int? day)
        {
            if (month == null || month < 0 || month > 12)
                month = 1;
            if (day == null || day < 0 || day > DateTime.DaysInMonth(year, month.Value))
                day = 1;
            return new DateTime(year, month.Value, day.Value);
        }

        /// <summary>
        /// Gets the ending date for the Zeitgeist query
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        private static DateTime EndingDate(int year, int? month, int? day)
        {
            if (month == null || month < 0 || month > 12)
                month = 12;
            if (day == null || day < 0 || day > DateTime.DaysInMonth(year, month.Value))
                day = DateTime.DaysInMonth(year, month.Value);
            if(day!=null)
                return new DateTime(year, month.Value, day.Value).AddDays(1);

            return new DateTime(year, month.Value, day.Value);
        }
    }
}
