<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hosts.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Admin.Hosts" %>
<%@ Register Src="../../Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

This will be the host admin page
    
</asp:Content>

<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <uc1:AdminMenu id="AdminMenu1" runat="server" />
</asp:Content>
