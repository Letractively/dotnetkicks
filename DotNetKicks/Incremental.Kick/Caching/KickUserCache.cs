using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Security;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Caching
{
    public class KickUserCache
    {
        public static KickUser GetUser(string securityToken)
        {
            int? userID = null;

            if (!String.IsNullOrEmpty(securityToken))
                userID = SecurityToken.FromString(securityToken).UserID;

            KickUser user;
            if (userID.HasValue)
                user = GetUser(userID.Value);
            else
                user = GetUser(0);

            return user;
        }

        private static object _getUserLock = new object();
        private static KickUser GetUser(int userID)
        {
            CacheManager<string, KickUser> userCache = GetUserCache();
            string cacheKey = GetUserProfileCacheKey(userID);
            KickUser user = userCache[cacheKey];

            lock (_getUserLock)
            {
                if (user == null)
                {
                    user = KickUser.FetchByID(userID);
                    System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                    userCache.Insert(cacheKey, user, 500); //TODO: GJ: config
                }
            }

            return user;
        }


        public static int GetUserID(string username)
        {
            CacheManager<string, int?> userIDCache = GetUserIDCache();
            string cacheKey = "GetUserID_" + username;

            int? userID = userIDCache[cacheKey];
            if (!userID.HasValue)
            {
                userID = KickUser.FetchUserByUsername(username).UserID;
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                userIDCache.Insert(cacheKey, userID, 500); //TODO: Config
            }

            return userID.Value;
        }
        
        public static void RemoveUser(string securityToken)
        {
            GetUserCache().Remove(GetUserProfileCacheKey(SecurityToken.FromString(securityToken).UserID));
        }

        private static string GetUserProfileCacheKey()
        {
            return "UserProfile_Anonymous";
        }

        private static string GetUserProfileCacheKey(int userID)
        {
            return "UserProfile_" + userID;
        }

        //TODO: GJ: some major improvements are needed here.
        public static int KickStory(int storyID, int userID, int hostID)
        {
            //TODO: GJ: implement
            KickStoryKick storyKick = KickStoryBR.AddStoryKick(storyID, userID, hostID);
    
                //merge with the cache
              /*  GetUserStoryKicks(userID).Merge(storyKickTable);
                 

                //increment the story kick count in the db (could be a db trigger?)
                Kick_StoryDataSet storyDS = new Kick_StoryBR().GetByStoryID(storyID);
                storyDS.Kick_Story[0].KickCount++;
                new Kick_StoryBR().Persist(storyDS);

                return storyDS.Kick_Story[0].KickCount; */
            return 999;
          
        }

        public static int UnKickStory(int storyID, int userID, int hostID)
        {
            //TODO: GJ: implement
            KickStoryBR.DeleteStoryKick(storyID, userID, hostID);
            /*

                //now remove from the cache
                RemoveStoryKick(storyID, userID, hostID);

                //decrement the story kick count in the db (could be a trigger?)
                Kick_StoryDataSet storyDS = new Kick_StoryBR().GetByStoryID(storyID);
                storyDS.Kick_Story[0].KickCount--;
                new Kick_StoryBR().Persist(storyDS);

                return storyDS.Kick_Story[0].KickCount;
            */
            return 999;
        }

        public static bool HasUserKickedStory(int storyID, int userID)
        {
            //PERF: there will be huge performance benefits if we use a hashtable here
            /*Kick_StoryKickTable storyKickTable = GetUserStoryKicks(userID);

            foreach (Kick_StoryKickRow storyKick in storyKickTable)
            {
                if (storyID == storyKick.StoryID)
                    return true;
            }*/

            return false;
        }

        public static void RemoveStoryKick(int storyID, int userID, int hostID)
        {
           /* Kick_StoryKickTable storyKickTable = GetUserStoryKicks(userID);
            Kick_StoryKickRow storyKick = storyKickTable.GetRowByID(storyID, userID, hostID);
            try
            {
                storyKick.Delete();
                storyKickTable.AcceptChanges();
            }
            catch { }*/
        }

       /* public static Kick_StoryKickTable GetUserStoryKicks(int userID)
        {
            string cacheKey = String.Format("Kick_StoryKickTable_{0}", userID);

            CacheManager<string, Kick_StoryKickTable> storyKickCache = GetStoryKickCache();

            Kick_StoryKickTable storyKickTable = storyKickCache[cacheKey];

            if (storyKickTable == null)
            {
                //TODO: get the latest n kicks for this userIdentifier
                storyKickTable = new Kick_StoryKickBR().GetAllByUserID(userID).Kick_StoryKick;
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                storyKickCache.Insert(cacheKey, storyKickTable, WebUIConfigReader.GetConfig().CategoryStoryListCacheDurationInSeconds);
            }

            return storyKickTable;
        }*/



        /*private static CacheManager<string, Kick_StoryKickTable> GetStoryKickCache()
        {
            return CacheManager<string, Kick_StoryKickTable>.GetInstance();
        }*/

        private static CacheManager<string, KickUser> GetUserCache()
        {
            return CacheManager<string, KickUser>.GetInstance();
        }

        private static CacheManager<string, int?> GetUserIDCache()
        {
            return CacheManager<string, int?>.GetInstance();
        }
    }
}
