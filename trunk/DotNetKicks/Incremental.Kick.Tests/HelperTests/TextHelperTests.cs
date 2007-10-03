using Incremental.Kick.Helpers;
using MbUnit.Core.Exceptions;
using MbUnit.Framework;

namespace Incremental.Kick.Tests.HelperTests {
    [TestFixture]
    public class TextHelperTests {

        [Row("", "")]
        [Row("no link", "no link")]
        [Row("htp://www.ireland.com/", "htp://www.ireland.com/")] //only valid links should be replaced

        //testing period at the end of a link
        [Row("http://iol.ie.", @"<a href=""http://iol.ie"" target=""_new"">http://iol.ie</a>.")]
        [Row("http://iol.ie/.", @"<a href=""http://iol.ie/"" target=""_new"">http://iol.ie/</a>.")]

        //testing bracket and period at the end of a link 
        [Row("(http://code.google.com/p/dotnetkicks/issues/detail?id=112).", @"(<a href=""http://code.google.com/p/dotnetkicks/issues/detail?id=112"" target=""_new"">http://code.google.com/p/dotnetkicks/issues/detail?id=112</a>).")]
                
        //Testing two links on a line
        [Row("This is a link http://www.iol.ie/ and this is another one: http://www.iol.ie/.",
            @"This is a link <a href=""http://www.iol.ie/"" target=""_new"">http://www.iol.ie/</a> and this is another one: <a href=""http://www.iol.ie/"" target=""_new"">http://www.iol.ie/</a>.")]

        [Row("http://iol.ie/foo.bar(vs.80).aspx", @"<a href=""http://iol.ie/foo.bar(vs.80).aspx"" target=""_new"">http://iol.ie/foo.bar(vs.80).aspx</a>")]


        //Valid Links:
        [Row("http://www.ireland.com/", @"<a href=""http://www.ireland.com/"" target=""_new"">http://www.ireland.com/</a>")]
        [Row("http://ireland.com/", @"<a href=""http://ireland.com/"" target=""_new"">http://ireland.com/</a>")]
        [Row("http://ireland.ie/", @"<a href=""http://ireland.ie/"" target=""_new"">http://ireland.ie/</a>")]
        [Row("http://ireland.ie", @"<a href=""http://ireland.ie"" target=""_new"">http://ireland.ie</a>")]
        [Row("http://iol.ie", @"<a href=""http://iol.ie"" target=""_new"">http://iol.ie</a>")]
        [Row("The first link is http://www.dotnetkicks.com/ and the second one is http://www.kick.ie/",
          @"The first link is <a href=""http://www.dotnetkicks.com/"" target=""_new"">http://www.dotnetkicks.com/</a> and the second one is <a href=""http://www.kick.ie/"" target=""_new"">http://www.kick.ie/</a>")]
        [Row(@"
               Line 1 http://news.bbc.co.uk/
               Line 2 http://ireland.com",
           @"
               Line 1 <a href=""http://news.bbc.co.uk/"" target=""_new"">http://news.bbc.co.uk/</a>
               Line 2 <a href=""http://ireland.com"" target=""_new"">http://ireland.com</a>")]
        [RowTest]
        [Row("http://www.aaa.com/page.php?forum_id=15&thread_id=12537&pid=40798#post_40798",
      @"<a href=""http://www.aaa.com/page.php?forum_id=15&thread_id=12537&pid=40798#post_40798"" target=""_new"">http://www.aaa.com/page.php?forum_id=15&thread_id=12537&pid=40798#post_40798</a>")]       
        public void UrlifyTest(string input, string expected) {
            Assert.AreEqual(expected, TextHelper.Urlify(input));
        }

        [Row("", "")]
        [Row(@":,(", "<img src=\"/cry.gif\" border=\"0\" />")]
        [Row(@":)", "<img src=\"/glad.gif\" border=\"0\" />")]
        [Row(@":D", "<img src=\"/happy.gif\" border=\"0\" />")]
        [Row(@";(", "<img src=\"/nervous.gif\" border=\"0\" />")]
        [Row(@";)", "<img src=\"/ok.gif\" border=\"0\" />")]
        [Row(@":(", "<img src=\"/sad.gif\" border=\"0\" />")]
        [Row(@"=)", "<img src=\"/satisfied.gif\" border=\"0\" />")]
        [Row(@"=):)", "<img src=\"/satisfied.gif\" border=\"0\" /><img src=\"/glad.gif\" border=\"0\" />")]
        [RowTest]
        public void ReplaceEmoticonsTest(string input, string expected)
        {
            Assert.AreEqual(expected, TextHelper.ReplaceEmoticons(input, ""));
        }

        [Row(@":d", "<img src=\"/happy.gif\" border=\"0\" />")]
        [RowTest]
        public void ReplaceEmoticonsTestInvalid(string input, string expected)
        {
            Assert.AreNotEqual(expected, TextHelper.ReplaceEmoticons(input, ""));
        }
    }
}