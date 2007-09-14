<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WhoIsOnline.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Community.WhoIsOnline" %>
<%@ Register Src="/Controls/User/ShoutBox.ascx" TagName="ShoutBox" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1><%= Incremental.Kick.Caching.UserCache.GetOnlineUsersCount(30, this.HostProfile.HostID) %> are online now:</h1>
    <Kick:UserList id="UserOnlineList" runat="server" />
    
    <h1><%= Incremental.Kick.Caching.UserCache.GetOnlineUsersCount(1440, this.HostProfile.HostID) %> were here today:</h1>
    <Kick:UserList id="UserTodayList" runat="server" />
    
</asp:Content>

<asp:Content ID="RightContentOutline" ContentPlaceHolderID="RightContent" runat="server">
   
    <uc1:Shoutbox ID="Shoutbox" runat="server" />

</asp:Content>