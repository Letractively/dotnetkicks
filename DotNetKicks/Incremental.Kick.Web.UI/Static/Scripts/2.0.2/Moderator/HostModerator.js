function Delete(storyID) {
    if(confirm("Are you sure you want to delete this story?")) {
        StartLoading();
        ajaxServices.moderatorMarkAsSpam(storyID, function(response) { DeleteStory_End(storyID); });
    }
}

function DeleteStory_End(storyID) {
    alert("The story has been queued for deletion.");
    FinishLoading();
}