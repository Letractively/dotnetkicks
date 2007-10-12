using System;
using System.Web;
using System.Web.Caching;

namespace Incremental.Kick.Caching {
    //TODO: GJ: add reluctant caching
    public class CacheManager<K, V> {
		private static CacheManager<K, V> _instance = null;
		private static readonly object _instanceLock = new object();

        private CacheManager() { }

        public V this[K key] {
            get { return (V)HttpRuntime.Cache[CreateKey(key)]; }
        }

        public bool ContainsKey(K key) {
            return HttpRuntime.Cache[CreateKey(key)] != null;
        }
		
        public V Get(K key) {
            return (V)HttpRuntime.Cache.Get(CreateKey(key));
        }
		
        public static CacheManager<K, V> GetInstance() {
            if (_instance == null)
                lock (_instanceLock)
                    if (_instance == null)
                        _instance = new CacheManager<K, V>();
            return _instance;
        }
		
        public void Insert(K key, V value, int cacheDurationInSeconds) {
            Insert(key, value, cacheDurationInSeconds, CacheItemPriority.Default);
        }
		
        public void Insert(K key, V value, int cacheDurationInSeconds, CacheItemPriority priority) {
            string keyString = CreateKey(key);
            System.Diagnostics.Trace.WriteLine("Cache: inserting [" + keyString + "]");
            HttpRuntime.Cache.Insert(keyString, value, null, DateTime.Now.AddSeconds(cacheDurationInSeconds), Cache.NoSlidingExpiration, priority, null);
        }
		
        public void Remove(K key) {
            HttpRuntime.Cache.Remove(CreateKey(key));
        }
		
        private static string CreateKey(K key) {
            return key +  typeof(K).ToString() + key.GetHashCode();
        }
    }
}
