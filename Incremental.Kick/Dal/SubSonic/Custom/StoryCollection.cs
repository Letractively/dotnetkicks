using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal.Entities.Api;

namespace Incremental.Kick.Dal {
    public partial class StoryCollection {
        public List<ApiStory> ToApi() {
            List<ApiStory> stories = new List<ApiStory>();
            foreach (Story s in this) {
                stories.Add(s.ToApi());
            }
            return stories;
        }

        /// <summary>
        /// Returns all the stories flagged as spam in a collection
        /// </summary>
        /// <returns></returns>
        public StoryCollection SpamStories()
        {
            StoryCollection spamStories = new StoryCollection();
            foreach (Story s in this)
            {
                if (s.IsSpam)
                    spamStories.Add(s);
            }

            return spamStories;
        }
    }

    public class PagedStoryCollection : PagedCollection<StoryCollection> {
        public ApiPagedList<ApiStory> ToApi() {
            ApiPagedList<ApiStory> storiesPage = new ApiPagedList<ApiStory>();
            storiesPage.Items = this.Items.ToApi();
            storiesPage.Total = this.Total;
            return storiesPage;
        }
    }
}
