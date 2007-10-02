using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.Dal.Entities.Api;

namespace Incremental.Kick.Caching {
    public class ChatCache {

        // Returns a list of shouts for a chat since a particular lastReceivedShoutID
        public static List<ApiShout> GetChatShoutDelta(int chatID, int lastReceivedShoutID) {
            return GetChatShoutDelta(chatID, lastReceivedShoutID, null);
        }
        public static List<ApiShout> GetChatShoutDelta(int chatID, int lastReceivedShoutID, int? userID) {
            //TODO: GJ: refactor some of this into the ShoutCache so that it can be used everywhere
            ApiChat apiChat = GetChat(chatID);
            List<ApiShout> deltaShouts = new List<ApiShout>();
            
            if (apiChat.Shouts[0].ShoutID > lastReceivedShoutID) {
                foreach (ApiShout apiShout in apiChat.Shouts) {
                    if (apiShout.ShoutID > lastReceivedShoutID)
                        deltaShouts.Add(apiShout);
                }
            }

            if (userID.HasValue) { }
            //TODO: GJ: update the last active time stamp for this user in this chat
               
            return deltaShouts;
        }

        public static ApiChat GetChat(int chatID) {
            string cacheKey = GetCacheKey(chatID);

            CacheManager<string, ApiChat> cache = GetCache();

            ApiChat chat = cache[cacheKey];
            if (chat == null) {
                chat = Chat.FetchByID(chatID).ToApi(true);
                cache.Insert(cacheKey, chat, 60, System.Web.Caching.CacheItemPriority.NotRemovable);
            }

            return chat;
        }


        private static string GetCacheKey(int chatID) {
            return String.Format("Chat_{0}", chatID);
        }
        private static CacheManager<string, ApiChat> GetCache() {
            return CacheManager<string, ApiChat>.GetInstance();
        }
    }
}