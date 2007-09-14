<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendsSubmittedStories.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.FriendsSubmittedStories" MasterPageFile="~/Templates/MasterPage.master" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <Kick:UserProfileHeader id="UserProfileHeader" runat="server" />
    <Kick:StoryList id="StoryListControl" runat="server" />
    <Kick:Paging id="Paging" runat="server" /> 
</asp:Content>
