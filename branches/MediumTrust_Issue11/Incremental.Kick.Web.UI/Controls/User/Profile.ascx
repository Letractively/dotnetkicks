<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Profile.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Profile" %>
<table class="FormTable">
    <tr>
        <td class="FormTitle FormTD">
            Member Since:</td>
        <td class="FormInput FormTD">
            <%= this.UserProfile.CreatedOn.ToLongDateString()%> <em>(<%= SubSonic.Sugar.Dates.ReadableDiff(this.UserProfile.CreatedOn, DateTime.Now)%>)</em>
        </td>
    </tr>
    <tr>
        <td class="FormTitle FormTD">
            Last Seen:</td>
        <td class="FormInput FormTD">
            <%= SubSonic.Sugar.Dates.ReadableDiff(this.UserProfile.LastActiveOn, DateTime.Now)%> <em><a class="smallerText" href="/whoisonline">Who else is online?</a></em>
        </td>
    </tr>
    <% if (!String.IsNullOrEmpty(this.UserProfile.Location)) { %>
    <tr>
        <td class="FormTitle FormTD">
            Location:</td>
        <td class="FormInput FormTD">
            <%= Server.HtmlEncode(this.UserProfile.Location) %>
        </td>
    </tr>
    <% } %>
    <% if (!String.IsNullOrEmpty(this.UserProfile.WebsiteURL)) { %>
    <tr>
        <td class="FormTitle FormTD">
            Website:</td>
        <td class="FormInput FormTD">
            <a href="<%= Server.HtmlEncode(this.UserProfile.WebsiteURL) %>" nofollow>
                <%= Server.HtmlEncode(this.UserProfile.WebsiteURL) %>
            </a>
        </td>
    </tr>
    <% } %>
    <% if (!String.IsNullOrEmpty(this.UserProfile.BlogURL)) { %>
    <tr>
        <td class="FormTitle FormTD">
            Blog:</td>
        <td class="FormInput FormTD">
            <a href="<%= Server.HtmlEncode(this.UserProfile.BlogURL) %>" nofollow>
                <%= Server.HtmlEncode(this.UserProfile.BlogURL) %>
            </a>
            <% if (!String.IsNullOrEmpty(this.UserProfile.BlogFeedURL)) { %>
            &nbsp; <a href="<%= Server.HtmlEncode(this.UserProfile.BlogFeedURL) %>" nofollow>
                <img src="/static/images/icons/rss.jpg" border="0" width="16" height="16" /></a>
            <% } %>
        </td>
    </tr>
    <% } %>
    <tr>
        <td class="FormTitle FormTD">
        </td>
        <td class="FormInput FormTD">
        </td>
    </tr>
</table>

<table class="FormTable">
    <tr>
        <td class="FormTitle FormTD">
        </td>
        <td class="FormInput FormTD">
        <h2>
            <asp:MultiView ID="mvProfileViews" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewProfileEdit" runat="server">
                    <a href="/users/<%= this.KickPage.KickUserProfile.Username %>/profile/edit">Edit Profile</a>
                </asp:View>
                <asp:View ID="viewProfileIsAFriend" runat="server">
                    <asp:LinkButton ID="lnkRemoveFriend" runat="server" OnClick="lnkRemoveFriend_Click">Remove <%= this.KickPage.UrlParameters.UserIdentifier%> as a Friend</asp:LinkButton>
                </asp:View>
                <asp:View ID="viewProfileIsNotAFriend" runat="server">
                    <asp:LinkButton ID="lnkAddFriend" runat="server" OnClick="lnkAddFriend_Click">Add <%= this.UserProfile.Username%> as a Friend</asp:LinkButton>
                </asp:View>
            </asp:MultiView>
            </h2>
        </td>
    </tr>
</table>
