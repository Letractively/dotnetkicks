using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.Dal
{
    public partial class Story
    {
        public static Story FetchStoryByIdentifier(string storyIdentifier)
        {
            return Story.FetchStoryByParemeter(Story.Columns.StoryIdentifier, storyIdentifier);
        }

        public static Story FetchStoryByParemeter(string columnName, object value)
        {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            StoryCollection t = new StoryCollection();
            t.Load(Story.FetchByParameter(columnName, value));
            return t[0];
        }

        public static StoryCollection GetStoriesByIsKickedAndHostID(bool isKicked, int hostID, int pageNumber, int pageSize) {
            throw new NotImplementedException();
        }

        public static StoryCollection GetPopularStories(int hostID, StoryListSortBy sortBy, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public static int GetPopularStoriesCount(int hostID, StoryListSortBy sortBy) {
            throw new NotImplementedException();
        }
    }
}
