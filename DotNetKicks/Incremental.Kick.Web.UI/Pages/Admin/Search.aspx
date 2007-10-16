<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Admin.Search" Title="Untitled Page" %>
<%@ Register Src="../../Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Admin/Search.ascx" TagName="Search" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:Search ID="SearchDetails" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContent" runat="server">
    <uc1:AdminMenu id="AdminMenu1" runat="server" />
</asp:Content>
