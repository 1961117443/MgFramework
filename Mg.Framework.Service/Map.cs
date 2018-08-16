using Mg.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.Service
{
    /// <summary>
    /// UI模型映射数据实体
    /// </summary>
    /// <typeparam name="TV"></typeparam>
    /// <typeparam name="TD"></typeparam>
    public class Map<TV,TD>
        where TV:VD_Base
        where TD:BaseModel,new()
    {
        static Map()
        {
            _ViewProps = typeof(TV).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            _ModelProps = typeof(TD).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        #region 属性
        public TV View { get; set; }
         
        public TD Model { get; set; }
        public Map()
        {

        }
        public Map(TV v)
        {
            View = v;
        }
        public Map(TV v, TD m):this(v)
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

        #region 获取实体类型
        /// <summary>
        /// 获取实体类型
        /// </summary>
        /// <returns></returns>
        public virtual TD Resolve()
        {
            if (View == null)
            {
                throw new ArgumentNullException("View");
            }
            return Resolve(View);
        }
        public virtual TD Resolve(TV tV)
        {
            if (tV == null)
            {
                throw new ArgumentNullException("tV");
            }
            var m = DB.Untility.DbContextFactory.CreateContext().Query<TD>().Where(w => w.Id == tV.Id).FirstOrDefault();
            m = m ?? new TD();// default(TD);
            return Resolve(tV, m);
        }

        public virtual TD Resolve(TV v, TD m)
        {
            if (v == null)
            {
                throw new ArgumentNullException("v");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            var vp = _ViewProps;
            if (v.ExtendedProperties.ContainsKey(ConstantSetting.TraceFieldCollection))
            {
                var keys = v.ExtendedProperties[ConstantSetting.TraceFieldCollection] as string[];
                vp = vp.Where(w => keys.Contains(w.Name)).ToArray();
            }
            foreach (var p in vp)
            {
                var tp = _ModelProps.FirstOrDefault(w => w.Name == p.Name);
                if (tp != null)
                {
                    var ov = tp.GetValue(m, null);
                    var nv = p.GetValue(v, null);
                    if (!DbEqual(ov, nv))
                    {
                        tp.SetValue(m, nv);
                    }
                }
            }
            return m;
        }

        public virtual bool Compare(TV v, TD m)
        {
            bool ifChange = false;
            if (v == null)
            {
                throw new ArgumentNullException("v");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            foreach (var p in _ViewProps)
            {
                var tp = _ModelProps.FirstOrDefault(w => w.Name == p.Name);
                if (tp != null)
                {
                    var ov = tp.GetValue(m, null);
                    var nv = p.GetValue(v, null);
                    if (!DbEqual(ov, nv))
                    {
                        tp.SetValue(m, nv);
                        ifChange = true;
                    }
                }
            }
            if (ifChange)
            {
                Model = m;
            }
            else
            {
                Model = null;
            }
            Model = m;
            return ifChange;
        }
        #endregion


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
}
