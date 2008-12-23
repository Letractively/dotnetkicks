<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTest.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.UserTest" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

<h1>Prove yourself...</h1>

<p>In order to reduce the amount of spam on the site, we ask new users to prove that they have some knowledge of .NET. We'll only ask you to do this once.</p>

<p>Use the <a href="/spy">shoutbox</a> if you have any problems.</p>

<h3>Please select 5 words that are related to .NET</h3>


<asp:checkboxlist id="checkboxList" runat="server" RepeatColumns="3">
</asp:checkboxlist>
<br />
<asp:Label runat="server" id="Message"></asp:Label>
<br />
<asp:button runat="server" id="TestMe" text="Take the test" OnClick="TestMe_Click" />

</asp:Content>

