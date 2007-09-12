<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JavaScriptFeeds.aspx.cs"
    Inherits="Incremental.Kick.Web.UI.Pages.Docs.JavaScriptFeeds" MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="HelpDiv">
        <div class="HelpAnswer">
            You can easily add live
            <%=HostProfile.SiteTitle%>
            headlines to your website.
            <p>
                Simply paste one of the snippets of code below into your website html. You can style
                the headlines as you wish by defining a custom CSS stylesheet - the two classes
                used are 'KickStoryList' and 'KickStory'.
            </p>
            <p>
                <Kick:JavaScriptFeedList id="JavaScriptFeedListControl1" runat="server" />
            </p>
            <p>
                <Kick:JavaScriptFeedList id="JavaScriptFeedListControl2" EntryCount="5" Title="Homepage Feed - custom number of entries" runat="server" />
            </p>
        </div>
    </div>
</asp:Content>
