<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ForgotPassword.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ForgotPassword" %>
    <div style="text-align: center;">
        <table border="0" cellpadding="4">
            <tbody>
                <tr>
                    <td colspan="2" align="left">
                        <strong>Email address:</strong></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:TextBox ID="Email" runat="server" CssClass="LargeInput"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="ResetPassword" runat="server" OnClick="ResetPassword_Click" Text="Reset Password" /><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left">
                        <span class="ValidationMessage">
                            <asp:Label ID="ErrorMessageLabel" runat="server" EnableViewState="False"></asp:Label>
                        </span>
                    </td>
                    <td colspan="2" align="left">
                            <asp:Label ID="ConfirmationMessageLabel" runat="server" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
