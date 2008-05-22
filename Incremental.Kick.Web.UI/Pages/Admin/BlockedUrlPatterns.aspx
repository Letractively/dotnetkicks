<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlockedUrlPatterns.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Admin.BlockedUrlPatterns" %>
<%@ Register Src="../../Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">

    <SubSonic:Scaffold ID="Scaffold1" runat="server" TableName="Kick_BannedUrlPattern" />
    
</asp:Content>

<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <uc1:AdminMenu id="AdminMenu1" runat="server" />
</asp:Content>
