
using AH.Untility.Reflection;
using Mg.Framework;
using Mg.IOSerialize.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Untility
{
    public static partial class MangoGreenExtensions
    {
        #region 扩展 BaseModel
        /// <summary>
        /// 比较source和data，
        /// 如果值不一样，把data赋值到source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">原始数据</param>
        /// <param name="data">修改过的数据</param>
        /// <param name="fields">需要更新的属性，如果为空则更新全部</param>
        public static PropertyInfo[] Replace<T>(this T source, T data,params string[] fields) where T : BaseModel
        {
            List<PropertyInfo> changed = new List<PropertyInfo>();
            PropertyInfo[] props = typeof(T).GetPropertiesEx();
            if (fields!=null && fields.Length>0)
            {
                props = props.Where(w => fields.Contains(w.Name)).ToArray();
            }
            foreach (var prop in props)
            {
                if (prop.CanWrite())
                {
                    var ov = prop.GetValue(source, null);
                    var nv = prop.GetValue(data, null);
                    if (!ov.DbEqual(nv))
                    {
                        prop.SetValue(source, nv);
                        changed.Add(prop);
                    }
                }
            }
            return changed.ToArray();
        }

        /// <summary>
        /// 把实体对象转换成 IDictionary<string, object>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDic<T>(this T entity) where T : BaseModel
        {
            Dictionary<string, object> val = new Dictionary<string, object>();
            EachHelper.EachObjectProperty(entity, (i, k, v) =>
            {
                val.Add(k, v);
            });
            return val;
        }

        /// <summary>
        /// 获取实体属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="bindingFlags"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertiesEx<T>(this T entity, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance) where T : BaseModel
        {
            return typeof(T).GetProperties(bindingFlags);
        }
        #endregion

        #region 扩展VD_Base
        public static void ObjectExtend<T>(this T target, T provider) where T : VD_Base
        {
            foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.CanWrite())
                {
                    var ov = prop.GetValue(target, null);
                    var nv = prop.GetValue(provider, null);
                    if (!ov.DbEqual(nv))
                    {
                        prop.SetValue(target, nv);
                    }
                }
            }
        }

        #endregion

        public static T CopyObject<T>(this T target) where T:VD_Base 
        {
            var entity = JsonHelper.CopyObject(target);
            entity.Id = Guid.NewGuid();
            return entity;
        }
        
    }
}
