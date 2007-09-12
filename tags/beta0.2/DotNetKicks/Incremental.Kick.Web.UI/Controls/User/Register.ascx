<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Register" %>

<br />
<asp:Panel ID="RegisterPanel" runat="server">
<table class="FormTable">
    <tr>
        <td class="FormTitle FormTD">Username:</td>
        <td class="FormInput FormTD">
            <asp:TextBox ID="Username" runat="server" EnableViewState="False" CssClass="LargeInput"></asp:TextBox>
            <span class="ValidationMessage"><asp:RegularExpressionValidator ID="UsernameValidator" runat="server" ErrorMessage="The username must be greater than 4 characters and can only contain letters and numbers." ControlToValidate="Username" ValidationExpression="^([a-zA-Z0-9._]{4,30})$" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="UsernameRequired" runat="server" ControlToValidate="username"
                ErrorMessage="Please enter a username" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Label ID="UsernameNotUniqueMessage" runat="server" EnableViewState="False" Text="The username already exists, please choose another one." Visible="False"></asp:Label>
                </span>
            
            <br /><span class="FormHelp">The username should be 4 characters or more and should only contain letters, numbers or underscores.</span>
    
        </td>
    </tr>
    <tr>
        <td class="FormTitle FormTD">Your email:</td>
        <td class="FormInput FormTD">
            <asp:TextBox ID="Email" runat="server" Width="200px" EnableViewState="False" CssClass="LargeInput"></asp:TextBox>
            <span class="ValidationMessage"><asp:RegularExpressionValidator ID="EmailValidator" runat="server" ErrorMessage="Please enter a valid email address." ControlToValidate="Email" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                ErrorMessage="Please enter an email." Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Label ID="EmailNotUniqueMessage" runat="server" EnableViewState="False" Text="The email already exists, please use another one or use the forgotten password page to reset your password." Visible="False"></asp:Label>
                </span>
                
                <br /><span class="FormHelp">We will send your new password to this email address, so please use a real one.</span>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="FormInput FormTD">
            <asp:CheckBox ID="ReceiveEmailNewsletter" runat="server" EnableViewState="False" Text="Notify me when new features are added to the site" />
        </td>
    </tr>
    
    <tr>
        <td></td>
        <td class="FormButtons FormTD"><asp:Button ID="CreateAccount" runat="server" Text="Create Account" OnClick="CreateAccount_Click" EnableViewState="False" />
            </td>
     </tr>
</table>

</asp:Panel>
<asp:Panel ID="SuccessPanel" runat="server" Visible="False">
<div class="HelpDiv">We have sent you an email containing your new password. <br /><br />Thanks for joining our community, with your help we can grow this site into a valuable resource.


</div></asp:Panel>


