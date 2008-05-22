using System;
using MbUnit.Framework;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Tests {
    [TestFixture("Ensure that test and database enviroments are available")]
    public class SanityTests {

        [Test]
        public void TheUniverseWorksTest() {
            Assert.AreEqual(1, 1);
        }

//        [Test]
//        public void CanAccessDatabaseTest() {
//            Assert.GreaterEqualThan(User.GetTotalCount(), 0);
//        }
    }
}