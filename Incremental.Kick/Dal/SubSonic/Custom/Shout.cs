using System;
using SubSonic;
using Incremental.Kick.Caching;
using System.Web;
using Incremental.Kick.Helpers;
using Incremental.Kick.Dal.Entities.Api;

namespace Incremental.Kick.Dal {
    public partial class Shout {
        public static ShoutCollection GetPage(int hostID, int? toUserID, int? chatID, int pageIndex, int pageSize) {
            Query query = new Query(Shout.Schema).WHERE(Shout.Columns.HostID, hostID).ORDER_BY(Shout.Columns.CreatedOn, "DESC");
            if (toUserID.HasValue)
                query = query.WHERE(Shout.Columns.ToUserID, toUserID.Value);
            else
                query = query.WHERE(Shout.Columns.ToUserID, Comparison.Is, null);

            if (chatID.HasValue)
                query = query.WHERE(Shout.Columns.ChatID, chatID.Value);
            else
                query = query.WHERE(Shout.Columns.ChatID, Comparison.Is, null);

            query.PageIndex = pageIndex;
            query.PageSize = pageSize;

            ShoutCollection shouts = new ShoutCollection();
            shouts.Load(query.ExecuteReader());
            return shouts;
        }

        public static void AddShout(User fromUser, int hostID, string message) {
            AddShout(fromUser, hostID, message, null, null);
        }

        public static void AddShout(User fromUser, int hostID, string message, string toUsername, int? chatID) {
            if (!String.IsNullOrEmpty(message) && (!fromUser.IsBanned)) {
                Shout shout = new Shout();
                shout.HostID = hostID;
                shout.Message = TextHelper.EncodeAndReplaceComment(message);
                shout.FromUserID = fromUser.UserID;

                User toUser = null;
                if (!string.IsNullOrEmpty(toUsername)) {
                    toUser = UserCache.GetUserByUsername(toUsername);
                    shout.ToUserID = toUser.UserID;
                }

                if (chatID.HasValue)
                    shout.ChatID = chatID;

                shout.Save();

                if (!chatID.HasValue) {
                    if (toUser == null)
                        UserAction.RecordShout(hostID, fromUser);
                    else
                        UserAction.RecordShout(hostID, fromUser, toUser);
                }

                ShoutCache.Remove(hostID, shout.ToUserID, chatID);
            }
        }

        public ApiShout ToApi(Host host) {
            //NOTE: GJ: PERFORMANCE: should we be hitting the cache here, we could defer until later and just add the id here
            return new ApiShout(this.ShoutID, UserCache.GetUser(this.FromUserID).ToApi(host), this.Message, this.CreatedOn);
        }
    }
}