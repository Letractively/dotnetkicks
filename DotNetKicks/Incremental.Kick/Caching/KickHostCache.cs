using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Caching
{
    public class KickHostCache
    {
        public static KickHost GetHost(string hostAndPort)
        {
            return KickHosts[hostAndPort];
        }

        public static KickHost GetHost(int hostID)
        {
            foreach (KickHost host in KickHosts.Values)
            {
                if (host.HostID == hostID)
                    return host;
            }

            throw new Exception("Invalid hostID:" + hostID);
        }

        public static Dictionary<string, KickHost> KickHosts
        {
            get
            {
                CacheManager<string, Dictionary<string, KickHost>> cache = GetHostProfileCache();
                string cacheKey = "KickHosts";
                Dictionary<string, KickHost> hostDictionary = cache[cacheKey];

                if (hostDictionary == null)
                {
                    hostDictionary = new Dictionary<string, KickHost>();
                    KickHostCollection hosts = new KickHostCollection();
                    hosts.LoadAndCloseReader(KickHost.FetchAll());

                    foreach(KickHost host in hosts) {
                        hostDictionary.Add(host.HostName, host);
                    }

                    System.Diagnostics.Trace.Write("Cache: inserting [" + cacheKey + "]");
                    cache.Insert(cacheKey, hostDictionary, 500);  //TODO: GJ: cache duration from config
                }

                return hostDictionary;
            }
        }

        private static CacheManager<string, Dictionary<string, KickHost>> GetHostProfileCache()
        {
            return CacheManager<string, Dictionary<string, KickHost>>.GetInstance();
        }
    }
}
