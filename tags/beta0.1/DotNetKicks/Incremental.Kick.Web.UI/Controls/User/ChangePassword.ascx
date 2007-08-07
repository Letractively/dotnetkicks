<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ChangePassword" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<br />
<asp:Panel ID="ChangePasswordPanel" runat="server">
<table class="FormTable">
    <% if(this.RequiresOldPassword) { %>
    <tr>
        <td class="FormTitle FormTD">Old Password:</td>
        <td class="FormInput FormTD">
            <asp:TextBox ID="OldPassword" runat="server" TextMode="Password"></asp:TextBox>          
        </td>
    </tr>
    <% } %>
    <tr>
        <td class="FormTitle FormTD">New password:</td>
        <td class="FormInput FormTD">
            <asp:TextBox ID="NewPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
            <span class="ValidationMessage"><asp:RegularExpressionValidator ID="NewPasswordValidator" runat="server" ErrorMessage="Your new password must be 4 characters or more." ControlToValidate="NewPassword" ValidationExpression="^(.{4,20})$" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                ErrorMessage="Please enter a new password." Display="Dynamic"></asp:RequiredFieldValidator>
                </span>
                
                <br /><span class="FormHelp">We will send you a confirmation email address for your records.</span>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="FormButtons FormTD">
        <span class="ValidationMessage">
                    <asp:Label ID="InvalidPassword" runat="server" EnableViewState="False" Text="You did not enter your correct old password." Visible="False"></asp:Label>
        
        <asp:Button ID="ChangePasswordButton" runat="server" Text="Change Password" OnClick="ChangePassword_Click" /></td>
     </tr>
</table>

</asp:Panel>
<asp:Panel ID="SuccessPanel" runat="server" Visible="False">
    <div class="HelpDiv">Your password has been changed.
    
    <p>
    <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.Home)%>">Continue >></a>
    </p>
    
    </div></asp:Panel>


