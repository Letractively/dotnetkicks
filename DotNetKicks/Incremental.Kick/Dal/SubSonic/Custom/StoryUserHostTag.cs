using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Dal {
    public partial class StoryUserHostTag {
        public static void Destroy(int storyID, int userID, int hostID, int tagID) {
            //NOTE: GJ: there is most likely a much better way of doing this with subsonic
            Query query = new Query(StoryUserHostTag.Schema).WHERE(StoryUserHostTag.Columns.StoryID, storyID).AND(StoryUserHostTag.Columns.UserID, userID).AND(StoryUserHostTag.Columns.HostID, hostID).AND(StoryUserHostTag.Columns.TagID, tagID);
            StoryUserHostTag storyUserHostTag = new StoryUserHostTag();
            storyUserHostTag.LoadAndCloseReader(StoryUserHostTag.FetchByQuery(query));
            StoryUserHostTag.Destroy(storyUserHostTag.StoryUserHostTagID);

            //update the story for the next crawl to pickup the change
            Story story = Story.FetchByID(storyID);
            story.UpdatedOn = DateTime.Now;
            story.Save();
        }
    }
}
