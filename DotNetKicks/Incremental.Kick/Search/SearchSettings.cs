using System;
using System.Collections.Generic;
using System.Text;

using Incremental.Kick.Dal;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Search
{
    /// <summary>
    /// Class to expose the settings for the search
    /// </summary>
    public class SearchSettings
    {
        const string LUCENE_INDEX_DIRECTORY_SETTING = "Search.Lucene.BaseDirectory";
        const string LUCENE_LAST_CRAWL_SETTING = "Search.Lucene.LastCrawl";
        const string LUCENE_UPDATE_INTERVAL_SETTING = "Search.Lucene.ReindexInterval";
        const string LUCENE_STORIES_PAGE_SIZE_SETTING = "Search.Lucene.StoriesPageSize";

        /// <summary>
        /// Read only property to return the base directory of the
        /// lucene search index. If this key does not exist in the
        /// settings table throws an ArgumentException
        /// </summary>
        /// <remarks>The file path return will be a relative value</remarks>
        public string SearchBaseDirectory
        {
            get { return SettingsCache.GetSetting(LUCENE_INDEX_DIRECTORY_SETTING); }
        }

        /// <summary>
        /// Get/set the DateTime the last crawl took place. This value is persisted to
        /// the settings table.
        /// </summary>
        public DateTime SearchLastCrawl
        {
            get
            {
                //default date of 1/1/1975 to use if not already in settings
                string lastCrawl = SettingsCache.GetSetting(LUCENE_LAST_CRAWL_SETTING, "622933632000000000"); 
                return new DateTime(long.Parse(lastCrawl));
            }
            set 
            {
                //maybe worthwhile adding a method to Setting class that will
                //add or update a key value pair, since this code will just
                //duplicated in the code base

                SettingCollection settings = new SettingCollection();
                settings.LoadAndCloseReader(Setting.FetchByParameter("Name", LUCENE_LAST_CRAWL_SETTING));
                if (settings.Count == 0)
                {
                    //key doesnt exist, so add it
                    Setting lastUpdateSetting = new Setting();
                    lastUpdateSetting.Name = LUCENE_LAST_CRAWL_SETTING;
                    lastUpdateSetting.ValueX = value.Ticks.ToString();
                    lastUpdateSetting.Save();
                }
                else
                {
                    //key already exists, update value
                    settings[0].ValueX = value.Ticks.ToString();
                    settings[0].Save();
                }
            }

        }

        /// <summary>
        /// Gets the timer interval in minutes used to check for new/updated stories
        /// </summary>
        /// <remarks>If this value doesnt exist within the settings table we'll add a default
        /// value of every 10 minutes</remarks>
        public int SearchUpdateInterval
        {
            get 
            {
                string crawlInterval = SettingsCache.GetSetting(LUCENE_UPDATE_INTERVAL_SETTING, "10", true);
                return Int32.Parse(crawlInterval);
            }
        }

        /// <summary>
        /// Gets the number of stories to return in a collection when adding/updating in the index. 
        /// Allows for paged access to the stories
        /// </summary>
        /// <remarks>If this value doesnt exist within the settings table we'll add a default of
        /// 100 stories per page</remarks>
        public int StoriesPageSize
        {
            get 
            {
                string storiesPerPage = SettingsCache.GetSetting(LUCENE_STORIES_PAGE_SIZE_SETTING, "100", true);
                return Int32.Parse(storiesPerPage);
            }
        }
    }
}
