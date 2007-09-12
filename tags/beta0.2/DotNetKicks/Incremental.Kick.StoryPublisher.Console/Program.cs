using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.BusinessLogic;
using System.Diagnostics;

namespace Incremental.Kick.StoryPublisher.Console {
    class Program {
        static void Main(string[] args) {
            Trace.Write("Atweb.Kick.Publisher Begin");
            StoryBR.PublishStoryProcess();
            Trace.Write("Atweb.Kick.Publisher End");
        }
    }
}
