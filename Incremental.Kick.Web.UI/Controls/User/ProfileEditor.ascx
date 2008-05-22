<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileEditor.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ProfileEditor" %>


<table class="FormTable">
    <tr>
        <td class="FormTitle FormTD">
            Display Gravatar:</td>
        <td class="FormInput FormTD">
            <asp:CheckBox ID="UseGravatar" runat="server" />
            <em class="smallerText">Gravatars are 80x80 images and are provided by this free service: <a href="http://site.gravatar.com/">http://site.gravatar.com/</a></em>
        </td>
    </tr>
    <tr>
        <td class="FormTitle FormTD">Custom Gravatar Email:</td>
        <td class="FormInput FormTD"><asp:TextBox ID="GravatarCustomEmail" runat="server" size="60"></asp:TextBox>
        <br><span class="FormHelp">(leave blank if you wish to use <em><asp:Label ID="UserEmail" runat="server" /></em>)</span>
</td>
    </tr>
    <tr>
        <td class="FormTitle FormTD">Location:</td>
        <td class="FormInput FormTD"><asp:TextBox ID="Location" runat="server" size="60"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="FormTitle FormTD">Website:</td>
        <td class="FormInput FormTD"><asp:TextBox ID="WebsiteURL" runat="server" size="60" />
        <br><span class="FormHelp">eg. <em>http://www.dotnetkicks.com/</em></span></td>
    </tr>
    <tr>
        <td class="FormTitle FormTD">Blog</td>
        <td class="FormInput FormTD"><asp:TextBox ID="BlogUrl" runat="server" size="60" />
        <br><span class="FormHelp">eg. <em>http://blog.incremental.ie/</em></span></td>
    </tr>
    <tr>
        <td class="FormTitle FormTD">Blog Feed</td>
        <td class="FormInput FormTD"><asp:TextBox ID="BlogFeedUrl" runat="server" size="60" />
        <br><span class="FormHelp">eg. <em>http://feeds.feedburner.com/dotnetkicks</em></span></td>
    </tr>
    <tr>
        <td class="FormTitle FormTD"></td>
        <td class="FormInput FormTD"><asp:Button ID="UpdateProfile" runat="server" Text="Update Profile" OnClick="UpdateProfile_Click" /></td>
    </tr>
</table>






