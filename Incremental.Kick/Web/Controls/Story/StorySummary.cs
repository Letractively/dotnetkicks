using System;
using System.Web;
using System.Web.UI;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Web.Helpers;
using SubSonic.Sugar;

namespace Incremental.Kick.Web.Controls
{
    public class StorySummary : KickWebControl
    {
        private bool _isOddRow;
        private bool _showFullSummary = true;
        private bool _showMoreLink = true;
        private bool _showGetKickImageCodeLink = false;
        private Story _story;

        /// <summary>
        /// Gets or sets a value indicating whether [show full summary].
        /// </summary>
        /// <value><c>true</c> if [show full summary]; otherwise, <c>false</c>.</value>
        /// <remarks>
        /// If <c>true</c> then displays the full story summary as shown in upcoming & published story lists.
        /// If <c>false</c> then displays a shorter story summary as shown in Zeitgeist.
        /// Default is <c>true</c>.
        /// </remarks>
        public bool ShowFullSummary
        {
            get { return _showFullSummary; }
            set { _showFullSummary = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display the [show more link].
        /// </summary>
        /// <value><c>true</c> if [show more link]; otherwise, <c>false</c>.</value>
        public bool ShowMoreLink
        {
            get { return _showMoreLink; }
            set { _showMoreLink = value; }
        }

        public bool ShowGetKickImageCodeLink
        {
            get { return _showGetKickImageCodeLink; }
            set { _showGetKickImageCodeLink = value; }
        }

        // [rgn] Public Methods (2)

        /// <summary>
        /// binds the datas
        /// </summary>
        /// <param name="story">The story.</param>
        public void DataBind(Story story)
        {
            DataBind(story, true);
        }

        /// <summary>
        /// binds the datas
        /// </summary>
        /// <param name="story">The story.</param>
        /// <param name="isOddRow">if set to <c>true</c> [is odd row].</param>
        public void DataBind(Story story, bool isOddRow)
        {
            _story = story;
            _isOddRow = isOddRow;
        }

        // [rgn] Protected Methods (3)

        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"></see> object that receives the control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if(_showFullSummary)
                RenderFullSummary(writer);
            else
                RenderShortSummary(writer);
        }

        /// <summary>
        /// Renders the full story summary.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected void RenderFullSummary(HtmlTextWriter writer)
        {
            Category category = CategoryCache.GetCategory(_story.CategoryID, KickPage.HostProfile.HostID);
            string kickStoryUrl =
                UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, _story.StoryIdentifier, category.CategoryIdentifier);

            string categoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, category.CategoryIdentifier);
            string kickCountClass = GetKickCountClass();

            bool isKicked = UserCache.HasUserKickedStory(_story.StoryID, KickPage.KickUserProfile.UserID);

            string kickItCssClass = "visible";
            string kickedCssClass = "hidden";
            if(isKicked)
            {
                kickItCssClass = "hidden";
                kickedCssClass = "visible";
            }

            string adminHtml = "";

            string tableClass = "storySummaryTable storySummaryTable";
            if(_isOddRow)
                tableClass += "Odd";
            else
                tableClass += "Even";

            //TODO: remove inline style from table
            // Render kick it side image
            writer.WriteLine(
                @"<div id =""m_{3}"">
                <table class=""" + tableClass +
                @"""><tr>
                    <td class=""storySummaryKickTD"">
                        <div class=""storyKickCount {2}""><a href=""{0}""><span id=""{3}_KickCount"">{1}</span></a><br /><span class=""smallText"">kicks</span></div>
                        <div class=""storyKickIt {4}"" id=""{3}_KickIt""><a href=""javascript:KickIt({3}, {6});"">
                            kick it</a></div>
                        <div class=""storyKicked {5}"" id=""{3}_UnKickIt""><a href=""javascript:UnKickIt({3});"">kicked</a></div>
                    {8}</td>
            ",
                kickStoryUrl, _story.KickCount, kickCountClass, _story.StoryID, kickItCssClass, kickedCssClass,
                KickPage.User.Identity.IsAuthenticated.ToString().ToLower(), KickPage.StaticIconRootUrl, adminHtml);

            string publishedHtml = "";
            string linkAttributes = "";

            // Create published date string
            if(_story.IsPublishedToHomepage)
                publishedHtml = "published " + Dates.ReadableDiff(_story.PublishedOn, DateTime.Now) + ", ";
            else
                linkAttributes = "rel=\"nofollow\"";

            //TODO: remove inline style from table
            // Render submitted by link
			writer.WriteLine(
                @"
                    <td class=""storySummaryMainTD""><table width=""100%"" class=""WideTable"" cellpadding=""0"" cellspacing=""0""><tr><td valign=""top"">
                        <div class=""storyTitle""><a onclick=""plusViewCount({5});"" href=""{0}"" {4}>{1}</a> <a href=""{0}""><img onclick=""plusViewCount({5});"" src=""{3}/external.png"" width=""10"" height=""10"" border=""0""/></a></div>
                        <div class=""storySubmitted"">{2} submitted by ",
				_story.Url, _story.Title, publishedHtml, KickPage.StaticIconRootUrl, linkAttributes, _story.StoryID);

            // Render user link
            UserLink userLink = new UserLink();
            userLink.DataBind(UserCache.GetUser(_story.UserID));
            userLink.RenderControl(writer);
            string hostname = GetHostName(_story.Url);
            // Render read more link
            string moreLink = "";
            if (ShowMoreLink)
                moreLink = String.Format(@" <a href=""{0}"" onclick=""javascript:plusViewCount({1});"">read more...</a>", kickStoryUrl, _story.StoryID);
            // Rended add comment/number of comments link
            writer.WriteLine(
                @"
                {0}</div>
        
                        <p>{1}</p>

                        <div class=""storyActions"">
                            <a href=""{2}"" class=""commentsLink"">
            ",
                Dates.ReadableDiff(_story.CreatedOn, DateTime.Now), hostname + _story.Description + moreLink, kickStoryUrl);

            writer.WriteLine(@"<img src=""{0}/comment.png"" alt=""Add a comment"" width=""16"" height=""16"" border=""0"" /> ",
                             KickPage.StaticIconRootUrl);

            if(_story.CommentCount == 0)
                writer.WriteLine(@"<a href=""{0}#comments"">add a comment</a>", kickStoryUrl);
            else if(_story.CommentCount == 1)
                writer.WriteLine(@"<a href=""{0}#comments"">1 comment</a>", kickStoryUrl);
            else
                writer.WriteLine(@"<a href=""{0}#comments"">{1} comments</a>", kickStoryUrl, _story.CommentCount);

            // Render category html
            string categoryIcon = "";
            if(category.IconNameSpecified)
                categoryIcon =
                    String.Format(@"<a href=""{0}""><img src=""{1}/{2}"" width=""16"" height=""16"" border=""0"" /></a>",
                                  categoryUrl, KickPage.StaticIconRootUrl, category.IconName);
			writer.WriteLine(@" | 
                category: {0} <a href=""{1}"" rel=""tag"">{2}</a> | Views: {3}", categoryIcon, categoryUrl,
							 category.Name, _story.ViewCount);

            // Render Get Kick Image html
            if(_showGetKickImageCodeLink)
                writer.WriteLine(@" | <a href=""javascript:;"" onclick=""$('#kickImagePersonalization').toggle();"">Get KickIt image code</a>");

            // Render report as spam link
            if(KickPage.IsAuthenticated)
                writer.WriteLine(
                    @" | <span class=""ReportAsSpamLink""><a href=""javascript:ReportAsSpam({0});"">report as spam</a></span>",
                    _story.StoryID);


            // Render delete story link
            if (KickPage.IsHostModerator)
            {
                string deleteText = "delete";
                if (_story.SpamCount > 0)
                    deleteText += " (spam count is " + _story.SpamCount + ")";
                if (_story.IsSpam)
                {
                    writer.WriteLine(
                        @" |
                    <span class=""ModeratorLink""><a href=""javascript:UnDelete({0});"">{1}</a></span>
                    ",
                        _story.StoryID, "un" + deleteText);
                }
                else
                {
                    writer.WriteLine(
                     @" |
                    <span class=""ModeratorLink""><a href=""javascript:Delete({0});"">{1}</a></span>
                    ",
                     _story.StoryID, deleteText);
                }
            }


            // Render story thumbnail
            //writer.WriteLine(@"</td><td width=""94""><a href=""http://{0}""><img src=""http://thumboo.com/?size=t&url={0}"" width=""92"" height=""70"" class=""Thumbnail"" /></a></td></tr></table>", this._storyRow.Url.Replace("http://", ""));
            // writer.WriteLine(@"</td><td width=""94""><a href=""{0}""><img src=""http://images.websnapr.com/?size=t&url={0}"" width=""92"" height=""70"" class=""Thumbnail"" /></a></td></tr></table>", this._story.Url);
            if(!KickPage.IsAuthenticated || KickPage.KickUserProfile.ShowStoryThumbnail)
            writer.WriteLine(
                @"</td><td width=""94""><a onclick=""javascript:plusViewCount({2});"" href=""{0}""><img src=""http://dotnetkicks.kwiboo.com/getimage.aspx?size=thumb&url={1}"" width=""92"" height=""70"" class=""Thumbnail"" /></a>",
                _story.Url, HttpUtility.UrlEncode(_story.Url), _story.StoryID);

            writer.WriteLine(@"</td></tr></table>", _story.Url);

            // Render tag list html
            writer.WriteLine(@"<span class=""TagListSummary"">");
            WeightedTagList tags = TagCache.GetStoryTags(_story.StoryID);

            tags.Sort(new WeightedTagList.UsageCountComparer());
            TagCommaList tagCommaList = new TagCommaList();
            Controls.Add(tagCommaList);
            tagCommaList.DataBind(tags.GetTopTags(5), _story.StoryID);
            tagCommaList.RenderControl(writer);
            writer.WriteLine(@"</span>");

            writer.WriteLine("</div><br /><br />");

            tags.Sort(new WeightedTagList.AlphabeticalComparer());
            StoryTagList storyTagList = new StoryTagList();
            Controls.Add(storyTagList);
            storyTagList.DataBind(tags, _story.StoryID);
            storyTagList.RenderControl(writer);

            writer.WriteLine("</td></tr></table></div>");
        }

        public string GetHostName(string url)
        {
            string hostname = url;
            // strip the http:// or https://
            hostname = hostname.ToLower().Replace("http://", "");
            hostname = hostname.ToLower().Replace("https://", "");
            hostname = hostname.ToLower().Replace("www.", "");
            // find the first indexof /
            int hn = hostname.IndexOf("/");
            if (hn > 0) hostname = hostname.Substring(0, hn);
            // <font class="source">ripten.com &#8212;</font>
            hostname = "<font class=\"source\">" + hostname + " &#8212</font> ";
            return hostname;
        }

        /// <summary>
        /// Renders the short story summary.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected void RenderShortSummary(HtmlTextWriter writer)
        {
            string kickStoryUrl =
                UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, _story.StoryIdentifier, _story.Category.CategoryIdentifier);
            string kickCountClass = GetKickCountClass();
            //

            //TODO: make this CSS
            writer.WriteLine(
                @"
                <div style=""padding-bottom:5px;margin-bottom:10px;border-bottom: solid 1px silver;display:block"" class=""smallText"">
                    <div style=""float:left;padding-right:15px;margin:0;width:60px;overflow:hidden;"">
                        <div class=""storyKickCount {2}""><a href=""{0}""><span id=""{3}_KickCount"">{1}</span></a><br/><span class=""smallText"">kicks</span></div>                       
                    </div>
            ",
                kickStoryUrl, _story.KickCount, kickCountClass, _story.StoryID);

            string publishedHtml = "";
            if(_story.IsPublishedToHomepage)
                publishedHtml = "published " + Dates.ReadableDiff(_story.PublishedOn, DateTime.Now) + ", ";

            //TODO: remove inline style from table
            writer.WriteLine(
                @"<div class=""storySummaryMainTD"">
                        <div class=""storyTitle""><a href=""{0}"">{1}</a> <a href=""{0}""></a></div>
                        <div class=""storySubmitted"">{2} submitted by 
            ",
                _story.Url, _story.Title, publishedHtml);

            UserLink userLink = new UserLink();
            userLink.DataBind(UserCache.GetUser(_story.UserID));
            userLink.RenderControl(writer);

            writer.WriteLine(@" {0}</div><div class=""storyActions"">", Dates.ReadableDiff(_story.CreatedOn, DateTime.Now));

            if(_story.CommentCount == 0)
                writer.WriteLine("0 comments");
            else if(_story.CommentCount == 1)
                writer.WriteLine(@"1 comment");
            else
                writer.WriteLine(@"{0} comments", _story.CommentCount);

            writer.WriteLine("</div></div>");
        }

        // [rgn] Private Methods (1)

        /// <summary>
        /// Gets the kick count class.
        /// </summary>
        /// <returns></returns>
        private string GetKickCountClass()
        {
            string cssClass = "storyKickCount1";
            if(_story.KickCount > 9)
                cssClass += "0";

            if(_story.KickCount > 99)
                cssClass += "0";

            if(_story.KickCount > 999)
                cssClass += "0";

            return cssClass;
        }
    }
}