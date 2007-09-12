<%@ WebHandler Language="C#" Class="CategoryFeed" %>

using System;
using System.Web;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Controls;

public class CategoryFeed : JavaScriptFeedHandler {
    protected override void GetStoryData(HttpContext context) {
        string categoryIdentifier = context.Request["categoryidentifier"];
        short categoryID = CategoryCache.GetCategoryByIdentifier(categoryIdentifier, this._hostProfile.HostID).CategoryID;
        this._stories = StoryCache.GetCategoryStories(categoryID, true, this._hostProfile.HostID, 1, 25);
    }
}