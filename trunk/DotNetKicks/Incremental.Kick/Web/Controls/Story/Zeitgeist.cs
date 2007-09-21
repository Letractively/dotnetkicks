using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;
using SubSonic;

namespace Incremental.Kick.Web.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Zeitgeist runat=server></{0}:Zeitgeist>")]
    public class Zeitgeist : KickWebControl
    {

        #region [rgn] Fields (9)

        //default caption
        private string _caption = "There are no data available for this time period.";
        private int? _day;
        private DateTime _minDate = new DateTime(2006, 1, 1);
        private int? _month = System.DateTime.Now.Month;
        private StoryCollection _mostCommentedOnStories;
        private StoryCollection _mostKickedStories;
        private int _storiesSubmittedCount;
        private int _storiesPublishedCount;
        private string _title = "";
        private int? _year;
        private int numberOfItems = 10;

        #endregion [rgn]

        #region [rgn] Properties (7)

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public int? Day
        {
            get { return _day; }
            set { _day = value; }
        }

        /// <summary>
        /// Gets or sets the minimum date.
        /// </summary>
        /// <value>The minimum date.</value>
        public DateTime MinimumDate
        {
            get { return _minDate; }
            set { _minDate = value; }
        }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The month.</value>
        private int? Month
        {
            get { return _month; }
            set
            {
                value = value > 12 ? 12 : value;
                value = value < 1 ? 1 : value;
                _month = value;
            }
        }

        /// <summary>
        /// Gets or sets the no data caption.
        /// </summary>
        /// <value>The no data caption.</value>
        public string NoDataCaption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }

        /// <summary>
        /// Gets or sets the number of items to show per category.
        /// </summary>
        /// <value>The number of items.</value>
        public int NumberOfItems
        {
            get { return numberOfItems; }
            set
            {
                if (value <= 0)
                    value = 1;
                numberOfItems = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        private int? Year
        {
            get { return _year; }
            set
            {
                value = value > DateTime.Now.Year ? DateTime.Now.Year : value;
                value = value < _minDate.Year ? _minDate.Year : value;
                _year = value;
            }
        }

        #endregion [rgn]

        #region [rgn] Methods (6)

        // [rgn] Public Methods (1)

        /// <summary>
        /// Binds the data.
        /// </summary>
        /// <param name="hostId">The host id.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        public void DataBind(int hostId, int? year, int? month, int? day)
        {
            //don't do data bind if year is null
            //just show listing
            if (year == null)
                return;

            this.Month = month;
            this.Year = year;
            this.Day = day;

            _mostKickedStories = ZeitgeistCache.GetMostKickedStories(hostId, this.NumberOfItems, this.Year.Value, this.Month, this.Day);
            _mostCommentedOnStories = ZeitgeistCache.GetMostCommentedOnStories(hostId, this.NumberOfItems, this.Year.Value, this.Month, this.Day);

            _storiesSubmittedCount = ZeitgeistCache.GetNumberOfStoriesSubmitted(hostId, this.Year.Value, this.Month, this.Day);
            _storiesPublishedCount = ZeitgeistCache.GetNumberOfStoriesPublished(hostId, this.Year.Value, this.Month, this.Day);

        }

        // [rgn] Protected Methods (1)

        /// <summary>
        /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"></see> that represents the output stream to render HTML content on the client.</param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (!String.IsNullOrEmpty(this.Title))
            {
                writer.WriteLine(@"<div class=""PageSmallCaption"">{0}</div>", this.Title);
            }

            if (this.Year == null)
            {
                RenderIndexPage(writer);
            }
            else
            {
                //navigation system
                RenderNavigation(writer);
                //
                RenderDateStatistics(writer);
                //render top 10/X lists
                RenderStoryLists(writer);
            }

        }

        /// <summary>
        /// Renders the date statistics.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void RenderDateStatistics(HtmlTextWriter writer)
        {
            //render single stats, like counters
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "ZeitgeistStatistics");
            writer.Write(HtmlTextWriter.TagRightChar);

            writer.RenderBeginTag(HtmlTextWriterTag.P);
            writer.Write("Number of Stories Submitted: ");
            writer.Write(_storiesSubmittedCount);
            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.Write("Number of Stories Published: ");
            writer.Write(_storiesPublishedCount);
            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.Write("Submit to Publish Percentage: ");
            if (_storiesPublishedCount > 0 && _storiesPublishedCount <= _storiesSubmittedCount)
                writer.Write(Math.Round((double)_storiesPublishedCount / _storiesSubmittedCount, 4).ToString("P"));
            else
                writer.Write("0 %");
            writer.RenderBeginTag(HtmlTextWriterTag.Br);

            writer.RenderEndTag();    //p

            writer.WriteEndTag("div");

            //writer.RenderBeginTag(HtmlTextWriterTag.Br);//msie hack
        }

      

        // [rgn] Private Methods (4)

        /// <summary>
        /// Renders the index page.
        /// This page is the default page when no dates are specified
        /// It displays a listing of year/month hyperlinks to pick from
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void RenderIndexPage(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("Browse By Year or Month");

            //start at min year
            //go to now
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            for (int y = MinimumDate.Year; y <= DateTime.Now.Year; y++)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                string yearUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist, y.ToString());
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", yearUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write("Year ");
                writer.Write(y);
                writer.WriteEndTag("a");

                RenderListOfMonths(writer, y);

                writer.RenderEndTag();//li year
            }
            writer.RenderEndTag();//ul year
        }

        /// <summary>
        /// Renders the list of years.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void RenderListOfYears(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            //each month of that year
            for (int y = this.MinimumDate.Year; y <= DateTime.Now.Year; y++)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                string yearUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist, y.ToString());
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", yearUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(y);
                writer.WriteEndTag("a");
                writer.RenderEndTag();//li year
            }
            writer.RenderEndTag();//ul year
        }
        /// <summary>
        /// Renders a list of hyperlinked months for the specified year.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="year">The year.</param>
        private void RenderListOfMonths(HtmlTextWriter writer, int year)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            //each month of that year
            for (int m = 1; m <= 12; m++)
            {
                if (year == DateTime.Now.Year && m > DateTime.Now.Month)
                    continue;

                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                string monthUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist, year.ToString(), m.ToString());
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", monthUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(new DateTime(year, m, 1).ToString("MMMM"));    //TODO find a better way to convert int to string
                writer.WriteEndTag("a");
                writer.RenderEndTag();//li month
            }
            writer.RenderEndTag();//ul month
        }
        /// <summary>
        /// Renders the list of days.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        private void RenderListOfDays(HtmlTextWriter writer, int year, int month)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            //each day of month of that year
            for (int d = 1; d <= DateTime.DaysInMonth(year, month); d++)
            {
                if (year == DateTime.Now.Year && month == DateTime.Now.Month && d >= DateTime.Now.Day)
                    continue;

                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                string dayUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist, year.ToString(), month.ToString(), d.ToString());
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", dayUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(d.ToString());
                writer.WriteEndTag("a");
                writer.RenderEndTag();//li day
            }
            writer.RenderEndTag();//ul day
        }

        /// <summary>
        /// Renders the story list items.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="title">The title.</param>
        /// <param name="reader">The reader.</param>
        private void RenderStoryListItems(HtmlTextWriter writer, StoryCollection stories, string title, string itemType)
        {
            //render top 10 lists
            writer.RenderBeginTag(HtmlTextWriterTag.H3);
            writer.Write(title);
            writer.Write(" for ");

            if (Month == null)
                writer.Write(Year);
            else if (Day == null)
                writer.Write(new DateTime(Year.Value, Month.Value, 1).ToString("MMMM yyyy"));
            else
                writer.Write(new DateTime(Year.Value, Month.Value, Day.Value).ToString("MMMM d, yyyy"));
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Ol);
            foreach (Story s in stories)
            {
                string kickStoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory,
                        s.StoryIdentifier,
                       s.Category.CategoryIdentifier);
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", kickStoryUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(s.Title);
                writer.WriteEndTag("a");
                writer.RenderEndTag();
            }

            if (stories.Count.Equals(0))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.Write(this.NoDataCaption);
                writer.RenderEndTag();//li
            }
            writer.RenderEndTag();

        }

        /// <summary>
        /// Renders the story lists.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void RenderStoryLists(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "ZeitgeistLists");
            writer.Write(HtmlTextWriter.TagRightChar);

            //most kicked during time period
            RenderStoryListItems(writer, _mostKickedStories, "Most Kicked Stories", "kicks");

            //do next top 10 list
            RenderStoryListItems(writer, _mostCommentedOnStories, "Most Commented On Stories", "comments");

            writer.Write("<p><i>Counts are calculated based on the the story's submission date.</i></p>");

            writer.WriteEndTag("div");



        }

        /// <summary>
        /// Renders the navigation.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void RenderNavigation(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "ZeitgeistNavigation");
            writer.Write(HtmlTextWriter.TagRightChar);

            //render year list
            writer.Write("Browse By Year");
            RenderListOfYears(writer);

            //if just year, then always give user option of drilling down to individual months
            writer.Write("Browse " + Year.ToString() + " By Month");
            RenderListOfMonths(writer, Year.Value);

            if (Month != null)
            {
                writer.Write("Browse " + new DateTime(Year.Value, Month.Value, 1).ToString("MMMM yyyy") + " By Day");
                RenderListOfDays(writer, Year.Value, Month.Value);
            }
            writer.WriteEndTag("div");
        }

        #endregion [rgn]

    }
}
