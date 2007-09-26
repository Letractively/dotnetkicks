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

        [JsonRpcMethod("getPopularStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most popular pubished stories from the last 30 days")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList getPopularStories() {
            return getPopularStoriesPaged(1, 50);
        }

        [JsonRpcMethod("getPopularStoriesPaged", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most popular pubished stories from the last 30 days")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList getPopularStoriesPaged(int pageNumber, int pageSize) {
            return getPopularStoriesPagedAndSorted(pageNumber, pageSize, StoryListSortBy.PastMonth);
        }

        [JsonRpcMethod("getPopularStoriesPagedFromTimePeriod", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most popular pubished stories from a time period")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList getPopularStoriesPagedAndSorted(int pageNumber, int pageSize, StoryListSortBy timePeriod) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetPopularStories(this.HostProfile.HostID, true, timePeriod, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetPopularStoriesCount(this.HostProfile.HostID, true, timePeriod);
            return storyList;
        }

        [JsonRpcMethod("getUpcomingStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most popular upcoming stories from the last 30 days")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUpcomingStories() {
            return GetUpcomingStoriesPaged(1, 50);
        }

        [JsonRpcMethod("getUpcomingStoriesPaged", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most popular upcoming stories from the last 30 days")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUpcomingStoriesPaged(int pageNumber, int pageSize) {
            return GetUpcomingStoriesPagedAndSorted(pageNumber, pageSize, StoryListSortBy.PastYear);
        }

        [JsonRpcMethod("getUpcomingStoriesPagedFromTimePeriod", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most popular upcoming stories from a time period")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUpcomingStoriesPagedAndSorted(int pageNumber, int pageSize, StoryListSortBy timePeriod) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetPopularStories(this.HostProfile.HostID, false, timePeriod, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetPopularStoriesCount(this.HostProfile.HostID, false, timePeriod);
            return storyList;
        }
    }
}
