<%@ Page Language="C#" AutoEventWireup="true" Codebehind="View.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Story.View"
    MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Register Src="../../Controls/Story/KickItImagePersonalization.ascx" TagName="KickItImagePersonalization"
    TagPrefix="uc2" %>
<%@ Register Src="../../Controls/Story/AddComment.ascx" TagName="AddComment" TagPrefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <Kick:StorySummary ID="StorySummary"  runat="server" />
    <div id="kickImagePersonalization" class="KickItImageCustomization">
        <uc2:KickItImagePersonalization ID="KickItImagePersonalization" runat="server" />
    </div>
    <Kick:UsersWhoKicked ID="UsersWhoKicked" runat="server" />
    <Kick:CommentList ID="CommentList" runat="server" />
    <uc1:AddComment ID="AddComment" runat="server" />
</asp:Content>
<asp:Content ID="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <Kick:KickForStoriesMenu ID="KickMenu" runat="Server" />
</asp:Content>
