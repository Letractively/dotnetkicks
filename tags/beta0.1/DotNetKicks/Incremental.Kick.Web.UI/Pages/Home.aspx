<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Home" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">


    <Kick:PopularStoryListHeader id="PopularStoryListHeader" runat="server" />
    <Kick:PopularStoryNavigator id="PopularStoryNavigator" runat="server" />
    
</asp:Content>

<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <Kick:KickForStoriesMenu id="KickMenu" runat="Server" />
</asp:Content>