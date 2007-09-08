using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;
using Incremental.Kick.Helpers;
using Incremental.Kick.Dal.Entities;
using System.Web;

namespace Incremental.Kick.Web.Controls {

    public class StorySummary : KickWebControl {
        private Story _story;
        private bool _isOddRow;

        private bool _showMoreLink = true;
        public bool ShowMoreLink {
            get { return this._showMoreLink; }
            set { this._showMoreLink = value; }
        }

        public void DataBind(Story story) {
            this.DataBind(story, true);
        }

        public void DataBind(Story story, bool isOddRow) {
            this._story = story;
            this._isOddRow = isOddRow;
        }

        protected override void Render(HtmlTextWriter writer) {
            Category category = CategoryCache.GetCategory(this._story.CategoryID, this.KickPage.HostProfile.HostID);
            string categoryIdentifier = category.CategoryIdentifier;
            string categoryName = category.Name;
            string kickStoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, this._story.StoryIdentifier, categoryIdentifier);
            string userUrl = UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this._story.Username);
                        
            string categoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, categoryIdentifier);
            string kickCountClass = this.GetKickCountClass(this._story.KickCount);

            bool isKicked = UserCache.HasUserKickedStory(this._story.StoryID, this.KickPage.KickUserProfile.UserID);

            string kickItCssClass = "visible";
            string kickedCssClass = "hidden";
            if (isKicked) {
                kickItCssClass = "hidden";
                kickedCssClass = "isible";
            }

            string adminHtml = "";
            
            string tableClass = "storySummaryTable storySummaryTable";
            if (this._isOddRow)
                tableClass += "Odd";
            else
                tableClass += "Even";

            writer.WriteLine(@"
                <table class=""" + tableClass + @"""><tr>
                    <td class=""storySummaryKickTD"">
                        <div class=""storyKickCount {2}""><a href=""{0}""><span id=""{3}_KickCount"">{1}</span></a><br /><span class=""smallText"">kicks</span></div>
                        <div class=""storyKickIt {4}"" id=""{3}_KickIt""><a href=""javascript:KickIt({3}, {6});"">
                            kick it</a></div>
                        <div class=""storyKicked {5}"" id=""{3}_UnKickIt""><a href=""javascript:UnKickIt({3});"">kicked</a></div>
                    {8}</td>
            ", kickStoryUrl, this._story.KickCount, kickCountClass, this._story.StoryID, kickItCssClass, kickedCssClass,
             this.KickPage.User.Identity.IsAuthenticated.ToString().ToLower(), this.KickPage.StaticIconRootUrl, adminHtml);


            string publishedHtml = "";
            if (this._story.IsPublishedToHomepage) {
                publishedHtml = "published " + DateHelper.ConverDateToTimeAgo(this._story.PublishedOn) + ", ";
            }
            //TODO: remove inline style from table
            writer.WriteLine(@"
                    <td class=""storySummaryMainTD""><table width=""100%"" class=""WideTable"" cellpadding=""0"" cellspacing=""0""><tr><td valign=""top"">
                        <div class=""storyTitle""><a href=""{0}"">{1}</a> <a href=""{0}""><img src=""{3}/external.png"" width=""10"" height=""10"" border=""0""/></a></div>
                        <div class=""storySubmitted"">{2} submitted by 
            ", this._story.Url, this._story.Title, publishedHtml, this.KickPage.StaticIconRootUrl);

            UserLink userLink = new UserLink();
            userLink.DataBind(UserCache.GetUserByUsername(this._story.Username));
            userLink.RenderControl(writer);

            string moreLink = "";
            if (this.ShowMoreLink)
                moreLink = String.Format(@" <a href=""{0}"">read more...</a>", kickStoryUrl);

            writer.WriteLine(@"
                {0}</div>
        
                        <p>{1}</p>

                        <div class=""storyActions"">
                            <a href=""{2}"" class=""commentsLink"">
            ", DateHelper.ConverDateToTimeAgo(this._story.CreatedOn), this._story.Description + moreLink, kickStoryUrl);

            writer.WriteLine(@"<img src=""{0}/comment.png"" alt=""Add a comment"" width=""16"" height=""16"" border=""0"" /> ", this.KickPage.StaticIconRootUrl);

            if (this._story.CommentCount == 0) {
                writer.WriteLine(@"<a href=""{0}"">add a comment</a>", kickStoryUrl);
            } else {
                if (this._story.CommentCount == 1)
                    writer.WriteLine(@"<a href=""{0}"">1 comment</a>", kickStoryUrl);
                else
                    writer.WriteLine(@"<a href=""{0}"">{1} comments</a>", kickStoryUrl, this._story.CommentCount);
            }


            writer.WriteLine(@" | 
                            category: <a href=""{0}""><img src=""{3}/{4}"" width=""16"" height=""16"" border=""0"" /></a>
                            <a href=""{0}"" rel=""tag"">{2}</a>
            ", categoryUrl, categoryIdentifier, categoryName, this.KickPage.StaticIconRootUrl, CategoryCache.GetCategory(this._story.CategoryID, this._story.HostID).IconName);

            writer.WriteLine(@" |
                            <span class=""ReportAsSpamLink""><a href=""javascript:ReportAsSpam({0});"">report as spam</a></span>
            ", this._story.StoryID);

            if (this.KickPage.IsHostModerator) {
                string deleteText = "delete";
                if (this._story.SpamCount > 0)
                    deleteText += " (spam count is " + this._story.SpamCount.ToString() + ")";

                writer.WriteLine(@" |
                    <span class=""ModeratorLink""><a href=""javascript:Delete({0});"">{1}</a></span>
                    ", this._story.StoryID, deleteText);          
            }

            //writer.WriteLine(@"</td><td width=""94""><a href=""http://{0}""><img src=""http://thumboo.com/?size=t&url={0}"" width=""92"" height=""70"" class=""Thumbnail"" /></a></td></tr></table>", this._storyRow.Url.Replace("http://", ""));
            // writer.WriteLine(@"</td><td width=""94""><a href=""{0}""><img src=""http://images.websnapr.com/?size=t&url={0}"" width=""92"" height=""70"" class=""Thumbnail"" /></a></td></tr></table>", this._story.Url);
            writer.WriteLine(@"</td><td width=""94""><a href=""{0}""><img src=""http://dotnetkicks.kwiboo.com/getimage.aspx?size=thumb&url={1}"" width=""92"" height=""70"" class=""Thumbnail"" /></a>", this._story.Url, HttpUtility.UrlEncode(this._story.Url));
            writer.WriteLine(@"</td></tr></table>", this._story.Url);
            
            writer.WriteLine(@"<span class=""TagListSummary"">");
            WeightedTagList tags = TagCache.GetStoryTags(this._story.StoryID);

            tags.Sort(new WeightedTagList.UsageCountComparer());
            TagCommaList tagCommaList = new TagCommaList();
            this.Controls.Add(tagCommaList);
            tagCommaList.DataBind(tags.GetTopTags(5), this._story.StoryID);
            tagCommaList.RenderControl(writer);
            writer.WriteLine(@"</span>");
            
           

            writer.WriteLine("</div><br /><br />");

            tags.Sort(new WeightedTagList.AlphabeticalComparer());
            StoryTagList storyTagList = new StoryTagList();
            this.Controls.Add(storyTagList);
            storyTagList.DataBind(tags, this._story.StoryID);
            storyTagList.RenderControl(writer);

            

            writer.WriteLine("</td></tr></table>");
        }


        private string GetKickCountClass(int kickCount) {
            string cssClass = "storyKickCount1";
            if (this._story.KickCount > 9)
                cssClass += "0";

            if (this._story.KickCount > 99)
                cssClass += "0";

            if (this._story.KickCount > 999)
                cssClass += "0";

            return cssClass;
        }
    }
}

