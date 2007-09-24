using System;
using SubSonic;
using Incremental.Kick.Caching;
using System.Web;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.Dal {
    public partial class Shout {
        public static ShoutCollection GetPage(int hostID, int? toUserID, int pageIndex, int pageSize) {
            Query query = new Query(Shout.Schema).WHERE(Shout.Columns.HostID, hostID).ORDER_BY(Shout.Columns.CreatedOn, "DESC");
            if (toUserID.HasValue)
                query = query.WHERE(Shout.Columns.ToUserID, toUserID.Value);
            else
                query = query.WHERE(Shout.Columns.ToUserID, Comparison.Is, null);

            query.PageIndex = pageIndex;
            query.PageSize = pageSize;

            ShoutCollection shouts = new ShoutCollection();
            shouts.Load(query.ExecuteReader());
            return shouts;
        }

        public static void AddShout(User fromUser, int hostID, string message) {
            AddShout(fromUser, hostID, message, null);
        }

        public static void AddShout(User fromUser, int hostID, string message, string toUsername) {
            if (!String.IsNullOrEmpty(message) && (!fromUser.IsBanned)) {
                Shout shout = new Shout();
                shout.HostID = hostID;
                //TODO:GJ: move replace rules to helper
                message = HttpUtility.HtmlEncode(message);
                message = TextHelper.Urlify(message);
                shout.Message = message.Replace("\n", "<br/>");
                shout.FromUserID = fromUser.UserID;

                User toUser = null;
                if (!string.IsNullOrEmpty(toUsername)) {
                    toUser = UserCache.GetUserByUsername(toUsername);
                    shout.ToUserID = toUser.UserID;
                }

                shout.Save();
                
                if (toUser == null) {
                    UserAction.RecordShout(hostID, fromUser);
                    ShoutCache.Remove(hostID);
                } else {
                    UserAction.RecordShout(hostID, fromUser, toUser);
                    ShoutCache.Remove(hostID, toUsername);
                }
            }
        }
    }
}