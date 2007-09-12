using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.Web.Helpers {
    public class UrlParametersHelper {

        public static UrlParameters GetUrlParameters(HttpRequest request) {
            return GetUrlParameters(request, HostHelper.GetHostName(request.Url));
        }


        public static UrlParameters GetUrlParameters(HttpRequest request, string hostName) {
            UrlParameters urlParameters = new UrlParameters(hostName);

            //TODO: (GJ): use contant values for these
            if (!String.IsNullOrEmpty(request["useridentifier"]))
                urlParameters.UserIdentifier = request["useridentifier"].Replace("/", "");

            if (!String.IsNullOrEmpty(request["categoryidentifier"]))
                urlParameters.CategoryIdentifier = request["categoryidentifier"].Replace("/", "");

            if (!String.IsNullOrEmpty(request["storyidentifier"]))
                urlParameters.StoryIdentifier = request["storyidentifier"].Replace("/", "");

            if (!String.IsNullOrEmpty(request["tagidentifier"]))
                urlParameters.TagIdentifier = request["tagidentifier"].Replace("/", "");

            if (!String.IsNullOrEmpty(request["pagenumber"]))
                urlParameters.PageNumber = int.Parse(request["pagenumber"].Replace("/", ""));

            if (!String.IsNullOrEmpty(request["pagesize"]))
                urlParameters.PageSize = int.Parse(request["pagesize"].Replace("/", ""));

            if (!String.IsNullOrEmpty(request["skin"]))
                urlParameters.Skin = request["skin"];

            if (!String.IsNullOrEmpty(request["storyListSortBy"]))
                urlParameters.StoryListSortBy = (StoryListSortBy)System.Enum.Parse(typeof(StoryListSortBy), request["storyListSortBy"], true);

            if (!String.IsNullOrEmpty(request["upcomingStoryListSortBy"]))
                urlParameters.StoryListSortBy = (StoryListSortBy)System.Enum.Parse(typeof(StoryListSortBy), request["upcomingStoryListSortBy"], true);

            return urlParameters;
        }
    }
}
