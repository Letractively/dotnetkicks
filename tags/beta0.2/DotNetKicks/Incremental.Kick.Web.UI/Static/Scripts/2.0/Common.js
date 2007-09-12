
function KickIt(storyID, isAuthenticated) {
    if(isAuthenticated) {
        HideElement(GetStoryKickItElement(storyID));
        Ajax_KickStory(storyID, true, KickIt_End, Failure);
    } else {
        document.location = WEB_BASE_URL + "login";
    }
}

function KickIt_End(storyID, kickCount) {
    SetStoryKickCountText(storyID, kickCount);
    ShowElement(GetStoryUnKickItElement(storyID));
    FinishLoading();
}

function UnKickIt(storyID) {
    HideElement(GetStoryUnKickItElement(storyID));
    Ajax_KickStory(storyID, false, UnKickIt_End, Failure);
}

function UnKickIt_End(storyID, kickCount) {
    SetStoryKickCountText(storyID, kickCount);
    ShowElement(GetStoryKickItElement(storyID));
    FinishLoading();
}



function SetStoryKickCountText(storyID, kickCount) {
    if(kickCount != "") {
        GetStoryKickCountElement(storyID).innerHTML = kickCount;
    }
}





function GetStoryKickCountElement(storyID) { return document.getElementById(storyID + "_KickCount"); }
function GetStoryKickItElement(storyID) { return document.getElementById(storyID + "_KickIt"); }
function GetStoryUnKickItElement(storyID) { return document.getElementById(storyID + "_UnKickIt"); }
function GetStoryTagsElement(storyID) { return document.getElementById(storyID + "_StoryTags"); }
function GetStoryTagInputElement(storyID) { return document.getElementById(storyID + "_TagInput"); }
function GetLoadingElement() { return document.getElementById("LoadingSpan"); }
function GetEditableTagList(storyID) { return document.getElementById(storyID + "_EditableTagList"); }
function GetEditableTagListNoTags(storyID) { return document.getElementById(storyID + "_EditableTagListNoTags"); }

//common:

function StartLoading() {
    //ShowElement(GetLoadingElement());
}

function FinishLoading() {
    //HideElement(GetLoadingElement());
}


function HideElement(element) { SwitchClass(element, "Visible", "Hidden"); }
function ShowElement(element) { SwitchClass(element, "Hidden", "Visible"); }

function SwitchClass(element, oldClass, newClass) {
    var regEx = new RegExp(oldClass, "gi");
    element.className = element.className.replace(regEx, "");
        
    regEx = new RegExp(newClass, "gi");
    element.className = element.className.replace(regEx, "");
        
    if(element.className.length > 0) {
        element.className = element.className + " " + newClass; 
    } else {
        element.className = newClass;  
    }
}

function ToggleElement(element) {
    if (element != null) {
        if (IsElementVisible(element)) {
			HideElement(element);
        } else {
			ShowElement(element);               
        }
    }
}

function IsElementVisible(element) {
    return !(element.className.indexOf("Hidden") != -1);
}

function IsElementHidden(element) {
    return !IsElementVisible(element);
}

function Failure() {
    alert("oops, an error has occured.");
}


function JsonToObject(json) {
    return eval('(' + json + ')');
}



function TrimString(rawString) {
  rawString = rawString.replace( /^\s+/g, "" );
  return rawString.replace( /\s+$/g, "" );
}