<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Story.View" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Register Src="../../Controls/Story/AddComment.ascx" TagName="AddComment" TagPrefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     
    <Kick:StorySummary id="StorySummary" runat="server" />
    <Kick:UsersWhoKicked id="UsersWhoKicked" runat="server" />
    <Kick:CommentList id="CommentList" runat="server" />
    <uc1:AddComment ID="AddComment" runat="server" />
    
</asp:Content>


<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <Kick:KickForStoriesMenu id="KickMenu" runat="Server" />
</asp:Content>