<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tasks.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Admin.Tasks" %>

<h1>Admin Tasks:</h1>
<asp:Button ID="RunStoryPublisher" runat="server" OnClick="RunStoryPublisher_Click"
    Text="Run Story Publisher" />
<br />
<asp:Button ID="UpdateStoryKickCounts" runat="server" OnClick="UpdateStoryKickCounts_Click"
    Text="Update Story Kick Counts" />