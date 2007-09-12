using System;
using System.Collections.Generic;
using Incremental.Kick.Helpers;
using MbUnit.Framework;

namespace Incremental.Kick.Tests.HelperTests {
    [TestFixture]
    public class TagHelperTests {

        [Row("", false, new string[] { })]
        [Row("tag", false, new string[] { "tag" })] //Single tag
        [Row("tag1 tag2", false, new string[] { "tag1", "tag2" })] //Two tags
        [Row("    tag1    tag2  tag3     ", false, new string[] { "tag1", "tag2", "tag3" })] //Whitespace removal
        [Row("tag1 tag2 tag1 tag2", false, new string[] { "tag1", "tag2" })] //Duplicate removal
        [Row("tag1 tagWi£thD$odgyCh*ara^cte;rs", false, new string[] { "tag1", "tagWithDodgyCharacters" })] //Character removal
        [Row("C# C++", false, new string[] { "C#", "C++" })] //Allowed characters in tags
        [Row(@"""A Tag In Quotes"" ATagWithoutQuotes", false, new string[] { "ATagInQuotes", "ATagWithoutQuotes" })] //Quotes
        [Row("tag1 tag2 a bb c tag3", false, new string[] { "tag1", "tag2", "bb", "tag3" })] //Single character removal
        [Row("tag1 namespaced;tag", false, new string[] { "tag1", "namespacedtag" })] //Disallow namespaced tags for non admins
        [Row("tag1 namespaced;tag", true, new string[] { "tag1", "namespaced;tag" })] //Allow namespaced tags for admins
        [RowTest]
        public void DistillTagInputTest(string rawTagInput, bool isAdministrator, string[] expected) {
            string[] distilledTags = TagHelper.DistillTagInput(rawTagInput, isAdministrator).ToArray();
            ArrayAssert.AreEqual(expected, distilledTags);
        }
    }
}