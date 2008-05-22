<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Admin.Default" %>

<%@ Register Src="../../Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Admin/Tasks.ascx" TagName="Tasks" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Admin/Cache.ascx" TagName="Cache" TagPrefix="uc1" %>

<asp:content id="MainContent" contentplaceholderid="MainContent" runat="Server">


    <uc1:Tasks id="Tasks" runat="server" />
    <uc1:Cache id="CacheControl" runat="server" />

    
</asp:content>
<asp:content id="RightContent" contentplaceholderid="RightContent" runat="Server">
    <uc1:AdminMenu id="AdminMenu1" runat="server" />
</asp:content>
