using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Security;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Caching {
    public class UserCache {
        public static User GetUser(string securityToken) {
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
        private static User GetUser(int userID) {
            CacheManager<string, User> userCache = GetUserCache();
            string cacheKey = GetUserProfileCacheKey(userID);
            User user = userCache[cacheKey];

            lock (_getUserLock) {
                if (user == null) {
                    if (userID == 0) {
                        user = new User(0);
                        user.Username = "Anonymous";
                    } else {
                        user = User.FetchByID(userID);
                    }
                    System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                    userCache.Insert(cacheKey, user, CacheHelper.CACHE_DURATION_IN_SECONDS);
                }
            }

            return user;
        }


        public static int GetUserID(string username) {
            CacheManager<string, int?> userIDCache = GetUserIDCache();
            string cacheKey = "GetUserID_" + username;

            int? userID = userIDCache[cacheKey];
            if (!userID.HasValue) {
                userID = User.FetchUserByUsername(username).UserID;
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                userIDCache.Insert(cacheKey, userID, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return userID.Value;
        }

        public static void RemoveUser(string securityToken) {
            GetUserCache().Remove(GetUserProfileCacheKey(SecurityToken.FromString(securityToken).UserID));
        }

        private static string GetUserProfileCacheKey() {
            return "UserProfile_Anonymous";
        }

        private static string GetUserProfileCacheKey(int userID) {
            return "UserProfile_" + userID;
        }

        //TODO: GJ: some improvements are needed here - a sproc would be better
        public static int KickStory(int storyID, int userID, int hostID) {
            if (StoryBR.DoesStoryKickNotExist(storyID, userID, hostID)) {
                StoryKick storyKick = StoryBR.AddStoryKick(storyID, userID, hostID);
                GetUserStoryKicks(userID).Add(storyKick);
                //increment the story kick count in the db (could be a db trigger?)
                return StoryBR.IncrementKickCount(storyID);
            } else {
                return 0; //NOTE: GJ: not very elegant, will revisit later
            }
        }

        public static int UnKickStory(int storyID, int userID, int hostID) {
            if (StoryBR.DoesStoryKickExist(storyID, userID, hostID)) {
                StoryBR.DeleteStoryKick(storyID, userID, hostID);
                RemoveStoryKick(storyID, userID, hostID);
                return StoryBR.DecrementKickCount(storyID);
            } else {
                return 0;
            }
        }

        public static bool HasUserKickedStory(int storyID, int userID) {
            //PERF: there will be performance benefits if we use a hashtable here
            foreach (StoryKick storyKick in GetUserStoryKicks(userID)) {
                if (storyID == storyKick.StoryID)
                    return true;
            }

            return false;
        }

        public static void RemoveStoryKick(int storyID, int userID, int hostID) {
            //PERF: there will be performance benefits if we use a hashtable here
            StoryKickCollection storyKicks = GetUserStoryKicks(userID);
            foreach (StoryKick storyKick in storyKicks) {
                if (storyID == storyKick.StoryID) {
                    storyKicks.Remove(storyKick);
                    return;
                }
            }
        }

        public static StoryKickCollection GetUserStoryKicks(int userID) {
            string cacheKey = String.Format("Kick_StoryKickTable_{0}", userID);

            CacheManager<string, StoryKickCollection> storyKickCache = GetStoryKickCache();

            StoryKickCollection storyKicks = storyKickCache[cacheKey];

            if (storyKicks == null) {
                //TODO: get the latest n kicks for this userIdentifier
                storyKicks = StoryKick.FetchByUserID(userID);
                System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                storyKickCache.Insert(cacheKey, storyKicks, CacheHelper.CACHE_DURATION_IN_SECONDS);
            }

            return storyKicks;
        }
        
        private static CacheManager<string, StoryKickCollection> GetStoryKickCache() {
            return CacheManager<string, StoryKickCollection>.GetInstance();
        }

        private static CacheManager<string, User> GetUserCache() {
            return CacheManager<string, User>.GetInstance();
        }

        private static CacheManager<string, int?> GetUserIDCache() {
            return CacheManager<string, int?>.GetInstance();
        }
    }
}
