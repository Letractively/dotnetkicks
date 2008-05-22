<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyEmail.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.VerifyEmail" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Register Src="../../Controls/User/VerifyEmail.ascx" TagName="VerifyEmail" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
<p align="center">    
    <uc1:VerifyEmail ID="VerifyEmailControl" runat="server" />
</p>
</asp:Content>