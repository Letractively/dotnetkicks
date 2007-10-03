<%@ Import Namespace="Incremental.Kick.Helpers" %>
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
    
    if(commentField.length != 0)
    {
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
}
 
function insertEmoticonCode(code) {
    var commentField = $("#<%= Comment.ClientID %>");
    
    if (commentField[0].selectionStart >= 0)
        commentField.val(commentField.val().substring(0, commentField[0].selectionStart) 
            + code + commentField.val().substring(commentField[0].selectionStart, commentField.val().length));
    else
        commentField.val(commentField.val() + code);
        
    commentField.focus();
    countChars();
}
 
</script>

<asp:Panel ID="AddCommentPanel" Visible="false" runat="server">
    <table class="FormTable">
        <tr>
            <td class="FormInput FormTD">
                <strong>Leave a comment:</strong>
                <div style="padding: 5px 0 5px 0;">
                    Some emoticons are allowed: <span runat="server" id="Emoticons"></span>
                </div>
                <asp:TextBox ID="Comment" runat="server" EnableViewState="False" MaxLength="2500"
                    TextMode="MultiLine" Width="100%" Height="170px"></asp:TextBox>
                Available characters: <span id="availableChars">2500</span>
            </td>
        </tr>
        <tr>
            <td class="FormButtons FormTD">
                <span class="ValidationMessage">
                    <asp:CustomValidator ID="CommentLength" runat="server" EnableClientScript="false"
                        Display="Dynamic" ControlToValidate="Comment" OnServerValidate="CommentLength_ServerValidate"
                        ValidateEmptyText="True" Text="The comment must be between {0} and {1} characters long." />
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
