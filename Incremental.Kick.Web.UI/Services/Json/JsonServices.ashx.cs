namespace Incremental.Kick.Web.UI.Services.Json {
    
    #region Imports

    using Dal;
    using Jayrock.JsonRpc;
    using Incremental.Kick.Web.Controls;
    using Incremental.Kick.Common.Enums;
    using Incremental.Kick.Dal.Entities.Api;

    #endregion

    public class JsonServices : KickJsonRpcHandler {
        
        private const int defaultPageNumber = 1; // TODO GJ: centralize these defautls?
        private const int defaultPageSize = 16;
        private const StoryListSortBy defaultTimePeriod = StoryListSortBy.PastMonth;

        [JsonRpcMethod("getFrontPageStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of recently published stories to the homepage.")]
        public ApiPagedList<ApiStory> GetFrontPageStories(int? pageNumber, int? pageSize) {
            return Story.Api.GetFrontPageStories(this.HostProfile.HostID, 
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize);
        }

        [JsonRpcMethod("getUpcomingPageStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of recently submitted stories to the site.")]
        public ApiPagedList<ApiStory> GetUpcomingPageStories(int? pageNumber, int? pageSize) {
            return Story.Api.GetUpcomingPageStories(this.HostProfile.HostID,
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize);
        }

        [JsonRpcMethod("getPopularStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most popular published stories (from the last 30 days as the default time period).")]
        public ApiPagedList<ApiStory> GetPopularStories(int? pageNumber, int? pageSize, StoryListSortBy? timePeriod) {
            return Story.Api.GetPopularStoriesPagedAndSorted(this.HostProfile.HostID,
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize, 
                timePeriod ?? defaultTimePeriod);
        }

        [JsonRpcMethod("getUpcomingStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most popular upcoming stories (from the last 30 days as the default time period).")]
        public ApiPagedList<ApiStory> GetUpcomingStories(int? pageNumber, int? pageSize, StoryListSortBy? timePeriod) {
            return Story.Api.GetUpcomingStoriesPagedAndSorted(this.HostProfile.HostID,
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize,
                timePeriod ?? defaultTimePeriod);
        }

        [JsonRpcMethod("getUserKickedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories kicked by a user.")]
        public ApiPagedList<ApiStory> GetUserKickedStories(string username, int? pageNumber, int? pageSize) {
            return Story.Api.GetUserKickedStories(this.HostProfile.HostID, username,
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize);
        }

        [JsonRpcMethod("getUserSubmittedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories submitted by a user.")]
        public ApiPagedList<ApiStory> GetUserSubmittedStories(string username, int? pageNumber, int? pageSize) {
            return Story.Api.GetUserSubmittedStories(this.HostProfile.HostID, username,
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize);
        }

        [JsonRpcMethod("getUserFriendsKickedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories kicked by a user's friends.")]
        public ApiPagedList<ApiStory> GetUserFriendsKickedStories(string username, int? pageNumber, int? pageSize) {
            return Story.Api.GetUserFriendsKickedStories(this.HostProfile.HostID, username,
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize);
        }

        [JsonRpcMethod("getUserFriendsSubmittedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the most recent stories submitted by a user's friends.")]
        public ApiPagedList<ApiStory> GetUserFriendsSubmittedStories(string username, int? pageNumber, int? pageSize) {
            return Story.Api.GetUserFriendsSubmittedStories(this.HostProfile.HostID, username,
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize);
        }

        [JsonRpcMethod("getTaggedStories", Idempotent = true)]
        [JsonRpcHelp("Returns a list of the recent stories tagged with a tag.")]
        public ApiPagedList<ApiStory> GetTaggedStories(string tag, int? pageNumber, int? pageSize) {
            return Story.Api.GetTaggedStories(this.HostProfile.HostID, tag,
                pageNumber ?? defaultPageNumber, pageSize ?? defaultPageSize);
        }
    }
}
