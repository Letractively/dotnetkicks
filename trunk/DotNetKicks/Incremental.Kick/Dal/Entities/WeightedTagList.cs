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
            decimal dd = 0.05M;
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

        public string ToCommaDelimitedString() {
            string result = "";
            foreach (WeightedTag exisitingTag in this) {
                result += exisitingTag.TagIdentifier + ",";
            }
            return result.Substring(0, result.Length - 1);
        }
        
        /// <summary>
        /// Calculates the size (in em) for a weighted tag in relation to all tags.
        /// </summary>
        /// <remarks>
        /// Requires:
        /// * <paramref name="minTagSize"/> must be less than <paramref name="maxTagSize"/>
        /// * <paramref name="maxTagSize"/> must be greater than zero.
        /// * <paramref name="totalTagUsageCount"/> must be greater than or equal to <paramref name="tagUsageCount"/>
        /// 
        /// <paramref name="maxTagSize"/> is returned if:
        /// * <paramref name="minTagSize"/> and <paramref name="maxTagSize"/> are equal
        /// * <paramref name="tagUsageCount"/> is less than one 
        /// * <paramref name="totalTagUsageCount"/> is less than two
        /// * <paramref name="tagUsageCount"/> equals <paramref name="totalTagUsageCount"/> 
        /// 
        /// To determine <paramref name="totalTagUsageCount"/>, use <seealso cref="WeightedTagList.TotalTagUsageCount"/>
        /// </remarks>
        /// <param name="minTagSize">The minimum font size (in em)</param>
        /// <param name="maxTagSize">The maximum font size (in em)</param>
        /// <param name="totalTagUsageCount">The total number of times all tags have been used in the system.</param>
        /// <param name="tagUsageCount">The total number of times shown, or weight, of the tag in question</param>
        /// <returns>A value that is the correct relative font size, in em, of the tag</returns>
        public static double GetTagFontSize(double minTagSize, double maxTagSize, double totalTagUsageCount, double tagUsageCount)
        {
            // sanity
            if (minTagSize > maxTagSize) throw new ArgumentException("minTagSize must be less than or equal to maxTagSize");
            if (maxTagSize <= 0 || minTagSize <= 0) throw new ArgumentException("Sizes must be greater than zero");
            if (tagUsageCount > totalTagUsageCount) throw new ArgumentException("tagUsageCount is larger than totalUsageCount; this fails.");
            if (minTagSize == maxTagSize || totalTagUsageCount < 2 || tagUsageCount < 1 || totalTagUsageCount == tagUsageCount) return maxTagSize;
            // Shift max down so that the minimum is zero so that we can map percentage of use (0 to 100) to size (0 to max)
            double max = maxTagSize - minTagSize;
            double percent = tagUsageCount / totalTagUsageCount;
            // map and shift back for result
            return max * percent + minTagSize;
        }
    }
}
