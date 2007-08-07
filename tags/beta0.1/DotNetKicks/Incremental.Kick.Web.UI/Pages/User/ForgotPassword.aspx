<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.ForgotPassword" MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Register Src="../../Controls/User/ForgotPassword.ascx" TagName="ForgotPassword"
    TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:ForgotPassword ID="ForgotPassword1" runat="server" />
     
</asp:Content>

