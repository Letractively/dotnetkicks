using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.BusinessLogic {
    //NOTE: GJ: at some point I will be moving much of this logic into the SubSonic models
    public class StoryKickBR {
        public static StoryKickCollection KickStory(int storyID, int userID, int hostID) {
            //TODO: (GJ) we could score some performance goodness here if we move this logic to the database. (triggers or sp?)

            //Kick_StoryKickDataSet storyKickDS = new Kick_StoryKickDataSet();
            //Kick_StoryKickRow storyKick = storyKickDS.Kick_StoryKick.NewKick_StoryKickRow();
            //storyKick.StoryKickID = -1;
            //storyKick.StoryID = storyID;
            //storyKick.UserID = userID;
            //storyKick.HostID = hostID;
            //storyKick.CreatedDateTime = DateTime.Now;

            //storyKickDS.Kick_StoryKick.AddRow(storyKick);
            //storyKickDS = new Kick_StoryKickBR().Persist(storyKickDS);

            //return storyKickDS.Kick_StoryKick;
            return new StoryKickCollection();
        }

        public static void UnKickStory(int storyID, int userID, int hostID) {
            //StoryKick.Delete(storyID, userID, hostID);
        }

        internal static StoryKickCollection GetAllByUserID(int userID) {
            return new StoryKickCollection(); //TODO: GJ: implement
        }
    }
}
