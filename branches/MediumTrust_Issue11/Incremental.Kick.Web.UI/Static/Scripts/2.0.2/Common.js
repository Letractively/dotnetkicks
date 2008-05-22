
function KickIt(storyID, isAuthenticated) {
    if(isAuthenticated) {
        StartLoading();
        HideElement(GetStoryKickItElement(storyID));
        ajaxServices.kickStory(storyID, true, function(response) { KickIt_End(storyID, response.result); });
    } else {
        document.location = WEB_BASE_URL + "login?ReturnUrl=" + document.URL;
    }
}

function KickIt_End(storyID, kickCount) {
    SetStoryKickCountText(storyID, kickCount);
    ShowElement(GetStoryUnKickItElement(storyID));
    FinishLoading();
}

function UnKickIt(storyID) {
    StartLoading();
    HideElement(GetStoryUnKickItElement(storyID));
    ajaxServices.kickStory(storyID, false, function(response) { UnKickIt_End(storyID, response.result); });
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

function ReportAsSpam(storyID) {
    StartLoading();
    ajaxServices.reportAsSpam(storyID, function(response) { ReportAsSpam_End(storyID); });
}

function ReportAsSpam_End(storyID) {
    alert("Thanks, the story has been flagged as potential spam and may be removed from the site in the near future.");
    FinishLoading();
}


function GetStoryKickCountElement(storyID) { return document.getElementById(storyID + "_KickCount"); }
function GetStoryKickItElement(storyID) { return document.getElementById(storyID + "_KickIt"); }
function GetStoryUnKickItElement(storyID) { return document.getElementById(storyID + "_UnKickIt"); }
function GetStoryTagsElement(storyID) { return document.getElementById(storyID + "_StoryTags"); }
function GetStoryTagInputElement(storyID) { return document.getElementById(storyID + "_TagInput"); }
function GetLoadingElement() { return document.getElementById("LoadingSpan"); }
function GetEditableTagList(storyID) { return document.getElementById(storyID + "_EditableTagList"); }
function GetEditableTagListNoTags(storyID) { return document.getElementById(storyID + "_EditableTagListNoTags"); }

function plusViewCount(storyID) { ajaxServices.viewCount(storyID); }
//common:

function opacity(id, opacStart, opacEnd, millisec) {
    //speed for each frame
    var speed = Math.round(millisec / 100);
    var timer = 0;
    //determine the direction for the blending, if start and end are the same nothing happens
    if(opacStart > opacEnd) {
        for(i = opacStart; i >= opacEnd; i--) {
            setTimeout("changeOpac(" + i + ",'" + id + "')",(timer * speed));
            timer++;
        }
    } else if(opacStart < opacEnd) {
        for(i = opacStart; i <= opacEnd; i++)
            {
            setTimeout("changeOpac(" + i + ",'" + id + "')",(timer * speed));
            timer++;
        }
    }
}

//change the opacity for different browsers
function changeOpac(opacity, id) {
    var object = document.getElementById(id).style;
    object.opacity = (opacity / 100);
    object.MozOpacity = (opacity / 100);
    object.KhtmlOpacity = (opacity / 100);
    object.filter = "alpha(opacity=" + opacity + ")";
} 

function shiftOpacity(id, millisec) {
    opacity(id, 100, 0, millisec);
    setTimeout("HideDiv('" + id + "')",(millisec));
} 

function ReportAsSpam(storyID) {
    StartLoading();
    ajaxServices.reportAsSpam(storyID, function(response) { ReportAsSpam_End(storyID); });
}

function ReportAsSpam_End(storyID) {
    alert("Thanks, the media has been flagged as potential spam and may be removed from the site in the near future.");
    shiftOpacity('m_' + storyID, 1000);
    FinishLoading();
}

function HideDiv(divID) {
	var d = document.getElementById('PopularStoryListDiv');
	var olddiv = document.getElementById(divID);
	d.removeChild(olddiv);
}

function StartLoading() {
    ShowElement(GetLoadingElement());
}

function FinishLoading() {
    HideElement(GetLoadingElement());
}

function getElementsByClass(searchClass,node,tag) {
	var classElements = new Array();
	if ( node == null )
		node = document;
	if ( tag == null )
		tag = '*';
	var els = node.getElementsByTagName(tag);
	var elsLen = els.length;
	var pattern = new RegExp('(^|\\s)'+searchClass+'(\\s|$)');
	for (i = 0, j = 0; i < elsLen; i++) {
		if ( pattern.test(els[i].className) ) {
			classElements[j] = els[i];
			j++;
		}
	}
	return classElements;
}


function HideElement(element) { SwitchCssClass(element, "Visible", "Hidden"); }
function ShowElement(element) { SwitchCssClass(element, "Hidden", "Visible"); }

function SwitchCssClass(element, oldClass, newClass) {
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

function AddCssClass(element, cssClassName) {
    SwitchCssClass(element, cssClassName, "");
    
    element.className = element.className + " " + cssClassName; 
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
var ajaxServices;
$(function() {
   ajaxServices = new AjaxServices();
});
