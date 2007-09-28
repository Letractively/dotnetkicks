<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FrequentlyAskedQuestions.aspx.cs"
    Inherits="Incremental.Kick.Web.UI.Pages.Docs.FrequentlyAskedQuestions" MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <style type="text/css">
/* Temp will be moved to .css file once things have been more finalized */
.FaqCategories
{

}
.FaqCategory
{
    font-size: medium;
    font-size: medium;
    font-weight: bold;
}
.FaqQuestion
{
    font-weight: bold;
}
.FaqAnswer  
{
}
</style>
    <h2>
        DotNetKicks FAQ</h2>
    Topics:
    <dl id="FAQ_Top" class="FaqCategories">
        <dt><a href="#FAQ_Meta">FAQ Meta</a></dt>
        <dd>
            This section are questions relating to this FAQ document.</dd>
        <dt><a href="#FAQ_StoryKicks">Story Kicks</a></dt>
        <!-- Story Related Sections -->
        <dd>
            This section contains questions relating the "Kicking" of stories.
        </dd>
        <dt><a href="#FAQ_StorySubmission">Story Submission</a></dt>
        <dd>
            This section relates to the story submission processes including submission rules
            concerning SPAM and "BlogSpam".</dd>
        <dt><a href="#FAQ_StoryCategories">Story Categories</a></dt>
        <dd>
            This section provides guidance on common questions related to story categories.</dd>
        <dt><a href="#FAQ_StoryTags">Story Tags</a></dt>
        <dd>
            This section provides answers to questions about story tags and the tagging process.</dd>
        <dt><a href="#FAQ_UserComments">User Comments</a></dt>
        <dd>
            This section deals with submitting and moderating user comments related to a story.</dd>
        <!-- User Related Sections -->
        <dt><a href="#FAQ_UserBanning">User Banning</a></dt>
        <dd>
            This section answers questions about the banning of users.</dd>
        <dt><a href="#FAQ_UserProfile">User Profile</a></dt>
        <dd>
            This section addresses questions relating to user accounts, profiles, and personalization.</dd>
        <dt><a href="#FAQ_UserKarma">User Karma Points</a></dt>
        <dd>
            This section discusses questions related to user karma points.</dd>
        <dt><a href="#FAQ_UserFriends">User Friends</a></dt>
        <dd>
            This section contains questions related to friends.</dd>
        <!-- Site wide level topics -->
        <dt><a href="#FAQ_SiteWebFeeds">WebFeeds</a></dt>
        <dd>
            This section provides answers to questions concerning RSS, Web Feeds, and syndication.</dd>
        <dt><a href="#FAQ_EarnMoney">FAQ_EarnMoney</a></dt>
        <dd>
            FAQ_EarnMoney</dd>
        <dt><a href="#FAQ_Helping">FAQ_Helping</a></dt>
        <dd>
            FAQ_Helping</dd>
        <!-- place holders 
 <dt><a href="#">TOPIC</a></dt>
        <dd>
            DESCRIPTION</dd>
 <dt><a href="#">TOPIC</a></dt>
        <dd>
            DESCRIPTION</dd>
 <dt><a href="#">TOPIC</a></dt>
        <dd>
            DESCRIPTION</dd>
-->
    </dl>
    <hr />
    <h3 id="FAQ_Meta" class="FaqCategory">
        FAQ Meta</h3>
    <p class="FaqQuestion">
        What is a FAQ?</p>
    <p class="FaqAnswer">
        An FAQ is a list of Frequently Asked Questions (FAQ). This page should address a
        majority of the most frequently asked questions concerning this web site.</p>
    <p class="FaqQuestion">
        I have a question that is not answered in this FAQ. What should I do?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        Who is responsible for the FAQ?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_StoryKicks" class="FaqCategory">
        Story Kicks</h3>
    <p class="FaqQuestion">
        What is a Kick?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I Kick a story?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I Unkick a story?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How many Kicks does it take to get to the front page?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_StorySubmission" class="FaqCategory">
        Story Submission</h3>
    <p class="FaqQuestion">
        How do I submit stories to DotNetKicks?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I add a “Kick It” link to my own page?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        Why didn’t you post my story?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        Why was my story marked as SPAM?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I add a "Kick It" image to my blog entry?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I change the colors of my "Kick It" image?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_StoryCategories" class="FaqCategory">
        Story Categories</h3>
    <p class="FaqQuestion">
        What is a category for?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        What if a category that I need doesn’t exist?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        What if my story was placed in the wrong category?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_StoryTags" class="FaqCategory">
        Story Tags</h3>
    <p class="FaqQuestion">
        What is a tag for?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I add a tag?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I remove a tag?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p id="FAQ_UserBanning" class="FaqQuestion">
        Why was I banned?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_UserProfile" class="FaqCategory">
        User Profile</h3>
    <p class="FaqQuestion">
        I forgot my password!</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        I don’t want any cookies!</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I change my password?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I change my email address?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I see which stories I have kicked?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I see which stories I have submitted?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I see my friends?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I add my website/blog/ blog feed?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I set my avatar/image?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_UserComments" class="FaqCategory">
        User Comments</h3>
    <p class="FaqQuestion">
        How do I add a comment?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I delete my comment?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        Can I edit my comments?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        Can I delete someone’s comment about my story?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        Why was my comment deleted?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_UserKarma" class="FaqCategory">
        User Karma Points</h3>
    <p class="FaqQuestion">
        What is Karma?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I gain Karma points?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        Why did I lose Karma points?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I "spend" Karma points?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_UserFriends" class="FaqCategory">
        User Friends</h3>
    <p class="FaqQuestion">
        What is a friend?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I add a friend?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I remove a friend?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_SiteWebFeeds" class="FaqCategory">
        Web Feeds</h3>
    <p class="FaqQuestion">
        What is a Web Feed?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        What is RSS?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I subscribe to a DotNetKicks Web Feed?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I subscribe to a DotNetKicks category only Web Feed?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I subscribe to …</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_EarnMoney" class="FaqCategory">
        Earn Money</h3>
    <p class="FaqQuestion">
        How can I earn money?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I get a Google AdSense id?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I enter my Google AdSense id?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_Helping" class="FaqCategory">
        Helping DotNetKicks</h3>
    <p class="FaqQuestion">
        How can I help DotNetKicks?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I submit a bug?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <p class="FaqQuestion">
        How do I submit comments?</p>
    <p class="FaqAnswer">
        Placeholder</p>
    <a href="#FAQ_Top">Return to Topic List</a>
</asp:Content>
