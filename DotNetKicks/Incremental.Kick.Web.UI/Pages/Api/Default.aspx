<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Api.Default" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>

<%@ Register Src="../../Controls/Api/ApiMenu.ascx" TagName="ApiMenu" TagPrefix="uc1" %>
<asp:content id="MainContent" contentplaceholderid="MainContent" runat="Server">
    <h4>Getting Started</h4>
    <p>
        To start using the API, you'll first need to <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.ApiGenerateKey)%>">generate your API key</a>. 
        You should not share this key, it's like your password. Your API key is
        linked to your <%=HostProfile.SiteTitle%> account, so even before you can
        generate an API key, you'll need an account. 
    </p>
    <h4>Feature Summary</h4>
    <p>
            list of features
    </p>
</asp:content>
<asp:content id="RightContent" contentplaceholderid="RightContent" runat="Server">
    <uc1:ApiMenu id="ApiMenu1" runat="server" />
</asp:content>
