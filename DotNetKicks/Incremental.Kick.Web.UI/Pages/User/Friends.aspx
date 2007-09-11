<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.Friends" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     
    <Kick:UserProfileHeader id="UserProfileHeader" runat="server" />
    
    <Kick:UserList id="FriendList" runat="server" />
        
</asp:Content>