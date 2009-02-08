using System;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls
{

    /// <summary>
    /// Displays a list of related stories
    /// </summary>
    public class RelatedStories: KickWebControl
    {
        string title;
        StoryCollection relatedStory;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        public StoryCollection RelatedStory
        {
            get { return relatedStory; }
            set { relatedStory = value; }
        }

        public void DataBind(StoryCollection stories)
        {
            this.relatedStory = stories;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (relatedStory == null)
                return;

            if (!String.IsNullOrEmpty(this.Title))
            {
                writer.WriteLine(@"<div class=""PageSmallCaption"">{0}</div>", this.Title);
            }

            writer.WriteLine("<ul id=\"relatedStoriesList\">");

            foreach (Story s in relatedStory)
            {
                Category category = CategoryCache.GetCategory(s.CategoryID, KickPage.HostProfile.HostID);
                string kickStoryUrl =
                    UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, s.StoryIdentifier, category.CategoryIdentifier);

                writer.WriteLine("<li><a href=\"{0}\">{1}</a></li>", kickStoryUrl, s.Title);
            }

            writer.WriteLine("</ul>");
        }
    }
}
