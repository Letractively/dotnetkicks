
function SetAutoKickCount(storyID) {
    var autoKickCount = prompt('Please enter an auto kick count for this storyID:' + storyID,'6')
    
    if(autoKickCount > -1) {
        Ajax_SetAutoKickCount(storyID, autoKickCount, SetAutoKickCount_End, Failure);
    }
}

function SetAutoKickCount_End(storyID, autoKickCount) {
    alert("The autoKickCount is " + autoKickCount);
}

function Ajax_SetAutoKickCount(storyID, autoKickCount, success, failure) {   
    dojo.io.bind({
        url: AJAX_BASE_URL + "/autokickit/" + storyID + "/" + autoKickCount,
        load: function(type, data, evt) { success(storyID, autoKickCount); },
        error: function(type, data, evt) { failure(); },
        mimetype: "text/plain"
    });
}

