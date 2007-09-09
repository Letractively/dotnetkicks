<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.View" 
MasterPageFile="~/Templates/MasterPage.master" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:Button ID="BanUser" runat="server" Text="Ban This User" Visible="False" OnClick="BanUser_Click" />
    
    <br />

<Kick:StoryList id="StoryListControl" runat="server" />
<Kick:Paging id="Paging" runat="server" />
     
</asp:Content>
