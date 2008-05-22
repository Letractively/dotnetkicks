<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chats.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Admin.Chats" %>
<%@ Register Src="../../Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <SubSonic:Scaffold ID="Scaffold1" runat="server" TableName="Kick_Chat" />
    
</asp:Content>

<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <uc1:AdminMenu id="AdminMenu1" runat="server" />
</asp:Content>
