<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Profile.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Profile" %>

<p>location: <%= Server.HtmlEncode(this.UserProfile.Location) %></p>
<p>website: <%= Server.HtmlEncode(this.UserProfile.WebsiteURL) %></p>
<p>blog: <%= Server.HtmlEncode(this.UserProfile.BlogURL) %></p>
<p>blog feed: <%= Server.HtmlEncode(this.UserProfile.BlogFeedURL) %></p>
<p>useGravatar: <%= this.UserProfile.UseGravatar%></p>
 
 
<% if(this.KickPage.KickUserProfile.UserID == this.UserProfile.UserID) { %>
 <h1><a href="/users/<%= this.KickPage.KickUserProfile.Username %>/profile/edit">Edit Profile</a></h1>
<% } %>