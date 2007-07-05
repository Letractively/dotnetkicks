using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Dal {
    public partial class TagCollection {
        public WeightedTagList ToWeightedTagList() {
            WeightedTagList weightedTagList = new WeightedTagList();
            foreach (Tag tag in this) 
                weightedTagList.Add(new WeightedTag(tag.TagID, tag.TagIdentifier, 1));

            return weightedTagList;
        }
    }
}
