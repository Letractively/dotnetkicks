<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Api.Default"
    MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<%@ Register Src="../../Controls/Api/ApiMenu.ascx" TagName="ApiMenu" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <h4>
        Getting Started</h4>
    <p>
        To start using the API, you'll first need to <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.ApiGenerateKey)%>">
            generate your API key</a>. You should not share this key, it's like your password.
        Your API key is linked to your
        <%=HostProfile.SiteTitle%>
        account, so you'll need an account before you can generate an API key.
    </p>
    <h4>
        Feature Summary</h4>
    <dl>
        <dt>JSON Services</dt>
        <dd>
            <%=HostProfile.SiteTitle%>
            offers several JSON-RPC service methods. To learn more about JSON-RPC, visit <a href="http://json-rpc.org/">
                JSON-RPC.org</a>. You can view the
            <%=HostProfile.SiteTitle%>
            methods at <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.JsonServices)%>">
                <%=HostProfile.SiteTitle%>
                JSON-RPC Methods</a>. The list of methods include:
            <ul>
                <li>getFrontPageStories</li>
                <li>getPopularStories</li>
                <li>getPopularStoriesPagedFromTimePeriod</li>
                <li>getTaggedStories</li>
                <li>getUpcomingPageStories</li>
                <li>getUpcomingStories</li>
                <li>getUpcomingStoriesPagedFromTimePeriod</li>
                <li>getUserFriendsKickedStories</li>
                <li>getUserFriendsSubmittedStories</li>
                <li>getUserKickedStories</li>
                <li>getUserSubmittedStories</li>
                <li>system.about</li>
                <li>system.listMethods</li>
                <li>system.version</li>
            </ul>
        </dd>
    </dl>
    <h4>Live Kicks!</h4>
    <p>
        You can view some of the features in action at: <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.LiveKicks)%>">Live Kicks</a>.
    </p>
</asp:Content>
<asp:Content ID="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <uc1:ApiMenu ID="ApiMenu1" runat="server" />
</asp:Content>
