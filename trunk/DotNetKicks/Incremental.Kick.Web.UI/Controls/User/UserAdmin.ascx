<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAdmin.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.UserAdmin" %>
<h2>User Admin</h2>
<p>
<asp:Button ID="BanUser" runat="server" OnClick="BanUser_Click" Text="Ban User" />
<asp:Button ID="UnBanUser" runat="server" OnClick="UnBanUser_Click" Text="Un-Ban User" />