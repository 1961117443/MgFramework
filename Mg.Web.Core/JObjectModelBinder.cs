using Mg.IOSerialize.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mg.Web.Core
{
    /// <summary>
    /// JObject 做参数
    /// </summary>
    public class JObjectModelBinder : IModelBinder //System.Web.Mvc
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var vv = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var stream = controllerContext.RequestContext.HttpContext.Request.InputStream;
            stream.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(stream).ReadToEnd();

            return JsonHelper.ToObject<dynamic>(json);
        }
    }
}
