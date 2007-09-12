using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.BusinessLogic.Maintenance {
    public class DataUpdater {
        public static void UpdateCommentsHostIDs() {
            //This iterates through each comment, updating its HostID (host id was added in SVN revision 226
            //NOTE: GJ: This will not perform well if there are thousands of comments
            CommentCollection comments = new CommentCollection();
            comments.Load(Comment.FetchAll());
            foreach (Comment comment in comments) {
                comment.HostID = comment.Story.HostID;
                comment.Save();
            }
        }
    }
}
