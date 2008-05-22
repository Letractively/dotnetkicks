<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeEmail.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.ChangeEmail" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Register Src="../../Controls/User/ChangeEmail.ascx" TagName="ChangeEmail" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
<p align="center">    
    <uc1:ChangeEmail ID="ChangeEmailControl" runat="server" />
</p>
</asp:Content>
