<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideAds.ascx.cs" Inherits="Incremental.Kick.Web.UI.Templates.Ruby.SideAds" %>

<% if (this.KickPage.DisplayAds && this.KickPage.DisplaySideAds) { %>
<div id="sideAds">
<script type="text/javascript"><!--
google_ad_client = "<%=this.KickPage.AdSenseID %>";
google_ad_width = 160;
google_ad_height = 600;
google_ad_format = "160x600_as";
google_ad_type = "text";
google_ad_channel ="";
google_color_border = "FFFFFF";
google_color_bg = "FFFFFF";
google_color_link = "0066CC";
google_color_url = "000000";
google_color_text = "000000";
//--></script>
<script type="text/javascript"
  src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>
</div>

<% } %>
