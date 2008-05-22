<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tools.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Docs.Tools" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     

<div class="HelpDiv">
    
    
    <div class="HelpTitle">Submit a story bookmarklet for Firefox</div>

<div class="HelpAnswer">

Drag the following link to your Firefox bookmarks toolbar: 

<p>
 &nbsp;&nbsp;&nbsp;<a href="javascript:location.href='<%=this.HostProfile.RootUrl%>/submit/?url='+encodeURIComponent(location.href)+'&title='+encodeURIComponent(document.title)" onclick="alert('please drag this link to the bookmarks toolbar on your firefox browser'); return false;">post to <%=this.HostProfile.SiteTitle%></a>
</p>

<p>
Simply press the new button on your toolbar anytime you wish to post a webpage to <%=this.HostProfile.SiteTitle%>.
</p>

<br />
<hr />
<br />
<br />

If you do not have Firefox, you can download it for free by clicking the following button:

<p>

<script type="text/javascript"><!--
google_ad_client = "pub-2786188635346157";
google_ad_width = 180;
google_ad_height = 60;
google_ad_format = "180x60_as_rimg";
google_cpa_choice = "CAAQ_7HzzwEaCKq-Q3II7WEwKLW193M";
//--></script>
<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>
</p>
</div>
    

</asp:Content>