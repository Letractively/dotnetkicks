using System;
using System.Collections.Generic;
using System.Text;
using MbUnit.Framework;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Tests.CachingTests {
    [TestFixture]
    public class SpyCacheTests {

        [Test]
        public void SpyListTestsTemp() {
            SpyList<string> spyList = new SpyList<string>();
            spyList.MaxSize = 5;

            spyList.Add("item 1");
            Assert.AreEqual(spyList.Count, 1);

            spyList.Add("item 2");
            Assert.AreEqual(spyList[0], "item 2");

            spyList.Add("item 3");
            spyList.Add("item 4");
            spyList.Add("item 5");
            Assert.AreEqual(spyList.Count, 5);

            spyList.Add("item 6");
            Assert.AreEqual(spyList.Count, 5);

            Assert.AreEqual(spyList[0], "item 6");
            Assert.AreEqual(spyList[1], "item 5");
        }
    }
}
