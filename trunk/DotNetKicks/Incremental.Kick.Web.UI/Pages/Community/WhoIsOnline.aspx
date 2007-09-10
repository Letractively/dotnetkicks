<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WhoIsOnline.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Community.WhoIsOnline" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1><%= Incremental.Kick.Caching.UserCache.GetOnlineUsersCount(30, this.HostProfile.HostID) %> are online now:</h1>
    <Kick:UserList id="UserOnlineList" runat="server" />
    
    <h1><%= Incremental.Kick.Caching.UserCache.GetOnlineUsersCount(1440, this.HostProfile.HostID) %> were here today:</h1>
    <Kick:UserList id="UserTodayList" runat="server" />
    
</asp:Content>