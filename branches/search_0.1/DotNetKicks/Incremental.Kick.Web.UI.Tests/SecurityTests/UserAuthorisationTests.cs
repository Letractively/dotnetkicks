using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using MbUnit.Framework;
using WatiN.Core;


namespace Incremental.Kick.Web.UI.Tests.SecurityTests {
    [TestFixture(ApartmentState = ApartmentState.STA)]
    public class UserAuthorisationTests {

        [SetUp]
        public void SetUp() {
            using (DnkBrowser ie = new DnkBrowser().Logout()) { } //ensure the user is logged out
        }

        [Test]
        public void AdministratorCanViewAdminSectionTest() {
            using (DnkBrowser browser = new DnkBrowser()) {
                browser.AdminLogin().GoToAdmin();
                Assert.IsTrue(browser.IsAdminPage);
            }
        }

        [Test]
        public void ModeratorCanNotViewAdminSectionTest() {
            using (DnkBrowser browser = new DnkBrowser()) {
                browser.ModeratorLogin().GoToAdmin();
                Assert.IsTrue(browser.IsNotAuthorisedPage);
            }
        }

        [Test]
        public void UserCanNotViewAdminSectionTest() {
            using (DnkBrowser browser = new DnkBrowser()) {
                browser.UserLogin().GoToAdmin();
                Assert.IsTrue(browser.IsNotAuthorisedPage);
            }
        }
    }
}
