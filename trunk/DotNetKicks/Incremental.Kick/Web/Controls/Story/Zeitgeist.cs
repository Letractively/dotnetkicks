using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;
using System.Data;

namespace Incremental.Kick.Web.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Zeitgeist runat=server></{0}:Zeitgeist>")]
    public class Zeitgeist : KickWebControl
    {

        #region [rgn] Fields (6)

        //default caption
        private string _caption = "There are no data available for this time period.";
        private DateTime _minDate = new DateTime(2005, 10, 1);
        private int? _month = System.DateTime.Now.Month;
        private string _title = "";
        private int? _year;
        private SubSonic.StoredProcedure mostKicked;
        private SubSonic.StoredProcedure mostCommentedOn;

        #endregion [rgn]

        #region [rgn] Properties (5)

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
        public void DataBind(int hostId, int? year, int? month)
        {
            //don't do data bind if year is null
            //just show listing
            if (year == null)
                return;

            this.Month = month;
            this.Year = year;

            if (this.Month == null)
            {
                //show year stats
                mostKicked = SPs.Kick_GetTopKickedStoriesByYear(hostId, this.Year);
                mostCommentedOn = SPs.Kick_GetTopCommentedOnStoriesByYear(hostId, this.Year);
            }
            else
            {
                //show month stats
                mostKicked = SPs.Kick_GetTopKickedStoriesByYearMonth(hostId, this.Year, this.Month);
                mostCommentedOn = SPs.Kick_GetTopCommentedOnStoriesByYearMonth(hostId, this.Year, this.Month);
            }
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
                RenderStoryLists(writer);
            }


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
            for (int y = MinimumDate.Year; y <= DateTime.Now.Year; y++)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
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
                writer.RenderEndTag();//ul year

            }
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
        /// Renders the story list items.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="title">The title.</param>
        /// <param name="reader">The reader.</param>
        private void RenderStoryListItems(HtmlTextWriter writer, IDataReader reader, string title, string itemType)
        {
            //render top 10 lists
            writer.Write(title);
            writer.Write(" for ");
            if (Month == null)
                writer.Write(Year);
            else
                writer.Write(new DateTime((int)Year, (int)Month, 1).ToString("MMMM yyyy"));

            bool hasData = false;

            writer.RenderBeginTag(HtmlTextWriterTag.Ol);
            while (reader.Read())
            {
                string kickStoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory,
                        reader["StoryIdentifier"].ToString(),
                        reader["CategoryIdentifier"].ToString());
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", kickStoryUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(reader["title"]);
                writer.WriteEndTag("a");
                writer.Write(" [{0} {1}]", reader["ItemCount"].ToString(), itemType);
                writer.RenderEndTag();
                hasData = true;
            }

            if (!hasData)
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
            //most kicked during time period
            IDataReader reader = mostKicked.GetReader();
            RenderStoryListItems(writer, reader, "Most Kicked Stories", "kicks");
            reader.Close();

            //do next top 10 list
            reader = mostCommentedOn.GetReader();
            RenderStoryListItems(writer, reader, "Most Commented On Stories", "comments");
            reader.Close();

            writer.Write("<p><i>Counts are calculated based on the specified time period.</i></p>");

            //if just year, then always give user option of drilling down to individual months
            writer.Write("Browse " + Year.ToString() + " By Month");
            RenderListOfMonths(writer, (int)Year);
        }

        #endregion [rgn]

    }
}
