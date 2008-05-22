<%@ Import Namespace="Incremental.Common.Web.Helpers" %>
<%@ Import Namespace="Incremental.Kick.Web.Controls" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="KickItImagePersonalization.ascx.cs"
    Inherits="Incremental.Kick.Web.UI.Controls.KickItImagePersonalization" %>
<style type="text/css">
div.csq {
background-color:transparent;
border:medium none;
height:10px;
width:10px;
}
</style>

<script language="JavaScript" type="text/JavaScript">
    var defaultColors = { kickText: '#FFFFFF', 
                          kickBackground: '#A3C952', 
                          countText: '#000000', 
                          countBackground: '#D4E1ED',
                          border: '#000000' };

    var customColors = {  kickText: '#<%= KickPage.KickUserProfile.KickItTextColor ??  "FFFFFF" %>', 
                          kickBackground: '#<%= KickPage.KickUserProfile.KickItBackgroundColor ??  "A3C952" %>', 
                          countText: '#<%= KickPage.KickUserProfile.KickCountTextColor ??  "000000" %>', 
                          countBackground: '#<%= KickPage.KickUserProfile.KickCountBackgroundColor ??  "D4E1ED" %>',
                          border: '#<%= KickPage.KickUserProfile.KickImageBorderColor ??  "000000" %>' };
                          
    var imageUrlFormatString = "<%= LiveImage.ImageUrlClientSideFormatString %>";
    var htmlCodeFormatString = '<%= LiveImage.HtmlCodeClientSideFormatString %>';
                          
    String.format = function( text )
    {
        //check if there are two arguments in the arguments list
        if ( arguments.length <= 1 )
        {
            //if there are not 2 or more arguments there’s nothing to replace
            //just return the original text
            return text;
        }

        //decrement to move to the second argument in the array
        var tokenCount = arguments.length - 2;

        for( var token = 0; token <= tokenCount; token++ )
        {
            //iterate through the tokens and replace their placeholders from the original text in order
            text = text.replace( new RegExp( "\\{" + token + "\\}", "gi" ), arguments[ token + 1 ] );
        }

        return text;
    };

    function assignColor(color) 
    {
         var colorFormatRegex = /#[0-9A-Za-z]{6}/;
         
         if (!colorFormatRegex.test(color)) 
             return;
         
         if($('#kickTextRadio')[0].checked)
         {
            $('#kickTextColor')[0].style.backgroundColor = 
            $('#kickTextText')[0].value = color;
         }
         else if($('#kickBackgroundRadio')[0].checked)
         {
            $('#kickBackgroundColor')[0].style.backgroundColor = 
            $('#kickBackgroundText')[0].value = color;
         }
         else if($('#countTextRadio')[0].checked)
         {
            $('#countTextColor')[0].style.backgroundColor = 
            $('#countTextText')[0].value = color;
         }
         else if($('#countBackgroundRadio')[0].checked)
         {
            $('#countBackgroundColor')[0].style.backgroundColor = 
            $('#countBackgroundText')[0].value = color;
         }
         else if($('#borderRadio')[0].checked)
         {
            $('#borderColor')[0].style.backgroundColor = 
            $('#borderText')[0].value = color;
         }
    }

    function updateImageAndHtmlCode()
    {    
        $('#liveImage')[0].src = String.format(imageUrlFormatString,
          $('#borderText')[0].value != defaultColors.border ? "&border=" + stripHexChar($('#borderText')[0].value) : "",
          $('#kickTextText')[0].value != defaultColors.kickText ? "&fgcolor=" + stripHexChar($('#kickTextText')[0].value) : "",
          $('#kickBackgroundText')[0].value != defaultColors.kickBackground ? "&bgcolor=" + stripHexChar($('#kickBackgroundText')[0].value) : "",
          $('#countTextText')[0].value != defaultColors.countText ? "&cfgcolor=" + stripHexChar($('#countTextText')[0].value) : "",
          $('#countBackgroundText')[0].value != defaultColors.countBackground ? "&cbgcolor=" + stripHexChar($('#countBackgroundText')[0].value) : "");
    
        $('#htmlCode')[0].value = String.format(htmlCodeFormatString, $('#liveImage')[0].src);
    }
    
    function stripHexChar(str)
    {
        return str.substr(1);
    }
    
    function saveColorPreferences()
    {
        StartLoading();
        $('#saveColors')[0].disabled = "disabled";
        
        ajaxServices.saveColorPreferences(  stripHexChar($('#kickTextText')[0].value), 
                                            stripHexChar($('#kickBackgroundText')[0].value), 
                                            stripHexChar($('#countTextText')[0].value), 
                                            stripHexChar($('#countBackgroundText')[0].value), 
                                            stripHexChar($('#borderText')[0].value), 
                                            saveColorPreferencesCallback);
    }
    
    function saveColorPreferencesCallback(response)
    {
        FinishLoading();
        
        $('#saveColorsFeedback').text(response.error == null ? "Preferences saved successfully" : "Error saving preferences");
        
        if(response.error != null)
            $('#saveColors')[0].disabled = "";
    }
    
    $(function()
    {
        $('#kickTextColor')[0].style.backgroundColor = 
        $('#kickTextText')[0].value = customColors.kickText;

        $('#kickBackgroundColor')[0].style.backgroundColor = 
        $('#kickBackgroundText')[0].value = customColors.kickBackground;

        $('#countTextColor')[0].style.backgroundColor = 
        $('#countTextText')[0].value = customColors.countText;

        $('#countBackgroundColor')[0].style.backgroundColor = 
        $('#countBackgroundText')[0].value = customColors.countBackground;

        $('#borderColor')[0].style.backgroundColor = 
        $('#borderText')[0].value = customColors.border;
        
        updateImageAndHtmlCode();
    });
</script>

<p>
    <img alt="new" src="<%=KickPage.StaticIconRootUrl %>/new.gif" width="28" height="11"
        border="0" />
    Add a live kick counter to your blog >>
    <img id="liveImage" alt="liveImage" style="vertical-align: middle;" />
</p>
<p>
    You can even customize the image by choosing your own colors, and then clicking
    the button below to update the preview and the html code:</p>
<div style="float: left; margin-right: 10px;">
    <table style="border: 0; padding: 0; margin: 0 0 12px 0; border-collapse: collapse;
        width: 200px;">
        <tr>
            <td style="background-color: #000000; margin: 0; padding: 0">
                <a href="javascript:assignColor('#000000')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #000033; margin: 0; padding: 0">
                <a href="javascript:assignColor('#000033')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #000066; margin: 0; padding: 0">
                <a href="javascript:assignColor('#000066')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #000099; margin: 0; padding: 0">
                <a href="javascript:assignColor('#000099')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #0000CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#0000CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #0000FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#0000FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #006600; margin: 0; padding: 0">
                <a href="javascript:assignColor('#006600')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #006633; margin: 0; padding: 0">
                <a href="javascript:assignColor('#006633')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #006666; margin: 0; padding: 0">
                <a href="javascript:assignColor('#006666')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #006699; margin: 0; padding: 0">
                <a href="javascript:assignColor('#006699')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #0066CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#0066CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #0066FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#0066FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00CC00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00CC00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00CC33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00CC33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00CC66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00CC66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00CC99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00CC99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00CCCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00CCCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00CCFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00CCFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #003300; margin: 0; padding: 0">
                <a href="javascript:assignColor('#003300')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #003333; margin: 0; padding: 0">
                <a href="javascript:assignColor('#003333')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #003366; margin: 0; padding: 0">
                <a href="javascript:assignColor('#003366')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #003399; margin: 0; padding: 0">
                <a href="javascript:assignColor('#003399')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #0033CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#0033CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #0033FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#0033FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #009900; margin: 0; padding: 0">
                <a href="javascript:assignColor('#009900')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #009933; margin: 0; padding: 0">
                <a href="javascript:assignColor('#009933')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #009966; margin: 0; padding: 0">
                <a href="javascript:assignColor('#009966')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #009999; margin: 0; padding: 0">
                <a href="javascript:assignColor('#009999')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #0099CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#0099CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #0099FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#0099FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00FF00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00FF00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00FF33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00FF33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00FF66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00FF66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00FF99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00FF99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00FFCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00FFCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #00FFFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#00FFFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #330000; margin: 0; padding: 0">
                <a href="javascript:assignColor('#330000')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #330033; margin: 0; padding: 0">
                <a href="javascript:assignColor('#330033')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #330066; margin: 0; padding: 0">
                <a href="javascript:assignColor('#330066')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #330099; margin: 0; padding: 0">
                <a href="javascript:assignColor('#330099')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #3300CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#3300CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #3300FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#3300FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #336600; margin: 0; padding: 0">
                <a href="javascript:assignColor('#336600')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #336633; margin: 0; padding: 0">
                <a href="javascript:assignColor('#336633')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #336666; margin: 0; padding: 0">
                <a href="javascript:assignColor('#336666')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #336699; margin: 0; padding: 0">
                <a href="javascript:assignColor('#336699')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #3366CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#3366CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #3366FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#3366FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33CC00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33CC00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33CC33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33CC33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33CC66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33CC66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33CC99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33CC99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33CCCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33CCCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33CCFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33CCFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #333300; margin: 0; padding: 0">
                <a href="javascript:assignColor('#333300')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #333333; margin: 0; padding: 0">
                <a href="javascript:assignColor('#333333')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #333366; margin: 0; padding: 0">
                <a href="javascript:assignColor('#333366')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #333399; margin: 0; padding: 0">
                <a href="javascript:assignColor('#333399')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #3333CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#3333CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #3333FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#3333FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #339900; margin: 0; padding: 0">
                <a href="javascript:assignColor('#339900')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #339933; margin: 0; padding: 0">
                <a href="javascript:assignColor('#339933')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #339966; margin: 0; padding: 0">
                <a href="javascript:assignColor('#339966')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #339999; margin: 0; padding: 0">
                <a href="javascript:assignColor('#339999')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #3399CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#3399CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #3399FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#3399FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33FF00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33FF00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33FF33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33FF33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33FF66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33FF66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33FF99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33FF99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33FFCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33FFCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #33FFFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#33FFFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #660000; margin: 0; padding: 0">
                <a href="javascript:assignColor('#660000')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #660033; margin: 0; padding: 0">
                <a href="javascript:assignColor('#660033')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #660066; margin: 0; padding: 0">
                <a href="javascript:assignColor('#660066')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #660099; margin: 0; padding: 0">
                <a href="javascript:assignColor('#660099')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #6600CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#6600CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #6600FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#6600FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #666600; margin: 0; padding: 0">
                <a href="javascript:assignColor('#666600')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #666633; margin: 0; padding: 0">
                <a href="javascript:assignColor('#666633')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #666666; margin: 0; padding: 0">
                <a href="javascript:assignColor('#666666')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #666699; margin: 0; padding: 0">
                <a href="javascript:assignColor('#666699')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #6666CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#6666CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #6666FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#6666FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66CC00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66CC00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66CC33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66CC33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66CC66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66CC66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66CC99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66CC99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66CCCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66CCCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66CCFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66CCFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #663300; margin: 0; padding: 0">
                <a href="javascript:assignColor('#663300')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #663333; margin: 0; padding: 0">
                <a href="javascript:assignColor('#663333')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #663366; margin: 0; padding: 0">
                <a href="javascript:assignColor('#663366')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #663399; margin: 0; padding: 0">
                <a href="javascript:assignColor('#663399')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #6633CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#6633CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #6633FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#6633FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #669900; margin: 0; padding: 0">
                <a href="javascript:assignColor('#669900')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #669933; margin: 0; padding: 0">
                <a href="javascript:assignColor('#669933')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #669966; margin: 0; padding: 0">
                <a href="javascript:assignColor('#669966')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #669999; margin: 0; padding: 0">
                <a href="javascript:assignColor('#669999')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #6699CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#6699CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #6699FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#6699FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66FF00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66FF00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66FF33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66FF33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66FF66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66FF66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66FF99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66FF99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66FFCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66FFCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #66FFFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#66FFFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #990000; margin: 0; padding: 0">
                <a href="javascript:assignColor('#990000')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #990033; margin: 0; padding: 0">
                <a href="javascript:assignColor('#990033')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #990066; margin: 0; padding: 0">
                <a href="javascript:assignColor('#990066')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #990099; margin: 0; padding: 0">
                <a href="javascript:assignColor('#990099')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #9900CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#9900CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #9900FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#9900FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #996600; margin: 0; padding: 0">
                <a href="javascript:assignColor('#996600')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #996633; margin: 0; padding: 0">
                <a href="javascript:assignColor('#996633')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #996666; margin: 0; padding: 0">
                <a href="javascript:assignColor('#996666')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #996699; margin: 0; padding: 0">
                <a href="javascript:assignColor('#996699')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #9966CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#9966CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #9966FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#9966FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99CC00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99CC00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99CC33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99CC33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99CC66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99CC66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99CC99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99CC99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99CCCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99CCCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99CCFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99CCFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #993300; margin: 0; padding: 0">
                <a href="javascript:assignColor('#993300')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #993333; margin: 0; padding: 0">
                <a href="javascript:assignColor('#993333')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #993366; margin: 0; padding: 0">
                <a href="javascript:assignColor('#993366')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #993399; margin: 0; padding: 0">
                <a href="javascript:assignColor('#993399')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #9933CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#9933CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #9933FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#9933FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #999900; margin: 0; padding: 0">
                <a href="javascript:assignColor('#999900')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #999933; margin: 0; padding: 0">
                <a href="javascript:assignColor('#999933')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #999966; margin: 0; padding: 0">
                <a href="javascript:assignColor('#999966')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #999999; margin: 0; padding: 0">
                <a href="javascript:assignColor('#999999')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #9999CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#9999CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #9999FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#9999FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99FF00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99FF00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99FF33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99FF33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99FF66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99FF66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99FF99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99FF99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99FFCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99FFCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #99FFFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#99FFFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #CC0000; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC0000')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC0033; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC0033')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC0066; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC0066')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC0099; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC0099')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC00CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC00CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC00FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC00FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC6600; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC6600')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC6633; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC6633')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC6666; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC6666')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC6699; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC6699')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC66CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC66CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC66FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC66FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCCC00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCCC00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCCC33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCCC33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCCC66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCCC66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCCC99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCCC99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCCCCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCCCCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCCCFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCCCFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #CC3300; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC3300')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC3333; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC3333')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC3366; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC3366')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC3399; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC3399')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC33CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC33CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC33FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC33FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC9900; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC9900')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC9933; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC9933')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC9966; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC9966')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC9999; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC9999')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC99CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC99CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CC99FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CC99FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCFF00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCFF00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCFF33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCFF33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCFF66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCFF66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCFF99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCFF99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCFFCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCFFCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #CCFFFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#CCFFFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #FF0000; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF0000')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF0033; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF0033')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF0066; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF0066')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF0099; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF0099')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF00CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF00CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF00FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF00FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF6600; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF6600')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF6633; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF6633')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF6666; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF6666')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF6699; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF6699')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF66CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF66CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF66FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF66FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFCC00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFCC00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFCC33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFCC33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFCC66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFCC66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFCC99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFCC99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFCCCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFCCCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFCCFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFCCFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td style="background-color: #FF3300; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF3300')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF3333; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF3333')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF3366; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF3366')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF3399; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF3399')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF33CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF33CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF33FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF33FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF9900; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF9900')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF9933; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF9933')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF9966; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF9966')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF9999; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF9999')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF99CC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF99CC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FF99FF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FF99FF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFFF00; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFFF00')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFFF33; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFFF33')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFFF66; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFFF66')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFFF99; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFFF99')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFFFCC; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFFFCC')">
                    <div class="csq">
                    </div>
                </a>
            </td>
            <td style="background-color: #FFFFFF; margin: 0; padding: 0">
                <a href="javascript:assignColor('#FFFFFF')">
                    <div class="csq">
                    </div>
                </a>
            </td>
        </tr>
    </table>
</div>
<ul style="list-style-type: none">
    <li>
        <input id="kickTextRadio" class="radioButton" type="radio" checked="checked" name="radioColor" />
        <input type="text" id="kickTextText" style="width: 80px;" onfocus="$('#kickTextRadio')[0].checked=true;"
            onkeyup="assignColor(this.value)" value="99CCFF" maxlength="7" />
        <input type="text" readonly="readonly" id="kickTextColor" style="cursor: default;
            width: 20px; border: 1px solid; margin-right: 5px;" />
        "Kick It" text </li>
    <li>
        <input id="kickBackgroundRadio" class="radioButton" type="radio" name="radioColor" />
        <input type="text" id="kickBackgroundText" style="width: 80px;" onfocus="$('#kickBackgroundRadio')[0].checked=true;"
            onkeyup="assignColor(this.value)" value="99CCFF" maxlength="7" />
        <input type="text" readonly="readonly" id="kickBackgroundColor" style="cursor: default;
            width: 20px; border: 1px solid; margin-right: 5px;" />
        "Kick It" background </li>
    <li>
        <input id="countTextRadio" class="radioButton" type="radio" name="radioColor" />
        <input type="text" id="countTextText" style="width: 80px;" onfocus="$('#countTextRadio')[0].checked=true;"
            onkeyup="assignColor(this.value)" value="99CCFF" maxlength="7" />
        <input type="text" readonly="readonly" id="countTextColor" style="cursor: default;
            width: 20px; border: 1px solid; margin-right: 5px;" />
        kick count text </li>
    <li>
        <input id="countBackgroundRadio" class="radioButton" type="radio" name="radioColor" />
        <input type="text" id="countBackgroundText" style="width: 80px;" onfocus="$('#countBackgroundRadio')[0].checked=true;"
            onkeyup="assignColor(this.value)" value="99CCFF" maxlength="7" />
        <input type="text" readonly="readonly" id="countBackgroundColor" style="cursor: default;
            width: 20px; border: 1px solid; margin-right: 5px;" />
        kick count background </li>
    <li>
        <input id="borderRadio" class="radioButton" type="radio" name="radioColor" />
        <input type="text" id="borderText" style="width: 80px;" onfocus="$('#borderRadio')[0].checked=true;"
            onkeyup="assignColor(this.value)" value="99CCFF" maxlength="7" />
        <input type="text" readonly="readonly" id="borderColor" style="cursor: default; width: 20px;
            border: 1px solid; margin-right: 5px;" />
        border </li>
</ul>
<div style="clear: both;">
</div>
<input type="button" onclick="$('#saveColors').attr('disabled', '');updateImageAndHtmlCode();" value="Update live image!" />
<% if (!KickPage.KickUserProfile.IsGuest)
   { %>
   <input type="button" id="saveColors" onclick="saveColorPreferences();" disabled="disabled" value="Save color preferences" />
   <span id="saveColorsFeedback" style="color:Red;"></span>
<% } %>
<p>
    Simply copy and paste this HTML into your blog post.
    <br />
    <br />
    <textarea id="htmlCode" onclick="this.select();" cols="80" rows="4"></textarea>
</p>
