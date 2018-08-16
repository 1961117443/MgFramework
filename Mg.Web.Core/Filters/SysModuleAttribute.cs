using App.ViewModel;
using Mg.Cache;
using Mg.Core.IOC;
using Mg.Framework.IService;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity.Resolution;

namespace Mg.Web.Core.Filters
{
    public class SysModuleAttribute: ActionFilterAttribute
    {
        public string SysModuleID { get;private set; }

        public SysModuleAttribute(string Id)
        {
            SysModuleID = Id;
        }

       
       

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var p = filterContext.Controller.GetType().GetProperties().FirstOrDefault(w => w.PropertyType.Equals(typeof(IModule)));
            if (p!=null)
            {
                //string[] keys = new string[2];
                //keys[0] = filterContext.RouteData.DataTokens.ContainsKey("area") ? filterContext.RouteData.DataTokens["area"].ToString() : "";
                //keys[1] = filterContext.RouteData.Values.ContainsKey("controller") ? filterContext.RouteData.Values["controller"].ToString() : "";
                var key = SysModuleID.ToString();// string.Join("_", keys);
                IModule module = CacheHelper.TryGet(key, () => CreateModule());
                p.SetValue(filterContext.Controller, module);
            }
           
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 构建模块
        /// </summary>
        /// <returns></returns>
        protected virtual IModule CreateModule()
        {
            IModule module = new BaseModule(Guid.Parse(SysModuleID));
            CreateButton(module);
            return module;
        }
        /// <summary>
        /// 工具栏所有按钮
        /// </summary>
        /// <param name="module"></param>
        protected virtual void CreateButton(IModule module)
        {
            var server = DIFactory.GetService<ISysModuleService>();
            module.Buttons= server.GetButton(module);
        }
    }
}
