using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal.Entities.Api;

namespace Incremental.Kick.Dal {
    public partial class Chat {

        public ApiChat ToApi(bool includeLatestShouts) {

            List<ApiShout> apiShouts = new List<ApiShout>();
            if (includeLatestShouts) {
                //TODO: GJ: get the latest shouts
            }

            return new ApiChat(this.ChatID, this.Title, this.Description, apiShouts);
        }
    }
}
