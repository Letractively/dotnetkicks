using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Helpers;
using MbUnit.Framework;

namespace Incremental.Kick.Tests.HelperTests
{
    [TestFixture]
    public class PasswordGeneratorTest
    {

        [Row(5)]    //valid test
        [Row(0)]    //valid test
        [Row(128)]  //valid test
        [Row(-5)]   //produces error
        [RowTest]
        public void GenerateTest(int length)
        {
            string pw = PasswordGenerator.Generate(length);
            Assert.AreEqual(length, pw.Length);
        }
    }
}
