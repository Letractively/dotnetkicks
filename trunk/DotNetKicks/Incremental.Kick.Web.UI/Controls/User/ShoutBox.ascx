<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoutBox.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ShoutBox" %>



<script type="text/javascript">
    var forUsername = "<%= KickPage.UrlParameters.UserIdentifier %>";
    var chatID = <%= this.JavaScriptChatID %>;
    var lastReceivedShoutID = <%= this.MostRecentShoutID %>;
    var locked = false;

    function addShout() {
        locked = true;
        StartLoading();
        ajaxServices.addShout($("#shout_message").val(), forUsername, chatID, lastReceivedShoutID, addShout_complete);
    }
    function addShout_complete(response) {
        $("#shout_message").val("");
        $("#shout_message").focus();
        addShoutsToList(response.result);
        FinishLoading();
        locked = false;
    }
    
    function refreshShoutbox() {
        StartLoading();
        ajaxServices.getDeltaShouts(forUsername, chatID, lastReceivedShoutID, refreshShoutbox_complete);
    }
    function refreshShoutbox_complete(response) {
        addShoutsToList(response.result);
        FinishLoading();       
    }
    
    
    function getDeltaShouts() {
        ajaxServices.getDeltaShouts(forUsername, chatID, lastReceivedShoutID, getDeltaShouts_complete);
    }
    
    function getDeltaShouts_complete(response) { 
        if(!locked)    
            addShoutsToList(response.result);
        setTimeout("getDeltaShouts()", 5000); //TODO: GJ: set the refresh time based on how recent the last shout was
    }
    
    function addShoutsToList(shouts) {
        if(shouts.length > 0) {
            var shoutList = $("#shoutList");
            for(i=shouts.length-1; i>=0; i--) {
                var avatarUrl = shouts[i].user.avatarUrl; //TODO :GJ: replace
                var shoutHtml = "<div class='shout'><span class='user'><a href='" + shouts[i].user.profileUrl + "'>";
                if(avatarUrl.length > 0) 
                    shoutHtml += "<img src='" + avatarUrl + "' alt='" + shouts[i].user.username + "' class='userGravatar' height='16' width='16'> ";
                
                shoutHtml += shouts[i].user.username + "</a></span> said";
                shoutHtml +=    "<div class='shoutMessage'>" + shouts[i].message + "</div></div>";

                shoutList.prepend(shoutHtml);
            }
            lastReceivedShoutID = shouts[0].shoutID;
        }
    }
    
    //TODO: GJ: only once the page has loaded
    setTimeout("getDeltaShouts()", 10000)
</script>

<h2>Shoutbox</h2>
<asp:Panel ID="SaySomethingPanel" runat="server">
<textarea id="shout_message" rows="4" cols="20" style="width: 100%;"></textarea><br />
<input type="button" id="Button1" value="Shout It!" onclick='addShout();' /> <span style="font-size:smaller"><a href="#" onclick="refreshShoutbox()">(refresh)</a></span>
</asp:Panel>

<Kick:ShoutList id="ShoutList" runat="server" renderContainer="true" />


