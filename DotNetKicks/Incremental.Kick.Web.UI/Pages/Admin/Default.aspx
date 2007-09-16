<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Admin.Default" %>
<%@ Register Src="../../Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Admin/Tasks.ascx" TagName="Tasks" TagPrefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">


    <uc1:Tasks id="Tasks" runat="server" />

    
</asp:Content>

<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <uc1:AdminMenu id="AdminMenu1" runat="server" />
</asp:Content>