using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Incremental.Kick.Dal;
using SubSonic;
using System.Text.RegularExpressions;

namespace Incremental.Kick.Caching
{
    /// <summary>
    /// Cache used by the Zeitgeist 
    /// </summary>
    public class ZeitgeistCache
    {

        #region Methods

        // [rgn] Public Methods (9)

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
                qry.AddWhere(Story.Columns.IsSpam, false);
                qry.AddWhere(Story.Columns.HostID, hostID);
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
        /// Gets the most kicked stories.
        /// </summary>
        /// <param name="hostID">The host ID.</param>
        /// <param name="storyCount">The story count.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static StoryCollection GetMostPopularStories(int hostID, int storyCount, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_MostPopular_{0}_{1}_{2}_{3}_{4}", hostID, storyCount, year, month, day);
            CacheManager<string, StoryCollection> storyCache = GetStoryCollectionCache();
            StoryCollection stories = storyCache[cacheKey];

            if (stories == null)
            {
                Query qry = new Query(Story.Schema);
                qry.Top = storyCount.ToString();
                qry.OrderBy = OrderBy.Desc(Story.Columns.KickCount);
                qry.AddWhere(Story.Columns.IsSpam, false);
                qry.AddWhere(Story.Columns.HostID, hostID);
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
        /// Gets the most popular domains.
        /// Measured by number of kicks per domain
        /// </summary>
        /// <param name="hostID">The host ID.</param>
        /// <param name="storyCount">The story count.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetMostPopularDomains(int hostID, int storyCount, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_MostPopularDomains_{0}_{1}_{2}_{3}_{4}", hostID, storyCount, year, month, day);
            CacheManager<string, Dictionary<string, int>> domainCache = GetMostPopularDomainsCache();
            Dictionary<string, int> domainList = domainCache[cacheKey];

            if (domainList == null)
            {
                //get all stories, then loop and make our own domain list
                Query qry = new Query(Story.Schema);
                qry.OrderBy = OrderBy.Desc(Story.Columns.KickCount);
                qry.AddWhere(Story.Columns.IsSpam, false);
                qry.AddWhere(Story.Columns.HostID, hostID);
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                qry.AddWhere(Story.Columns.KickCount, Comparison.GreaterOrEquals, 1);
                StoryCollection stories = new StoryCollection();
                stories.LoadAndCloseReader(Story.FetchByQuery(qry));

                domainList = new Dictionary<string, int>();
                Regex rx = new Regex(@"^(?=[^&])(?:(?<scheme>[^:/?#]+):)?(?://(?<authority>[^/?#]*))?(?<path>[^?#]*)(?:\?(?<query>[^#]*))?(?:#(?<fragment>.*))?");

                foreach (Story s in stories)
                {
                    Match uriMatch = rx.Match(s.Url);
                    if (!uriMatch.Success)
                        continue;
                    string authority = uriMatch.Groups["authority"].Value;

                    if (string.IsNullOrEmpty(authority))
                        continue;

                    if (domainList.ContainsKey(authority))
                        domainList[authority] += s.KickCount;
                    else
                        domainList.Add(authority, s.KickCount);
                }
                //sort and trim to   storyCount
                List<KeyValuePair<string, int>> sortedPairs = new List<KeyValuePair<string, int>>(domainList);
                sortedPairs.Sort(
                   delegate(KeyValuePair<string, int> obj1, KeyValuePair<string, int> obj2)
                   { return obj2.Value.CompareTo(obj1.Value); }
                );

                domainList.Clear();//clear and add top X values
                if (sortedPairs.Count < storyCount)
                    storyCount = sortedPairs.Count;

                for (int i = 0; i < storyCount; i++)
                    domainList.Add(sortedPairs[i].Key, sortedPairs[i].Value);

                domainCache.Insert(cacheKey, domainList, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return domainList;
        }

        /// <summary>
        /// Gets the most published domains.
        /// Measured by number of published stories per domain
        /// </summary>
        /// <param name="hostID">The host ID.</param>
        /// <param name="storyCount">The story count.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetMostPublishedDomains(int hostID, int storyCount, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_MostPublishedDomains_{0}_{1}_{2}_{3}_{4}", hostID, storyCount, year, month, day);
            CacheManager<string, Dictionary<string, int>> domainCache = GetMostPublishedDomainsCache();
            Dictionary<string, int> domainList = domainCache[cacheKey];

            if (domainList == null)
            {
                //get all stories, then loop and make our own domain list
                Query qry = new Query(Story.Schema);
                qry.AddWhere(Story.Columns.IsSpam, false);
                qry.AddWhere(Story.Columns.IsPublishedToHomepage, true);
                qry.AddWhere(Story.Columns.HostID, hostID);
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                StoryCollection stories = new StoryCollection();
                stories.LoadAndCloseReader(Story.FetchByQuery(qry));

                domainList = new Dictionary<string, int>();
                Regex rx = new Regex(@"^(?=[^&])(?:(?<scheme>[^:/?#]+):)?(?://(?<authority>[^/?#]*))?(?<path>[^?#]*)(?:\?(?<query>[^#]*))?(?:#(?<fragment>.*))?");

                foreach (Story s in stories)
                {
                    Match uriMatch = rx.Match(s.Url);
                    if (!uriMatch.Success)
                        continue;
                    string authority = uriMatch.Groups["authority"].Value;

                    if (string.IsNullOrEmpty(authority))
                        continue;

                    if (domainList.ContainsKey(authority))
                        domainList[authority] += 1;
                    else
                        domainList.Add(authority, 1);
                }
                //sort and trim to storyCount
                List<KeyValuePair<string, int>> sortedPairs = new List<KeyValuePair<string, int>>(domainList);
                sortedPairs.Sort(
                   delegate(KeyValuePair<string, int> obj1, KeyValuePair<string, int> obj2)
                   { return obj2.Value.CompareTo(obj1.Value); }
                );

                domainList.Clear();//clear and add top X values
                if (sortedPairs.Count < storyCount)
                    storyCount = sortedPairs.Count;

                for (int i = 0; i < storyCount; i++)
                    domainList.Add(sortedPairs[i].Key, sortedPairs[i].Value);

                domainCache.Insert(cacheKey, domainList, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return domainList;
        }

        /// <summary>
        /// Gets the most published users.
        /// Measured by number of published stories per user
        /// </summary>
        /// <param name="hostID">The host ID.</param>
        /// <param name="userCount">The story count.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetMostPublishedUsers(int hostID, int userCount, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_MostPublishedUsers_{0}_{1}_{2}_{3}_{4}", hostID, userCount, year, month, day);
            CacheManager<string, Dictionary<string, int>> userListCache = GetMostPublishedUsersCache();
            Dictionary<string, int> userList = userListCache[cacheKey];

            if (userList == null)
            {
                //get all stories, then loop and make our own domain list
                Query qry = new Query(Story.Schema);
                qry.OrderBy = OrderBy.Desc(Story.Columns.UserID);
                qry.AddWhere(Story.Columns.IsSpam, false);
                qry.AddWhere(Story.Columns.IsPublishedToHomepage, true);
                qry.AddWhere(Story.Columns.HostID, hostID);
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                StoryCollection stories = new StoryCollection();
                stories.LoadAndCloseReader(Story.FetchByQuery(qry));

                userList = new Dictionary<string, int>();

                foreach (Story s in stories)
                {
                    if (userList.ContainsKey(s.User.Username))
                        userList[s.User.Username] += 1;
                    else
                        userList.Add(s.User.Username, 1);
                }
                //sort and trim to storyCount
                List<KeyValuePair<string, int>> sortedPairs = new List<KeyValuePair<string, int>>(userList);
                sortedPairs.Sort(
                   delegate(KeyValuePair<string, int> obj1, KeyValuePair<string, int> obj2)
                   { return obj2.Value.CompareTo(obj1.Value); }
                );

                userList.Clear();//clear and add top X values
                if (sortedPairs.Count < userCount)
                    userCount = sortedPairs.Count;

                for (int i = 0; i < userCount; i++)
                    userList.Add(sortedPairs[i].Key, sortedPairs[i].Value);

                userListCache.Insert(cacheKey, userList, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return userList;
        }




        /// <summary>
        /// Gets the most used tags.
        /// </summary>
        /// <param name="hostID">The host ID.</param>
        /// <param name="tagCount">The tag count.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetMostUsedTags(int hostID, int tagCount, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_MostUsedTags_{0}_{1}_{2}_{3}_{4}", hostID, tagCount, year, month, day);
            CacheManager<string, Dictionary<string, int>> tagCache = GetTagCollectionCache();
            Dictionary<string, int> tags = tagCache[cacheKey];

            if (tags == null)
            {
                //very messy need support for Group By and Joins in SubSonic
                StringBuilder sqlSelect = new StringBuilder(128);
                //select
                sqlSelect.AppendFormat("SELECT TOP {0} COUNT(0) AS TagCount, {1}.{2} ",
                    tagCount,
                    Tag.Schema.TableName, Tag.Columns.TagIdentifier);

                //from
                sqlSelect.AppendFormat("FROM {0} INNER JOIN {1} on {0}.{2}={1}.{3} ",
                        StoryUserHostTag.Schema.TableName, Story.Schema.TableName,
                        StoryUserHostTag.Columns.StoryID, Story.Columns.StoryID);
                sqlSelect.AppendFormat("INNER JOIN {0} on {0}.{1}={2}.{3} ",
                        Tag.Schema.TableName, Tag.Columns.TagID,
                        StoryUserHostTag.Schema.TableName, StoryUserHostTag.Columns.TagID);

                //where
                sqlSelect.AppendFormat("WHERE {0}.{1} >= @StartingDate AND {0}.{1} <= @EndingDate ",
                    Story.Schema.TableName, Story.Columns.CreatedOn);

                sqlSelect.AppendFormat("AND {0}.{1} = 0 AND {0}.{2} = @HostId ",
                  Story.Schema.TableName, Story.Columns.IsSpam,
                  Story.Columns.HostID);

                //group by
                sqlSelect.AppendFormat("GROUP BY {0} ", Tag.Columns.TagIdentifier);

                //order by
                sqlSelect.Append("ORDER BY COUNT(0) DESC");

                /* 
                 * SELECT TOP 10 COUNT(0) AS TagCount, Kick_Tag.TagIdentifier 
                 * FROM Kick_StoryUserHostTag INNER JOIN Kick_Story on Kick_StoryUserHostTag.StoryID=Kick_Story.StoryID 
                 * INNER JOIN Kick_Tag on Kick_Tag.TagID=Kick_StoryUserHostTag.TagID 
                 * WHERE Kick_Story.CreatedOn >= @StartingDate AND Kick_Story.CreatedOn <= @EndingDate 
                 * AND Kick_Story.IsSpam = 0 AND Kick_Story.HostID = @HostId 
                 * GROUP BY TagIdentifier 
                 * ORDER BY COUNT(0) DESC
                 */
                //System.Diagnostics.Debug.WriteLine(sqlSelect.ToString());

                QueryCommand qry = new QueryCommand(sqlSelect.ToString());
                qry.AddParameter("@StartingDate", StartingDate(year, month, day));
                qry.AddParameter("@EndingDate", EndingDate(year, month, day));
                qry.AddParameter("@HostId", hostID);

                tags = new Dictionary<string, int>();

                IDataReader reader = DataService.GetInstance("DotNetKicks").GetReader(qry);
                while (reader.Read())
                {
                    tags.Add(reader[1].ToString(), int.Parse(reader[0].ToString()));//1=TagIdentifier (key), 0=TagCount (value)
                }
                reader.Close();

                tagCache.Insert(cacheKey, tags, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return tags;
        }

        /// <summary>
        /// Gets the number of comments.
        /// </summary>
        /// <param name="hostID">The host id.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static int GetNumberOfComments(int hostID, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_CommentCount_{0}_{1}_{2}_{3}", hostID, year, month, day);
            CacheManager<string, int?> countCache = GetStoryCountCache();
            int? count = countCache[cacheKey];

            if (count == null)
            {
                Query qry = new Query(Comment.Schema);
                qry.AddWhere(Comment.Columns.HostID, hostID);
                qry.AddWhere(Comment.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(Comment.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                count = qry.GetRecordCount();// GetCount(Comment.Columns.CommentID);
                countCache.Insert(cacheKey, count.Value, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        /// <summary>
        /// Gets the number of kicks.
        /// </summary>
        /// <param name="hostID">The host id.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static int GetNumberOfKicks(int hostID, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_KickCount_{0}_{1}_{2}_{3}", hostID, year, month, day);
            CacheManager<string, int?> countCache = GetStoryCountCache();
            int? count = countCache[cacheKey];

            if (count == null)
            {
                Query qry = new Query(StoryKick.Schema);
                qry.AddWhere(StoryKick.Columns.HostID, hostID);
                qry.AddWhere(StoryKick.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(StoryKick.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                count = qry.GetRecordCount();// GetCount(StoryKick.Columns.StoryKickID);
                countCache.Insert(cacheKey, count.Value, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        /// <summary>
        /// Gets the number of stories published.
        /// </summary>
        /// <param name="hostID">The host id.</param>
        /// <returns></returns>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public static int GetNumberOfStoriesPublished(int hostID, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_PublishedCount_{0}_{1}_{2}_{3}", hostID, year, month, day);
            CacheManager<string, int?> countCache = GetStoryCountCache();
            int? count = countCache[cacheKey];

            if (count == null)
            {
                Query qry = new Query(Story.Schema);
                qry.AddWhere(Story.Columns.IsSpam, false);
                qry.AddWhere(Story.Columns.HostID, hostID);
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                qry.AddWhere(Story.Columns.IsPublishedToHomepage, true);
                count = qry.GetRecordCount();// GetCount(Story.Columns.StoryID);
                countCache.Insert(cacheKey, count.Value, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        /// <summary>
        /// Gets the number of stories submitted.
        /// </summary>
        /// <param name="hostID">The host id.</param>
        /// <returns></returns>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public static int GetNumberOfStoriesSubmitted(int hostID, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_SubmittedCount_{0}_{1}_{2}_{3}", hostID, year, month, day);
            CacheManager<string, int?> countCache = GetStoryCountCache();
            int? count = countCache[cacheKey];

            if (count == null)
            {
                Query qry = new Query(Story.Schema);
                qry.AddWhere(Story.Columns.IsSpam, false);
                qry.AddWhere(Story.Columns.HostID, hostID);
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(Story.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                count = qry.GetRecordCount();// GetCount(Story.Columns.StoryID);
                countCache.Insert(cacheKey, count.Value, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        /// <summary>
        /// Gets the number of user registrations.
        /// </summary>
        /// <param name="hostID">The host ID.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public static int GetNumberOfUserRegistrations(int hostID, int year, int? month, int? day)
        {
            string cacheKey = String.Format("Zeitgeist_UserRegistrationCount_{0}_{1}_{2}_{3}", hostID, year, month, day);
            CacheManager<string, int?> countCache = GetUserRegistrationCountCache();
            int? count = countCache[cacheKey];

            if (count == null)
            {
                Query qry = new Query(User.Schema);
                qry.AddWhere(User.Columns.IsBanned, false);
                qry.AddWhere(User.Columns.IsValidated, true);
                qry.AddWhere(User.Columns.HostID, hostID);
                qry.AddWhere(User.Columns.CreatedOn, Comparison.GreaterOrEquals, StartingDate(year, month, day));
                qry.AddWhere(User.Columns.CreatedOn, Comparison.LessOrEquals, EndingDate(year, month, day));
                count = qry.GetRecordCount();
                countCache.Insert(cacheKey, count.Value, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return count.Value;
        }

        // [rgn] Private Methods (7)

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
            if (day != null)
                return new DateTime(year, month.Value, day.Value).AddDays(1);

            return new DateTime(year, month.Value, day.Value);
        }

        /// <summary>
        /// Gets the most popular domains cache.
        /// </summary>
        /// <returns></returns>
        private static CacheManager<string, Dictionary<string, int>> GetMostPopularDomainsCache()
        {
            return CacheManager<string, Dictionary<string, int>>.GetInstance();
        }
        /// <summary>
        /// Gets the most published domains cache.
        /// </summary>
        /// <returns></returns>
        private static CacheManager<string, Dictionary<string, int>> GetMostPublishedDomainsCache()
        {
            return CacheManager<string, Dictionary<string, int>>.GetInstance();
        }
        /// <summary>
        /// Gets the most published users cache.
        /// </summary>
        /// <returns></returns>
        private static CacheManager<string, Dictionary<string, int>> GetMostPublishedUsersCache()
        {
            return CacheManager<string, Dictionary<string, int>>.GetInstance();
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
        /// Gets the story count cache.
        /// </summary>
        /// <returns></returns>
        private static CacheManager<string, int?> GetStoryCountCache()
        {
            return CacheManager<string, int?>.GetInstance();
        }

        /// <summary>
        /// Gets the tag collection cache.
        /// </summary>
        /// <returns></returns>
        private static CacheManager<string, Dictionary<string, int>> GetTagCollectionCache()
        {
            return CacheManager<string, Dictionary<string, int>>.GetInstance();
        }

        /// <summary>
        /// Gets the user registration count cache.
        /// </summary>
        /// <returns></returns>
        private static CacheManager<string, int?> GetUserRegistrationCountCache()
        {
            return CacheManager<string, int?>.GetInstance();
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

        #endregion

    }


}
