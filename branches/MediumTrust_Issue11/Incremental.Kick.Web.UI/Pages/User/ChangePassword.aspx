<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.ChangePassword" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Register Src="../../Controls/User/ChangePassword.ascx" TagName="ChangePassword" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
<p align="center">    
    <uc1:ChangePassword ID="ChangePasswordControl" runat="server" />
</p>
</asp:Content>
