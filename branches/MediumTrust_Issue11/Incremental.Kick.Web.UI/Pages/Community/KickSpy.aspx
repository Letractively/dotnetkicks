<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KickSpy.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Community.KickSpy" %>

<%@ Register Src="../../Controls/Community/KickSpy.ascx" TagName="KickSpy" TagPrefix="uc1" %>
<%@ Register Src="/Controls/User/ShoutBox.ascx" TagName="ShoutBox" TagPrefix="uc1" %>

<asp:content id="MainContent" contentplaceholderid="MainContent" runat="Server">
<span style="font-size: 1.2em;"><em>
<strong><%= Incremental.Kick.Caching.UserCache.GetOnlineUsersCount(30, HostProfile.HostID, KickUserProfile) %> users are online now, <%= Incremental.Kick.Caching.UserCache.GetOnlineUsersCount(1440, HostProfile.HostID, KickUserProfile) %> were on today.
</strong></em></span>
   

    <Kick:UserList id="UserOnlineList" runat="server" />
    
    <uc1:KickSpy id="KickSpy1" runat="server" />
</asp:content>
<asp:content id="RightContentOutline" contentplaceholderid="RightContent" runat="server">
   
    <uc1:Shoutbox ID="Shoutbox" runat="server" />

</asp:content>
