<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contribute.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Docs.Contribute" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     
    <div class="HelpDiv">

<div class="HelpTitle">Tell your friends</div>

<div class="HelpAnswer">

The most immediate and effective way that you can help us is to tell your friends <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.About)%>">about us</a>. If you have a blog, please write a short post with a link to <%=this.HostProfile.SiteTitle%>. The more users we have, the more useful the content becomes for everyone.

</div>

<div class="HelpTitle">Kick some stories</div>

<div class="HelpAnswer">
As the site has no editors in the traditional sense, we rely on our users to kick the good content onto our homepage. 
<a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.NewStories)%>">Recently submitted stories</a> that have not yet received enough kicks to make the homepage are awaiting your kicks right now.
</div>

<div class="HelpTitle">Add a story</div>
<div class="HelpAnswer">
Without our users submitting stories, we would have no content. If you find any interesting stories relevant to <%=this.HostProfile.SiteTitle%>, please <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.SubmitStory)%>">submit them</a> so that we can all know about them.
</div>

<div class="HelpTitle">Add our headlines to your website</div>
<div class="HelpAnswer">
We provide <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.JavaScriptFeeds)%>">various feeds</a> that you can add to your website. These are updated in real time and you can add them to your site very simply.
</div>

<div class="HelpTitle">Let us know your comments and suggestions</div>
<div class="HelpAnswer">
It is early days for <%=this.HostProfile.SiteTitle%> and we have many improvements and new features coming soon. Please <a href="mailto:<%=this.HostProfile.Email %>">let us know</a> what you think of the site and how we may improve it to better serve you.
</div>


</div>
</asp:Content>
