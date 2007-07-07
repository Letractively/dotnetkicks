using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Incremental.Kick.Caching {
    //TODO: GJ: add reluctant caching
    public class CacheManager<K, V> {
        private CacheManager() { }

        private static readonly object _instanceLock = new object();
        private static CacheManager<K, V> _instance = null;

        public static CacheManager<K, V> GetInstance() {
            if (_instance == null)
                lock (_instanceLock)
                    if (_instance == null)
                        _instance = new CacheManager<K, V>();
            return _instance;
        }

        public V this[K key] {
            get { return (V)HttpRuntime.Cache[CreateKey(key)]; }
        }

        public void Insert(K key, V value, int cacheDurationInSeconds) {
            HttpRuntime.Cache.Insert(CreateKey(key), value, null, DateTime.Now.AddSeconds(cacheDurationInSeconds), Cache.NoSlidingExpiration);
        }

        public void Remove(K key) {
            HttpRuntime.Cache.Remove(CreateKey(key));
        }

        public V Get(K key) {
            return (V)HttpRuntime.Cache.Get(CreateKey(key));
        }

        public bool ContainsKey(K key) {
            return HttpRuntime.Cache[CreateKey(key)] != null;
        }

        private static string CreateKey(K key) {
            return typeof(K).ToString() + key.GetHashCode().ToString();
        }
    }
}
