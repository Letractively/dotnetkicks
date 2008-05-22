<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentsMade.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.CommentsMade"  MasterPageFile="~/Templates/MasterPage.master" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <Kick:UserProfileHeader id="UserProfileHeader" runat="server" />
    <Kick:CommentList id="CommentList" runat="server" />
    <Kick:Paging id="Paging" runat="server" /> 
</asp:Content>
