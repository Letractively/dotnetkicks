using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
//using Microsoft.ApplicationBlocks.ConfigurationManagement;
using System.Collections;
using System.Configuration;

namespace Incremental.Kick.Config {

    public abstract class ConfigReaderBase {
        protected static object Read(string configSection) {
            return ConfigurationManager.GetSection(configSection);
            //return ConfigurationManager.Read(configSection);
        }

        //protected static Hashtable GetHashtable(string configSection) {
        //    //return ConfigurationManager.
        //    return ConfigurationManager.Read(configSection) as Hashtable;
        //}
    }
}