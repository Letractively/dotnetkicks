
function Ajax_KickStory(storyID, isKick, success, failure) {
    StartLoading();
    dojo.io.bind({
        url: AJAX_BASE_URL + "/kickit/" + storyID + "/" + isKick,
        load: function(type, data, evt) { success(storyID, data); },
        error: function(type, data, evt) { failure(); },
        mimetype: "text/plain"
    });
}

function Ajax_GetUserStoryTags(storyID, success, failure) {
    StartLoading();
    dojo.io.bind({
        url: AJAX_BASE_URL + "/getuserstorytags/" + storyID,
        load: function(type, data, evt) { success(storyID, data); },
        error: function(type, data, evt) { failure(); },
        mimetype: "text/plain"
    });
}

function Ajax_AddUserStoryTags(storyID, tagInput, success, failure) {
    StartLoading();
    dojo.io.bind({
        url: AJAX_BASE_URL + "/adduserstorytags/" + storyID + "?tags=" + escape(tagInput),
        load: function(type, data, evt) { success(storyID, data); },
        error: function(type, data, evt) { failure(); },
        mimetype: "text/plain"
    });
}

function Ajax_RemoveUserStoryTag(storyID, tagID, success, failure) {
    StartLoading();
    dojo.io.bind({
        url: AJAX_BASE_URL + "/removeuserstorytag/" + storyID + "/" + tagID,
        load: function(type, data, evt) { success(storyID, tagID, data); },
        error: function(type, data, evt) { failure(); },
        mimetype: "text/plain"
    });
}