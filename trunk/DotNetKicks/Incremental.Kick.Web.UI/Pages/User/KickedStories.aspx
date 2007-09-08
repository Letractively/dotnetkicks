<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KickedStories.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.KickedStories" MasterPageFile="~/Templates/MasterPage.master" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <Kick:UserProfileMenu id="UserProfileMenu" runat="server" />
    <Kick:StoryList id="StoryListControl" runat="server" />
    <Kick:Paging id="Paging" runat="server" /> 
</asp:Content>
