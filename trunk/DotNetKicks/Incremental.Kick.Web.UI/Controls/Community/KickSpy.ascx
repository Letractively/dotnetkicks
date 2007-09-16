<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KickSpy.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Community.KickSpy" %>
<h1>Kick Spy:</h1>

<div class="users">

<span style="font-size: smaller; color: green;"><em>It is early stages for <a href="http://code.google.com/p/dotnetkicks/issues/detail?id=86">this feature</a>.</em></span>

<br />
<br />
<Kick:SpyItemList id="SpyItemList" runat="server" renderContainer="true" />
</div>