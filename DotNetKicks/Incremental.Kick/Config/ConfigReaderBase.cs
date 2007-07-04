using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.ApplicationBlocks.ConfigurationManagement;
using System.Collections;

namespace Incremental.Kick.Config {

    public abstract class ConfigReaderBase {
        protected static object Read(string configSection) {
            try {
                return ConfigurationManager.Read(configSection);
            } catch(Exception exception) {
                Trace.TraceError(string.Format("Could not load the '{0}' configuration file", configSection));
                throw;
            }
        }

        protected static Hashtable GetHashtable(string configSection) {
            try {
                return ConfigurationManager.Read(configSection) as Hashtable;
            } catch(Exception exception) {
                Trace.TraceError(string.Format("Could not load the '{0}' configuration file Hashtable", configSection));
                throw;
            }
        }
    }
}