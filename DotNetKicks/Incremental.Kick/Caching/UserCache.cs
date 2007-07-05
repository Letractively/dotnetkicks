using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Security;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Caching
{
    public class UserCache
    {
        public static User GetUser(string securityToken)
        {
            int? userID = null;

            if (!String.IsNullOrEmpty(securityToken))
                userID = SecurityToken.FromString(securityToken).UserID;

            User user;
            if (userID.HasValue)
                user = GetUser(userID.Value);
            else
                user = GetUser(0);

            return user;
        }

        private static object _getUserLock = new object();
        private static User GetUser(int userID)
        {
            CacheManager<string, User> userCache = GetUserCache();
            string cacheKey = GetUserProfileCacheKey(userID);
            User user = userCache[cacheKey];

            lock (_getUserLock)
            {
                if (user == null)
                {
                    if (userID == 0) {
                        //TODO: GJ: construct an anonymous user object
                        user = new User(0);
                        user.Username = "Anonymous";
                    } else {
                        user = User.FetchByID(userID);
                    }
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
                userID = User.FetchUserByUsername(username).UserID;
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
            ////TODO: GJ: implement
            //StoryKick storyKick = StoryBR.AddStoryKick(storyID, userID, hostID);
    
            //    //merge with the cache
            //    GetUserStoryKicks(userID).Merge(storyKickTable);
                 

            //    //increment the story kick count in the db (could be a db trigger?)
            //    Kick_StoryDataSet storyDS = new Kick_StoryBR().GetByStoryID(storyID);
            //    storyDS.Kick_Story[0].KickCount++;
            //    new Kick_StoryBR().Persist(storyDS);

            //    return storyDS.Kick_Story[0].KickCount; 
            return 999;
          
        }

        public static int UnKickStory(int storyID, int userID, int hostID)
        {
            //TODO: GJ: implement
            StoryBR.DeleteStoryKick(storyID, userID, hostID);
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

        public static StoryKickCollection GetUserStoryKicks(int userID)
        {
            string cacheKey = String.Format("Kick_StoryKickTable_{0}", userID);

            CacheManager<string, StoryKickCollection> storyKickCache = GetStoryKickCache();

            StoryKickCollection storyKicks = storyKickCache[cacheKey];

            if (storyKicks == null)
            {
                //TODO: get the latest n kicks for this userIdentifier
                storyKicks = StoryKickBR.GetAllByUserID(userID);
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                storyKickCache.Insert(cacheKey, storyKicks, 500); //TODO: GJ: config
            }

            return storyKicks;
        }



        private static CacheManager<string, StoryKickCollection> GetStoryKickCache()
        {
            return CacheManager<string, StoryKickCollection>.GetInstance();
        }

        private static CacheManager<string, User> GetUserCache()
        {
            return CacheManager<string, User>.GetInstance();
        }

        private static CacheManager<string, int?> GetUserIDCache()
        {
            return CacheManager<string, int?>.GetInstance();
        }
    }
}
