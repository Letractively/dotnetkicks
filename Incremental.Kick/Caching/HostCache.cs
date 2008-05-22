using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching {
    public class HostCache {
        public static Host GetHost(string hostAndPort) {
            return Hosts[hostAndPort];
        }

        public static Host GetHost(int hostID) {
            foreach (Host host in Hosts.Values) {
                if (host.HostID == hostID)
                    return host;
            }

            throw new Exception("Invalid hostID:" + hostID);
        }

        public static Dictionary<string, Host> Hosts {
            get {
                CacheManager<string, Dictionary<string, Host>> cache = GetHostProfileCache();
                string cacheKey = "Hosts";
                Dictionary<string, Host> hostDictionary = cache[cacheKey];

                if (hostDictionary == null) {
                    hostDictionary = new Dictionary<string, Host>();
                    HostCollection hosts = new HostCollection();
                    hosts.LoadAndCloseReader(Host.FetchAll());

                    foreach (Host host in hosts) {
                        hostDictionary.Add(host.HostName, host);
                    }

                    System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                    cache.Insert(cacheKey, hostDictionary, CacheHelper.CACHE_DURATION_IN_SECONDS);
                }

                return hostDictionary;
            }
        }

        private static CacheManager<string, Dictionary<string, Host>> GetHostProfileCache() {
            return CacheManager<string, Dictionary<string, Host>>.GetInstance();
        }
    }
}
