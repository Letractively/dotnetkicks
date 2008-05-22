<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddComment.ascx.cs" Inherits="Incremental.Kick.Web.UI.Controls.AddComment" %>

<br />
<br />
<br />


<asp:Panel ID="AddCommentPanel" Visible="false" runat="server">
    <table class="FormTable">
        <tr>
            <td class="FormInput FormTD"><strong>Leave a comment:</strong>
                <asp:TextBox ID="Comment" runat="server" EnableViewState="False" TextMode="MultiLine" Width="100%" Height="170px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FormButtons FormTD">
            <span class="ValidationMessage">
               <asp:Label ID="InvalidComment" runat="server" EnableViewState="False" Text="Your comment is too short to post, please add a little more." Visible="False"></asp:Label>
                <asp:Button ID="AddCommentButton" runat="server" Text="Add Comment" OnClick="AddComment_Click" />
            </td>
         </tr>
    </table>
</asp:Panel>

<asp:Panel ID="LoginToCommentPanel" Visible="true" runat="server">

    <div class="HelpDiv">
    <img src="<%=this.KickPage.StaticIconRootUrl%>/information.png" /> 
    <a href="<%=this.LoginUrl%>">Login</a> or <a href="<%=this.RegisterUrl%>">create an account</a> to comment on this story
    </div>
</asp:Panel>