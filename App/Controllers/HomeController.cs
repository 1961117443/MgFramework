using Mg.Untility.Web;
using Mg.Core;
using Mg.Framework.IService;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mg.Web.Core;
using Mg.Web.Core.Filters;
using App.ViewModel;
using Mg.Core.IOC;
using Unity.Resolution;

namespace App.Controllers
{
    [Authorization] 
    public class HomeController : BaseController
    {
         
        public ActionResult HomePage()
        {
            var loginer = FormsAuth.GetBaseLoginerData();
            ViewBag.Title = "MangoGreen";
            ViewBag.UserId = loginer.UserId;
            ViewBag.UserCode = loginer.UserCode;
            ViewBag.UserName = loginer.UserName;

            ViewBag.LoginUser = loginer.UserName;
            return View();
        } 

        public JsonResult CreateNavs(string code)
        {
            var server = GetService<ISys_MenuService>();
            LayuiMenu[] menus = server.GetChildMenus(code);
            return JsonNet(menus, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var loginer = FormsAuth.GetBaseLoginerData();
            ViewBag.Title = "MangoGreen";
            ViewBag.UserId = loginer.UserId;
            ViewBag.UserCode = loginer.UserCode;
            ViewBag.UserName = loginer.UserName;

            ViewBag.LoginUser = loginer.UserName;

           
            //var server = GetService<ISys_MenuService>();
            // var userSettings = Base_UserService.Instance.GetCurrentUserSettings();
            var userSettings = new Dictionary<string, string>();
            userSettings.Add("navigation", "menubutton1");
            userSettings.Add("theme", "bootstrap");
            ViewBag.Settings = userSettings;
            ViewBag.EasyuiTheme = userSettings["theme"].ToString();
            ViewBag.EasyuiVersion = ConfigUtil.GetConfigString("EasyuiVersion");//easyui版本
            ViewBag.SystemVersion = ConfigUtil.GetConfigString("SystemVersion");//系统版本
            CookiesUtil.WriteCookies("EasyuiTheme", 0, userSettings["theme"].ToString());
            CookiesUtil.WriteCookies("EasyuiVersion", 0, ConfigUtil.GetConfigString("EasyuiVersion"));
            var server = GetService<ISys_MenuService>();
            var list = server.GetUserMenus(loginer);
            var model = new
            {
                userSettings = userSettings,
                UserId = loginer.UserId,
                UserCode = loginer.UserCode,
                UserName = loginer.UserName,
                UserMenus = list
            };
            return View(model);
        }

         

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Portal()
        {
            return View();
        }
    }
}