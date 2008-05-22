using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;

using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;

using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Search.Analyzer;

using log4net;

namespace Incremental.Kick.Search
{
    
    public class SearchUpdate : IDisposable
    {
        /// <summary>
        /// log4net logger
        /// </summary>
        protected static readonly ILog Log = LogManager.GetLogger(
                        MethodBase.GetCurrentMethod().DeclaringType);

        static readonly SearchUpdate instance = new SearchUpdate();

        /// <summary>
        /// holds the datetime the index was last crawled, this value
        /// is used to get the changes for an increment crawl
        /// </summary>
        static DateTime lastUpdate;

        /// <summary>
        /// flag indicating if we currently updating the
        /// lucene index
        /// </summary>
        bool isUpdateRunning = false;

        /// <summary>
        /// sync lock object
        /// </summary>
        object updateLock = new object();

        /// <summary>
        /// Timer object used to crawl the database at the time interval to check
        /// for new/modified stories to add to th index
        /// </summary>
        static Timer updateTimer;

        /// <summary>
        /// holds the base path to the lucene index directory, this will contain directories
        /// for each host that contains a single index for each host. This value is an absolute
        /// file path.
        /// </summary>
        string indexBasePath;

        /// <summary>
        /// Used to detect redundant calls to the dispose method
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Holds a list dictionary indicating if a given host
        /// was crawled successful on the last crawl
        /// </summary>
        Dictionary<int, bool> hostCrawlError;

        #region cstor

        /// <summary>
        /// explict private static cstor
        /// </summary>
        static SearchUpdate()
        {
        }

        /// <summary>
        /// explict private cstor
        /// </summary>
        SearchUpdate()
        {
            Log.Debug("Creating SearchUpdate singleton");

            int crawlIntervalMinutes;
            hostCrawlError = new Dictionary<int, bool>();

            SearchSettings searchSettings = new SearchSettings();

            try
            {
                //attempt to lookup the index location for the settings
                string baseDirectory = searchSettings.SearchBaseDirectory;
                indexBasePath = HttpContext.Current.Server.MapPath(baseDirectory);
            }
            catch (ArgumentException ex)
            {
                Log.Fatal("The setting key is missing, we cant create an index of the site without it. This value holds the location of the index");
                throw ex;
            }

            crawlIntervalMinutes = searchSettings.SearchUpdateInterval;           

            TimerCallback callback = new TimerCallback(UpdateIndex);
            updateTimer = new Timer(callback, null, TimeSpan.Zero, TimeSpan.FromMinutes(crawlIntervalMinutes));
        }

        #endregion


        /// <summary>
        /// Returns an instance of this object. This object
        /// is a singleton
        /// </summary>
        public static SearchUpdate Instance
        {
            get { return instance; }
        }


        public void UpdateIndex(object state)
        {
            UpdateIndex();
        }

        /// <summary>
        /// Creates or updates the existing index. This takes place on a 
        /// new thread
        /// </summary>
        public void UpdateIndex()
        {
            if (!isUpdateRunning)
            {
                lock (updateLock)
                {
                    if (isUpdateRunning)
                        return;

                    ThreadStart indexMethod = new ThreadStart(GenerateHostIndexes);
                    Thread indexThread = new Thread(indexMethod);
                    indexThread.IsBackground = true;
                    indexThread.Start();
                }
            }
        }

        /// <summary>
        /// Starts the process of creating or updating an index for all the
        /// hosts listed in the database. This method will be called by the timer
        /// to update the indexes at a regular interval
        /// </summary>
        private void GenerateHostIndexes()
        {
            isUpdateRunning = true;

            DateTime startIndexTime = DateTime.Now;
            
            DateTime searchDate = LastUpdateCrawl;
            LastUpdateCrawl = DateTime.Now;

            foreach (KeyValuePair<string, Host> entry in HostCache.Hosts)
            {
                GenerateIndex(entry.Value.HostID, searchDate);
            }

            DateTime finishIndexTime = DateTime.Now;
            TimeSpan indexDuration = finishIndexTime.Subtract(startIndexTime);
            Log.InfoFormat("Completed indexing of all hosts, time taken: {0} mins {1} secs", 
                            indexDuration.Minutes, 
                            indexDuration.Seconds);

            isUpdateRunning = false;
        }


        /// <summary>
        /// Creates/Updates the index for a given host. If the index already exists then we'll update it other
        /// wise we create a new index for the host. Each host index is store in its own folder off the base directory.
        /// </summary>
        /// <param name="hostId"></param>
        private void GenerateIndex(int hostId, DateTime lastUpdateTime)
        {
            Log.InfoFormat("Starting index generation for HostID: {0}", hostId);
            
            IndexModifier modifier = null;            
            bool isIncrementalCrawl = false;
            int storiesToIndexCount = 0;
            int pageSize;

            try
            {
                bool indexExists = IndexExists(hostId);

                StoryCollection stories = null;

                if (!indexExists)
                {
                    //the index doesnt exist so we are going to do a full index of
                    //all stories in the database
                    Log.InfoFormat("Creating a new index HostID: {0}", hostId);

                    isIncrementalCrawl = false;
                    storiesToIndexCount = Story.GetAllStoriesCount(hostId);                    
                }
                else
                {
                    if (!HostCrawlSuccessful(hostId))
                    {
                        //force the last update time to a low value to get all the records
                        //since we need to recrawl the index fully
                        lastUpdateTime = DateTime.Parse("1/1/1975");
                        Log.InfoFormat("Last crawl didnt complete successfully, attempting a full crawl");
                    }
                    else
                        Log.InfoFormat("Updating existing index");

                    isIncrementalCrawl = true;
                    storiesToIndexCount = Story.GetUpdatedStoriesCount(hostId, lastUpdateTime);
                }


                if (storiesToIndexCount == 0)
                {
                    Log.InfoFormat("Nothing todo, no new stories to crawl for HostID: {0}", hostId);
                    isUpdateRunning = false;
                    return;
                }


                modifier = new IndexModifier(IndexHostPath(hostId), new DnkAnalyzer(), !indexExists);
                modifier.SetMaxBufferedDocs(50);
                modifier.SetMergeFactor(150);

                SearchSettings searchSettings = new SearchSettings();
                pageSize = searchSettings.StoriesPageSize;

                int pageTotal = CalculateNumberOfPages(storiesToIndexCount, pageSize);
                for (int i = 1; i <= pageTotal; i++)
                {
                    if (isIncrementalCrawl)
                        stories = Story.GetUpdatedStories(hostId, lastUpdateTime, i, pageSize);
                    else
                        stories = Story.GetAllStories(hostId, i, pageSize);

                    AddStoriesToIndex(modifier, isIncrementalCrawl, stories);
                }

                modifier.Optimize();
                Log.InfoFormat("index optimized for HostID:{0}", hostId);

                modifier.Close();
                Log.InfoFormat("Index Modifier closed for Host:{0}", hostId);

                modifier = null;

                //we completed ok
                RecordHostCrawlSuccess(hostId, true);
            }
            catch (Exception ex)
            {
                RecordHostCrawlSuccess(hostId, false);
                Log.ErrorFormat("Error occurred while adding items to the index HostID:{0}, message: {1}",hostId, ex.Message);
            }
            finally
            {
                //attempt to close the modifier if it still exists
                if (modifier != null)
                {
                    try
                    {
                        modifier.Close();
                        modifier = null;
                        Log.InfoFormat("Able to close the Index Modifier in the final block, HostID:{0}", hostId);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("Unable to close the modifer in the final block HostID:{0} Message:{1}", hostId, ex.Message);
                    }
                }
            }
        }


        /// <summary>
        /// Loops thro a list of stories and adds them to the index. If the crawl is an incremental
        /// update then first the story is removed then added again.
        /// </summary>
        /// <param name="modifier">IndexModifer used to update the index</param>
        /// <param name="isIncrementalCrawl">bool indicating if the stories should
        /// be removed from the existing index before being added again.</param>
        /// <param name="stories">StoryCollection containing the stories to add/update
        /// in the index</param>
        private void AddStoriesToIndex(IndexModifier modifier, bool isIncrementalCrawl, StoryCollection stories)
        {
            if (isIncrementalCrawl)
            {

                //remove the stories from the index that have been updated
                Log.DebugFormat("Updating index, removing {0} stories", stories.Count);
                foreach (Story s in stories)
                {
                    Term existingItem = new Term("id", s.StoryID.ToString());
                    int j = modifier.DeleteDocuments(existingItem);
                }
            }


            //add the new documents
            Log.DebugFormat("Adding batch of {0} stories to the index", stories.Count);
            foreach (Story story in stories)
            {
                //spam stories shouldnt be added to the index
                if (story.IsSpam)
                    continue;

                Document doc = new Document();

                doc.Add(new Field("url", story.Url, Field.Store.NO, Field.Index.TOKENIZED));
                doc.Add(new Field("title", story.Title, Field.Store.NO, Field.Index.TOKENIZED));
                doc.Add(new Field("description", story.Description, Field.Store.NO, Field.Index.TOKENIZED));
                doc.Add(new Field("users", GetUserWhoKickedSearchString(story), Field.Store.NO, Field.Index.TOKENIZED));
                doc.Add(new Field("category", story.Category.Name, Field.Store.NO, Field.Index.TOKENIZED));
                doc.Add(new Field("tags", GetStoryTags(story), Field.Store.NO, Field.Index.TOKENIZED));
                doc.Add(new Field("id", story.StoryID.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));

                modifier.AddDocument(doc);
                Log.DebugFormat("StoryId {0} added to index", story.StoryID);
            }
        }


        /// <summary>
        /// Calculates the number of pages required to page completely thro' the total
        /// number of records
        /// </summary>
        /// <param name="totalRecords">total number of records</param>
        /// <param name="pageSize">size of the page, i.e. the number of
        /// records returned on a single page</param>
        /// <returns>number of pages required to display all records</returns>
        private int CalculateNumberOfPages(int totalRecords, int pageSize)
        {
            if (totalRecords > 0)
                return (totalRecords / pageSize) + 1;
            return 0;
        }


        /// <summary>
        /// Returns a string containing the tags for a given story, seperated
        /// by a space
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        private string GetStoryTags(Story story)
        {
            TagCollection tags = Tag.FetchStoryTags(story.StoryID);
            StringBuilder sb = new StringBuilder();

            foreach (Tag tag in tags)
            {
                sb.Append(tag.TagIdentifier);
                sb.Append(' ');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns a string containing the usernames of users
        /// that kicked the story. The usernames are seperated
        /// by a space
        /// </summary>
        /// <param name="story">story to return the usernames for</param>
        /// <returns>string containing the usernames of users that kicked
        /// the story</returns>
        private string GetUserWhoKickedSearchString(Story story)
        {

            //dont use the cache since this maybe stale, we need
            //to get the data directly from the database otherwise 
            //index wont be as fresh as could be, plus we could just 
            //bloat the cache with the crawl
            UserCollection users = story.UsersWhoKicked;
            StringBuilder sb = new StringBuilder();

            foreach (User u in users)
            {
                sb.Append(u.Username);
                sb.Append(' ');
            }

            return sb.ToString();
        }



        /// <summary>
        /// Determines if the index already exists for the host
        /// </summary>
        /// <param name="hostID">HostID of the index to check</param>
        /// <returns></returns>
        private bool IndexExists(int hostId)
        {
            //first check the folder exists, if not just create it
            string hostIndexPath = IndexHostPath(hostId);

            if (!Directory.Exists(hostIndexPath))
                Directory.CreateDirectory(hostIndexPath);

            return IndexReader.IndexExists(hostIndexPath);
        }


        /// <summary>
        /// Read only property determining if the search update
        /// is currently running
        /// </summary>
        internal bool IsUpdateRunning
        {
            get
            {
                return isUpdateRunning;
            }
        }


        /// <summary>
        /// Returns the index path of the index for a 
        /// given host. The path returned will be
        /// absolute
        /// </summary>
        /// <param name="hostID"></param>
        /// <returns></returns>
        internal string IndexHostPath(int hostId)
        {
            return Path.Combine(indexBasePath, string.Format("HostID_{0}", hostId));
        }


        /// <summary>
        /// Get/set the last time the database was crawled for new/modified stories.
        /// </summary>
        private DateTime LastUpdateCrawl
        {
            get
            {
                //check if the local var has a value
                if (lastUpdate > DateTime.MinValue)
                    return lastUpdate;
                else
                {
                    SearchSettings searchSettings = new SearchSettings();
                    return searchSettings.SearchLastCrawl;
                }
            }

            set
            {
                //sort the value in a local static and also
                //to the database in case the app get recycled
                SearchSettings searchSettings = new SearchSettings();
                searchSettings.SearchLastCrawl = value;
                lastUpdate = value;
            }
        }


        /// <summary>
        /// Determine if the last crawl for host completed successfully
        /// </summary>
        /// <param name="hostId"></param>
        /// <returns></returns>
        private bool HostCrawlSuccessful(int hostId)
        {
            if (hostCrawlError.ContainsKey(hostId))
                return hostCrawlError[hostId];
            else
                return true;

        }


        /// <summary>
        /// Stores the last crawl success/failure result for a 
        /// given host
        /// </summary>
        /// <param name="hostId"></param>
        /// <param name="success"></param>
        private void RecordHostCrawlSuccess(int hostId, bool success)
        {
            if (hostCrawlError.ContainsKey(hostId))
                hostCrawlError[hostId] = success;
            else
                hostCrawlError.Add(hostId, success);
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //managed code clean up

                    //kill the timer
                    if (updateTimer != null)
                    {
                        Log.Debug("timer dispose called");
                        updateTimer.Dispose();
                    }
                }

                //unmanaged code clean up
                //nothing todo here

                disposed = true;
            }
        }

        ~SearchUpdate()
        {
            Dispose(false);
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
