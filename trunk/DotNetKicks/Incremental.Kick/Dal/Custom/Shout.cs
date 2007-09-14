using System;
using SubSonic;

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
    }
}