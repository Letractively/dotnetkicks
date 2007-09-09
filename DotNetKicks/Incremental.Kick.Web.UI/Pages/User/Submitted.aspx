<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Submitted.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.Submitted" 
    MasterPageFile="~/Templates/MasterPage.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

<Kick:StoryList id="StoryListControl" runat="server" />
<Kick:Paging id="Paging" runat="server" />
     
</asp:Content>
