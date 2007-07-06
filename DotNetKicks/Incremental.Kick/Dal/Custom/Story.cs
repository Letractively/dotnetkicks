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

        public static StoryCollection GetPopularStories(int hostID, StoryListSortBy sortBy, int pageIndex, int pageSize) {
            Query query = GetStoryQuery(hostID, true, GetStartDate(sortBy), DateTime.Now);
            query = query.ORDER_BY(Story.Columns.PublishedOn, "DESC");
            query.PageIndex = pageIndex;
            query.PageSize = pageSize;
            StoryCollection stories = new StoryCollection();
            stories.Load(query.ExecuteReader());
            return stories;
        }

        public static int GetPopularStoriesCount(int hostID, StoryListSortBy sortBy) {
            Query query = GetStoryQuery(hostID, true, GetStartDate(sortBy), DateTime.Now);
            query = query.ORDER_BY(Story.Columns.PublishedOn, "DESC");
            return query.GetCount(Story.Columns.StoryID);
        }
        
        public static int GetStoryCount(int hostID, bool isPublished, DateTime startDate, DateTime endDate) {
            return (int)GetStoryQuery(hostID, isPublished, startDate, endDate).GetCount("StoryID");
        }

        public static int GetStoryCount(int hostID, bool isPublished) {
            Query query = new Query(Story.Schema).WHERE("HostID", hostID).AND("IsPublished", isPublished);
            return (int)GetStoryQuery(hostID, isPublished).GetCount("StoryID");
        }

        public static int GetStoryCount(int tagID, int hostID) {
            return 0; //TODO: GJ: return the story count for a tag and host
        }

        public static StoryCollection GetUserKickedStories(int userID, int hostID, int pageNumber, int pageSize) {
            return new StoryCollection(); //TODO: GJ: implement
        }

        //TODO: GJ: rename to GetUserKickedStoriesCount?
        public static int GetStoryKicksByUserIDAndHostID_Count(int userID, int hostID) {
            return 0; //TODO: GJ: implement
        }

        private static Query GetStoryQuery(int hostID) {
            return new Query(Story.Schema).WHERE(Story.Columns.HostID, hostID);
        }
        
        private static Query GetStoryQuery(int hostID, bool isPublished) {
            return GetStoryQuery(hostID).AND(Story.Columns.IsPublished, isPublished);
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

        internal static StoryCollection GetStoriesByCategoryKickedStateAndHostID(short categoryID, bool isKicked, int hostID, int pageNumber, int pageSize) {
            throw new Exception("The method or operation is not implemented.");
        }

        internal static StoryCollection GetTaggedStories(string tagIdentifier, int hostID, int pageNumber, int pageSize) {
            throw new Exception("The method or operation is not implemented.");
        }

        internal static StoryCollection GetUserTaggedStories(string tagIdentifier, int userID, int hostID, int pageNumber, int pageSize) {
            throw new Exception("The method or operation is not implemented.");
        }

        internal static int? GetUserTaggedStoryCount(string tagIdentifier, int userID, int hostID) {
            throw new Exception("The method or operation is not implemented.");
        }

        internal static int? GetStoriesByCategoryKickedStateAndHostID_Count(short categoryID, bool isKicked, int hostID) {
            throw new Exception("The method or operation is not implemented.");
        }

        internal static int? GetTaggedStoryCount(string tagIdentifier, int hostID) {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
