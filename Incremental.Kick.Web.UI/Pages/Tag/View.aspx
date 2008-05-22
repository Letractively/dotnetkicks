<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Tag.View" MasterPageFile="~/Templates/MasterPage.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <Kick:StoryList id="StoryList" runat="server" />
    <Kick:Paging id="Paging" runat="server" />
</asp:Content>


