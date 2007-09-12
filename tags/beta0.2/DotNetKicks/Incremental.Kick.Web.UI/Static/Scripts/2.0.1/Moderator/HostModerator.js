function Delete(storyID) {
    if(confirm("Are you sure you want to delete this story?")) {
        Ajax_DeleteStory(storyID, DeleteStory_End, Failure);
    }
}

function DeleteStory_End(storyID) {
    alert("The story has been queued for deletion.");
    FinishLoading();
}

function Ajax_DeleteStory(storyID, success, failure) { 
    StartLoading();
    dojo.io.bind({
        url: AJAX_BASE_URL + "/moderator/delete/" + storyID,
        load: function(type, data, evt) { success(storyID); },
        error: function(type, data, evt) { failure(); },
        mimetype: "text/plain"
    });
}