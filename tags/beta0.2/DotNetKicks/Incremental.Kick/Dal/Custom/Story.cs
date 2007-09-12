using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Common.Enums;
using SubSonic;

namespace Incremental.Kick.Dal {
    public partial class Story {
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

        /*
        public static StoryCollection GetUpComingStoriesToday(bool isPublished, int hostID, int pageIndex, int pageSize )
        {
            Query query = GetStoryQuery(hostID, isPublished);
            string startDate = DateTime.Now.ToShortDateString();
            string endDate = DateTime.Now.AddDays(1).ToShortDateString();
            query = query.BETWEEN_AND(Story.Columns.CreatedOn, startDate,endDate);
            query = query.ORDER_BY(Story.Columns.KickCount, "DESC");
            query = query.ORDER_BY(Story.Columns.CreatedOn, "DESC");

            query.PageIndex = pageIndex;
            query.PageSize = pageSize;

            string sql = query.GetSql();

            StoryCollection stories = new StoryCollection();
            stories.Load(query.ExecuteReader());
            return stories;
        }

        public static StoryCollection GetUpComingStoriesThisWeek(bool isPublished, int hostID, int pageIndex, int pageSize )
        {
            Query query = GetStoryQuery(hostID, isPublished);
            DateTime startDate = DateTime.Now.AddDays(-7);
            DateTime endDate = DateTime.Now;
            query = query.BETWEEN_AND(Story.Columns.CreatedOn, startDate, endDate);
            query = query.ORDER_BY(Story.Columns.KickCount, "DESC");
            query = query.ORDER_BY(Story.Columns.CreatedOn, "DESC");
            query.PageIndex = pageIndex;
            query.PageSize = pageSize;

            string sql = query.Inspect();

            StoryCollection stories = new StoryCollection();
            stories.Load(query.ExecuteReader());
            return stories;
        }*/


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

        public static StoryCollection GetTaggedStories(int tagID, int hostID, int pageNumber, int pageSize) {
            StoryCollection stories = new StoryCollection();
            stories.Load(SPs.Kick_GetPagedStoriesByTagIDAndHostID(tagID, hostID, pageNumber, pageSize).GetReader());
            return stories;
        }
        public static int GetTaggedStoryCount(int tagID, int hostID) {
            Query query = new Query(StoryUserHostTag.Schema).WHERE(StoryUserHostTag.Columns.TagID, tagID).AND(StoryUserHostTag.Columns.HostID, hostID);
            return (int)query.GetCount(StoryUserHostTag.Columns.StoryUserHostTagID);
        }

        public static StoryCollection GetUserTaggedStories(int tagID, int userID, int hostID, int pageNumber, int pageSize) {
            StoryCollection stories = new StoryCollection();
            stories.Load(SPs.Kick_GetPagedStoriesByTagIDAndHostIDAndUserID(tagID, hostID, userID, pageNumber, pageSize).GetReader());
            return stories;
        }

        public static int GetUserTaggedStoryCount(int tagID, int userID, int hostID) {
            Query query = new Query(StoryUserHostTag.Schema).WHERE(StoryUserHostTag.Columns.TagID, tagID).AND(StoryUserHostTag.Columns.HostID, hostID).AND(StoryUserHostTag.Columns.UserID, userID);
            return (int)query.GetCount(StoryUserHostTag.Columns.StoryUserHostTagID);
        }
        public static StoryCollection GetStoriesByIsPublishedAndHostIDAndPublishedDate(int hostID, bool isPublished, DateTime startDate, DateTime endDate) {
            StoryCollection stories = new StoryCollection();
            stories.Load(GetStoryQuery(hostID, isPublished, startDate, endDate).ExecuteReader());
            return stories;
        }

        private static Query GetStoryQuery(int hostID) {
            return new Query(Story.Schema).WHERE(Story.Columns.HostID, hostID);
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
