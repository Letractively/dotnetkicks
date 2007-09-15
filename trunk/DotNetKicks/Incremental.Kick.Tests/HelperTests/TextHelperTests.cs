using System;
using System.Collections.Generic;
using Incremental.Kick.Helpers;
using MbUnit.Framework;

namespace Incremental.Kick.Tests.HelperTests {
    [TestFixture]
    public class TextHelperTests {

        [Row("", "")]
        [Row("no link", "no link")]
        [Row("htp://www.ireland.com/", "htp://www.ireland.com/")] //only valid links should be replaced

        //Valid Links:
        [Row("http://www.ireland.com/", @"<a href=""http://www.ireland.com/"" target=""_new"">http://www.ireland.com/</a>")]
        [Row("http://ireland.com/", @"<a href=""http://ireland.com/"" target=""_new"">http://ireland.com/</a>")]
        [Row("http://ireland.ie/", @"<a href=""http://ireland.ie/"" target=""_new"">http://ireland.ie/</a>")]
        [Row("http://ireland.ie", @"<a href=""http://ireland.ie"" target=""_new"">http://ireland.ie</a>")]
        [Row("http://iol.ie", @"<a href=""http://iol.ie"" target=""_new"">http://iol.ie</a>")]
        [Row("The first link is http://www.dotnetkicks.com/ and the second one is http://www.kick.ie/",
          @"The first link is <a href=""http://www.dotnetkicks.com/"" target=""_new"">http://www.dotnetkicks.com/</a> and the second one is <a href=""http://www.kick.ie/"" target=""_new"">http://www.kick.ie/</a>")]
        [RowTest]
        public void UrlifyTest(string input, string expected) {
            Assert.AreEqual(expected, TextHelper.Urlify(input));
        }
    }
}