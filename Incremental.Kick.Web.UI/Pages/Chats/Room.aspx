<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Chats.Room" %>
<%@ Register Src="/Controls/User/ShoutBox.ascx" TagName="ShoutBox" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

     This will be the chat room for id : <%=this.UrlParameters.ChatID %>
    
    <uc1:Shoutbox ID="Shoutbox" runat="server" />
</asp:Content>