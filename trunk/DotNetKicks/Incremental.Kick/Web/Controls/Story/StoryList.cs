using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class StoryList : KickWebControl {
        private StoryCollection _stories;

        private string _title = "";
        public string Title {
            get { return this._title; }
            set { this._title = value; }
        }

        //default caption
        private string _caption = string.Format(
            @"There are currently no stories here.<br/><br/>Would you like to be the first to <a href=""{0}"">submit a story</a>?", 
            UrlFactory.CreateUrl(UrlFactory.PageName.SubmitStory));

        public string NoStoriesCaption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
        //private StoryListHeader _header = new StoryListHeader();
        //public StoryListHeader Header {
        //    get { return this._header; }
        //}

        public void DataBind(StoryCollection stories) {
            this._stories = stories;
        }

        protected override void Render(HtmlTextWriter writer) {

            if (!String.IsNullOrEmpty(this.Title)) {
                writer.WriteLine(@"<div class=""PageSmallCaption"">{0}</div>", this.Title);
            }

            bool isOddRow = true;
            foreach (Story storyRow in this._stories) {
                StorySummary story = new StorySummary();
                this.Controls.Add(story);
                story.DataBind(storyRow, isOddRow);
                story.RenderControl(writer);
                isOddRow = !isOddRow;
            }

            if (this._stories.Count == 0) {
                writer.WriteLine(@"
                    <div class=""HelpDiv"">
                        <img src=""{0}/information.png"" /> 
                        {1}
                    </div>
                ", this.KickPage.StaticIconRootUrl, _caption);
            }
        }

        
    }
}
