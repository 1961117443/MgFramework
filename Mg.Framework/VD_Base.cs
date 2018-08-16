
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework
{
    public class VD_Base 
    { 
        public virtual Guid Id { get; set; } 
        public virtual long AutoID { get; set; }

        [JsonIgnore]
        private PropertyCollection _ExtendedProperties = new PropertyCollection();
        [JsonIgnore]
        public PropertyCollection ExtendedProperties { get { return _ExtendedProperties; } }
    }

    //public class VD_Base<T> :VD_Base where T:BaseModel
    //{
    //    static VD_Base()
    //    {
    //        _ModelProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance); 
    //    }

    //    /// <summary>
    //    /// 实体模型的公共属性
    //    /// </summary>
    //    private static PropertyInfo[] _ModelProps;
    //    public PropertyInfo[] ModelProps
    //    {
    //        get
    //        {
    //            return _ModelProps;
    //        }
    //    }

    //    public T GetModel()
    //    {
    //        return default(T);
    //    }
    //}


}
