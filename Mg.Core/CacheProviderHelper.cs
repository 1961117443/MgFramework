using Mg.Core.IOC;
using Mg.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Core
{
    public class CacheProviderHelper<T>
    {
        private static readonly ConcurrentDictionary<string, ICacheProvider> CacheProvider = new ConcurrentDictionary<string, ICacheProvider>();
        public static ICacheProvider GetCacheProvider()
        {
            var key = typeof(T).FullName;
            if (!CacheProvider.ContainsKey(key))
            {
                var cache = DIFactory.GetService<ICacheProvider>();
                CacheProvider.TryAdd(key, cache);
            }
            return CacheProvider[key];
        }
         

 
    }

    public class CacheProviderHelper
    {
        private static readonly ConcurrentDictionary<string, ICacheProvider> CacheProvider = new ConcurrentDictionary<string, ICacheProvider>();
        public static ICacheProvider GetCacheProvider(string key)
        { 
            if (!CacheProvider.ContainsKey(key))
            {
                var cache = DIFactory.GetService<ICacheProvider>();
                CacheProvider.TryAdd(key, cache);
            }
            return CacheProvider[key];
        }



    }

}
