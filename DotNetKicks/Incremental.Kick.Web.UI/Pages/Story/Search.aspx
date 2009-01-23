<%@ Page Language="C#" MasterPageFile="~/Templates/Default/MasterPage.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Search" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:right;padding-top:5px;">Sort Results By: 
        <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
            <asp:ListItem Text="Relevance" Value="relevance"></asp:ListItem>
            <asp:ListItem Text="Kicks High-Low" Value="kicks_desc"></asp:ListItem>
            <asp:ListItem Text="Kicks Low-High" Value="kicks_asc"></asp:ListItem>
            <asp:ListItem Text="Submission Date Older" Value="date_asc"></asp:ListItem>
            <asp:ListItem Text="Submission Date Newer" Value="date_desc"></asp:ListItem>
        </asp:DropDownList>
    </div>    
    <div class="PageCaption">Search Results</div>
    <div class="searchResultsSummary"><asp:Label ID="lblSearchTerm" runat="server"></asp:Label></div>         
    <Kick:StoryList runat="server" ID="searchResults"/>
    <asp:Label ID="lblNoResults" CssClass="searchNoResults" Visible="false" runat="server" Text="No Results found for the search"></asp:Label>
    <Kick:SearchPaging runat="server" ID="paging" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
