function Delete(storyID) {
    if(confirm("Are you sure you want to delete this story?")) {
        StartLoading();
        ajaxServices.moderatorMarkAsSpam(storyID, function(response) { DeleteStory_End(storyID); });
    }
}

function UnDelete(storyID) {
    if(confirm("Are you sure you want to undelete this story?")) {
        StartLoading();
        ajaxServices.moderatorUnMarkAsSpam(storyID, function(response) { FinishLoading(); });
    }
}

function DeleteStory_End(storyID) {
    alert("The story has been queued for deletion.");
    shiftOpacity('m_' + storyID, 1000);
    FinishLoading();
}