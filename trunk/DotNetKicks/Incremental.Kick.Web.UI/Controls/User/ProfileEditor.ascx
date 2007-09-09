<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileEditor.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.ProfileEditor" %>
this is the profile editor
<br />
<br />
use gravatar:
<asp:CheckBox ID="UseGravatar" runat="server" /><br />
custom gravatar email:
<asp:TextBox ID="GravatarCustomEmail" runat="server"></asp:TextBox>
(leave blank if you wish to use
<asp:Label ID="UserEmail" runat="server"></asp:Label>)<br />
location:
<asp:TextBox ID="Location" runat="server"></asp:TextBox><br />
website url:
<asp:TextBox ID="WebsiteURL" runat="server"></asp:TextBox><br />
blog url:
<asp:TextBox ID="BlogUrl" runat="server"></asp:TextBox><br />
blog feed url:
<asp:TextBox ID="BlogFeedUrl" runat="server"></asp:TextBox><br />
<br />
<asp:Button ID="UpdateProfile" runat="server" Text="Update Profile" OnClick="UpdateProfile_Click" />

