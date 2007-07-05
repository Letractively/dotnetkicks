<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.Login" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Register Src="../../Controls/User/Login.ascx" TagName="Register" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

<br /><br /><p align="center">    
    <uc1:Register ID="Register1" runat="server" />
</p>

</asp:Content>



