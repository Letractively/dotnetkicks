<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.User.ForgotPassword" %>
Email address:
<asp:TextBox ID="Email" runat="server"></asp:TextBox>
<asp:Button ID="ResetPassword" runat="server" OnClick="ResetPassword_Click" Text="Reset Password" /><br />
<br />
<asp:Label ID="MessageLabel" runat="server" EnableViewState="False"></asp:Label>
