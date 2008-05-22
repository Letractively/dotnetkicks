using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Collections;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// Web Control to handle pagination
    /// </summary>
    public class Paging : KickHtmlControl
    {

        #region Fields

        private string _baseUrl;
        private int _maxPageNumberingCount = 8;
        private string _nextText = "Next »";
        private SortedList _pageIdsToDisplay = new SortedList();
        private int _pageNumber = 1;
        private int _pageSize = 10;
        private string _previousText = "« Previous";
        private int _recordCount = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Paging"/> class.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordCount">The record count.</param>
        public Paging(int pageSize, int pageNumber, int recordCount)
        {
            //TODO: GJ: change the order - pagenumber pagesize
            this._pageSize = pageSize;
            this._pageNumber = pageNumber;
            this._recordCount = recordCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Paging"/> class.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        public Paging(int pageSize)
        {
            this._pageSize = pageSize;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Paging"/> class.
        /// </summary>
        public Paging() { }

        #endregion [rgn]

        #region Properties

        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>The base URL.</value>
        public string BaseUrl
        {
            get { return this._baseUrl; }
            set
            {
                this._baseUrl = value;
                //TODO TEMP: we still have the url bug
                //HACK url bug
                if (this._baseUrl.Length > 0)
                {
                    this._baseUrl = this._baseUrl.TrimEnd("/".ToCharArray());
                    this._baseUrl = this._baseUrl.Replace("//", "/");
                }
                //System.Diagnostics.Trace.WriteLine("Paging.BaseUrl = " + this._baseUrl);
            }
        }

        /// <summary>
        /// Gets or sets the max page numbering count.
        /// This tells the pager how many pages to show such
        /// as: "Previous 1 2 ... 23 [24] 25 ...  98 99 Next" 
        /// counts as 3 page numbering         
        /// </summary>
        /// <value>The max page numbering count.</value>
        /// <remarks>
        /// First/Second, Current, & NextToLast/Last pages will always be shown
        /// MaxPageNumberingCount should be >= 3
        /// </remarks>
        public int MaxPageNumberingCount
        {
            get { return _maxPageNumberingCount; }
            set { _maxPageNumberingCount = value; }
        }

        /// <summary>
        /// Gets or sets the next text.
        /// </summary>
        /// <value>The next text.</value>
        public string NextText
        {
            get { return _nextText; }
            set { _nextText = value; }
        }

        /// <summary>
        /// Gets the page count.
        /// </summary>
        /// <value>The page count.</value>
        public int PageCount
        {
            get
            {
                if (this.RecordCount > 0)
                    return (this.RecordCount / this.PageSize) + 1;
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        /// <value>The page number.</value>
        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// Gets or sets the previous text.
        /// </summary>
        /// <value>The previous text.</value>
        public string PreviousText
        {
            get { return _previousText; }
            set { _previousText = value; }
        }

        /// <summary>
        /// Gets or sets the record count.
        /// </summary>
        /// <value>The record count.</value>
        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        #endregion 

        #region Methods 

        // Protected Methods 

        //TODO remove this code block after test
        //this was the previous code, leaving here until after test
        protected void OldRender(Html32TextWriter writer)
        {
            if (this.RecordCount > 0)
            {
                writer.WriteLine(@"<div class=""Paging"">");
                if (this.PageNumber > 1)
                {
                    writer.WriteLine(@"<span class=""PagingPrevious""><a href=""{0}"">« Previous</a></span>",
                        this.BaseUrl + "/page/" + (this.PageNumber - 1));
                }

                writer.WriteLine(@"<span class=""PagingInfo"">Page {0} of {1}</span>",
                    this.PageNumber, this.PageCount);

                if (this.PageNumber < this.PageCount)
                {
                    writer.WriteLine(@"<span class=""PagingNext""><a href=""{0}"">Next »</a></span>",
                        this.BaseUrl + "/page/" + (this.PageNumber + 1));
                }

                writer.WriteLine(@"</div>");
            }
        }

        /// <summary>
        /// Writes content to render on a client to the specified <see cref="T:System.Web.UI.HtmlTextWriter"></see> object.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"></see> that contains the output stream to render on the client.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "Paging");
            writer.Write(HtmlTextWriter.TagRightChar);

            if (this.RecordCount > 0)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);

                //draw previous link
                if (this.PageNumber > 1)
                    WritePageHyperlink(writer, this.PageNumber - 1, "PagingPrevious", _previousText);
                else
                    WritePageHyperlink(writer, this.PageNumber - 1, "PagingPrevious disablelink", _previousText);

                //get which pages to draw 
                GetPagesToDisplay();

                //draw pages
                int lastPageId = 1;
                for (int i = 0; i < _pageIdsToDisplay.Count; i++)
                {
                    int pageId = (int)_pageIdsToDisplay.GetKey(i);
                    if (pageId > lastPageId + 1)
                        WritePageHyperlink(writer, -1); //write "..."
                    WritePageHyperlink(writer, pageId);
                    lastPageId = pageId;
                }

                //draw next link
                if (this.PageNumber < this.PageCount)
                    WritePageHyperlink(writer, this.PageNumber + 1, "PagingNext", _nextText);
                else
                    WritePageHyperlink(writer, this.PageNumber + 1, "PagingNext disablelink", _nextText);

                //close unordered list
                writer.RenderEndTag();//ul
            }

            writer.WriteEndTag("div");

        }

        //Private Methods

        /// <summary>
        /// Adds to page list if not the item isn't alrady in the list
        /// </summary>
        /// <param name="pageId">The page id.</param>
        private void AddToPageListIfNotExists(int pageId)
        {
            if (pageId > this.PageCount)
                return;
            if (!_pageIdsToDisplay.Contains(pageId))
                _pageIdsToDisplay.Add(pageId, pageId);
        }

        /// <summary>
        /// Gets the pages to display.
        /// </summary>
        private void GetPagesToDisplay()
        {
            //add current page
            _pageIdsToDisplay.Add(this.PageNumber, this.PageNumber);

            //add pages 1 and 2
            if (this.PageNumber > 0)
                AddToPageListIfNotExists(1);
            if (this.PageNumber > 1)
                AddToPageListIfNotExists(2);

            //add last 2 pages
            if (this.PageCount > 1)
                AddToPageListIfNotExists(this.PageCount);
            if (this.PageCount - 1 > 1)
                AddToPageListIfNotExists(this.PageCount - 1);

            //now we fill up the page list with pages
            //that are before and after the current page

            int start = 1;
            int end = PageCount;
            if (PageCount > _maxPageNumberingCount)
            {
                //loop through and add the remaining pages based on maxNumberingPageCount
                start = this.PageNumber - (_maxPageNumberingCount / 2);
                end = this.PageNumber + (_maxPageNumberingCount / 2);

                //make sure start is at least page 1
                start = start < 1 ? 1 : start;

                //if end is less than start
                end = end < start ? start : end;
                end = end > PageCount ? PageCount : end;

                //make sure end fills up at least MaxPageNumberingCount pages
                int numberOfPages = end - start + 1;
                if (numberOfPages < this.MaxPageNumberingCount)
                {
                    end += (MaxPageNumberingCount - numberOfPages) / 2;
                    start -= (MaxPageNumberingCount - numberOfPages) / 2;
                }

                //make sure end is not > pagecount
                end = end > PageCount ? PageCount : end;

                //make sure start is at least page 1
                start = start < 1 ? 1 : start;
            }

            //add all of the before/after current pages to list
            for (int i = start; i <= end; i++)
            {
                AddToPageListIfNotExists(i);
            }

        }

        /// <summary>
        /// Gets the page URL.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <returns></returns>
        protected virtual string PageUrl(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > this.PageCount)
                return "#";
            return string.Concat(this.BaseUrl, "/page/", pageNumber);
        }

        /// <summary>
        /// Writes the hyperlink.
        /// This method is for generic text written as a page item
        /// such as Next/Previous links
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="pageId">The page id.</param>
        /// <param name="cssClass">The CSS class.</param>
        /// <param name="text">The text.</param>
        private void WritePageHyperlink(HtmlTextWriter writer, int pageId, string cssClass, string text)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            writer.WriteBeginTag("a");
            writer.WriteAttribute("href", PageUrl(pageId));
            writer.WriteAttribute("class", cssClass);
            writer.Write(HtmlTextWriter.TagRightChar);//close a
            writer.Write(text);
            writer.WriteEndTag("a");
            writer.RenderEndTag();//li
        }

        /// <summary>
        /// Writes the hyperlink.
        /// This method is for individual page links such as [1] [2] etc
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="pageId">The page id.</param>
        private void WritePageHyperlink(HtmlTextWriter writer, int pageId)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Li);

            if (pageId < 0)
                writer.Write("...");            
            else
            {
                writer.WriteBeginTag("a");
                if (pageId == this.PageNumber)
                {
                    writer.WriteAttribute("href", "#");
                    writer.WriteAttribute("class", "CurrentPage");
                }
                else
                    writer.WriteAttribute("href", PageUrl(pageId));
                writer.Write(HtmlTextWriter.TagRightChar);//close a
                writer.Write(pageId);
                writer.WriteEndTag("a");
            }
            writer.RenderEndTag();//li
        }

        #endregion

    }
}