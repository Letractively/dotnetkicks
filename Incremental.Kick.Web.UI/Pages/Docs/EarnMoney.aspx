<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EarnMoney.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Docs.EarnMoney" MasterPageFile="~/Templates/MasterPage.master" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     
   <div class="HelpDiv">
   <div class="HelpTitle"><%=this.HostProfile.SiteTitle%> 50% advertising revenue share</div>

<div class="HelpAnswer">
<p>
You can earn real money by submitting stories to <%=this.HostProfile.SiteTitle%>. You will receive 50% of the advertisement revenue on this site for all stories that you submit.
</p>
<p>
How it works is simple. Your AdSense account ID is used 50% of the time for all views of your submitted stories. As people click on your ads, your Google AdSense account will be credited. That’s it. Google will send you the check.
</p>


<asp:panel id="AuthenticatedPanel" runat="server">

<p>
If you have a Google AdSense account, please enter the ID below. You will find your ID in your custom AdSense code (it will be something like 'pub-123456..........'):
</p>

Your AdSense ID: <asp:textbox id="AdSenseIDTextBox" runat="server"></asp:textbox>
<asp:button id="UpdateAdSenseID" onclick="UpdateAdSenseID_Click" runat="server" text="Update" /><br />
<asp:RequiredFieldValidator runat="server" id="AdSenseIDRequiredValidator" ErrorMessage="Please enter your AdSense ID or signup for an AdSense account below" ControlToValidate="AdSenseIDTextBox" Display="Dynamic"></asp:RequiredFieldValidator>

</asp:panel>

<asp:panel id="AnonymousPanel" runat="server">

<a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.Login)%>">Login</a> or 
<a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.Register)%>">register</a> with <%=this.HostProfile.SiteTitle%>, then enter your AdSense ID to start earning.
</asp:panel>


<p>
If you do not have a Google AdSense account, you can signup below:
</p>


<p>

<script type="text/javascript"><!--
google_ad_client = "pub-2786188635346157";
google_ad_width = 125;
google_ad_height = 125;
google_ad_format = "125x125_as_rimg";
google_cpa_choice = "CAAQm-abzgEaCJeJo3gFw_6bKInC93M";
//--></script>
<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>
</p>

<p>
If you have any questions, please let us know : <a href="mailto:<%=this.HostProfile.Email %>"><%=this.HostProfile.Email %></a>
</p>

</div>
     
</asp:Content>


