<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KickSpy.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Community.KickSpy" %>

<% if(!this.KickPage.UrlParameters.UserIdentifierSpecified) {%>
 <script type="text/javascript">
    function refreshSpy() {
        StartLoading();
        Incremental.Kick.Web.UI.Services.Ajax.AjaxServices.GetSpyHtml(<%= KickPage.HostProfile.HostID %>, getSpyHtml_complete);
    }
    
    function getSpyHtml_complete(result) {
        $("#userActionList").html(result.value);
        FinishLoading();
        setTimeout("refreshSpy()", 60000)
    }
    
    setTimeout("refreshSpy()", 60000)
</script>
<% } %>


<div class="users">

<span style="color: green;"><em>Auto-refreshes every 60 seconds.</em></span>

<br />
<br />

<Kick:UserActionList id="UserActionList" runat="server" renderContainer="true" />



</div>