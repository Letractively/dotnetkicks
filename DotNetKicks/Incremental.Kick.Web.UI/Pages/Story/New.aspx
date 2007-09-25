<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="Incremental.Kick.Web.UI.Pages.Story.New" MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Register Src="../../Controls/Story/SubmitNewStory.ascx" TagName="SubmitNewStory" TagPrefix="uc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
     
   <uc1:SubmitNewStory ID="SubmitNewStoryControl" runat="server" />
     
</asp:Content>

