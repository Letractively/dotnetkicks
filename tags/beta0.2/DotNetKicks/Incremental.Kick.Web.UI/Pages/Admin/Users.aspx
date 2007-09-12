<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Admin.Users" %>
<%@ Register Src="../../Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>


<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     NOTE: GJ: we can't use scaffold here as it doesn't support server side paging
    <!--<SubSonic:Scaffold ID="Scaffold1" runat="server" TableName="Kick_User" />-->
    
</asp:Content>


<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <uc1:AdminMenu id="AdminMenu1" runat="server" />
</asp:Content>
