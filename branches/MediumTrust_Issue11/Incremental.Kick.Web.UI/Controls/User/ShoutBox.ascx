<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoutBox.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ShoutBox" %>



<script type="text/javascript">
    var forUsername = "<%= KickPage.UrlParameters.UserIdentifier %>";
    var chatID = <%= this.JavaScriptChatID %>;
    var lastReceivedShoutID = <%= this.MostRecentShoutID %>;

    function addShout() {
        StartLoading();
        ajaxServices.addShout($("#shout_message").val(), forUsername, chatID, lastReceivedShoutID, addShout_complete);
    }
    function addShout_complete(response) {
        $("#shout_message").val("");
        $("#shout_message").focus();
        addShoutsToList(response.result);
        FinishLoading();
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
        addShoutsToList(response.result);
        setTimeout("getDeltaShouts()", 5000); //TODO: GJ: set the refresh time based on how recent the last shout was
    }
    
    function addShoutsToList(response) {
        if(response.latestShout != null) {
            if(response.latestShout.shoutID > lastReceivedShoutID) {
                $("#shoutList").prepend(response.html);
                lastReceivedShoutID = response.latestShout.shoutID;
            }          
         }
    }
    
    $(function() {
         setTimeout("getDeltaShouts()", 5000)
    });
   
</script>

<h2>Shoutbox</h2>
<asp:Panel ID="SaySomethingPanel" runat="server">
<textarea id="shout_message" rows="4" cols="20" style="width: 100%;"></textarea><br />
<input type="button" id="Button1" value="Shout It!" onclick='addShout();' /> <span style="font-size:smaller"><a href="javascript:;" onclick="refreshShoutbox()">(refresh)</a></span>
</asp:Panel>

<Kick:ShoutList id="ShoutList" runat="server" renderContainer="true" />


