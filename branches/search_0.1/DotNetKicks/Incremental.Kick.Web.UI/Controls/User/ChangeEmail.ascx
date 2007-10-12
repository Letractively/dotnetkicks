<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangeEmail.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ChangeEmail" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<br />
<asp:Panel ID="ChangeEmailPanel" runat="server">
<table class="FormTable">
    <tr>
        <td class="FormTitle FormTD">
            Your new email:</td>
        <td class="FormInput FormTD">
            <asp:TextBox ID="Email" runat="server" Width="300px" EnableViewState="False" CssClass="LargeInput"></asp:TextBox>
            <span class="ValidationMessage">
                <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ErrorMessage="Please enter a valid email address."
                    ControlToValidate="Email" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"
                    Display="Dynamic"></asp:RegularExpressionValidator>
                </span><br />
            <span class="FormHelp">We will send a validation email, so please use a real one.<br />(Your email is currently set to <em><asp:Label ID="CurrentEmail" runat="server" /></em>)</span>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td class="FormButtons FormTD">
            <asp:Button ID="btnChangeEmail" runat="server" Text="Change Email" OnClick="btnChangeEmail_Click"
                EnableViewState="False" />
        </td>
    </tr>
</table>
</asp:Panel>
<asp:Panel ID="SuccessPanel" runat="server" Visible="False">
	<div class="HelpDiv">A verification email has been sent, please check it to verify your new address.
    </div>
    
    <p>
    <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.Home)%>">Continue >></a>
    </p></asp:Panel>
<asp:Panel ID="FailedPanel" runat="server" Visible="False">
    <div class="HelpDiv">A verification email could not be sent.  Either that address already in use or could not be sent at this time.
    </div>
    <p>
    <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.ChangeEmail)%>">Try Again >></a>
    </p></asp:Panel>
