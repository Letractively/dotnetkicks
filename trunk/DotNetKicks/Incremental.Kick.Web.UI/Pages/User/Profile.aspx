<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.User.Profile" %>

<%@ Register Src="../../Controls/User/UserAdmin.ascx" TagName="UserAdmin" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/User/Profile.ascx" TagName="Profile" TagPrefix="uc1" %>
<%@ Register Src="/Controls/User/ShoutBox.ascx" TagName="ShoutBox" TagPrefix="uc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

<Kick:UserProfileHeader id="UserProfileHeader" runat="server" />
    <table class="SimpleTable">
        <tr>
            <td width="60%" valign="top">
                <uc1:Profile ID="Profile1" runat="server" />
                
                <h3>Friends With:</h3>
                <Kick:UserList id="FriendList" runat="server" />
                
                <h3>Friends By:</h3>
                <Kick:UserList id="FriendByList" runat="server" />
                
                <h2>Kick Spy:</h2>
                <Kick:UserActionList id="UserActionList" runat="server" renderContainer="true" />
                
            </td>
            <td valign="top" style="padding-right: 40px;">
                <uc1:Shoutbox ID="Shoutbox" runat="server" />               
            </td>
        </tr>
    </table>
    
    

    <uc2:UserAdmin id="UserAdmin" runat="server" Visible="false" />
</asp:Content>