using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching {
    public class SettingsCache {
        
        public static string GetSetting(string name) {
            if (Settings.ContainsKey(name))
                return Settings[name].ValueX;
            else
                throw new ArgumentException("Invalid Setting name : " + name);
        }

        /// <summary>
        /// Gets the setting from the database with the given key. If the key
        /// does not exist then the defaultValue will be returned.
        /// </summary>
        /// <param name="name">key name of the value to return from the
        /// database</param>
        /// <param name="defaultValue">default value to return if the key doesnt exist in
        /// the database</param>
        /// <returns>string value for the key</returns>
        public static string GetSetting(string name, string defaultValue)
        {
            return GetSetting(name, defaultValue, false);
        }

        /// <summary>
        /// Gets the setting from the database for the given key. If the key does
        /// not exit then the default value will be returned. If the key does not exist
        /// then when persistToDatabase is true the default value will be save to database.
        /// </summary>
        /// <remarks>This method provides useful way to add new values to the settings table
        /// when first accessing a key which does not already exist</remarks>
        /// <param name="name">key name of the value to return from the
        /// database</param>
        /// <param name="defaultValue">default value to return if the key doesnt exist in
        /// the database</param>
        /// <param name="persistToDatabase">indicates if the key does not already exist
        /// then the default value should be stored in the database</param>
        /// <returns>string value for the key</returns>
        public static string GetSetting(string name, string defaultValue, bool persistToDatabase)
        {
            if (Settings.ContainsKey(name))
                return Settings[name].ValueX;
            else
            {
                if (persistToDatabase)
                {
                    //todo: store the value
                    Setting newSetting = new Setting();
                    newSetting.Name = name;
                    newSetting.ValueX = defaultValue;
                    newSetting.Save();

                    //force a reload of the cache on the next request
                    ClearSettingsCache();
                }

                return defaultValue;
            }
               
        }

        /// <summary>
        /// Clears the settings cache
        /// </summary>
        /// <remarks>Used when adding/updating a setting to force a reload the next
        /// the cache is accessed</remarks>
        private static void ClearSettingsCache()
        {
            CacheManager<string, Dictionary<string, Setting>> cache = GetSettingCache();
            string cacheKey = "Settings";
            cache.Remove(cacheKey);
        }

        public static Dictionary<string, Setting> Settings {
            get {
                CacheManager<string, Dictionary<string, Setting>> cache = GetSettingCache();
                string cacheKey = "Settings";
                Dictionary<string, Setting> settingDictionary = cache[cacheKey];

                if (settingDictionary == null) {
                    settingDictionary = new Dictionary<string, Setting>();
                    SettingCollection settings = new SettingCollection();
                    settings.LoadAndCloseReader(Setting.FetchAll());

                    foreach (Setting setting in settings) {
                        settingDictionary.Add(setting.Name, setting);
                    }

                    cache.Insert(cacheKey, settingDictionary, CacheHelper.CACHE_DURATION_IN_SECONDS, System.Web.Caching.CacheItemPriority.NotRemovable);
                }

                return settingDictionary;
            }
        }

        private static CacheManager<string, Dictionary<string, Setting>> GetSettingCache() {
            return CacheManager<string, Dictionary<string, Setting>>.GetInstance();
        }
    }
}
