using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using MbUnit.Framework;
using WatiN.Core;


namespace Incremental.Kick.Web.UI.Tests.SecurityTests {
    [TestFixture(ApartmentState = ApartmentState.STA)]
    public class UserAuthenticationTests {

        [SetUp]
        public void SetUp() {
            using (DnkBrowser ie = new DnkBrowser().Logout()) { } //ensure the user is logged out
        }
        
        [Row("user1", "user1")]
        [Row("moderator", "moderator")]
        [Row("admin", "admin")]
        [RowTest]
        public void ValidUserCredentialsCanLoginTest(string username, string password) {
            using (DnkBrowser browser = new DnkBrowser()) {
                browser.Login(username, password);
                Assert.IsTrue(Regex.IsMatch(browser.Html, String.Format(@"Welcome <a href=""/users/{0}"">{0}</a>", username), RegexOptions.IgnoreCase));
            }
        }

        [Row("user1", "baspassword")]
        [Row("badusername", "user1")]
        [RowTest]
        public void InValidUserCredentialsCanNotLoginTest(string username, string password) {
            using (DnkBrowser browser = new DnkBrowser()) {
                browser.Login(username, password);
                Assert.IsTrue(Regex.IsMatch(browser.Html, "Username and password do not match", RegexOptions.IgnoreCase));
            }
        }
    }
}
