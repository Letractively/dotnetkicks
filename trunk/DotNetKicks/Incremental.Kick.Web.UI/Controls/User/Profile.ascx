<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Profile.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Profile" %>

<h2>Note: GJ: this will list a number of user attributes </h2>

<Kick:Gravatar id="gravatar" runat="server" Visible="false" EnableViewState="false" Size="80" Rating="R" />

<p>location: <%= this.UserProfile.Location %></p>
<p>website: <%= this.UserProfile.WebsiteURL%></p>
<p>blog: <%= this.UserProfile.BlogURL%></p>
<p>blog feed: <%= this.UserProfile.BlogFeedURL%></p>
<p>useGravatar: <%= this.UserProfile.UseGravatar%></p>
       
