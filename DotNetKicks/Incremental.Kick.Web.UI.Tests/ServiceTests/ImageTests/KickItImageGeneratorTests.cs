using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using MbUnit.Framework;
using WatiN.Core;

namespace Incremental.Kick.Web.UI.Tests.ServiceTests.ImageTests {
    [TestFixture(ApartmentState = ApartmentState.STA)]
    public class KickItImageGeneratorTests {

        [Test]
        public void KickItImageIsGeneratedForExistantStoryTest() {
            using (DnkBrowser browser = new DnkBrowser()) {
                browser.GoTo(browser.RootUrl + "Services/Images/KickItImageGenerator.ashx?url=http%3a%2f%2fnews.bbc.co.uk%2fsport2%2fhi%2frugby_union%2fwelsh%2f6996579.stm");
                Assert.IsTrue(browser.RootUrl != null);
                Assert.IsTrue(browser.Images.Length == 1);
            }
        }

        [Test]
        public void KickItImageIsGeneratedForNonExistantStoryTest() {
            using (DnkBrowser browser = new DnkBrowser()) {
                browser.GoTo(browser.RootUrl + "Services/Images/KickItImageGenerator.ashx?url=http%3a%2f%2fwww.doesnotexist.com");
                Assert.IsTrue(browser.RootUrl != null);
                Assert.IsTrue(browser.Images.Length == 1);
            }
        }
    }
}