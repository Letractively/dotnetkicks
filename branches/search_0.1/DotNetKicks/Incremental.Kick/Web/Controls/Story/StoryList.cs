using System;
using System.Web.UI;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class StoryList : KickWebControl {
        
		#region [rgn] Fields (3)

		//default caption
        private string _caption = string.Format(
            @"There are currently no stories here.<br/><br/>Would you like to be the first to <a href=""{0}"">submit a story</a>?", 
            UrlFactory.CreateUrl(UrlFactory.PageName.SubmitStory));
		private StoryCollection _stories;
		private string _title = "";
        private bool _showFullSummary = true;

		#endregion [rgn]

		#region [rgn] Properties (2)

		/// <summary>
        /// Gets or sets the no stories caption.
        /// </summary>
        /// <value>The no stories caption.</value>
        public string NoStoriesCaption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }
		
		/// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title {
            get { return this._title; }
            set { this._title = value; }
        }
		
		#endregion [rgn]

		#region [rgn] Methods (2)

		// [rgn] Public Methods (1)


        /// <summary>
        /// Binds the data
        /// </summary>
        /// <param name="stories">The stories.</param>
        public void DataBind(StoryCollection stories) {
            this._stories = stories;
        }

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
      

		// [rgn] Protected Methods (1)

        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"></see> object that receives the control content.</param>
		protected override void Render(HtmlTextWriter writer) {

            if (!String.IsNullOrEmpty(this.Title)) {
                writer.WriteLine(@"<div class=""PageSmallCaption"">{0}</div>", this.Title);
            }
            
            if (_stories == null)
                return;

            bool isOddRow = true;
            foreach (Story storyRow in this._stories) {
                StorySummary story = new StorySummary();
                this.Controls.Add(story);
                story.DataBind(storyRow, isOddRow);
                story.ShowFullSummary = _showFullSummary;
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
		
		#endregion [rgn]

    }
}
