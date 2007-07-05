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

        public static Story FetchStoryByParameter(string columnName, object value) {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            StoryCollection t = new StoryCollection();
            t.Load(Story.FetchByParameter(columnName, value));
            return t[0];
        }

        public static StoryCollection GetStoriesByIsKickedAndHostID(bool isKicked, int hostID, int pageNumber, int pageSize) {
            return new StoryCollection(); //TODO: GJ: implement
        }

        public static StoryCollection GetPopularStories(int hostID, StoryListSortBy sortBy, int pageNumber, int pageSize) {
            return new StoryCollection(); //TODO: GJ: implement
        }

        public static int GetPopularStoriesCount(int hostID, StoryListSortBy sortBy) {
            return 1234; //TODO: GJ: implement
        }

        public static int GetStoryCount(int hostID, bool isPublished, DateTime startDate, DateTime endDate) {
            Query query = new Query(Story.Schema).WHERE("HostID", hostID).AND("IsPublished", isPublished);
            if (isPublished)
                query = query.AddBetweenValues("PublishedOn", startDate, endDate);
            else
                query = query.AddBetweenValues("CreatedOn", startDate, endDate);

            return (int)query.GetCount("StoryID");
        }

        public static int GetStoryCount(int tagID, int hostID) {
            return 0; //TODO: GJ: return the story count for a tag and host
        }

    }
}
