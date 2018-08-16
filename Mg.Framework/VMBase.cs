using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework
{
 
    public abstract class VMBase
    {
        public virtual bool DbEqual(object obj, object targetObj)
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
    }
    public class VMBase<V, M> : VMBase
        where V : VD_Base
        where M : BaseModel
    {
        static VMBase()
        {
            _ViewProps = typeof(V).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            _ModelProps = typeof(M).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        #region 属性
        public V View { get; set; }
        public M Model { get; set; }
        public VMBase()
        {

        }
        public VMBase(V v)
        {
            View = v;
        }
        public VMBase(V v,M m):this(v)
        {
            Model = m;
        }
        private static PropertyInfo[] _ViewProps;
        /// <summary>
        /// UI模型的公共属性
        /// </summary>
        public PropertyInfo[] ViewProps
        {
            get
            {
                return _ViewProps;
            }
        }
        /// <summary>
        /// 实体模型的公共属性
        /// </summary>
        private static PropertyInfo[] _ModelProps;
        public PropertyInfo[] ModelProps
        {
            get
            {
                return _ModelProps;
            }
        } 
        #endregion

        protected virtual M MapTo(M target, V data)
        { 
            foreach (var p in _ViewProps)
            {
                var tp = _ModelProps.FirstOrDefault(w => w.Name == p.Name);
                if (tp != null)
                {
                    var ov = tp.GetValue(target, null);
                    var nv = p.GetValue(data, null);
                    if (!DbEqual(ov,nv))
                    {
                        tp.SetValue(target, nv);
                    }
                }
            }
            return target;
        }

       

    }
}
