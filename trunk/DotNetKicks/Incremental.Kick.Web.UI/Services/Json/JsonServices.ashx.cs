using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Jayrock.JsonRpc;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Common.Enums;
using System.Collections.Generic;

namespace Incremental.Kick.Web.UI.Services.Json {
    public class JsonServices : KickJsonRpcHandler {

        [JsonRpcMethod("getPopularStories")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList getPopularStories() {
            return getPopularStoriesPaged(1, 50);
        }

        [JsonRpcMethod("getPopularStoriesPaged")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList getPopularStoriesPaged(int pageNumber, int pageSize) {
            return getPopularStoriesPagedAndSorted(pageNumber, pageSize, StoryListSortBy.PastYear);
        }

        [JsonRpcMethod("getPopularStoriesPagedAndSorted")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList getPopularStoriesPagedAndSorted(int pageNumber, int pageSize, StoryListSortBy sortBy) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetPopularStories(this.HostProfile.HostID, true, sortBy, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetPopularStoriesCount(this.HostProfile.HostID, true, sortBy);
            return storyList;
        }

        [JsonRpcMethod("getUpcomingStories")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUpcomingStories() {
            return GetUpcomingStoriesPaged(1, 50);
        }

        [JsonRpcMethod("getUpcomingStoriesPaged")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUpcomingStoriesPaged(int pageNumber, int pageSize) {
            return GetUpcomingStoriesPagedAndSorted(pageNumber, pageSize, StoryListSortBy.PastYear);
        }

        [JsonRpcMethod("getUpcomingStoriesPagedAndSorted")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUpcomingStoriesPagedAndSorted(int pageNumber, int pageSize, StoryListSortBy sortBy) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetPopularStories(this.HostProfile.HostID, false, sortBy, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetPopularStoriesCount(this.HostProfile.HostID, false, sortBy);
            return storyList;
        }
    }
}
