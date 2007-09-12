<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upcoming.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Upcoming" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <Kick:UpcomingStoryListHeader ID="UpcomingStoryListHeader" runat="server" />
    <Kick:StoryList id="StoryList" runat="server" />
   <Kick:Paging id="Paging" runat="server" />
   
    <%--TODO: add controls and page logic.
    
    <p>
    Some example URLs:
    </p>
    
    <ul>
        <li><a href="/upcoming/popular">Upcoming / Popular</a></li>
        <li><a href="/upcoming/popular/page/2">Upcoming / Popular / Page 2</a></li>
        <li><a href="/upcoming/popular/today">Upcoming / Popular / Today</a></li>
        <li><a href="/upcoming/popular/today/page/2">Upcoming / Popular / Today / Page 2</a></li>
        <li><a href="/upcoming/popular/toptenupcoming">Upcoming / Popular / Top Ten</a></li>
        <li><a href="/upcoming/popular/toptenupcoming/page/2">Upcoming / Popular / Top Ten / Page 2</a></li>
    </ul>--%>
    
</asp:Content>

<asp:Content id="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <Kick:KickForStoriesMenu id="KickMenu" runat="Server" />
</asp:Content>