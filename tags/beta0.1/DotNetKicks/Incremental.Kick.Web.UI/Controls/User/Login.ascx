<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Login" %>
<table border="0" cellpadding="4">
			<tbody><tr>
				<td colspan="2" align="center"><strong>Log In</strong></td>
			</tr><tr>
				<td align="right"><label class="LargeInputLabel">Username:</label></td>
				<td><asp:TextBox ID="Username" runat="server" EnableViewState="False" CssClass="LargeInput"></asp:TextBox></td>
			</tr><tr>
				<td align="right"><label class="LargeInputLabel">Password:</label></td>
				<td><asp:TextBox ID="Password" runat="server" EnableViewState="False" TextMode="Password" CssClass="LargeInput"></asp:TextBox></td>
			</tr><tr>
				<td colspan="2"><asp:CheckBox ID="RememberMe" runat="server" EnableViewState="False" Text="Remember me on this computer" Checked="True" /></td>

			</tr><tr>
				<td colspan="2" align="right">
				    <span class="ValidationMessage">
                    <asp:Label ID="InvalidLogin" runat="server" EnableViewState="False" Text="Username and password do not match" Visible="False"></asp:Label>
                </span>
                    <asp:Button ID="LogIn" runat="server" EnableViewState="False" Text="Log In" OnClick="LogIn_Click" /></td>
			</tr><tr>
				<td colspan="2"><img src="<%=this.KickPage.StaticIconRootUrl%>/createuser.png" alt="New User?" width="16" height="16" />
				<a href="<%=this.RootUrl%>register">New user?</a>
				<br /><img src="<%=this.KickPage.StaticIconRootUrl%>/forgotpassword.png" alt="Forgot Password?" width="16" height="16" />
				<a href="<%=this.RootUrl%>forgotpassword">Forgot your password?</a></td>
			</tr>
		</tbody></table>
