using Mg.Core.IOC;
using Mg.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Core
{
    public sealed class CacheManager : ICacheProvider
    {

        #region 公共属性
        private static ICacheProvider cache = null;
        private static CacheManager instance = new CacheManager();
        /// <summary>
        /// 获取<c>CacheManager</c>类型的单件（Singleton）实例。
        /// </summary>
        public static CacheManager Instance
        {
            get { return instance; }
        }

        private CacheManager()
        { }

        private CacheManager(ICacheProvider cacheProvider)
        {
            cache = cacheProvider;
        }


        static CacheManager()
        {
            Console.WriteLine($"{DateTime.Now}...开始缓存的初始化.....");
            cache = DIFactory.GetService<ICacheProvider>();
            //可以创建不同的cache对象
            //cache = (ICacheProvider)Activator.CreateInstance(typeof(MemoryCacheCache));
            // 这里可以根据配置文件来选择
            //cache = (ICacheProvider)Activator.CreateInstance(typeof(CustomCache));
        }

        #endregion Identity
        #region ICacheProvider
        public int Count
        {
            get
            {
                return cache.Count;
            }
        }

        public object this[string key]
        {
            get
            {
                return cache[key];
            }
            set
            {
                cache[key] = value;
            }
        }
        public T Get<T>(string key)
        {
            return cache.Get<T>(key);
        }

        public void Add(string key, object data, int cacheTime = 30)
        {
            cache.Add(key, data, cacheTime);
        }

        public bool Contains(string key)
        {
            return cache.Contains(key);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public void RemoveAll()
        {
            cache.RemoveAll();
        }

        public T TryGet<T>(string key, Func<T> func)
        {
          return  cache.TryGet(key, func);
        }
        #endregion
    }
}
