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
        [JsonRpcMethod("getFrontPageStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most popular pubished stories from the last 30 days")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetFrontPageStories() {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetAllStories(true, this.HostProfile.HostID, 1, 16).ToDto();
            storyList.Total = StoryCache.GetStoryCount(this.HostProfile.HostID, true);
            return storyList;
       } 

        [JsonRpcMethod("getPopularStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most popular pubished stories from the last 30 days")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList getPopularStories() {
            return getPopularStoriesPaged(1, 16);
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
            return GetUpcomingStoriesPaged(1, 16);
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

        [JsonRpcMethod("getUserKickedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories kicked by a user")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUserKickedStories(string username) {
            return GetUserKickedStoriesPaged(username, 1, 16);
        }

        [JsonRpcMethod("getUserKickedStoriesPaged", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most recent stories kicked by a user")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUserKickedStoriesPaged(string username, int pageNumber, int pageSize) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetUserKickedStories(username, this.HostProfile.HostID, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetUserKickedStoriesCount(username, this.HostProfile.HostID);
            return storyList;
        }

        [JsonRpcMethod("getUserSubmittedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories submitted by a user")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUserSubmittedStories(string username) {
            return GetUserSubmittedStoriesPaged(username, 1, 16);
        }

        [JsonRpcMethod("getUserSubmittedStoriesPaged", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most recent stories submitted by a user")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUserSubmittedStoriesPaged(string username, int pageNumber, int pageSize) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetUserSubmittedStories(username, this.HostProfile.HostID, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetUserSubmittedStoriesCount(username, this.HostProfile.HostID);
            return storyList;
        }

        [JsonRpcMethod("getUserFriendsKickedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories kicked by a user's friends")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUserFriendsKickedStories(string username) {
            return GetUserFriendsKickedStoriesPaged(username, 1, 16);
        }

        [JsonRpcMethod("getUserFriendsKickedStoriesPaged", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most recent stories kicked by a user's friends")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUserFriendsKickedStoriesPaged(string username, int pageNumber, int pageSize) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetFriendsKickedStories(username, this.HostProfile.HostID, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetFriendsKickedStoriesCount(username, this.HostProfile.HostID);
            return storyList;
        }

        [JsonRpcMethod("getUserFriendsSubmittedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories submitted by a user's friends")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUserFriendsSubmittedStories(string username) {
            return GetUserFriendsSubmittedStoriesPaged(username, 1, 16);
        }

        [JsonRpcMethod("getUserFriendsSubmittedStoriesPaged", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most recent stories submitted by a user's friends")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetUserFriendsSubmittedStoriesPaged(string username, int pageNumber, int pageSize) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetFriendsSubmittedStories(username, this.HostProfile.HostID, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetFriendsSubmittedStoriesCount(username, this.HostProfile.HostID);
            return storyList;
        }

        [JsonRpcMethod("getTaggedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories tagged with a tag")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetTaggedStories(string tag) {
            return GetTaggedStoriesPaged(tag, 1, 16);
        }

        [JsonRpcMethod("getTaggedStoriesPaged", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the recent stories tagged with a tag")]
        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList GetTaggedStoriesPaged(string tag, int pageNumber, int pageSize) {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storyList = StoryCache.GetTaggedStories(tag, this.HostProfile.HostID, pageNumber, pageSize).ToDto();
            storyList.Total = StoryCache.GetTaggedStoryCount(tag, this.HostProfile.HostID);
            return storyList;
        }
    }
}
