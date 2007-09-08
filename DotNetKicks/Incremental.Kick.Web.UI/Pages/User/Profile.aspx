<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.Profile" %>

<%@ Register Src="../../Controls/User/Profile.ascx" TagName="Profile" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <Kick:UserProfileMenu id="UserProfileMenu" runat="server" />
    <br />
    <br />
    <h1>TODO: GJ: Implement user profile view and editor</h1>
    <h2>This feature will be implemented soon : <a href="http://code.google.com/p/dotnetkicks/issues/detail?id=63">issue 63</a></h2>
    
    <p>
    <uc1:Profile ID="Profile1" runat="server" />
    </p>
</asp:Content>

