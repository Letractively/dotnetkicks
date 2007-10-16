<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Admin.Search" %>
<h1>Search:</h1>
Lucene Index Base Directory: <asp:Label ID="lblBaseDirectory" runat="server" Text="Label"></asp:Label><br />
Lucene Recrawl Interval: <asp:Label ID="lblRecrawlRate" runat="server" Text="Label"></asp:Label> minutes<br />
Last Crawl Time: <asp:Label ID="lblLastCrawl" runat="server" Text="Label"></asp:Label><br />

<asp:Repeater ID="rptDeleteIndex" runat="server">
    <ItemTemplate>
        <asp:Label ID="lblHostName" runat="server"><%# Eval("Value.hostName") %></asp:Label>
        <asp:Button ID="btnDeleteIndex" runat="server" Text="Recreate Index" OnClick="btnDeleteIndex_Click" CommandArgument='<%# Eval("Value.hostID") %>'/>
        <br />
    </ItemTemplate>
</asp:Repeater>

<p>
    <asp:Label ID="lblDeleteOutput" runat="server"></asp:Label>
</p>