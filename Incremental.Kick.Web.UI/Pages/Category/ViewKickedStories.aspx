<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewKickedStories.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Category.ViewKickedStories" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
   <Kick:StoryList id="StoryList" runat="server" />
   <Kick:Paging id="Paging" runat="server" />
</asp:Content>

<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <Kick:KickForStoriesMenu id="KickMenu" runat="Server" />
</asp:Content>