using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Controls.Admin {
    public partial class Tasks : Incremental.Kick.Web.Controls.KickUserControl {
        protected void Page_Load(object sender, EventArgs e) {
           this.KickPage.DemandAdministratorRole();
        }

        protected void RunStoryPublisher_Click(object sender, EventArgs e) {
            StoryBR.PublishStoryProcess();
        }

        protected void UpdateStoryKickCounts_Click(object sender, EventArgs e) {
            //NOTE: GJ: a little hackery here - kicks are currently not under a transaction so when something goes wrong, the kick count can get out of sync.
            //Iterate thru each story and update its kick count based on the number of kicks it has received
            IDataReader dataReader = Incremental.Kick.Dal.Story.FetchAll();
            while (dataReader.Read()) {
                int storyID = dataReader.GetInt32(0);
                Incremental.Kick.Dal.Story story = Incremental.Kick.Dal.Story.FetchByID(storyID);
                System.Diagnostics.Trace.WriteLine(String.Format("Updading {0} to {1}", story.KickCount, story.StoryKickRecords().Count));
                story.KickCount = story.StoryKickRecords().Count;
                story.Save();
            }
        }
    }
}