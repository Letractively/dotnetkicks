using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls {
    public class Paging : KickHtmlControl {
        private int _pageSize = 10;
        private int _pageNumber = 1;
        private int _recordCount = 0;
        private int _wingSize = 2;
        private int _bodySize = 7;
        private string _baseUrl;

        public int PageSize {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public int PageNumber {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        public int RecordCount {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        public int PageCount {
            get {
                if (this.RecordCount > 0) {
                    return (this.RecordCount / this.PageSize) + 1;
                } else {
                    return 0;
                }
            }
        }

        public int WingSize {
            get { return _wingSize; }
            set { _wingSize = value; }
        }

        public int BodySize {
            get { return _bodySize; }
            set { _bodySize = value; }
        }

        public string BaseUrl {
            get { return this._baseUrl; }
            set { 
                
                this._baseUrl = value;
                //TEMP: we still have the url bug
                if (this._baseUrl.Length > 0) {
                    this._baseUrl = this._baseUrl.TrimEnd("/".ToCharArray());
                    this._baseUrl = this._baseUrl.Replace("//", "/");
                }
                //System.Diagnostics.Trace.WriteLine("Paging.BaseUrl = " + this._baseUrl);
            }
        }

        //TODO: GJ: change the order - pagenumber pagesize
        public Paging(int pageSize, int pageNumber, int recordCount) {
            this._pageSize = pageSize;
            this._pageNumber = pageNumber;
            this._recordCount = recordCount;
        }

        public Paging(int pageSize) {
            this._pageSize = pageSize;
        }

        public Paging() { }


        protected override void Render(System.Web.UI.HtmlTextWriter writer) {

            //TODO: implement a full paging control. for now, just show previous and next and the page number

            if (this.RecordCount > 0) {

                writer.WriteLine(@"<div class=""Paging"">");

                if (this.PageNumber > 1) {
                    writer.WriteLine(@"<span class=""PagingPrevious""><a href=""{0}"">« Previous</a></span>",
                        this.BaseUrl + "/page/" + (this.PageNumber - 1));
                }

                writer.WriteLine(@"<span class=""PagingInfo"">Page {0} of {1}</span>",
                    this.PageNumber, this.PageCount);

                if (this.PageNumber < this.PageCount) {
                    writer.WriteLine(@"<span class=""PagingNext""><a href=""{0}"">Next »</a></span>",
                        this.BaseUrl + "/page/" + (this.PageNumber + 1));
                }

                writer.WriteLine(@"</div>");
            }

            /*

            if (this._displayPageNumbers) {
                writer.WriteLine("<span class=\"PagingWing\" id=\"{0}\"></span>", this.GetUniqueClientID("LeftWing"));
                writer.WriteLine("<span class=\"PagingBone\" id=\"{0}\"> ... </span>", this.GetUniqueClientID("LeftBone"));
                writer.WriteLine("<span class=\"PagingBody\" id=\"{0}\"></span>", this.GetUniqueClientID("Body"));
                writer.WriteLine("<span class=\"PagingBone\" id=\"{0}\"> ... </span>", this.GetUniqueClientID("RightBone"));
                writer.WriteLine("<span class=\"PagingWing\" id=\"{0}\"></span>", this.GetUniqueClientID("RightWing"));
            }

            if (this._displayPreviousAndNext) {
                writer.WriteLine("<span class=\"PageCommand\" id=\"{0}\"> <a href=\"javascript:Paging_PagePrevious('{1}');\">{2}</a> </span>", this.GetUniqueClientID("Previous"), this.ClientID, Resources.Navigation.Previous);
                writer.WriteLine("<span class=\"PageCommand\" id=\"{0}\"> <a href=\"javascript:Paging_PageNext('{1}');\">{2}</a> </span>", this.GetUniqueClientID("Next"), this.ClientID, Resources.Navigation.Next);
            }

            writer.WriteLine("</div>");

            */


        }
    }
}