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
        private string _title = "";
        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }
        //default caption
        private string _caption = "There are no data available for this time period.";

        public string NoDataCaption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }

        private int? _year;
        private int _minYear = 2005;

        public int MinimumYear
        {
            get { return _minYear; }
            set { _minYear = value; }
        }

        private int? Year
        {
            get { return _year; }
            set {
                value = value > DateTime.Now.Year ? DateTime.Now.Year : value;
                value = value < _minYear ? _minYear : value;
                _year = value; 
            }
        }
        private int? _month = System.DateTime.Now.Month;

        private int? Month
        {
            get { return _month; }
            set {
                value = value > 12 ? 12 : value;
                value = value < 1 ? 1 : value;
                _month = value; 
            }
        }

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
            }
            else
            {
                //show month stats
                mostKicked = SPs.Kick_GetTopKickedStoriesByYearMonth(hostId, this.Year, this.Month);
            }
        }
        
        private SubSonic.StoredProcedure mostKicked;

        private void RenderIndexPage(HtmlTextWriter writer)
        {
            //start at min year
            //go to now
            for (int y = MinimumYear; y <= DateTime.Now.Year; y++)
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

                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                //each month of that year
                for (int m = 1; m <= 12; m++)
                {
                    if (y == DateTime.Now.Year && m > DateTime.Now.Month)
                        continue;
                    writer.RenderBeginTag(HtmlTextWriterTag.Li);
                    string monthUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist, y.ToString(), m.ToString());
                    writer.WriteBeginTag("a");
                    writer.WriteAttribute("href", monthUrl);
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Write(new DateTime(y,m,1).ToString("MMMM"));    //TODO find a better way to convert int to string
                    writer.WriteEndTag("a");
                    writer.RenderEndTag();//li month
                }
                writer.RenderEndTag();//ul month

                writer.RenderEndTag();//li year
                writer.RenderEndTag();//ul year

            }
        }
        private void RenderTop10Lists(HtmlTextWriter writer)
        {
            //most kicked during time period
            IDataReader reader = mostKicked.GetReader();
            RenderTop10ListItems(writer, "Most Kicked Stories", reader);

            //do next top 10 list

        }
        private void RenderTop10ListItems(HtmlTextWriter writer, string title, IDataReader reader)
        {
            //render top 10 lists
            writer.Write(title);
            writer.Write(" for ");
            if (Month == null)
                writer.Write(Year);
            else
                writer.Write(new DateTime((int)Year, (int)Month, 1).ToString("MMMM yyyy"));
           
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
                writer.RenderEndTag();
            }
            reader.Close();
            writer.RenderEndTag();
        }
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
                RenderTop10Lists(writer);
            }
           

        }
    }
}
