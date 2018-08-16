using Mg.IOSerialize.Serialize;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    /// <summary>
    /// 定义自JsonResult对象JsonNetResult
    /// </summary>
    public class JsonNetResult : JsonResult
    {
        #region JsonNetResult构造函数
        public JsonNetResult() { }

        public JsonNetResult(object data) : this(data, JsonRequestBehavior.AllowGet, "text/html", Encoding.UTF8)
        {

        }

        public JsonNetResult(object data, JsonRequestBehavior behavior) : this(data, behavior, "text/html", Encoding.UTF8)
        {

        }

        public JsonNetResult(object data, JsonRequestBehavior behavior, string contentType) : this(data, behavior, contentType, Encoding.UTF8)
        {
        }

        public JsonNetResult(object data, JsonRequestBehavior behavior, string contentType, Encoding contentEncoding)
        {
            this.Data = data;
            this.JsonRequestBehavior = behavior;
            this.ContentEncoding = contentEncoding;
            this.ContentType = contentType;
        } 
        #endregion

        /// <summary>
        /// 获取json序列化是日期格式方式。
        /// </summary>
        protected IsoDateTimeConverter IsoDateTimeConverter
        {
            get
            {
                return new IsoDateTimeConverter()
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    DateTimeStyles = System.Globalization.DateTimeStyles.AllowInnerWhite
                };
            }
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("JSON GET is not allowed");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;

            var json = JsonHelper.ToJson(this.Data, Formatting.Indented, this.IsoDateTimeConverter);
            response.Write(json);
        }
    }
}