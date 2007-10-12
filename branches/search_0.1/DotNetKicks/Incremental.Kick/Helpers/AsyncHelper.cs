using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; 

namespace Incremental.Kick.Helpers {
    public class AsyncHelper {
        public static void FireAndForget(ThreadStart work) {
            ThreadPool.QueueUserWorkItem(delegate {
                try {
                    work();
                } catch (Exception ex) {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
            });
        }
    }
}
