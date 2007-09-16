<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cache.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.Admin.Cache" %>
<h1>Cache:</h1>

There are <%= this.Cache.Count%> items in the cache

<!--<% foreach (DictionaryEntry d in this.Cache) { %>
    <%= d.Key %> : <%= d.Value %><br />
<% } %>-->