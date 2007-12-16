<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SubmitNewStory.ascx.cs"
    Inherits="Incremental.Kick.Web.UI.Controls.SubmitNewStory" %>
<%@ Register Src="KickItImagePersonalization.ascx" TagName="KickItImagePersonalization"
    TagPrefix="uc1" %>

<script type="text/javascript">

function checkStory(sender, args)
{
    StartLoading();
    var context = {sender:sender, args:args};

    ajaxServices.checkStory(args.Value, function(response) 
    { response.context = context; checkStoryCallback(response); });  
}

function checkStoryCallback(response)
{
    if(response.result)
    {
        response.context.sender.innerHTML = response.result;
        response.context.args.IsValid = false;
        
        response.context.sender.style.display = '';
    }
    else
        response.context.sender.style.display = 'none'; 
        
    FinishLoading();   
}

</script>

<br />
<br />
<asp:Panel ID="NewStoryPanel" runat="server">
    <table class="FormTable">
        <tr>
            <td class="FormTitle FormTD">
                Story Url:</td>
            <td class="FormInput FormTD">
                <asp:TextBox ID="Url" Text="http://" Width="100%" runat="server"></asp:TextBox>
                <span class="ValidationMessage">
                    <asp:RegularExpressionValidator ID="UrlValidator" runat="server" ErrorMessage="Please enter a valid URL.<br/>"
                        ControlToValidate="Url" ValidationExpression="^http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,4}(/\S*)?$"
                        Display="Dynamic" ValidationGroup="SubmitStoryValidation"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="UrlRequired" runat="server" ControlToValidate="Url"
                        ErrorMessage="Please enter the URL of the story.<br/>" Display="Dynamic" ValidationGroup="SubmitStoryValidation"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="UrlCheck" runat="server" ControlToValidate="Url"
                        Display="Dynamic" ErrorMessage="You cannot submit this URL.<br/>" ValidationGroup="SubmitStoryValidation"
                        ClientValidationFunction="checkStory" OnServerValidate="UrlCheck_ServerValidate"></asp:CustomValidator></span>
                <span class="FormHelp">The URL to the story.</span>
            </td>
        </tr>
        <tr>
            <td class="FormTitle FormTD">
                Title:</td>
            <td class="FormInput FormTD">
                <asp:TextBox ID="Title" Columns="60" MaxLength="70" Width="100%" runat="server"></asp:TextBox>
                <asp:Label ID="TitleNoteLabel" runat="server" Visible="false" EnableViewState="False"
                    ForeColor="Blue"></asp:Label>
                <span class="ValidationMessage">
                    <asp:RequiredFieldValidator ID="TitleRequired" runat="server" ControlToValidate="Title"
                        ErrorMessage="Please enter a title for the story.<br/>" Display="Dynamic" ValidationGroup="SubmitStoryValidation"></asp:RequiredFieldValidator>
                </span><span class="FormHelp">The title of the story.</span>
            </td>
        </tr>
        <tr>
            <td class="FormTitle FormTD">
                Description:</td>
            <td class="FormInput FormTD">
                <asp:TextBox ID="Description" TextMode="MultiLine" Columns="60" Rows="7" Width="100%"
                    runat="server"></asp:TextBox>
                <span class="ValidationMessage">
                    <asp:RequiredFieldValidator ID="DescriptionRequired" runat="server" ControlToValidate="Description"
                        ErrorMessage="Please enter a description for the story.<br/>" Display="Dynamic"
                        ValidationGroup="SubmitStoryValidation"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="descriptionTitleDifferent" runat="server" ControlToCompare="Title"
                        ControlToValidate="Description" ErrorMessage="The story title and description cannot be the same.<br/>"
                        Operator="NotEqual" SetFocusOnError="True" ToolTip="Tell us something more about the story"
                        ValidationGroup="SubmitStoryValidation" Display="Dynamic"></asp:CompareValidator></span>
                <span class="FormHelp">In your own word, provide a brief description of the story.</span>
            </td>
        </tr>
        <tr>
            <td class="FormTitle FormTD">
                Category:</td>
            <td class="FormInput FormTD">
                <asp:RadioButtonList ID="Category" runat="server" RepeatColumns="5" DataTextField="Name"
                    DataValueField="CategoryID" />
                <asp:RequiredFieldValidator ID="CategoryRequired" runat="server" ControlToValidate="Category"
                    ErrorMessage="Please choose a category for this story.<br/>" Display="Dynamic"
                    ValidationGroup="SubmitStoryValidation"></asp:RequiredFieldValidator>
                <span class="FormHelp">Select the best category that this story belong to.</span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="FormButtons FormTD">
                <Subkismet:InvisibleCaptcha ID="captcha" runat="server" ErrorMessage="Oops! You must be bad at maths."
                    Display="dynamic" ValidationGroup="SubmitStoryValidation" />
                <br />
                <asp:Button ID="SubmitStory" runat="server" Text="Submit Story" OnClick="SubmitStory_Click"
                    ValidationGroup="SubmitStoryValidation" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="SuccessPanel" runat="server" Visible="False">
    <div class="HelpDiv">
        Thanks, your story has been submitted & kicked and will appear in the
        <asp:HyperLink ID="UpcomingStoryQueue" runat="server" />
        shortly.
        <p>
            <asp:HyperLink ID="StoryLink" Text="View the story" runat="server" /></p>
        <uc1:KickItImagePersonalization ID="KickItImagePersonalization" runat="server"></uc1:KickItImagePersonalization>
    </div>
</asp:Panel>
&nbsp;
<br />
<div class="HelpDiv">
    <img alt="information" src="<%=KickPage.StaticIconRootUrl%>/information.png" />
    Tip: If you have firefox, use our new <a href="<%=ToolsUrl%>">submit a story bookmarklet</a>
    to rapidly post new stories to
    <%=KickPage.HostProfile.SiteTitle%>
    .
</div>
