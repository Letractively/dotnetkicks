<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AddComment.ascx.cs"
    Inherits="Incremental.Kick.Web.UI.Controls.AddComment" %>
<br />
<br />
<br />

<script type="text/javascript">
// When DOM is ready bind charsCount function to comment textarea events and call it to handle previously existing text
$(function() { $("#<%= Comment.ClientID %>").change(countChars).keyup(countChars); countChars(); });

function countChars() {
    var commentField = $("#<%= Comment.ClientID %>");
    var comment = commentField.val();
    var maxLength = <%= Comment.MaxLength %>;
    var availableChars;

    if (comment.length > maxLength) {
        commentField.val(comment.substring(0, maxLength));
        availableChars = 0;
    }
    else {
        availableChars = maxLength - comment.length;
    }
    $("#availableChars").text(availableChars);
 }
 
</script>

<asp:Panel ID="AddCommentPanel" Visible="false" runat="server">
    <table class="FormTable">
        <tr>
            <td class="FormInput FormTD">
                <strong>Leave a comment:</strong>
                <asp:TextBox ID="Comment" runat="server" EnableViewState="False" MaxLength="2500"
                    TextMode="MultiLine" Width="100%" Height="170px"></asp:TextBox>
                Available characters: <span id="availableChars">2500</span>
            </td>
        </tr>
        <tr>
            <td class="FormButtons FormTD">
                <span class="ValidationMessage">
                    <asp:CustomValidator ID="CommentLength" runat="server" EnableClientScript="false"
                        Display="Dynamic" ControlToValidate="Comment" SetFocusOnError="true" OnServerValidate="CommentLength_ServerValidate">The comment must be between 4 and 2500 characters long.</asp:CustomValidator>
                </span>
                <asp:Button ID="AddCommentButton" runat="server" Text="Add Comment" OnClick="AddComment_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="LoginToCommentPanel" Visible="true" runat="server">
    <div class="HelpDiv">
        <img src="<%=KickPage.StaticIconRootUrl%>/information.png" alt="information" />
        <a href="<%=LoginUrl%>">Login</a> or <a href="<%=RegisterUrl%>">create an account</a>
        to comment on this story
    </div>
</asp:Panel>
