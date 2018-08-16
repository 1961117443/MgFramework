 
using AH.Untility.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Untility
{
    public static partial class MangoGreenExtensions
    {
        #region 扩展IDictionary
        

        /// <summary>
        /// 向字典追加对象的属性
        /// </summary>
        /// <param name="source"></param>
        /// <param name="row"></param>
        /// <param name="fieldName"></param>
        /// <param name="columns"></param>
        public static void AppendProperty(this IDictionary<string, object> source, object row, string fieldName, params string[] columns)
        {
            if (row == null)
            {
                return;
            }
            if (columns == null || columns.Length == 0)
            {
                columns = row.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).Select(w => w.Name).ToArray();
            }
            EachHelper.EachObjectProperty(row, (j, k, o) =>
            {
                if (columns.Contains(k))
                {
                    k = $"{fieldName}_" + k;
                    if (!source.ContainsKey(k))
                    {
                        source.Add(k, o);
                    }
                }
            });
        }

        /// <summary>
        /// Dictionary扩展方法： 通过key查找value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Value<T>(this IDictionary<string, string> dict, string key)
        {
            if (dict == null)
                throw new Exception("Dictionary is NULL.");
            string value = string.Empty;
            if (!dict.TryGetValue(key, out value)) return default(T);
            T v = default(T);
            switch (typeof(T).Name)
            {
                case "Guid":
                    Guid val = Guid.Empty;
                    if (Guid.TryParse(value,out val))
                    {
                        v = FromType<T, Guid>(val);
                    }
                    break;
                default:
                    v = FromType<T, string>(value);
                    break;
            }
            
            //throw new Exception("The given key:" + key + " was not present in the dictionary.");
           
            return v;
        }
        /// <summary>
        /// Dictionary扩展方法： 列表同步方法封装-查找项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ab"></param>
        /// <param name="item"></param>
        public static V Value<K, V>(this IDictionary<K, V> dict, K key)
        {
            lock (dict)
            {
                if (dict.ContainsKey(key))
                {
                    return dict[key];
                }
                else
                {
                    return default(V);
                }
            }
        }

        /// <summary>
        /// Dictionary扩展方法： 列表同步方法封装-添加项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ab"></param>
        /// <param name="item"></param>
        public static void DictionaryAdd<K, V>(this IDictionary<K, V> dict, K id, V val)
        {
            if (val != null)
            {
                lock (dict)
                {
                    if (!dict.ContainsKey(id))
                    {
                        dict.Add(id, val);
                    }
                }
            }
        }

        /// <summary>
        ///  Dictionary扩展方法：列表同步方法封装 - 替换或添加项
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="ab"></param>
        /// <param name="id"></param>
        /// <param name="val"></param>
        public static void DictionaryExchange<K, V>(this IDictionary<K, V> dict, K id, V val)
        {
            if (val != null)
            {
                lock (dict)
                {
                    if (dict.ContainsKey(id))
                    {
                        dict.Remove(id);
                    }
                    dict.Add(id, val);
                }
            }
        }
        #endregion
    }
}
