<%@ WebHandler Language="C#" Class="MainFeed" %>

using System;
using System.Web;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Controls;

public class MainFeed : JavaScriptFeedHandler {
    protected override void GetStoryData(HttpContext context) {
        this._stories = StoryCache.GetAllStories(true, this._hostProfile.HostID, 1, 25);
    }
}