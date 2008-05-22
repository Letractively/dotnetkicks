using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal.Entities {

    //TODO: GJ: sort this using the ReverseComparer
    public class WeightedTagList : List<WeightedTag> {

        public int TotalTagUsageCount {
            get {
                int total = 0;
                foreach (WeightedTag tag in this) {
                    total += tag.UsageCount;
                }

                return total;
            }
        }

        public int MinTagUsageCount {
            get {
                if (this.Count == 0)
                    return 1;
                else
                    return this[this.Count-1].UsageCount;
            }
        }

        public int MaxTagUsageCount {
            get {
                if (this.Count == 0)
                    return 1;
                else
                    return this[0].UsageCount;
            }
        }

        public int TagUsageCountDistributionStepCount {
            get {
                if (this.Count < 5)
                    return this.Count;
                else
                    return 5;
            }
        }

        public decimal TagUsageCountDistributionStepSize {
            get {
                decimal ff = (decimal)(this.MaxTagUsageCount - this.MinTagUsageCount) / this.TagUsageCountDistributionStepCount;

                if (ff == 0)
                    ff = 1;

                return ff;
            }
        }

        public decimal GetTagWeight(int tagUsageCount) {
            decimal dd = (decimal)0.05;
            decimal oneandten = (tagUsageCount / this.TagUsageCountDistributionStepSize); //this should be a number between 1 and 10
            decimal result = Math.Round(oneandten * dd + 1, 1);
            if (result > 2) //NOTE: GJ: Imposing a minimum maximum size
                result = 2;
            else if (result < (decimal)0.9)
                result = (decimal)0.9;

            return result;

        }

        public WeightedTagList GetTopTags(int tagCount) {
            if (tagCount > this.Count)
                tagCount = this.Count;

            WeightedTagList topTags = new WeightedTagList();
            for (int i = 0; i < tagCount; i++) {
                topTags.Add(this[i]);
            }

            return topTags;
        }

        public class UsageCountComparer : IComparer<WeightedTag> {
            int IComparer<WeightedTag>.Compare(WeightedTag x, WeightedTag y) {
                return y.UsageCount.CompareTo(x.UsageCount);
            }
        }

        public class AlphabeticalComparer : IComparer<WeightedTag> {
            int IComparer<WeightedTag>.Compare(WeightedTag x, WeightedTag y) {
                return x.TagName.CompareTo(y.TagName);
            }
        }

        public void AddWeightedTag(WeightedTag weightedTag) {
            //NOTE: GJ: the old DNK retuned tag weightings from the sproc - we should do this is the near future
            //NOTE: GJ: in the mean time I am going to sacrafice some performance with a cheap and nasty solution
            foreach (WeightedTag exisitingTag in this) {
                if (exisitingTag.TagID == weightedTag.TagID) {
                    exisitingTag.UsageCount += weightedTag.UsageCount;
                    return;
                }
            }

            this.Add(weightedTag);
        }
    }
}
