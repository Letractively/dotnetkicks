<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Home.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Home" %>

<asp:content id="MainContent" contentplaceholderid="MainContent" runat="Server">


    <Kick:PopularStoryListHeader id="PopularStoryListHeader" runat="server" />
    <Kick:PopularStoryNavigator id="PopularStoryNavigator" runat="server" />
    
</asp:content>
<asp:content id="RightContent" contentplaceholderid="RightContent" runat="Server">
    <Kick:KickForStoriesMenu id="KickMenu" runat="Server" />
</asp:content>
