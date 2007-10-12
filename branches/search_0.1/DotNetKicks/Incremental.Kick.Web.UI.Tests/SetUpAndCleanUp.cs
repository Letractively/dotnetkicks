using System;
using System.Collections.Generic;
using System.Text;
using MbUnit.Framework;
using Incremental.Kick.Web.UI.Tests;
using WatiN.Core;

[assembly: AssemblyCleanup(typeof(SetUpAndCleanUp))]
namespace Incremental.Kick.Web.UI.Tests {
    public static class SetUpAndCleanUp {
        [SetUp]
        public static void SetUp() {

        }

        [TearDown]
        public static void TearDown() {

        }
    }
}
