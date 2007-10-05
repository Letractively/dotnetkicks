<%@ Page Language="C#" AutoEventWireup="true" Codebehind="GenerateKey.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Api.GenerateKey"  MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Register Src="../../Controls/Api/ApiMenu.ascx" TagName="ApiMenu" TagPrefix="uc1" %>

<asp:content id="MainContent" contentplaceholderid="MainContent" runat="Server">


    <h4>Your Current API Key</h4>
    <p>
        
    </p>
    <p>
        
    </p>
</asp:content>
<asp:content id="RightContent" contentplaceholderid="RightContent" runat="Server">
    <uc1:ApiMenu id="ApiMenu1" runat="server" />
</asp:content>
