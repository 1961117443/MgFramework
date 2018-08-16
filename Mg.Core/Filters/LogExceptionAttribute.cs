using Mg.Logger;
using Mg.Untility.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mg.Core.Filters
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class LogExceptionAttribute : HandleErrorAttribute
    {
        private ILogger log = new LoggerBase(typeof(LogExceptionAttribute));
        public override void OnException(ExceptionContext filterContext)
        { 
            if (!filterContext.ExceptionHandled)//异常有没有被处理过
            {
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];
                string msgTemplate = "在执行 controller[{0}] 的 action[{1}] 时产生异常";
                log.Error(string.Format(msgTemplate, controllerName, actionName), filterContext.Exception);

                if (filterContext.HttpContext.Request.IsAjaxRequest())//检查请求头 是不是XMLHttpRequest
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new CommandResult()
                        {
                            ResultID = -1,
                            ResultMsg = "系统出现异常，请联系管理员",
                            ResultData = "系统出现异常，请联系管理员" // filterContext.Exception.Message
                        }//这个就是返回的结果
                    };
                }
                else
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
                    };
                }
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
