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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool isUserRestrictedSearch = false;

                string query          = Request["q"];
                string page           = Request["page"];
                string userRestricted = Request["user"];

                int pageNumber;

                if (!Int32.TryParse(page, out pageNumber))
                    pageNumber = 1;

                bool.TryParse(userRestricted, out isUserRestrictedSearch);

                Title = string.Format("Search Results for - {0}", query);

                LoadResults(query, isUserRestrictedSearch, pageNumber, this.UrlParameters.PageSize);

                paging.RecordCount = resultTotalCount;
                paging.PageSize = 16;
                paging.PageNumber = pageNumber;
                paging.BaseUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Search, query);

                lblSearchTerm.Text = string.Format("Results <strong>{0}</strong> - <strong>{1}</strong> of <strong>{2}</strong> for <strong>{3}</strong>", 
                                                    SearchStartIndex(pageNumber),
                                                    SearchEndIndex(pageNumber),
                                                    resultTotalCount, 
                                                    query);
            }
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



        private void LoadResults(string queryTerm, bool restrictSearchToUser, int pageNumber, int pageSize)
        {
            StoryCollection results;

            if (restrictSearchToUser)
            {
                results = SearchStoryCache.GetStoryCollectionSearchResultsByUser(queryTerm, Page.User.Identity.Name, this.HostProfile.HostID, pageNumber, pageSize);
                resultTotalCount = SearchStoryCache.GetStoryCollectionSearchResultsCountByUser(queryTerm, Page.User.Identity.Name, this.HostProfile.HostID, pageNumber, pageSize);
            }
            else
            {
                results = SearchStoryCache.GetStoryCollectionSearchResults(queryTerm, this.HostProfile.HostID, pageNumber, pageSize);
                resultTotalCount = SearchStoryCache.GetStoryCollectionSearchResultsCount(queryTerm, this.HostProfile.HostID, pageNumber, pageSize);
            }

            if (results != null)
                resultCurrentPageCount = results.Count;
            else
                resultCurrentPageCount = 0;

            if (results!= null && results.Count > 0)
                searchResults.DataBind(results);
            else
                lblNoResults.Visible = true;
        }
    }
}
