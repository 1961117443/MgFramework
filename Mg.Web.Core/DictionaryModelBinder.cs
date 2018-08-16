using Mg.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mg.Web.Core
{
    /// <summary>
    /// Dictionary<string, string> 做参数
    /// </summary>
    public class DictionaryModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            IDictionary<string, string> dicts = controllerContext.RequestContext.HttpContext.Request.QueryString.ToDictionary();
            return dicts;
        }
    }
}
