using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.ApplicationBlocks.ConfigurationManagement;
using System.Collections;

namespace Incremental.Kick.Config {

    public abstract class ConfigReaderBase {
        protected static object Read(string configSection) {
            return ConfigurationManager.Read(configSection);
        }

        protected static Hashtable GetHashtable(string configSection) {
            return ConfigurationManager.Read(configSection) as Hashtable;
        }
    }
}