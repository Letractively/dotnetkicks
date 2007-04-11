using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal
{
    public partial class KickStory
    {
        public static KickStory FetchStoryByIdentifier(string storyIdentifier)
        {
            return KickStory.FetchStoryByParemeter(KickStory.Columns.StoryIdentifier, storyIdentifier);
        }

        public static KickStory FetchStoryByParemeter(string columnName, object value)
        {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            KickStoryCollection t = new KickStoryCollection();
            t.Load(KickStory.FetchByParameter(columnName, value));
            return t[0];
        }
    }
}
