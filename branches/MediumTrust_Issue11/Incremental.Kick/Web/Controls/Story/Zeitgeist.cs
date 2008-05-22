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

        #region [rgn] Fields (14)

        //default caption
        private string _caption = "There are no data available for this time period.";
        private int _commentsCount;
        private int? _day;
        private int _kicksCount;
        private int _userRegistrationCount;
        private DateTime _minDate = new DateTime(2006, 1, 1);
        private int? _month = System.DateTime.Now.Month;
        private StoryCollection _mostCommentedOnStories;
        private StoryCollection _mostKickedStories;
        private Dictionary<string, int> _mostUsedTags;
        private Dictionary<string, int> _mostPopularDomains;
        private Dictionary<string, int> _mostPublishedDomains;
        private Dictionary<string, int> _mostPublishedUsers;
        private int _storiesPublishedCount;
        private int _storiesSubmittedCount;
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

        #region [rgn] Methods (11)

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

            _mostKickedStories = ZeitgeistCache.GetMostPopularStories(hostId, this.NumberOfItems, this.Year.Value, this.Month, this.Day);
            _mostCommentedOnStories = ZeitgeistCache.GetMostCommentedOnStories(hostId, this.NumberOfItems, this.Year.Value, this.Month, this.Day);
            _mostUsedTags = ZeitgeistCache.GetMostUsedTags(hostId, this.numberOfItems, this.Year.Value, this.Month, this.Day);
            _mostPopularDomains = ZeitgeistCache.GetMostPopularDomains(hostId, this.numberOfItems, this.Year.Value, this.Month, this.Day);
            _mostPublishedDomains = ZeitgeistCache.GetMostPublishedDomains(hostId, this.numberOfItems, this.Year.Value, this.Month, this.Day);
            _mostPublishedUsers = ZeitgeistCache.GetMostPublishedUsers(hostId, this.numberOfItems, this.Year.Value, this.Month, this.Day);

            _storiesSubmittedCount = ZeitgeistCache.GetNumberOfStoriesSubmitted(hostId, this.Year.Value, this.Month, this.Day);
            _storiesPublishedCount = ZeitgeistCache.GetNumberOfStoriesPublished(hostId, this.Year.Value, this.Month, this.Day);
            _kicksCount = ZeitgeistCache.GetNumberOfKicks(hostId, this.Year.Value, this.Month, this.Day);
            _commentsCount = ZeitgeistCache.GetNumberOfComments(hostId, this.Year.Value, this.Month, this.Day);
            _userRegistrationCount = ZeitgeistCache.GetNumberOfUserRegistrations(hostId, this.Year.Value, this.Month, this.Day);
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
                writer.WriteBeginTag("div");
                writer.WriteAttribute("class", "ZeitgeistTotals");
                writer.WriteAttribute("style", "display:inline-block;");
                writer.Write(HtmlTextWriter.TagRightChar);

                RenderDateStatistics(writer);

                //render top 10/X lists
                RenderZeitgeistLists(writer);

                writer.WriteEndTag("div");
            }

        }

        // [rgn] Private Methods (9)

        /// <summary>
        /// Renders the date statistics.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void RenderDateStatistics(HtmlTextWriter writer)
        {
            //TODO clean this up using DL/DT/DDs to align ":", etc.

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
            {
                writer.Write(Math.Round((double)_storiesPublishedCount / _storiesSubmittedCount, 4).ToString("P"));
            }
            else
            {
                writer.Write("0 %");
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Br);

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.Write("Number of Story Kicks: ");
            writer.Write(_kicksCount);
            writer.RenderBeginTag(HtmlTextWriterTag.Br);

            writer.Write("Number of Story Comments: ");
            writer.Write(_commentsCount);
            writer.RenderBeginTag(HtmlTextWriterTag.Br);

            writer.Write("Number of User Registrations: ");
            writer.Write(_userRegistrationCount);
            writer.RenderBeginTag(HtmlTextWriterTag.Br);

            

            writer.RenderEndTag();    //p

            writer.WriteEndTag("div");

            //writer.RenderBeginTag(HtmlTextWriterTag.Br);//msie hack
        }

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

        /// <summary>
        /// Renders the story list items.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="title">The title.</param>
        /// <param name="reader">The reader.</param>
        private void RenderStoryListItems(HtmlTextWriter writer, StoryCollection stories, string valueCountField, string title, string itemType)
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


            //just plain OL with story title links
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
                writer.Write(" (" + SubSonic.Sugar.Strings.Pluralize(s.GetColumnValue<int>(valueCountField), itemType) + ")");
                writer.RenderEndTag();
            }
            writer.RenderEndTag();

            if (stories.Count.Equals(0))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write(this.NoDataCaption);
                writer.RenderEndTag();
            }

            //do story summary in OL
            //foreach (Story s in stories)
            //{
            //    string kickStoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory,
            //            s.StoryIdentifier,
            //           s.Category.CategoryIdentifier);
            //    writer.RenderBeginTag(HtmlTextWriterTag.Li);
            //    StorySummary ss = new StorySummary();
            //    ss.ShowFullSummary = false;
            //    ss.DataBind(s);
            //    ss.RenderControl(writer);
            //    writer.RenderEndTag();
            //}

        }

        /// <summary>
        /// Renders the tag list items.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="tags">The tags.</param>
        /// <param name="title">The title.</param>
        /// <param name="itemType">Type of the item.</param>
        private void RenderTagListItems(HtmlTextWriter writer, Dictionary<string, int> tags, string title)
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

            //just plain OL with tag links
            writer.RenderBeginTag(HtmlTextWriterTag.Ol);
            foreach (KeyValuePair<string, int> kvp in tags)
            {
                string tagUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewTag,
                        kvp.Key);
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", tagUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(kvp.Key);
                writer.WriteEndTag("a");
                writer.Write(" (" + SubSonic.Sugar.Strings.Pluralize(kvp.Value, "tag") + ")");
                writer.RenderEndTag();
            }
            writer.RenderEndTag();

            if (tags.Count.Equals(0))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write(this.NoDataCaption);
                writer.RenderEndTag();
            }
        }

        /// <summary>
        /// Renders the user list items.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="users">The users.</param>
        /// <param name="title">The title.</param>
        /// <param name="itemType">Type of the item.</param>
        private void RenderUserListItems(HtmlTextWriter writer, Dictionary<string, int> users, string title, string itemType)
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

            //just plain OL with tag links
            writer.RenderBeginTag(HtmlTextWriterTag.Ol);
            foreach (KeyValuePair<string, int> kvp in users)
            {
                string userUrl = UrlFactory.CreateUrl(UrlFactory.PageName.UserHome,
                        kvp.Key);
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", userUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(kvp.Key);
                writer.WriteEndTag("a");
                writer.Write(" (" + SubSonic.Sugar.Strings.Pluralize(kvp.Value, itemType) + ")");
                writer.RenderEndTag();
            }
            writer.RenderEndTag();

            if (users.Count.Equals(0))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write(this.NoDataCaption);
                writer.RenderEndTag();
            }
        }

        /// <summary>
        /// Renders the story lists.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void RenderZeitgeistLists(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "ZeitgeistLists");
            writer.Write(HtmlTextWriter.TagRightChar);

            //most kicked during time period
            RenderStoryListItems(writer, _mostKickedStories, Story.Columns.KickCount, "Most Popular Stories", "kick");

            //do next top 10 list
            RenderStoryListItems(writer, _mostCommentedOnStories, Story.Columns.CommentCount, "Most Commented On Stories", "comment");

            //most used tags
            RenderTagListItems(writer, _mostUsedTags, "Most Popular Tags");

            //most published users
            RenderUserListItems(writer, _mostPublishedUsers, "Most Published Users", "story");            

            //most popular domains
            RenderDictionaryListItems(writer, _mostPopularDomains, "Most Popular Domains", "story kick");
            
            //most published domains
            RenderDictionaryListItems(writer, _mostPublishedDomains, "Most Published Domains", "story");

            //footer
            writer.Write("<p><i>Aggregate statistics are based on the item date. For example, the number of kicks listed is based on the exact time period and are totalled without regard to the story's submission date.</i></p>");
            writer.Write("<p><i>Story lists are calculated based on the the story's submission date.</i></p>");

            writer.WriteEndTag("div");
        }

        /// <summary>
        /// Simple renders for a dictionary where key is the text and value is the count.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="dictionaryList">The dictionary list.</param>
        /// <param name="p">The p.</param>
        private void RenderDictionaryListItems(HtmlTextWriter writer, Dictionary<string, int> dictionaryList, string title, string itemType)
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

            //just plain OL with tag links
            writer.RenderBeginTag(HtmlTextWriterTag.Ol);
            foreach (KeyValuePair<string, int> kvp in dictionaryList)
            {
                string tagUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewTag,
                        kvp.Key);
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.Write(kvp.Key);
                writer.Write(" (" + SubSonic.Sugar.Strings.Pluralize( kvp.Value, itemType) + ")");
                writer.RenderEndTag();
            }
            writer.RenderEndTag();

            if (dictionaryList.Count.Equals(0))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write(this.NoDataCaption);
                writer.RenderEndTag();
            }
        }

        #endregion [rgn]

    }
}
