<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VerifyEmail.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.VerifyEmail" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<asp:Panel ID="SuccessPanel" runat="server" Visible="False">
    <div class="HelpDiv">You have succesfully verified your email address.
    
    <p>
    <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.Home)%>">Continue >></a>
    </p>
    
    </div></asp:Panel>
<asp:Panel ID="FailedPanel" runat="server" Visible="False">
    <div class="HelpDiv">Email verification has failed.  Please try the link again, or try changing it again.
    
    <p>
    <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.Home)%>">Continue >></a>
    </p>
    
    </div></asp:Panel>