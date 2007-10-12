<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.Register" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Register Src="../../Controls/User/Register.ascx" TagName="Register" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
   
   <br /><br />
    <uc1:Register ID="Register1" runat="server" />
</asp:Content>
