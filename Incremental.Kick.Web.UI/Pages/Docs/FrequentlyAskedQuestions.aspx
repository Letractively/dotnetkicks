<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FrequentlyAskedQuestions.aspx.cs"
    Inherits="Incremental.Kick.Web.UI.Pages.Docs.FrequentlyAskedQuestions" MasterPageFile="~/Templates/MasterPage.master" %>

<%@ Import Namespace="Incremental.Kick.Web.Controls" %>
<%@ Import Namespace="Incremental.Common.Web.Helpers" %>
<%@ Import Namespace="Incremental.Kick.Web.Helpers" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <style type="text/css">
/* Temp 
will be moved to .css file once things have been more finalized */
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
        <!-- User Related Sections -->
        <dt><a href="#FAQ_UserBanning">User Banning</a></dt>
        <dd>
            This section answers questions about the banning of users.</dd>
        <dt><a href="#FAQ_UserProfile">User Profile</a></dt>
        <dd>
            This section addresses questions relating to user accounts, profiles, and personalization.</dd>
        <dt><a href="#FAQ_UserComments">User Comments</a></dt>
        <dd>
            This section deals with submitting and moderating user comments related to a story.</dd>
        <!--
        <dt><a href="#FAQ_UserKarma">User Karma Points</a></dt>
        <dd>
            This section discusses questions related to user karma points.</dd>
-->
        <dt><a href="#FAQ_UserFriends">User Friends</a></dt>
        <dd>
            This section contains questions related to friends.</dd>
        <!-- Site wide level topics -->
        <dt><a href="#FAQ_SiteWebFeeds">RSS, Web Feeds</a></dt>
        <dd>
            This section provides answers to questions concerning RSS, Web Feeds, and syndication.</dd>
        <dt><a href="#FAQ_EarnMoney">Earn Money</a></dt>
        <dd>
            This section provides answers to the Ad Revenue sharing system.</dd>
        <dt><a href="#FAQ_Helping">Helping</a></dt>
        <dd>
            This section provides information to how to help the project.</dd>
        <!--    place holders 
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
        You can post the question on the Kick Shoutbox or email your question to <a href="mailto:<%=HostProfile.Email %>">
            <%=HostProfile.Email%>
        </a>.</p>
    <p class="FaqQuestion">
        Who is responsible for the FAQ?</p>
    <p class="FaqAnswer">
        This document is maintained by the
        <%=HostProfile.SiteTitle%>
        development team.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_StoryKicks" class="FaqCategory">
        Story Kicks</h3>
    <p class="FaqQuestion">
        What is a Kick?</p>
    <p class="FaqAnswer">
        Kicks are votes of approval from our members. If a story has 16 kicks, that means
        16 users liked it. The more kicks a story receives, the more likely that it will
        appear on the homepage. If you don't like a story, don’t give it a kick.</p>
    <p class="FaqQuestion">
        How do I Kick a story?</p>
    <p class="FaqAnswer">
        To kick a story, simply click the "Kick It" hyperlink located next to the story
        summary. When you have kicked a story, the hyperlinked text turns from "Kick It"
        to "Kicked."</p>
    <p class="FaqQuestion">
        How do I Unkick a story?</p>
    <p class="FaqAnswer">
        To unkick a story, simply click the "Kicked" hyperlink located next to the story
        summary. When you have unkicked a story, the hyperlinked text turns from "Kicked"
        to "Kick It."</p>
    <p class="FaqQuestion">
        How do I find stories to kick?</p>
    <p class="FaqAnswer">
        To find stories that have not been promoted, click the '<a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.NewStories)%>">Upcoming
            Stories</a>' link in the navigation section. You can also click the 'find' link
        beside each category in the list of categories.</p>
    <p class="FaqQuestion">
        How many Kicks does it take to get to the front page?</p>
    <p class="FaqAnswer">
        The promotion algorithm determines when a story is promoted to the front page.
        <%=HostProfile.SiteTitle%>
        requires a story to have
        <%=HostProfile.Publish_KickScore%>
        kicks and
        <%=HostProfile.Publish_CommentScore%>
        comments to be promoted from the upcoming stories to the front page.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_StorySubmission" class="FaqCategory">
        Story Submission</h3>
    <p class="FaqQuestion">
        How do I submit stories to DotNetKicks?</p>
    <p class="FaqAnswer">
        You simply need to <a href="<%=UrlFactory.CreateUrl(UrlFactory.PageName.Register)%>">
            register for a new account</a>. With an account you can submit stories by clicking
        the 'Submit a story' link on the right menu of the homepage.</p>
    <p class="FaqQuestion">
        How do I add a "Kick It" link and image to my own page?</p>
    <p class="FaqAnswer">
        When you submit a story, you are provided with the HTML needed to add a "Kick It"
        image and link to your web page, that you can customize by choosing the colors you
        prefer. You can use the below HTML code as a template, just remember to replace
        "MyURL" with the exact URL as the submitted story.
    </p>
    <p class="FaqAnswer">
        <%= HttpUtility.HtmlEncode(ControlHelper.RenderControl(new StoryDynamicImage("MyURL", HostProfile))) %>
    </p>
    <p class="FaqQuestion">
        How do I automatically add a "Kick It" link to each of my FeedBurner feed entries?</p>
    <p class="FaqAnswer">
        FeedBurner has a feature called FeedFlare which lets you easily add links to the
        bottom of each entry in your feed. To add a "Kick it" link to each of your feed
        entries you need to configure your feed accordingly following these steps:
    </p>
    <ul>
        <li>Open your feed in FeedBurner and go to the Optimize section. </li>
        <li>On the side menu there's an option called FeedFlare, click on it. </li>
        <li>You will be shown a list of available flares, among which you can find Email, Del.icio.us,
            Digg. </li>
        <li>Scroll down the page, and in the "Personal FeedFlare" input field type the following:
            <a href="http://static.dotnetkicks.com/tools/feedflare/kickitflare.xml">http://static.dotnetkicks.com/tools/feedflare/kickitflare.xml</a> </li>
        <li>Click on the "Add new Flare" button, and enable the new flare by cheking the corresponding
            checkbox. </li>
        <li>Remember to activate this features using the "Activate" button at the bottom of
            the page. </li>
    </ul>
    <p class="FaqQuestion">
        How do I customize the "Kick It" image to match my web site's color scheme?</p>
    <p class="FaqAnswer">
        You can use the following URL parameters to customize the colors of the the "Kick
        It" image. All parameter values must be specified using valid hexidecimal web color
        without the "#" symbol. Remember, do not include the "#" symbol in the hexidecimal
        values. These URL parameters are used in the "img" tag for the KickItImageGenerator
        service.
    </p>
    <dl>
        <dt>border</dt>
        <dd>
            The "border" URL parameter defines the color used for the border of the image.</dd>
        <dt>bgcolor</dt>
        <dd>
            The "bgcolor" URL parameter defines the background color of the "kick it" text area.</dd>
        <dt>fgcolor</dt>
        <dd>
            The "fgcolor" URL parameter defines the foreground/text color of the "kick it" text.</dd>
        <dt>cbgcolor</dt>
        <dd>
            The "cbgcolor" URL parameter defines the background of the kick counter area.</dd>
        <dt>fbgcolor</dt>
        <dd>
            The "fbgcolor" URL parameter defines the foreground/text color of the kick counter
            text.</dd>
    </dl>
    <p class="FaqAnswer">
        An example is provided below.
    </p>
    <p class="FaqAnswer">
        &lt;img src="<%=HostProfile.RootUrl %>/Services/Images/KickItImageGenerator.ashx?url=MyURL
        &amp;border=000033&amp;bgcolor=0099FF &amp;fgcolor=000033 &amp;cbgcolor=FFFFCC&amp;cfgcolor=000033"
        border="0" alt="kick it on
        <%=HostProfile.SiteTitle%>
        " /&gt;
    </p>
    <p class="FaqQuestion">
        Why didn’t you post my story?</p>
    <p class="FaqAnswer">
        A story must recieve a certain number of kicks and/or comments to be promoted to
        the front page.</p>
    <p class="FaqQuestion">
        Why was my story marked as SPAM?</p>
    <p class="FaqAnswer">
        Any story that is not related to the specific topic of this site can be deleted
        by site moderators and administrators. If you believe your story was incorrectly
        marked as SPAM please contact the team at <a href="mailto:<%=HostProfile.Email %>">
            <%=HostProfile.Email%>
        </a>
    </p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_StoryCategories" class="FaqCategory">
        Story Categories</h3>
    <p class="FaqQuestion">
        What is a category for?</p>
    <p class="FaqAnswer">
        A category is a way of grouping your story submission. If your story applies to
        more than one category, then you may add additional categories by "tagging" the
        story.</p>
    <p class="FaqQuestion">
        What if a category that I need doesn’t exist?</p>
    <p class="FaqAnswer">
        Are you sure that the story fits within the rules for story submission? If so, then
        you may choose the closest category and then tag the story with the correct category.
        You may also want to contact the site administration and request the category.</p>
    <p class="FaqQuestion">
        What if my story was placed in the wrong category?</p>
    <p class="FaqAnswer">
        You may tag the story to place it into the correct category. If story has an incorrect
        tag, then you can delete your own tags, but you cannot delete tags placed by others.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_StoryTags" class="FaqCategory">
        Story Tags</h3>
    <p class="FaqQuestion">
        What is a tag for?</p>
    <p class="FaqAnswer">
        A tag is similiar to categories. However, a story may be tagged with multiple tags.
    </p>
    <p class="FaqQuestion">
        How do I add a tag?</p>
    <p class="FaqAnswer">
        You click the "tag it" link located next to the story summary. Then you may enter
        text values to tag the story.</p>
    <p class="FaqQuestion">
        How do I remove a tag?</p>
    <p class="FaqAnswer">
        To remove a tag, click the "tag it" link located next to the story summary. Your
        story tags will then appear and you can click the "X" link to delete the tag.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_UserBanning" class="FaqCategory">
        User Banning</h3>
    <p class="FaqQuestion">
        Why was I banned?</p>
    <p class="FaqAnswer">
        There are several reasons for banning. If you do not understand why you were banned,
        please contact the site administration. Banning my result from submitting SPAM and
        stories that do not fit within the site's rules.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_UserProfile" class="FaqCategory">
        User Profile</h3>
    <p class="FaqQuestion">
        I forgot my password!</p>
    <p class="FaqAnswer">
        Click the link labeled '<a href="<%=HostProfile.RootUrl %>/forgotpassword">Forgot
            your password</a>' to retrieve your password.</p>
    <p class="FaqQuestion">
        I don’t want any cookies!</p>
    <p class="FaqAnswer">
        Cookies are used for site administration and login purposes.</p>
    <p class="FaqQuestion">
        How do I change my password?</p>
    <p class="FaqAnswer">
        ** Currently, you cannot change your password.</p>
    <p class="FaqQuestion">
        How do I change my email address?</p>
    <p class="FaqAnswer">
        ** Currently, you cannot change your email address.</p>
    <p class="FaqQuestion">
        How do I see which stories I have kicked?</p>
    <p class="FaqAnswer">
        To see stories that you have kicked, visit your profile page by clicking on your
        account name hyperlink located in the navigation section of the header. Then you
        can click on "Kicked" profile hyperlink to view stories that you have kicked.
    </p>
    <p class="FaqQuestion">
        How do I see which stories I have submitted?</p>
    <p class="FaqAnswer">
        To see stories that you have submitted, visit your profile page by clicking on your
        account name hyperlink located in the navigation section of the header. Then you
        can click on "Submitted" profile hyperlink to view stories that you have submitted.</p>
    <p class="FaqQuestion">
        How do I see which stories I have commented on?</p>
    <p class="FaqAnswer">
        To see stories that you have commented on, visit your profile page by clicking on
        your account name hyperlink located in the navigation section of the header. Then
        you can click on "Comments" profile hyperlink to view stories that you have commented
        on.</p>
    <p class="FaqQuestion">
        How do I see my friends?</p>
    <p class="FaqAnswer">
        Your list of friends are dislayed on your profile page. To visit your profile page
        click on your account name hyperlink located in the navigation section of the header.
    </p>
    <p class="FaqQuestion">
        How do I add my web site, blog, or blog feed to my profile?</p>
    <p class="FaqAnswer">
        To add your website, blog, or blog feed (RSS), visit your profile page by clicking
        on your account name hyperlink located in the navigation section of the header.
        Then you can click on "Edit Profile" hyperlink to add the values to your profile.
    </p>
    <p class="FaqQuestion">
        How do I set my avatar/image?</p>
    <p class="FaqAnswer">
        To add your avatar, you must have an account with <a href="http://site.gravatar.com/">
            Gravatar</a>. If you have a Gravatar account, then you must enter it into your
        profile. To update your profile click on your account name hyperlink located in
        the navigation section of the header. Then you can click on "Edit Profile" hyperlink
        to add the Gravatar account to your profile.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_UserComments" class="FaqCategory">
        User Comments</h3>
    <p class="FaqQuestion">
        How do I add a comment?</p>
    <p class="FaqAnswer">
        To add a comment, click the "comments" link in the story summary. Once you are viewing
        the individual submitted story summary page, then you can use the form on that page
        to submit your comments.</p>
    <p class="FaqQuestion">
        How do I delete my comment?</p>
    <p class="FaqAnswer">
        Currently, you cannot delete your comments.</p>
    <p class="FaqQuestion">
        Can I edit my comments?</p>
    <p class="FaqAnswer">
        Currently, you cannot edit your comments.</p>
    <p class="FaqQuestion">
        Can I delete someone’s comment about my story?</p>
    <p class="FaqAnswer">
        You cannot delete someone else's comment about your story. If a comment is inappropriate
        please contact the site staff.</p>
    <p class="FaqQuestion">
        Why was my comment deleted?</p>
    <p class="FaqAnswer">
        Only the site staff can delete comments. If you feel that your comment was incorrectly
        delete, please contact the site staff.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <!--
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
    -->
    <h3 id="FAQ_UserFriends" class="FaqCategory">
        User Friends</h3>
    <p class="FaqQuestion">
        What is a friend?</p>
    <p class="FaqAnswer">
        A friend is someone that you are acquainted with.</p>
    <p class="FaqQuestion">
        How do I add a friend?</p>
    <p class="FaqAnswer">
        To add a friend, click the person's name to view their profile. On their profile,
        click "Add Friend" hyperlink.</p>
    <p class="FaqQuestion">
        How do I remove a friend?</p>
    <p class="FaqAnswer">
        To remove a friend, click the person's name to view their profile. On their profile,
        click "Remove As Friend" hyperlink.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_SiteWebFeeds" class="FaqCategory">
        Web Feeds</h3>
    <p class="FaqQuestion">
        What is a Web Feed?</p>
    <p class="FaqAnswer">
        A Web Feed (or RSS) is an XML document that contains specific data elements.</p>
    <p class="FaqQuestion">
        What is RSS?</p>
    <p class="FaqAnswer">
        RSS is Really Simple Syndication. RSS is the same as Web Feed.</p>
    <p class="FaqQuestion">
        How do I subscribe to a DotNetKicks Web Feed?</p>
    <p class="FaqAnswer">
        Most
        <%=HostProfile.SiteTitle%>
        pages contain a RSS icon that looks like:
        <img src="<%= StaticIconRootUrl %>/rss.jpg" />. To subscribe to the web feed,
        just click this image and your default Web Feed/RSS Reader will activate.
    </p>
    <p class="FaqQuestion">
        How do I subscribe to a DotNetKicks category only Web Feed?</p>
    <p class="FaqAnswer">
        Most
        <%=HostProfile.SiteTitle%>
        pages contain a RSS icon that looks like:
        <img src="<%= StaticIconRootUrl %>/rss.jpg" />. To subscribe to the web feed,
        just click this image and your default Web Feed/RSS Reader will activate.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_EarnMoney" class="FaqCategory">
        Earn Money</h3>
    <p class="FaqQuestion">
        How can I earn money?</p>
    <p class="FaqAnswer">
        <%=HostProfile.SiteTitle%>
        uses a revenue sharing system. You will receive 50% of the advertisement revenue
        on this site for all stories that you submit. How it works is simple. Your AdSense
        account ID is used 50% of the time for all views of your submitted stories. As people
        click on your ads, your Google AdSense account will be credited. That’s it. Google
        will send you the check.
    </p>
    <p class="FaqQuestion">
        How do I get a Google AdSense id?</p>
    <p class="FaqAnswer">
        To get a Google AdSense id, visit '<a href="">Google AdSense</a>' to sign up.</p>
    <!-- put site specific URL here to get income from referral -->
    <p class="FaqQuestion">
        How do I enter my Google AdSense id?</p>
    <p class="FaqAnswer">
        First, you must have a valid account. Second, visit the <a href="<%=HostProfile.RootUrl %>/docs/earnmoney">
            Earn Money</a> page to enter your Google AdSense id.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
    <hr />
    <h3 id="FAQ_Helping" class="FaqCategory">
        Helping DotNetKicks</h3>
    <p class="FaqQuestion">
        How can I help DotNetKicks?</p>
    <p class="FaqAnswer">
        Tell your friends - The most immediate and effective way that you can help us is
        to tell your friends about us. If you have a blog, please write a short post with
        a link to DotNetKicks.com. The more users we have, the more useful the content becomes
        for everyone.</p>
    <p class="FaqAnswer">
        Kick some stories - As the site has no editors in the traditional sense, we rely
        on our users to kick the good content onto our homepage. Recently submitted stories
        that have not yet received enough kicks to make the homepage are awaiting your kicks
        right now.</p>
    <p class="FaqAnswer">
        Add a story - Without our users submitting stories, we would have no content. If
        you find any interesting stories relevant to DotNetKicks.com, please submit them
        so that we can all know about them.</p>
    <p class="FaqAnswer">
        Add our headlines to your website - We provide various feeds that you can add to
        your website. These are updated in real time and you can add them to your site very
        simply.</p>
    <p class="FaqAnswer">
        Let us know your comments and suggestions - It is early days for DotNetKicks.com
        and we have many improvements and new features coming soon. Please let us know what
        you think of the site and how we may improve it to better serve you.</p>
    </p>
    <p class="FaqQuestion">
        How do I submit a bug?</p>
    <p class="FaqAnswer">
        You can submit a bug at <a href="http://code.google.com/p/dotnetkicks/issues/list">Add
            a Issue</a>.</p>
    <p class="FaqQuestion">
        How do I submit comments?</p>
    <p class="FaqAnswer">
        We would be delighted to hear your suggestions or comments, we can be reached at
        <a href="mailto:<%=HostProfile.Email %>">
            <%=HostProfile.Email%>
        </a>.</p>
    <a href="#FAQ_Top">Return to Topic List</a>
</asp:Content>
