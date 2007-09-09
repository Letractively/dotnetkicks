<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.Profile" %>

<%@ Register Src="../../Controls/User/Profile.ascx" TagName="Profile" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <Kick:UserProfileHeader id="UserProfileHeader" runat="server" />
    

    <uc1:Profile ID="Profile1" runat="server" />

</asp:Content>

