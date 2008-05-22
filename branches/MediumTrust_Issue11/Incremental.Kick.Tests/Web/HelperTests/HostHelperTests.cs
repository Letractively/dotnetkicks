using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Web.Helpers;
using MbUnit.Framework;

namespace Incremental.Kick.Tests.Web.HelperTests {
    [TestFixture]
    public class HostHelperTests {

        [Row("http://www.yahoo.com", "yahoo.com")] //valid test
        [Row("http://google.com", "google.com")] //valid test
        [Row("https://www.yahoo.com", "yahoo.com")] //valid test
        [Row("http://www.yahoo.co.jp/", "yahoo.co.jp")] //valid test
        [Row("http://yahoo.co.jp/", "yahoo.co.jp")] //CURRENTLY FAILS
        [Row("http://us.rd.yahoo.com/homepage/intlpage/text/jp/*http://www.yahoo.co.jp/", "us.rd.yahoo.com")] //CURRENTLY FAILS
        [Row("http://www.google.com/search?client=firefox-a&rls=org.mozilla%3Aen-US%3Aofficial&channel=s&hl=en&q=dotnetkicks&btnG=Google+Search", "google.com")] //valid test
        [RowTest]
        public void GetHostNameTest(string uriString, string expectedHostName) {
            //fails with international tld (.jp, etc.)
            Uri uri = new Uri(uriString);
            string hostName = HostHelper.GetHostName(uri);
            Assert.AreEqual(hostName, expectedHostName);
        }

        [Row("http://www.yahoo.com", "yahoo.com:80")] //valid test
        [Row("http://google.com", "google.com:80")] //valid test
        [Row("http://www.yahoo.co.jp/", "yahoo.co.jp:80")] //valid test
        [RowTest]
        public void GetHostAndPortTest(string uriString, string expectedHostAndPort) {
            //fails with international tld (.jp, etc.)
            Uri uri = new Uri(uriString);
            string hostNameAndPort = HostHelper.GetHostAndPort(uri);
            Assert.AreEqual(hostNameAndPort, expectedHostAndPort);
        }
    }
}
