<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoutBox.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ShoutBox" %>

<script type="text/javascript">
    function addShout() {
        StartLoading();
        Incremental.Kick.Web.UI.Services.Ajax.AjaxServices.AddShout(<%= this.KickPage.HostProfile.HostID %>, $("#shout_message").val(), addShout_complete);
    }
    
    function refreshShoutbox() {
        //note: gj: a quick hack to get the refresh working
        StartLoading();
        Incremental.Kick.Web.UI.Services.Ajax.AjaxServices.AddShout(<%= this.KickPage.HostProfile.HostID %>, "", addShout_complete);
    }
    
    function addShout_complete(result) {
        $("#shout_message").val("");
        $("#shoutList").html(result.value);
        FinishLoading();
    }
</script>

<h2>Shoutbox</h2>
<span style="font-size:smaller; color: green;"><em>TODO: Lots of work to do on this</em></span><br />
<asp:Panel ID="SaySomethingPanel" runat="server">
Say Something...
<textarea id="shout_message" rows="4" cols="20" style="width: 100%;"></textarea><br />
<input type="button" id="Button1" value="Shout It!" onclick='addShout();' /> <span style="font-size:smaller"><a href="#" onclick="refreshShoutbox()" />(refresh)</a></span>
</asp:Panel>

<Kick:ShoutList id="ShoutList" runat="server" renderContainer="true" />


