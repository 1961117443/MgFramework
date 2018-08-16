using App.ViewModel;
using Chloe;
using Mg.Core;
using Mg.Core.IOC;
using Mg.DB.Untility;
using Mg.Framework;
using Mg.Framework.IService;
using Mg.Untility;
using Mg.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public abstract class BaseController : Controller
    {


        #region 构造函数
        public BaseController()
        {
            ViewBag.ts = DateTime.Now.ToString("yyyyMMddhhmmss");
            //Service = GetBLLService<IBaseService>();
            //FormsAuth.CheckFormsCookieExpires();
        }
        #endregion
        #region 属性

        protected virtual IDbContext GetDbContext()
        {
            return DbContextFactory.CreateContext();
        }
        /// <summary>
        /// 当前模块编号
        /// </summary>
        protected string MenuCode { get; set; }

        /// <summary>
        /// 当前控制器名称Controller
        /// </summary>
        protected string CurrentAreaName
        {
            get
            {
                // return RouteData.Route.GetRouteData(this.HttpContext).Values["controller"].ToString();
                return RouteData.Values["area"].ToString();
            }
        }
        /// <summary>
        /// 当前控制器名称Controller
        /// </summary>
        protected string CurrentControllerName
        {
            get
            {
                // return RouteData.Route.GetRouteData(this.HttpContext).Values["controller"].ToString();
                return RouteData.Values["controller"].ToString();
            }
        }
        /// <summary>
        /// 当前动作名称Action
        /// </summary>
        protected string CurrentActionName
        {
            get
            {
                //return RouteData.Route.GetRouteData(this.HttpContext).Values["action"].ToString();
                return RouteData.Values["action"].ToString();
            }
        }


        /// <summary>
        /// 获取当前系统登录用户
        /// </summary>
        //protected internal SysUser CurrentUser
        //{
        //    get
        //    {
        //        return (CurrentBaseLoginer.Data as JObject).ToObject<SysUser>();
        //    }
        //}

        /// <summary>
        /// 获取当前的登录用户者
        /// </summary>
        protected internal BaseLoginer CurrentBaseLoginer
        {
            get
            {
                return FormsAuth.GetBaseLoginerData();
            }
        }



        /// <summary>
        /// 获取当前系统登录用户的缓存
        /// </summary> 
        //protected ICacheProvider LocalCache
        //{
        //    get
        //    {
        //        if (!HttpContext.Items.Contains(ConstantSetting.UserCacheName))
        //        {
        //            HttpContext.Items.Add(ConstantSetting.UserCacheName, CacheProviderHelper.GetCacheProvider(Session.SessionID));
        //        }
        //        return (ICacheProvider)HttpContext.Items[ConstantSetting.UserCacheName];
        //    }
        //}

        protected virtual ICacheProvider GetSessionCache()
        {
            if (Session==null || Session.SessionID.IsEmpty())
            {
                return null;
            }
            return  CacheProviderHelper.GetCacheProvider(Session.SessionID);
        }

        #endregion

        /// <summary>
        /// 获取当前用户的菜单权限按钮
        /// </summary>
        /// <param name="menucode">菜单代码</param>
        /// <returns>dynamic</returns>
        protected dynamic GetUserMenuButtons(string menucode)
        {
            //  Base_MenuService.Instance.GetUserMenuButtons(this.CurrentBaseLoginer.UserId, menucode);
            return new List<string>();
        }


        #region Result
        /// <summary>
        /// 摘要: 创建一个将指定对象序列化为 JavaScript 对象表示法 (JSON) 的 System.Web.Mvc.JsonResult 对象。
        /// </summary>
        /// <param name="data">参数: data: 要序列化的 JavaScript 对象图。</param>
        /// <returns> 返回结果:将指定对象序列化为 JSON 格式的 JSON 结果对象。在执行此方法所准备的结果对象时，ASP.NET MVC 框架会将该对象写入响应。</returns>
        protected internal JsonResult JsonNet(object data)
        {
            return new JsonNetResult(data);
        } 

        /// <summary>
        /// 摘要: 创建一个将指定对象序列化为 JavaScript 对象表示法 (JSON) 的 System.Web.Mvc.JsonResult 对象。
        /// </summary>
        /// <param name="data">参数: data: 要序列化的 JavaScript 对象图。</param>
        /// <param name="behavior">指定是否允许来自客户端的 HTTP GET 请求。</param>
        /// <returns> 返回结果:将指定对象序列化为 JSON 格式的 JSON 结果对象。在执行此方法所准备的结果对象时，ASP.NET MVC 框架会将该对象写入响应。</returns>
        protected internal JsonResult JsonNet(object data, JsonRequestBehavior behavior)
        {
            return new JsonNetResult(data, behavior);
        }

        /// <summary>
        /// 创建Easyui的DataGrid格式数据
        /// </summary>
        /// <param name="rows">数据</param>
        /// <returns>dynamic</returns>
        protected Dictionary<string, object> CreateJsonData_DataGrid(int total, object rows)
        {
            //dynamic result = new ExpandoObject();
            //result.rows = rows;
            //result.total = total;
            //return result;
            return CreateJsonData_DataGrid(total, rows, null);
        }
        /// <summary>
        /// 创建Json数据，Easyui的DataGrid专用
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="rows">当前页记录数</param>
        /// <param name="footer">表格footer</param>
        /// <returns>字典Dictionary<string, object> </returns>
        protected Dictionary<string, object> CreateJsonData_DataGrid(int total, object rows, object footer)
        {
            Dictionary<string, object> dicData = new Dictionary<string, object>();
            dicData.Add("total", total);
            dicData.Add("rows", rows);
            if (footer != null)
            {
                dicData.Add("footer", footer);
            }
            return dicData;
        }

        protected LayuiDataTable CreateJsonData_DataTable(int total, object rows)
        {
            LayuiDataTable layuiData = new LayuiDataTable()
            {
                count = total,
                data = rows
            };
            return layuiData;
        }
        #endregion

        #region BLL
        /// <summary>
        /// 获取业务逻辑访问层
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected static T GetService<T>()
        {
            return DIFactory.GetService<T>();
        }
        /// <summary>
        /// 获取业务逻辑层
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static IBaseService GetService(Type type)
        {
            return DIFactory.GetService(typeof(IAppService<>).MakeGenericType(type)) as IBaseService;
        }

        #endregion

       
    }
}