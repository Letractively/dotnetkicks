<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Constants.aspx.cs" Inherits="Incremental.Kick.Web.UI.Scripts.Constants" %>
var WEB_BASE_URL = "<%=this.RootUrl%>";
var AJAX_BASE_URL = WEB_BASE_URL + "services/ajax";
var IS_USER_AUTHENTICATED = <%=this.IsUserAuthenticated%>;
