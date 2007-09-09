<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTag.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.ViewTag" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <Kick:UserProfileHeader id="UserProfileHeader" runat="server" />
    <Kick:StoryList id="StoryList" runat="server" />
    <Kick:Paging id="Paging" runat="server" />    
</asp:Content>
