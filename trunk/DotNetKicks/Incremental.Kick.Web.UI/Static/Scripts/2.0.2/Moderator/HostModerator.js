function Delete(storyID) {
    if(confirm("Are you sure you want to delete this story?")) {
        StartLoading();
        ajaxServices.moderatorMarkAsSpam(storyID, function(response) { DeleteStory_End(storyID); });
    }
   }

function Ban(userID) {
	if (confirm("Are you sure you want to ban this user?")) {
		StartLoading();
		ajaxServices.moderatorBanUser(userID, function(response) { BanUser_End(userID); });
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

function BanUser_End(userID) {
	alert("The user has been banned.");
    shiftOpacityByClass('u_' + userID, 1000);
	FinishLoading();
}
