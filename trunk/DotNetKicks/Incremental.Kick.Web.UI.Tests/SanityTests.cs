using System;
using MbUnit.Framework;
using System.Threading;
using System.Text.RegularExpressions;
using WatiN.Core;

namespace Incremental.Kick.Web.UI.Tests {
    [TestFixture(ApartmentState = ApartmentState.STA)]
    public class SanityTests {

        [Test]
        public void TheUniverseWorksTest() {
            using (IE ie = new IE("http://localhost:8080/")) {
                Assert.IsTrue(Regex.IsMatch(ie.Html, @"localhost:8080"));
            }
        }
    }
}