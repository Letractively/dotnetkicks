<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoutBox.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ShoutBox" %>



<script type="text/javascript">
    var forUsername = "<%= KickPage.UrlParameters.UserIdentifier %>";
    var chatID = <%= this.JavaScriptChatID %>;

    function addShout() {
        StartLoading();
        ajaxServices.addShout($("#shout_message").val(), forUsername, chatID, addShout_complete);
    }
    
    function refreshShoutbox() {
        StartLoading();
        ajaxServices.getLatestShouts(forUsername, chatID, addShout_complete);      
    }
    
    function addShout_complete(response) {
        $("#shout_message").val("");
        $("#shoutList").html(response.result);
        FinishLoading();
    }
</script>

<h2>Shoutbox</h2>
<asp:Panel ID="SaySomethingPanel" runat="server">
<textarea id="shout_message" rows="4" cols="20" style="width: 100%;"></textarea><br />
<input type="button" id="Button1" value="Shout It!" onclick='addShout();' /> <span style="font-size:smaller"><a href="#" onclick="refreshShoutbox()">(refresh)</a></span>
</asp:Panel>

<Kick:ShoutList id="ShoutList" runat="server" renderContainer="true" />


