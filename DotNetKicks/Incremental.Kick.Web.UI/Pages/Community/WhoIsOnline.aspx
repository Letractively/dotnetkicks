<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WhoIsOnline.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Community.WhoIsOnline" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Who's Online:</h1>
    <Kick:UserList id="UserList" runat="server" />
    
</asp:Content>