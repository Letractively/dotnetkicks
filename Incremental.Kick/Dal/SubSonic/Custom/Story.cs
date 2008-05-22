using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Common.Enums;
using SubSonic;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities.Api;
using System.Data;

namespace Incremental.Kick.Dal {
    public partial class Story {

        #region API Methods

        public ApiStory ToApi() {
            Host host = HostCache.GetHost(this.HostID);
            return new ApiStory(
                this.Title, host.RootUrl + UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, this.StoryIdentifier, CategoryCache.GetCategory(this.CategoryID, this.HostID).CategoryIdentifier), this.Description,
                this.CreatedOn, this.PublishedOn, this.IsPublishedToHomepage, this.KickCount, this.CommentCount, UserCache.GetUser(this.UserID).ToApi(host));
        }

        public static class Api {
            //TODO : GJ : store pagedCollection in the cache instead of both the list and count

            public static ApiPagedList<ApiStory> GetFrontPageStories(int hostID, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetAllStories(true, hostID, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetStoryCount(hostID, true);
                return pagedCollection.ToApi();
            }


            public static ApiPagedList<ApiStory> GetUpcomingPageStories(int hostID, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetAllStories(false, hostID, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetStoryCount(hostID, false);
                return pagedCollection.ToApi();
            }

            public static ApiPagedList<ApiStory> GetPopularStories(int hostID, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                return GetPopularStoriesPagedAndSorted(hostID, pageNumber, pageSize, StoryListSortBy.PastMonth);
            }

            public static ApiPagedList<ApiStory> GetPopularStoriesPagedAndSorted(int hostID, int pageNumber, int pageSize, StoryListSortBy timePeriod) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetPopularStories(hostID, true, timePeriod, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetPopularStoriesCount(hostID, true, timePeriod);
                return pagedCollection.ToApi();
            }

            public static ApiPagedList<ApiStory> GetUpcomingStories(int hostID, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                return GetUpcomingStoriesPagedAndSorted(hostID, pageNumber, pageSize, StoryListSortBy.PastMonth);
            }

            public static ApiPagedList<ApiStory> GetUpcomingStoriesPagedAndSorted(int hostID, int pageNumber, int pageSize, StoryListSortBy timePeriod) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetPopularStories(hostID, false, timePeriod, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetPopularStoriesCount(hostID, false, timePeriod);
                return pagedCollection.ToApi();
            }

            public static ApiPagedList<ApiStory> GetUserKickedStories(int hostID, string username, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetUserKickedStories(username, hostID, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetUserKickedStoriesCount(username, hostID);
                return pagedCollection.ToApi();
            }

            public static ApiPagedList<ApiStory> GetUserSubmittedStories(int hostID, string username, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetUserSubmittedStories(username, hostID, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetUserSubmittedStoriesCount(username, hostID);
                return pagedCollection.ToApi();
            }

            public static ApiPagedList<ApiStory> GetUserFriendsKickedStories(int hostID, string username, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetFriendsKickedStories(username, hostID, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetFriendsKickedStoriesCount(username, hostID);
                return pagedCollection.ToApi();
            }

            public static ApiPagedList<ApiStory> GetUserFriendsSubmittedStories(int hostID, string username, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetFriendsSubmittedStories(username, hostID, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetFriendsSubmittedStoriesCount(username, hostID);
                return pagedCollection.ToApi();
            }

            public static ApiPagedList<ApiStory> GetTaggedStories(int hostID, string tag, int pageNumber, int pageSize) {
                ApplyPageLimits(ref pageNumber, ref pageSize);
                PagedStoryCollection pagedCollection = new PagedStoryCollection();
                pagedCollection.Items = StoryCache.GetTaggedStories(tag, hostID, pageNumber, pageSize);
                pagedCollection.Total = StoryCache.GetTaggedStoryCount(tag, hostID);
                return pagedCollection.ToApi();
            }

            private static void ApplyPageLimits(ref int pageNumber, ref int pageSize) {
                if (pageNumber <= 0)
                    pageNumber = 1;

                if (pageSize <= 0 || pageSize > 100)
                    pageSize = 16;
            }
        }
        #endregion

        #region Cached Properties

        /// <summary>
        /// Gets a count of all stories in the database not marked
        /// as spam
        /// </summary>
        /// <param name="hostID"></param>
        /// <returns></returns>
        public static int GetAllStoriesCount(int hostID)
        {
            Query q = GetStoryQuery(hostID);
            return q.GetCount(Story.Columns.StoryID);
        }

        /// <summary>
        /// Get all the stories for a given host
        /// </summary>
        /// <param name="hostID"></param>
        /// <returns></returns>
        public static StoryCollection GetAllStories(int hostID, int pageIndex, int pageSize)
        {
            Query q = Story.Query();
            q.WHERE(Story.Columns.HostID, hostID).AND(Story.Columns.IsSpam, false);
            q.PageIndex = pageIndex;
            q.PageSize = pageSize;

            StoryCollection stories = new StoryCollection();
            stories.LoadAndCloseReader(q.ExecuteReader());
            return stories;
        }


        public static int GetUpdatedStoriesCount(int hostID, DateTime updatedAfter)
        {
            Query q = Story.Query();
            q.WHERE(Story.Columns.HostID, hostID).AND(Story.Columns.UpdatedOn, Comparison.GreaterOrEquals, updatedAfter);
            return q.GetCount(Story.Columns.StoryID);
        }

        /// <summary>
        /// Returns a StoryCollection of stories that have been modified after the
        /// given DateTime value
        /// </summary>
        /// <remarks>this is used by lucene to create an incremental update of the search
        /// index without having to do a full index again</remarks>
        /// <param name="updatedAfter"></param>
        /// <returns></returns>
        public static StoryCollection GetUpdatedStories(int hostID, DateTime updatedAfter, int pageIndex, int pageSize)
        {
            Query q = Story.Query();
            q.WHERE(Story.Columns.HostID, hostID).AND(Story.Columns.UpdatedOn, Comparison.GreaterOrEquals, updatedAfter);
            q.PageIndex = pageIndex;
            q.PageSize = pageSize;

            StoryCollection stories = new StoryCollection();
            stories.LoadAndCloseReader(q.ExecuteReader());
            return stories;
        }


        /// <summary>
        /// Returns a StoryCollection for a given IList of storyIds
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public static StoryCollection GetStoriesByIds(IList<int> storyId)
        {
            Query q = Story.Query();

            object[] storyIdArray = new object[storyId.Count];
            for (int i = 0; i < storyId.Count; i++)
            {
                storyIdArray[i] = storyId[i];
            }

            q.IN("storyID", storyIdArray);

            StoryCollection stories = new StoryCollection();
            stories.LoadAndCloseReader(q.ExecuteReader());
            return stories;
        }

        //NOTE: GJ: These properties are lazy-loaded from the cache
        private UserCollection _usersWhoKicked;
        public UserCollection UsersWhoKicked {
            get {
                if (_usersWhoKicked == null) {
                    Query query = new Query(StoryKick.Schema, User.UserIDColumn, StoryKick.StoryKickIDColumn).WHERE(StoryKick.Columns.StoryID, this.StoryID);

                    IDataReader dataReader = query.ExecuteReader();
                    List<int> userIDs = new List<int>();

                    while (dataReader.Read()) {
                        userIDs.Add(dataReader.GetInt32(0));
                    }

                    dataReader.Close();

                    _usersWhoKicked = UserCache.GetUsers(userIDs);
                }
                return _usersWhoKicked;
            }
        }

        #endregion

        public static Story FetchStoryByIdentifier(string storyIdentifier) {
            return Story.FetchStoryByParameter(Story.Columns.StoryIdentifier, storyIdentifier);
        }

        public static Story FetchStoryByUrl(string url) {
            return Story.FetchStoryByParameter(Story.Columns.Url, url);
        }

        public static Story FetchStoryByParameter(string columnName, object value) {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            StoryCollection t = new StoryCollection();
            t.Load(Story.FetchByParameter(columnName, value));
            if (t.Count == 0)
                return null;
            else
                return t[0];
        }

        public static StoryCollection GetStoriesByIsPublishedAndHostID(bool isPublished, int hostID, int pageIndex, int pageSize) {
            Query query = GetStoryQuery(hostID, isPublished);
            query = query.ORDER_BY(Story.Columns.PublishedOn, "DESC");
            query.PageIndex = pageIndex;
            query.PageSize = pageSize;

            StoryCollection stories = new StoryCollection();
            stories.Load(query.ExecuteReader());
            return stories;
        }

        public static StoryCollection GetPopularStories(int hostID, bool isPublished, StoryListSortBy sortBy, int pageIndex, int pageSize) {
            Query query = GetStoryQuery(hostID, isPublished, GetStartDate(sortBy), DateTime.Now);
            query = query.ORDER_BY(Story.Columns.KickCount, "DESC");
            query.PageIndex = pageIndex;
            query.PageSize = pageSize;
            StoryCollection stories = new StoryCollection();
            stories.Load(query.ExecuteReader());
            return stories;
        }

        public static int GetPopularStoriesCount(int hostID, bool isPublished, StoryListSortBy sortBy) {
            Query query = GetStoryQuery(hostID, isPublished, GetStartDate(sortBy), DateTime.Now);
            return query.GetCount(Story.Columns.StoryID);
        }


        public static int GetStoryCount(int hostID, bool isPublished, DateTime startDate, DateTime endDate) {
            return (int)GetStoryQuery(hostID, isPublished, startDate, endDate).GetCount("StoryID");
        }

        public static int GetStoryCount(int hostID, bool isPublished) {
            Query query = GetStoryQuery(hostID, isPublished);
            return (int)GetStoryQuery(hostID, isPublished).GetCount("StoryID");
        }

        public static StoryCollection GetUserKickedStories(int userID, int hostID, int pageNumber, int pageSize) {
            StoryCollection stories = new StoryCollection();
            stories.Load(SPs.Kick_GetPagedKickedStoriesByUserIDAndHostID(userID, hostID, pageNumber, pageSize).GetReader());
            return stories;
        }

        public static int GetUserKickedStoriesCount(int userID, int hostID) {
            Query query = new Query(StoryKick.Schema).WHERE(StoryKick.Columns.UserID, userID).AND(StoryKick.Columns.HostID, hostID);
            return (int)query.GetCount(StoryKick.Columns.StoryKickID);
        }

        public static StoryCollection GetFriendsKickedStories(int userID, int hostID, int pageNumber, int pageSize) {
            StoryCollection stories = new StoryCollection();
            stories.Load(SPs.Kick_GetPagedFriendsKickedStoriesByUserIDAndHostID(userID, hostID, pageNumber, pageSize).GetReader());
            return stories;
        }
        public static StoryCollection GetFriendsSubmittedStories(int userID, int hostID, int pageNumber, int pageSize) {
            StoryCollection stories = new StoryCollection();
            stories.Load(SPs.Kick_GetPagedFriendsSubmittedStoriesByUserIDAndHostID(userID, hostID, pageNumber, pageSize).GetReader());
            return stories;
        }
        public static int GetFriendsKickedStoriesCount(int userID, int hostID) {
            SubSonic.StoredProcedure sp = SPs.Kick_GetPagedFriendsKickedStoriesByUserIDAndHostIDCount(userID, hostID, null);
            sp.Execute();
            int recordCount = int.Parse(sp.OutputValues[0].ToString());
            return recordCount;
        }
        public static int GetFriendsSubmittedStoriesCount(int userID, int hostID) {
            SubSonic.StoredProcedure sp = SPs.Kick_GetPagedFriendsSubmittedStoriesByUserIDAndHostIDCount(userID, hostID, null);
            sp.Execute();
            int recordCount = int.Parse(sp.OutputValues[0].ToString());
            return recordCount;
        }

        public static StoryCollection GetUserSubmittedStories(int userID, int hostID, int pageNumber, int pageSize) {
            StoryCollection stories = new StoryCollection();
            stories.Load(SPs.Kick_GetPagedSubmittedStoriesByUserIDAndHostID(userID, hostID, pageNumber, pageSize).GetReader());
            return stories;
        }

        public static int GetUserSubmittedStoriesCount(int userID, int hostID) {
            Query query = new Query(Story.Schema).WHERE(Story.Columns.UserID, userID).AND(Story.Columns.HostID, hostID);
            return (int)query.GetCount(Story.Columns.StoryID);
        }

        public static StoryCollection GetStoriesByCategoryKickedStateAndHostID(short categoryID, bool isPublished, int hostID, int pageIndex, int pageSize) {
            Query query = GetStoryQuery(hostID, isPublished, categoryID);
            query = query.ORDER_BY(Story.Columns.PublishedOn, "DESC");
            query.PageIndex = pageIndex;
            query.PageSize = pageSize;
            StoryCollection stories = new StoryCollection();
            stories.Load(query.ExecuteReader());
            return stories;
        }

        public static int GetStoriesByCategoryKickedStateAndHostID_Count(short categoryID, bool isPublished, int hostID) {
            return (int)GetStoryQuery(hostID, isPublished, categoryID).GetCount(Story.Columns.StoryID);
        }

        public static StoryCollection GetTaggedStories(int? tagID, int hostID, int pageNumber, int pageSize) {
            StoryCollection stories = new StoryCollection();
            
            if(tagID.HasValue)
                stories.Load(SPs.Kick_GetPagedStoriesByTagIDAndHostID(tagID, hostID, pageNumber, pageSize).GetReader());
            return stories;
        }
        public static int GetTaggedStoryCount(int? tagID, int hostID) {
            if (!tagID.HasValue)
                return 0;

            Query query = new Query(StoryUserHostTag.Schema).WHERE(StoryUserHostTag.Columns.TagID, tagID).AND(StoryUserHostTag.Columns.HostID, hostID);
            return (int)query.GetCount(StoryUserHostTag.Columns.StoryUserHostTagID);
        }

        public static StoryCollection GetUserTaggedStories(int? tagID, int userID, int hostID, int pageNumber, int pageSize) {
            StoryCollection stories = new StoryCollection();
            if (tagID.HasValue) {
                stories.Load(SPs.Kick_GetPagedStoriesByTagIDAndHostIDAndUserID(tagID, hostID, userID, pageNumber, pageSize).GetReader());
            }
            return stories;
        }

        public static int GetUserTaggedStoryCount(int? tagID, int userID, int hostID) {
            if (!tagID.HasValue)
                return 0;

            Query query = new Query(StoryUserHostTag.Schema).WHERE(StoryUserHostTag.Columns.TagID, tagID).AND(StoryUserHostTag.Columns.HostID, hostID).AND(StoryUserHostTag.Columns.UserID, userID);
            return (int)query.GetCount(StoryUserHostTag.Columns.StoryUserHostTagID);
        }
        public static StoryCollection GetStoriesByIsPublishedAndHostIDAndPublishedDate(int hostID, bool isPublished, DateTime startDate, DateTime endDate) {
            StoryCollection stories = new StoryCollection();
            stories.Load(GetStoryQuery(hostID, isPublished, startDate, endDate).ExecuteReader());
            return stories;
        }

        private static Query GetStoryQuery(int hostID) {
            return new Query(Story.Schema).WHERE(Story.Columns.HostID, hostID).AND(Story.Columns.IsSpam, false);
        }

        private static Query GetStoryQuery(int hostID, bool isPublished) {
            return GetStoryQuery(hostID).AND(Story.Columns.IsPublishedToHomepage, isPublished);
        }

        private static Query GetStoryQuery(int hostID, bool isPublished, short categoryID) {
            return GetStoryQuery(hostID).AND(Story.Columns.IsPublishedToHomepage, isPublished).AND(Story.Columns.CategoryID, categoryID);
        }

        private static Query GetStoryQuery(int hostID, bool isPublished, DateTime startDate, DateTime endDate) {
            Query query = GetStoryQuery(hostID, isPublished);
            if (isPublished)
                query = query.AddBetweenValues("PublishedOn", startDate, endDate);
            else
                query = query.AddBetweenValues("CreatedOn", startDate, endDate);
            return query;
        }

        private static DateTime GetStartDate(StoryListSortBy sortBy) {
            switch (sortBy) {
                case StoryListSortBy.Today:
                    return DateTime.Now.AddDays(-1);
                case StoryListSortBy.PastWeek:
                    return DateTime.Now.AddDays(-7);
                case StoryListSortBy.PastTenDays:
                    return DateTime.Now.AddDays(-10);
                case StoryListSortBy.PastMonth:
                    return DateTime.Now.AddDays(-31);
                case StoryListSortBy.PastYear:
                    return DateTime.Now.AddDays(-365);
                default:
                    throw new ArgumentException("Invalid sortBy");
            }
        }
    }
}
