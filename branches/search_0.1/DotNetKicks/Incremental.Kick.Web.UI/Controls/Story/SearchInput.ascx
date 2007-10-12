<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchInput.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Story.SearchInput" %>

<div class="GreenPanel">
    <div class="GreenPanelCaption">Search:</div>
    <asp:TextBox ID="txtSearchTerm" runat="server" Columns="20"></asp:TextBox><br />
    <asp:CheckBox ID="chkUserSearch" runat="server" CssClass="searchOnlyMyStories" Text="Only Search Stories I Kicked" />
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="searchButton" OnClick="btnSearch_Click" />
</div>