using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;

using Incremental.Kick.Dal;
using Incremental.Kick.Search.Analyzer;

using log4net;

namespace Incremental.Kick.Search
{
    public class SearchQuery
    {
        /// <summary>
        /// holds a list of index searchers, one for each host. We need these since the 
        /// recommend way is to use a single static indexSearcher for an index, creating a
        /// new indexsearch for each search will have a negative impact in performance.
        /// The indexSearcher is thread safe.
        /// </summary>
        /// <remarks>This is required since a single codebase/appdomain could be running
        /// multiple host sites, so we need to provide the correct searcher for the correct
        /// host. Maybe this should be moved to a factory pattern???</remarks>
        static Dictionary<int, IndexSearcher> searchers = new Dictionary<int,IndexSearcher>();

        /// <summary>
        /// Log4net logger
        /// </summary>
        protected static readonly ILog Log = LogManager.GetLogger(
                        MethodBase.GetCurrentMethod().DeclaringType);



        public StoryCollection SearchIndex(int hostID, string queryTerm, string username, int page,
                                            int pageSize, out int totalNoResults)
        {
            totalNoResults = 0;
            Query query;

            Log.Debug("Starting index search");

            IndexSearcher searcher = GetSearcher(hostID);

            if (username == null)
            {
                QueryFactory queryFactory = new QueryFactory(QueryFactory.QueryType.Stories);
                query = queryFactory.Parse(queryTerm, null);
            }
            else
            {
                QueryFactory queryFactory = new QueryFactory(QueryFactory.QueryType.User);
                query = queryFactory.Parse(queryTerm, username);
            }

            if (query == null)
            {
                Log.Debug("No query term supplied, finished");
                return null;
            }

            Log.DebugFormat("Querying the index for term:\"{0}\" page:{1} username:{2}", queryTerm, page, username);

            Hits hits = searcher.Search(query);

            Log.DebugFormat("No of results:{0} for term:\"{1}\"", hits.Length(), queryTerm);

            List<int> storyIds = new List<int>();

            //calculate the starting index of the hits
            int startIndex = (page - 1) * pageSize;

            if (startIndex > hits.Length())
                startIndex = 0;

            //calculate the ending index of the hits
            int endIndex;

            endIndex = (startIndex + pageSize);
            if (endIndex > hits.Length())
                endIndex = hits.Length();

            for (int i = startIndex; i < endIndex; i++)
            {
                Document doc = hits.Doc(i);
                string id = doc.GetField("id").StringValue();
                storyIds.Add(Int32.Parse(id));
            }

            totalNoResults = hits.Length();
            return LoadStorySearchResults(storyIds);
        }
        
        /// <summary>
        /// Searches the index for any documents that match the query 
        /// term. Returns a StoryCollection of matching stories.
        /// </summary>
        /// <param name="hostID">hostId for the site being searched</param>
        /// <param name="queryTerm">query string to search the index for</param>
        /// <param name="page">Page of results to return</param>
        /// <param name="pageSize">No of items to return for a page</param>
        /// <param name="totalNoResults">Total no of hits found for the query term, this
        /// value is outputted</param>
        /// <returns></returns>
        public StoryCollection SearchIndex(int hostID, string queryTerm, int page, int pageSize, out int totalNoResults)
        {
            return SearchIndex(hostID, queryTerm, null, page, pageSize, out totalNoResults);
            //totalNoResults = 0;

            //Log.Debug("Starting index search");

            //IndexSearcher searcher = GetSearcher(hostID);

            //QueryFactory queryFactory = new QueryFactory(QueryFactory.QueryType.Stories);
            //Query query = queryFactory.Parse(queryTerm, null);

            //if (query == null)
            //{
            //    Log.Debug("No query term supplied, finished");
            //    return null;
            //}

            //Log.DebugFormat("Querying the index for term:\"{0}\" page:{1}", queryTerm, page);

            //Hits hits = searcher.Search(query);

            //Log.DebugFormat("No of results:{0} for term:\"{1}\"", hits.Length(), queryTerm);

            //List<int> storyIds = new List<int>();

            ////calculate the starting index of the hits
            //int startIndex = (page - 1) * pageSize;

            //if (startIndex > hits.Length())
            //    startIndex = 0;

            ////calculate the ending index of the hits
            //int endIndex;

            //endIndex = (startIndex + pageSize);
            //if (endIndex > hits.Length())
            //    endIndex = hits.Length();

            //for (int i = startIndex; i < endIndex; i++)
            //{
            //    Document doc = hits.Doc(i);
            //    string id = doc.GetField("id").StringValue();
            //    storyIds.Add(Int32.Parse(id));
            //}

            //totalNoResults = hits.Length();
            //return LoadStorySearchResults(storyIds);
        }



        /// <summary>
        /// Gets the correct searcher for the host.
        /// Handles the searcher being out of date or not
        /// existing.
        /// </summary>
        /// <param name="hostID">hostID of the host to perform the search on</param>
        private static IndexSearcher GetSearcher(int hostID)
        {

            if (!searchers.ContainsKey(hostID))
            {
                //the searcher for this index doesnt exist, so we just
                //create one
                Log.Debug("Created IndexSearcher");
                searchers[hostID] = new IndexSearcher(SearchUpdate.Instance.IndexHostPath(hostID));

                return searchers[hostID];
            }
            else
            {
                //check the searcher is still valid, otherwise re-open to pick up
                //the new changes to the index
                IndexSearcher search = searchers[hostID];

                if (!search.Reader.IsCurrent() && !SearchUpdate.Instance.IsUpdateRunning)
                {
                    Log.Debug("Recreating IndexSearcher, since index has been updated");
                    search.Close();
                    searchers[hostID] = new IndexSearcher(SearchUpdate.Instance.IndexHostPath(hostID));
                }
                
                return searchers[hostID];
            }
        }


        /// <summary>
        /// Returns a StoryCollection containing the stories that match for the given
        /// search term. The stories are returned in the correct order as given
        /// by the lucene results.
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private StoryCollection LoadStorySearchResults(IList<int> results)
        {
            if (results.Count == 0)
                return null;

            StoryCollection stories = Story.GetStoriesByIds(results);

            //the stories are not returned in the hit order lucene found
            //the matches, the order is storyId asc. We need to correct
            //the order so the collection is correctly order as per the 
            //hits result from lucene
            StoryCollection searchResults = new StoryCollection();
            foreach (int i in results)
            {
                Story s = (Story)stories.Find(i);
                searchResults.Add(s);
            }

            return searchResults;
        }


        /// <summary>
        /// Attempts to delete the index. This could fail if the index is currently
        /// being crawled or because of an IO issue
        /// </summary>
        /// <remarks>For some reason deleting a single index folder causes
        /// the singleton to call the dispose method because the applicaiton_end
        /// event gets called. Not sure why this happens??
        /// </remarks>
        /// <returns></returns>
        public bool DeleteIndex(int hostID)
        {
            if (SearchUpdate.Instance.IsUpdateRunning)
                return false;

            IndexSearcher searcher = GetSearcher(hostID);

            if (searcher != null)
                searcher.Close();

            try
            {
                Directory.Delete(SearchUpdate.Instance.IndexHostPath(hostID), true);
                Log.Debug("Lucene index deleted");
                return true;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Unable to delete the index, messsage: {0}", ex.Message);
                return false;
            }
        }


    }
}
