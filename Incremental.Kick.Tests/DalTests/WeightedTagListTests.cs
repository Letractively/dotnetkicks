using System;
using System.Collections.Generic;
using System.Text;
using MbUnit.Framework;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Tests.DalTests
{
    [TestFixture("I can't believe its not butter")]
    public class WeightedTagListTests
    {

        [Row(100d, 100d, 2d, 1d)] // equals
        [Row(1d, 200d, 24d, 24d)]
        [Row(1d, 2d, -1d, -1d)] // less thans
        [Row(1d, 2d, 25d, -24d)]
        [Row(1d, 2d, 1d, 1d)]
        [Row(1d, 2d, 1d, 0d)]
        [Row(1d, 2d, 0d, 0d)]
        [RowTest]
        public void GetTagFontSizeTests_Defaults(double minTagSize, double maxTagSize, double totalTagUsageCount, double tagUsageCount)
        {
            if (minTagSize == 0.0d) return; // goddamnit
            double result = WeightedTagList.GetTagFontSize(minTagSize, maxTagSize, totalTagUsageCount, tagUsageCount);
            Assert.AreEqual(maxTagSize, result, "Defaults failed; expected {0} got {1}", maxTagSize, result);
        }

        //[Test]
        //public void GetTagFontSizeTests_Defaults(double minTagSize, double maxTagSize, double totalTagUsageCount, double tagUsageCount)
        //{
        //    double result;
        //    result = WeightedTagList.GetTagFontSize(100d, 100d, 25d, 200d);
        //    Assert.AreEqual(100d, result, "Defaults failed; expected {0} got {1}", 100, result);
        //    result = WeightedTagList.GetTagFontSize(1d, 200d, 24d, 24d);
        //    Assert.AreEqual(1d, result, "Defaults failed; expected {0} got {1}", 1d, result);
        //    result = WeightedTagList.GetTagFontSize(1d, 2d, -1d, -1d);
        //    Assert.AreEqual(1d, result, "Defaults failed; expected {0} got {1}", 1d, result);
        //    result = WeightedTagList.GetTagFontSize(1d, 2d, 25d, -24d);
        //    Assert.AreEqual(1d, result, "Defaults failed; expected {0} got {1}", 1d, result);
        //    result = WeightedTagList.GetTagFontSize(1d, 2d, -33d, 33d);
        //    Assert.AreEqual(1d, result, "Defaults failed; expected {0} got {1}", 1d, result);
        //    result = WeightedTagList.GetTagFontSize(1d, 2d, 1d, 1d);
        //    Assert.AreEqual(1d, result, "Defaults failed; expected {0} got {1}", 1d, result);
        //    result = WeightedTagList.GetTagFontSize(1d, 2d, 1d, 0d);
        //    Assert.AreEqual(1d, result, "Defaults failed; expected {0} got {1}", 1d, result);
        //    result = WeightedTagList.GetTagFontSize(1d, 2d, 0d, 0d);
        //    Assert.AreEqual(1d, result, "Defaults failed; expected {0} got {1}", 1d, result);
        //}

        [Row(1000d, 100d, 1d, 2d)] //less than
        [Row(-11d, 2d, 1d, 2d)] // less than but not less than zero
        [Row(-11d, -2d, 1d, 2d)] // same same
        [Row(-11d, 2d, 25d, 25d)] // not overrided by defaults
        [Row(-1d, -1d, 1d, 2d)]
        [Row(-1d, -1d, 2d, 0d)]
        [Row(-1d, -1d, -1d, -1d)]
        [RowTest]
        [ExpectedArgumentException()]
        public void GetTagFontSizeTests_Exceptions(double minTagSize, double maxTagSize, double totalTagUsageCount, double tagUsageCount)
        {
            //double result = WeightedTagList.GetTagFontSize(-11, 2, 25, 25);
            double result = WeightedTagList.GetTagFontSize(minTagSize, maxTagSize, totalTagUsageCount, tagUsageCount);
            Assert.Fail("Exception not thrown");
        }

        //[Row(d, d, d, d, d)]
        [Row(8d, 12d, 10d, 1d, 8.4d)]
        [Row(4d, 16d, 10d, 2d, 6.4d)]
        [Row(2d, 32d, 10d, 4d, 14d)]
        [Row(1d, 64d, 10d, 8d, 51.4d)]
        [RowTest]
        public void GetTagFontSizeTests_CorrectValues(double minTagSize, double maxTagSize, double totalTagUsageCount, double tagUsageCount, double expected)
        {
            Assert.AreEqual(expected,WeightedTagList.GetTagFontSize(minTagSize,maxTagSize,totalTagUsageCount,tagUsageCount));
        }
    }
}
