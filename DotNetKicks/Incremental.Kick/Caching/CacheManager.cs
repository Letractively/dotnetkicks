using System;
using System.Web;
using System.Web.Caching;

namespace Incremental.Kick.Caching {
    //TODO: GJ: add reluctant caching
    /// <summary>
    /// CacheManager
    /// </summary>
    /// <typeparam name="K">Key</typeparam>
    /// <typeparam name="V">Value</typeparam>
    public class CacheManager<K, V> {
        
		#region Fields

		private static CacheManager<K, V> _instance = null;
		private static readonly object _instanceLock = new object();

		#endregion

		#region Constructors

		/// <summary>
        /// Initializes a new instance of the <see cref="CacheManager&lt;K, V&gt;"/> class.
        /// </summary>
        private CacheManager() { }
		
		#endregion 

		#region  Properties 

		/// <summary>
        /// Gets the <see cref="V"/> with the specified key.
        /// </summary>
        /// <value></value>
        public V this[K key] {
            get { return (V)HttpRuntime.Cache[CreateKey(key)]; }
        }
		
		#endregion 

		#region Methods 

		//  Public Methods 

		/// <summary>
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified key contains key; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey(K key) {
            return HttpRuntime.Cache[CreateKey(key)] != null;
        }
		
		/// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V Get(K key) {
            return (V)HttpRuntime.Cache.Get(CreateKey(key));
        }
		
		/// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static CacheManager<K, V> GetInstance() {
            if (_instance == null)
                lock (_instanceLock)
                    if (_instance == null)
                        _instance = new CacheManager<K, V>();
            return _instance;
        }
		
		/// <summary>
        /// Inserts the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="cacheDurationInSeconds">The cache duration in seconds.</param>
        public void Insert(K key, V value, int cacheDurationInSeconds) {
            Insert(key, value, cacheDurationInSeconds, CacheItemPriority.Default);
        }
		
		/// <summary>
        /// Inserts the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="cacheDurationInSeconds">The cache duration in seconds.</param>
        /// <param name="priority">The priority.</param>
        public void Insert(K key, V value, int cacheDurationInSeconds, CacheItemPriority priority) {
            string keyString = CreateKey(key);
            System.Diagnostics.Trace.WriteLine("Cache: inserting [" + keyString + "]");
            HttpRuntime.Cache.Insert(keyString, value, null, DateTime.Now.AddSeconds(cacheDurationInSeconds), Cache.NoSlidingExpiration, priority, null);
        }
		
		/// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(K key) {
            HttpRuntime.Cache.Remove(CreateKey(key));
        }
		
		// [rgn] Private Methods (1)

		/// <summary>
        /// Creates the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private static string CreateKey(K key) {
            return key +  typeof(K).ToString() + key.GetHashCode();
        }
		
		#endregion 

    }
}
