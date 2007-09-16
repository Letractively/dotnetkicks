<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WhoIsOnline.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Community.WhoIsOnline" %>

<%@ Register Src="/Controls/User/ShoutBox.ascx" TagName="ShoutBox" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Community/KickSpy.ascx" TagName="KickSpy" TagPrefix="uc1" %>
<asp:content id="MainContent" contentplaceholderid="MainContent" runat="Server">

    <h1><%= Incremental.Kick.Caching.UserCache.GetOnlineUsersCount(30, this.HostProfile.HostID) %> are online now:</h1>

    <Kick:UserList id="UserOnlineList" runat="server" />
    
    <uc1:KickSpy id="KickSpy1" runat="server" />
    
    
</asp:content>
<asp:content id="RightContentOutline" contentplaceholderid="RightContent" runat="server">
    <uc1:Shoutbox ID="Shoutbox" runat="server" />
</asp:content>
