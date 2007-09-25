using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal {
    public partial class StoryCollection {

        public Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList ToDto() {
            Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList storieDtos = new Incremental.Kick.Dal.Entities.DataTransferObjects.StoryList();

            foreach (Story s in this) {
                storieDtos.Stories.Add(s.ToDto());
            }
            return storieDtos;
        }
    }
}
