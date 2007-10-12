using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Helpers;
using MbUnit.Framework;

namespace Incremental.Kick.Tests.HelperTests
{
    [TestFixture]
    public class PasswordGeneratorTests
    {

        [Row(0)]              //valid test
        [Row(1)]              //valid test
        [Row(64)]             //valid test
        [Row(byte.MaxValue)]  //valid test
        [Row(byte.MinValue)]  //valid test
        [RowTest]
        public void GenerateTest(byte length)
        {          
            string pw = PasswordGenerator.Generate(length);
            Assert.AreEqual(length, pw.Length);
        }
    }
}
