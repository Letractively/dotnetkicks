<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.EditProfile" %>
<%@ Register Src="../../Controls/User/ProfileEditor.ascx" TagName="ProfileEditor" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <Kick:UserProfileHeader id="UserProfileHeader" runat="server" />
    <uc1:ProfileEditor ID="ProfileEditor1" runat="server" />
</asp:Content>
