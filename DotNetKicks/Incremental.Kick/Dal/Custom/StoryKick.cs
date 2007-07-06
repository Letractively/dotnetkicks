using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Common.Enums;
using SubSonic;

namespace Incremental.Kick.Dal {
    public partial class StoryKick {
        public static void Destroy(int storyID, int userID, int hostID) {
            //NOTE: GJ: there is most likely a much better way of doing this with subsonic
            Query query = new Query(StoryKick.Schema).WHERE(StoryKick.Columns.StoryID, storyID).AND(StoryKick.Columns.UserID, userID).AND(StoryKick.Columns.HostID, hostID);
            StoryKick storyKick = new StoryKick();
            storyKick.LoadAndCloseReader(StoryKick.FetchByQuery(query));
            StoryKick.Destroy(storyKick.StoryKickID);
        }

        public static StoryKickCollection FetchByUserID(int userID) {
            StoryKickCollection storyKicks = new StoryKickCollection();
            storyKicks.LoadAndCloseReader(StoryKick.FetchByParameter(StoryKick.Columns.UserID, userID));
            return storyKicks;
        }
    }
}
