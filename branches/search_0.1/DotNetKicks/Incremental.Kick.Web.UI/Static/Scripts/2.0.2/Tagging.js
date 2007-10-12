
function ToggleStoryTags(storyID) {
    var storyTagsElement = GetStoryTagsElement(storyID);
    
    if(IsElementVisible(storyTagsElement)) {
        HideElement(storyTagsElement);
    } else {
        ShowElement(storyTagsElement);
        
        if(IS_USER_AUTHENTICATED) {
            GetStoryTagInputElement(storyID).focus();       
            if(IsElementHidden(GetEditableTagList(storyID))) {
                StartLoading();
                var editableTagListElement = GetEditableTagList(storyID);
                editableTagListElement.innerHTML = "retreiving your tags....";
                ShowElement(editableTagListElement);
                ajaxServices.getUserStoryTags(storyID, function(response) { GetUserStoryTags_End(storyID, response.result); });    
            }
        }
    }
}

function GetUserStoryTags_End(storyID, userTagsHtml) {
    ShowElement(GetEditableTagList(storyID));
    var editableTagListElement = GetEditableTagList(storyID);
    editableTagListElement.innerHTML = userTagsHtml;
    FinishLoading();
    
}

function AddUserStoryTags(storyID) {
    var tagInput = GetStoryTagInputElement(storyID).value;
    if(tagInput.length > 0) {
        StartLoading();
        GetAddTagButton(storyID).disabled = true;
        ajaxServices.tagStory(storyID, tagInput, function(response) { AddUserStoryTags_End(storyID, response.result); });    
    }
}

function AddUserStoryTags_End(storyID, userTagsHtml) {
    var editableTagListElement = GetEditableTagList(storyID);
    editableTagListElement.innerHTML += userTagsHtml;
    
    var tagInput = GetStoryTagInputElement(storyID);
    tagInput.value = "";
    GetStoryTagInputElement(storyID).focus();
    GetAddTagButton(storyID).disabled = false;
    FinishLoading();
}

function RemoveUserStoryTag(storyID, tagID) {
    StartLoading();
    ajaxServices.unTagStory(storyID, tagID, function(response) { RemoveUserStoryTag_End(storyID, tagID); });    
}

function RemoveUserStoryTag_End(storyID, tagID) {
    GetEditableTagElement(storyID, tagID).innerHTML = "";
    GetStoryTagInputElement(storyID).focus(); 
    FinishLoading();
}

function GetEditableTagElement(storyID, tagID) { return document.getElementById(storyID + "_" + tagID + "_EditableTag"); }
function GetAddTagButton(storyID) { return document.getElementById(storyID + "_SubmitNewTags"); }


