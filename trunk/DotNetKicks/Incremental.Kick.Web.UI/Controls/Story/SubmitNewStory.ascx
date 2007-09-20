<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubmitNewStory.ascx.cs"
    Inherits="Incremental.Kick.Web.UI.Controls.SubmitNewStory" %>

<script type="text/javascript">
function checkStoryExists(sender, args)
{
    var context = {sender:sender, args:args};

    Incremental.Kick.Web.UI.Services.Ajax.AjaxServices.FetchKickedStoryUrlByUrl(args.Value, checkStoryExistsCallback, context);   
}

function checkStoryExistsCallback(response)
{
    if(response.value)
    {
        response.context.sender.innerHTML = "The story already exists. You may want to <a href='" + response.value + "'>kick it</a> instead";
        response.context.args.IsValid = false;
        
        response.context.sender.style.display = '';
    }
    else
        response.context.sender.style.display = 'none';    
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
                    <asp:RegularExpressionValidator ID="UrlValidator" runat="server" ErrorMessage="Please enter a valid URL."
                        ControlToValidate="Url" ValidationExpression="^http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,4}(/\S*)?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="UrlRequired" runat="server" ControlToValidate="Url"
                        ErrorMessage="Please enter the URL of the story." Display="Dynamic" ValidationGroup="SubmitStoryValidation"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="StoryAlreadyExists" runat="server" ControlToValidate="Url"
                        Display="Dynamic" ErrorMessage="The story already exists." ValidationGroup="SubmitStoryValidation"
                        ClientValidationFunction="checkStoryExists" OnServerValidate="StoryAlreadyExists_ServerValidate"></asp:CustomValidator></span><br />
                <span class="FormHelp">The URL to the story.</span>
            </td>
        </tr>
        <tr>
            <td class="FormTitle FormTD">
                Title:</td>
            <td class="FormInput FormTD">
                <asp:TextBox ID="Title" Columns="60" MaxLength="70" runat="server"></asp:TextBox>
                <asp:Label ID="TitleNoteLabel" runat="server" EnableViewState="False" ForeColor="Blue"></asp:Label>
                <span class="ValidationMessage">
                    <asp:RequiredFieldValidator ID="TitleRequired" runat="server" ControlToValidate="Title"
                        ErrorMessage="Please enter a title for the story." Display="Dynamic" ValidationGroup="SubmitStoryValidation"></asp:RequiredFieldValidator>
                </span>
                <br />
                <span class="FormHelp">The title of the story.</span>
            </td>
        </tr>
        <tr>
            <td class="FormTitle FormTD">
                Description:</td>
            <td class="FormInput FormTD">
                <asp:TextBox ID="Description" TextMode="MultiLine" Columns="60" Rows="7" runat="server"></asp:TextBox>
                <span class="ValidationMessage">
                    <asp:RequiredFieldValidator ID="DescriptionRequired" runat="server" ControlToValidate="Description"
                        ErrorMessage="Please enter a description for the story." Display="Dynamic" ValidationGroup="SubmitStoryValidation"></asp:RequiredFieldValidator>
                </span>
                <br />
                <span class="FormHelp">In your own word, provide a brief description of the story.</span>
            </td>
        </tr>
        <tr>
            <td class="FormTitle FormTD">
                Category:</td>
            <td class="FormInput FormTD">
                <asp:RadioButtonList ID="Category" runat="server" RepeatColumns="5" />
                <asp:RequiredFieldValidator ID="CategoryRequired" runat="server" ControlToValidate="Category"
                    ErrorMessage="Please choose a category for this story." Display="Dynamic" ValidationGroup="SubmitStoryValidation"></asp:RequiredFieldValidator>
                <br />
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
            &nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="StoryLink" Text="View the story" runat="server" />
        </p>
        <br />
        <p>
            &nbsp;&nbsp;&nbsp;<img alt="new" src="<%=KickPage.StaticIconRootUrl %>/new.gif" width="28"
                height="11" border="0" />
            Add a live kick counter to your blog -->
            <img alt="livekickit" src="<%=KickPage.StaticIconRootUrl%>/LiveKickIt.png" />
        </p>
        <p>
            Simple copy and paste this HTML into your blog post.
            <br />
            <br />
            <asp:TextBox ID="LiveImage" runat="server" Columns="80" Rows="4" TextMode="MultiLine" />
        </p>
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
