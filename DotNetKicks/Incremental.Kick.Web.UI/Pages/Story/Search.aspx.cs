using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages
{
    public partial class Search : Incremental.Kick.Web.Controls.KickUIPage
    {
        int resultTotalCount;
        int resultCurrentPageCount;

        #region properties

        /// <summary>
        /// Indicates that the search results should be limited to only 
        /// include stories that the currently logged in user has kicked
        /// </summary>
        protected bool IsUserRestrictedSearch
        {
            get 
            {
                bool isUserRestrictedSearch = false;

                string userRestricted = Request["user"];
                bool.TryParse(userRestricted, out isUserRestrictedSearch);

                return isUserRestrictedSearch;
            }
        }

        /// <summary>
        /// Holds the current page number for the search results to display
        /// </summary>
        protected int PageNumber
        {
            get
            {
                int pageNumber;

                string page = Request["page"];
                if (!Int32.TryParse(page, out pageNumber))
                    pageNumber = 1;

                return pageNumber;
            }
        }

                

        /// <summary>
        /// Holds the current query term that should be used to search
        /// the index
        /// </summary>
        protected string Query
        {
            get { return Request["q"]; }
        }


        /// <summary>
        /// Holds the field in the index that the results should
        /// be sorted by.
        /// </summary>
        protected string SortField
        {
            get { return Request["sort"]; }
        }


        /// <summary>
        /// Indicates if the sort field should be sorted in reverse.
        /// </summary>
        /// <remarks>When this value is false (the default value) then smaller values will
        /// be displayed first. When set true this will mean larger values are displayed first.</remarks>
        protected bool SortReversed
        {
            get 
            {
                bool sortReversed = false;

                string sortReverse = Request["sortReverse"] ?? "false";

                bool.TryParse(Request["sortReverse"], out sortReversed);
                
                return sortReversed;
            }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Title = string.Format("Search Results for - {0}", Server.HtmlEncode(Query));

                LoadResults(Query, IsUserRestrictedSearch, SortField, SortReversed, PageNumber, this.UrlParameters.PageSize);

                paging.RecordCount = resultTotalCount;
                paging.PageSize = 16;
                paging.PageNumber = PageNumber;
                paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Search, HttpUtility.UrlEncode(Query));

                lblSearchTerm.Text = string.Format("Results <strong>{0}</strong> - <strong>{1}</strong> of <strong>{2}</strong> for <strong>{3}</strong>",
                                                    SearchStartIndex(PageNumber),
                                                    SearchEndIndex(PageNumber),
                                                    resultTotalCount,
                                                    HttpUtility.HtmlEncode(Query));
                LoadDropDownList();
            }
        }

        /// <summary>
        /// Loads the correct sort ordering for the results in the dropdown list
        /// displayed to the end user
        /// </summary>
        private void LoadDropDownList()
        {
            if (SortField == "kickCount")
            {
                ddlSort.SelectedValue = SortReversed ? "kicks_desc" : "kicks_asc";
            }
            else if (SortField == "dateAdded")
            {
                ddlSort.SelectedValue = SortReversed ? "date_desc" : "date_asc";
            }
            else
                ddlSort.SelectedValue = "relevance";
        }

        /// <summary>
        /// calculates the current index value of the first item
        /// displayed. For example page 2 will have a value of 
        /// 17 (assuming a page size of 16)
        /// </summary>
        /// <returns></returns>
        private int SearchStartIndex(int currentPage)
        {
            if (resultTotalCount > 0)
                return ((currentPage - 1) * this.UrlParameters.PageSize) + 1;
            else
                return 0;
        }

        /// <summary>
        /// calculates the current index value of the last item displayed on this
        /// page
        /// </summary>
        /// <returns></returns>
        private int SearchEndIndex(int currentPage)
        {
            if (resultTotalCount > 0)
                return SearchStartIndex(currentPage) + resultCurrentPageCount - 1;
            else
                return 0;
        }



        private void LoadResults(string queryTerm, bool restrictSearchToUser, string sortField, bool sortReversed, int pageNumber, int pageSize)
        {
            StoryCollection results;

            if (queryTerm == null)
                return;

            if (restrictSearchToUser)
            {
                results = SearchStoryCache.GetStoryCollectionSearchResultsByUser(queryTerm, Page.User.Identity.Name, sortField, sortReversed, this.HostProfile.HostID, pageNumber, pageSize);
                resultTotalCount = SearchStoryCache.GetStoryCollectionSearchResultsCountByUser(queryTerm, Page.User.Identity.Name, this.HostProfile.HostID, pageNumber, pageSize);
            }
            else
            {
                results = SearchStoryCache.GetStoryCollectionSearchResults(queryTerm, sortField, sortReversed, this.HostProfile.HostID, pageNumber, pageSize);
                resultTotalCount = SearchStoryCache.GetStoryCollectionSearchResultsCount(queryTerm, this.HostProfile.HostID, pageNumber, pageSize);
            }

            resultCurrentPageCount = results != null ? results.Count : 0; 

            if (results!= null && results.Count > 0)
                searchResults.DataBind(results);
            else
                lblNoResults.Visible = true;
        }


        /// <summary>
        /// Handles the user changing the sort order of the current query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool sortDescDirection;
            string sortField;

            switch (ddlSort.SelectedValue)
            {
                case "relevance":
                default:
                    sortDescDirection = true;
                    sortField = null;
                    break;

                case "kicks_desc":
                    sortDescDirection = true;
                    sortField = "kickCount";
                    break;

                case "kicks_asc":
                    sortDescDirection = false;
                    sortField = "kickCount";
                    break;

                case "date_desc":
                    sortDescDirection = true;
                    sortField = "dateAdded";
                    break;

                case "date_asc":
                    sortDescDirection = false;
                    sortField = "dateAdded";
                    break;
            }



            Response.Redirect(string.Format("/search?q={0}&user={1}&page={2}&sortReverse={3}&sort={4}",
                                        Server.UrlEncode(Query),
                                        IsUserRestrictedSearch,
                                        1,
                                        sortDescDirection,
                                        sortField));
        }
    }
}
