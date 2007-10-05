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
using Incremental.Kick.Dal.Entities.Api;

namespace Incremental.Kick.Web.UI.Services.Json {
    public class JsonServices : KickJsonRpcHandler {
        [JsonRpcMethod("getFrontPageStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of recently published stories to the homepage")]
        public ApiPagedList<ApiStory> GetFrontPageStories(int pageNumber, int pageSize) {
            return Story.Api.GetFrontPageStories(this.HostProfile.HostID, pageNumber, pageSize);
        }

        [JsonRpcMethod("getUpcomingPageStories", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of recently submitted stories to the site")]
        public ApiPagedList<ApiStory> GetUpcomingPageStories(int pageNumber, int pageSize) {
            return Story.Api.GetUpcomingPageStories(this.HostProfile.HostID, pageNumber, pageSize);
        }

        [JsonRpcMethod("getPopularStories", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most popular published stories from the last 30 days")]
        public ApiPagedList<ApiStory> GetPopularStories(int pageNumber, int pageSize) {
            return Story.Api.GetPopularStories(this.HostProfile.HostID, pageNumber, pageSize);
        }

        [JsonRpcMethod("getPopularStoriesPagedFromTimePeriod", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most popular published stories from a time period")]
        public ApiPagedList<ApiStory> GetPopularStoriesPagedAndSorted(int pageNumber, int pageSize, StoryListSortBy timePeriod) {
            return Story.Api.GetPopularStoriesPagedAndSorted(this.HostProfile.HostID, pageNumber, pageSize, timePeriod);
        }

        [JsonRpcMethod("getUpcomingStories", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most popular upcoming stories from the last 30 days")]
        public ApiPagedList<ApiStory> GetUpcomingStories(int pageNumber, int pageSize) {
            return Story.Api.GetUpcomingStories(this.HostProfile.HostID, pageNumber, pageSize);
        }

        [JsonRpcMethod("getUpcomingStoriesPagedFromTimePeriod", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most popular upcoming stories from a time period")]
        public ApiPagedList<ApiStory> GetUpcomingStoriesPagedAndSorted(int pageNumber, int pageSize, StoryListSortBy timePeriod) {
            return Story.Api.GetUpcomingStoriesPagedAndSorted(this.HostProfile.HostID, pageNumber, pageSize, timePeriod);
        }

        [JsonRpcMethod("getUserKickedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most recent stories kicked by a user")]
        public ApiPagedList<ApiStory> GetUserKickedStories(string username, int pageNumber, int pageSize) {
            return Story.Api.GetUserKickedStories(this.HostProfile.HostID, username, pageNumber, pageSize);
        }

        [JsonRpcMethod("getUserSubmittedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most recent stories submitted by a user")]
        public ApiPagedList<ApiStory> GetUserSubmittedStories(string username, int pageNumber, int pageSize) {
            return Story.Api.GetUserSubmittedStories(this.HostProfile.HostID, username, pageNumber, pageSize);
        }

        [JsonRpcMethod("getUserFriendsKickedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most recent stories kicked by a user's friends")]
        public ApiPagedList<ApiStory> GetUserFriendsKickedStories(string username, int pageNumber, int pageSize) {
            return Story.Api.GetUserFriendsKickedStories(this.HostProfile.HostID, username, pageNumber, pageSize);
        }

        [JsonRpcMethod("getUserFriendsSubmittedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the most recent stories submitted by a user's friends")]
        public ApiPagedList<ApiStory> GetUserFriendsSubmittedStories(string username, int pageNumber, int pageSize) {
            return Story.Api.GetUserFriendsSubmittedStories(this.HostProfile.HostID, username, pageNumber, pageSize);
        }

        [JsonRpcMethod("getTaggedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a paged list of the recent stories tagged with a tag")]
        public ApiPagedList<ApiStory> GetTaggedStories(string tag, int pageNumber, int pageSize) {
            return Story.Api.GetTaggedStories(this.HostProfile.HostID, tag, pageNumber, pageSize);
        }
    }
}
