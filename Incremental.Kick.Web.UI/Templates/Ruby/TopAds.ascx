<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopAds.ascx.cs" Inherits="Incremental.Kick.Web.UI.Templates.Ruby.TopAds" %>

<% if (this.KickPage.DisplayAds) { %>
    <script type="text/javascript"><!--
google_ad_client = "<%=this.KickPage.AdSenseID %>";
google_ad_width = 728;
google_ad_height = 90;
google_ad_format = "728x90_as";
google_ad_type = "text_image";
google_ad_channel = "";
google_color_border = "F0FEF1";
google_color_bg = "F0FEF1";
google_color_link = "0066CC";
google_color_text = "000000";
google_color_url = "000000";
google_ui_features = "rc:10";
//-->
</script>
<script type="text/javascript"
  src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>
<% } %>