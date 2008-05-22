
function ToggleStoryTags(storyID) {
    var storyTagsElement = GetStoryTagsElement(storyID);
    
    if(IsElementVisible(storyTagsElement)) {
        HideElement(storyTagsElement);
    } else {
        ShowElement(storyTagsElement);
        
        if(IS_USER_AUTHENTICATED) {
            GetStoryTagInputElement(storyID).focus();       
            if(IsElementHidden(GetEditableTagList(storyID))) {
                var editableTagListElement = GetEditableTagList(storyID);
                editableTagListElement.innerHTML = "retreiving your tags....";
                ShowElement(editableTagListElement);
                Ajax_GetUserStoryTags(storyID, GetUserStoryTags_End, Failure);
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
        GetAddTagButton(storyID).disabled = true;
        Ajax_AddUserStoryTags(storyID, tagInput, AddUserStoryTags_End, Failure);       
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
    Ajax_RemoveUserStoryTag(storyID, tagID, RemoveUserStoryTag_End, Failure);
}

function RemoveUserStoryTag_End(storyID, tagID) {
    GetEditableTagElement(storyID, tagID).innerHTML = "";
    GetStoryTagInputElement(storyID).focus(); 
    FinishLoading();
}

function GetEditableTagElement(storyID, tagID) { return document.getElementById(storyID + "_" + tagID + "_EditableTag"); }
function GetAddTagButton(storyID) { return document.getElementById(storyID + "_SubmitNewTags"); }


