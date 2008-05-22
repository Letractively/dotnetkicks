<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Docs.About" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     
    <div class="HelpDiv">

<div class="HelpTitle">What is <%=this.HostProfile.SiteTitle%>?</div>

<div class="HelpAnswer">
<%=this.HostProfile.SiteDescription%>

<p>Individual users of the site submit and review stories, the most popular of which make it to the homepage. Users are encouraged to 'kick' stories that they would like to appear on the homepage. If a story receives enough kicks, it will be promoted.
</p>
</div>

<div class="HelpTitle">What is a kick?</div>

<div class="HelpAnswer">
Kicks are votes of approval from our members. If a story has 16 kicks, that means 16 users liked it. The more kicks a story receives, the more likely that it will appear on the homepage. If you don't like a story, don’t give it a kick.
</div>

<div class="HelpTitle">How do I submit stories?</div>

<div class="HelpAnswer">
You simply need to <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.Register)%>">register for a new account</a>. With an account you can submit stories by clicking the 'Submit a story' link on the right menu of the homepage.
</div>



<div class="HelpTitle">How do I find stories?</div>

<div class="HelpAnswer">
To find stories that have not been promoted, click the '<a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.NewStories)%>">Find stories</a>' link on the right menu of the homepage. You can also click the 'find' link beside each category in the list of categories.
</div>

<div class="HelpTitle">Is that all?</div>

<div class="HelpAnswer">
Nope. We are working on many great new features that will be released over the coming weeks and months. We are committed to making this site a valuable resource for our users.
<br /><br />
We would be delighted to hear your suggestions or comments, we can be reached at <a href="mailto:<%=this.HostProfile.Email %>"><%=this.HostProfile.Email%></a>.


</div>

    </div>
     
</asp:Content>
