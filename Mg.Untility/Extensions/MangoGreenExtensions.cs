using Mg.Framework; 
using AH.Untility.Reflection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Untility
{
    /// <summary>
    /// 自定义扩展方法
    /// </summary>
    public static partial class MangoGreenExtensions
    { 
        #region 扩展string
        public static bool IsEmpty(this string val)
        {
            return val.IsNullOrEmpty() || val.IsNullOrWhiteSpace();
        }

        public static bool IsNullOrEmpty(this string val)
        {
            return string.IsNullOrEmpty(val);
        }

        public static bool IsNullOrWhiteSpace(this string val)
        {
            return string.IsNullOrWhiteSpace(val);
        }
        #endregion 

        #region 扩展NameValueCollection
        /// <summary>
        /// NameValueCollection扩展：将NameValueCollection对象转换成IDictionary字典集合
        /// </summary>
        /// <param name="source">NameValueCollection对象</param>
        /// <returns>IDictionary<string, string> </returns>
        public static IDictionary<string, string> ToDictionary(this NameValueCollection source)
        {
            return source.AllKeys.ToDictionary(k => k, k => source[k]);
        }

        /// <summary>
        /// NameValueCollection扩展：将NameValueCollection对象转换成IDictionary字典集合
        /// </summary>
        /// <param name="source">NameValueCollection对象</param>
        /// <returns>IDictionary<string, string[]></returns>
        public static IDictionary<string, string[]> ToDictionaryArray(this NameValueCollection source)
        {
            return source.AllKeys.ToDictionary(k => k, k => source.GetValues(k));
        }

        #endregion 

        #region 扩展DataTable
        public static List<object[]> GetPageList(this DataTable dataTable, int pageIndex, int pageSize, string orderByField)
        {
            List<object[]> rows = new List<object[]>();
            if (dataTable != null)
            {
                //  dataTable.RemotingFormat = SerializationFormat.Binary; 
                foreach (var r in dataTable.AsEnumerable().OrderBy(r => r[orderByField]).Skip((pageIndex - 1) * pageSize).Take(pageSize))
                {
                    rows.Add(r.ItemArray);
                }
            }
            return rows;
        }
        #endregion

        #region 扩展IQueryable<T>
        public static IQueryable<T> Sort<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> orderLambda, bool isDesc = false)
        {
            if (orderLambda == null)
            {
                throw new Exception("请设置排序字段");
            }
            if (isDesc)
            {
                return queryable.OrderByDescending(orderLambda);
            }
            else
            {
                return queryable.OrderBy(orderLambda);
            }
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">数据源总记录数</param>
        /// <returns></returns>
        public static IList<T> GetPageData<T>(this IQueryable<T> source, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = source.Count();
            return source.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
        }
        #endregion

        #region 扩展 Newtonsoft
        /// <summary>
        /// 不抛出异常的转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static T ToObjectEx<T>(this JToken data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data", "数据源为空！");
            }
            var t = default(T);
            if (data.TryToObject<T>(out t))
            {
                return t;
            }
            return t;
        }

        public static bool TryToObject<T>(this JToken data, out T val)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data", "数据源为空！");
            }
            var b = false;
            try
            {
                val = data.ToObject<T>();
                b = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               // LoggerHelper.Error("ToTryObject", ex);
                val = default(T);
            }
            return b;
        }
        #endregion

      

        #region 扩展GUID
        public static bool IsEmpty(this Guid val)
        {
            return val == null || val.Equals(Guid.Empty);
        }
        #endregion

        #region 扩展 Action
        /// <summary>
        /// 线程安全执行某些操作（双if+lock）
        /// </summary>
        /// <param name="action">需要执行的事件</param>
        /// <param name="ifLambda">if表达式（会取反）</param>
        /// <param name="lockObj">锁对象</param>
        public static void ThreadSafetyExecute(this Action action, Expression<Func<bool>> ifLambda, object lockObj)
        {
            if (!ifLambda.Compile()())
            {
                lock (lockObj)
                {
                    if (!ifLambda.Compile()())
                    {
                        action();
                    }
                }
            }
        } 
        #endregion
        
        #region 扩展 object
        /// <summary>
        /// 比较两个值是否相等
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetObj"></param>
        /// <returns></returns>
        public static bool DbEqual(this object obj, object targetObj)
        {
            if (obj == null && targetObj == null)
            {
                return true;
            }
            if (obj != null && targetObj != null)
            {
                return obj.Equals(targetObj);
            }
            return false;
        }
        #endregion 

        #region 扩展 PropertyInfo
        /// <summary>
        /// 判断属性是否可写
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool CanWrite(this PropertyInfo property)
        {
            if (property != null && property.CanWrite)
            {
                // property.CustomAttributes(typeof(Chloe.Entity.AutoIncrement))
                return true;
            }
            return false;
        } 
        #endregion


        public static string PadLeft(this int number, int totalWidth=2, char paddingChar='0')
        {
            return number.ToString().PadLeft(totalWidth, paddingChar);
        }

        public static int ToInt(this Enum source)
        { 
            return 0;
        }
    }
}
