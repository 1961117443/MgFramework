using Mg.Web.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "HomePage", id = UrlParameter.Optional }
            );

            //MVC添加自定义参数模型绑定ModelBinder
            ModelBinders.Binders.Add(typeof(JObject), new JObjectModelBinder()); //for dynamic model binder
            ModelBinders.Binders.Add(typeof(IDictionary<string, string>), new DictionaryModelBinder());
        }
    }
}
