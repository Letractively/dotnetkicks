<%@ Page Language="C#" AutoEventWireup="true" Codebehind="GenerateKey.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Api.GenerateKey"
    MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Register Src="../../Controls/Api/ApiMenu.ascx" TagName="ApiMenu" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:MultiView ID="mvGenerateKey" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewNotLoggedIn" runat="server">
        <p>
            You must be logged in to view your API key.
        </p>
        </asp:View>
        <asp:View ID="viewShowKey" runat="server">
        <p>
            Your current API key is: 
            <asp:TextBox ID="txtApiKey" runat="server" ReadOnly="true" Width="200"></asp:TextBox>
        </p>
        <p>
            Click the button below to generate a new key.            
        </p>
        <p>
            <asp:Button ID="butGenerateNewKey" runat="server" Text="Generate New Key" OnClick="butGenerateNewKey_Click" />
        </p>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="RightContent" ContentPlaceHolderID="RightContent" runat="Server">
    <uc1:ApiMenu ID="ApiMenu1" runat="server" />
</asp:Content>
