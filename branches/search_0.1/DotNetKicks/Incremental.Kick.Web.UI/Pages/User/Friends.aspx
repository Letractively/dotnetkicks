<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.Friends" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     
    <Kick:UserProfileHeader id="UserProfileHeader" runat="server" />
    
    <h2>Friends With:</h2>
    <Kick:UserList id="FriendList" runat="server" />
    
    <h2>Friends By:</h2>
    <Kick:UserList id="FriendByList" runat="server" />
        
</asp:Content>