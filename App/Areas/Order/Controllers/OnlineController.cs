using App.Controllers;
using App.ViewModel;
using Mg.Core;
using Mg.Framework.IService;
using Mg.Logger;
using Mg.Web.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace App.Areas.Order
{
    [SysModule("00000000-0000-0000-0000-000000000000")]
    public partial class OnlineController : BaseController
    {
        private static readonly string NewItemMark = "A*";
        protected ILogger log = new Mg.Untility.Logger.LoggerBase(typeof(OnlineController));


        /// <summary>
        /// 模块属性
        /// </summary>        
        public IModule CustomModule { get;protected set; }

        public ActionResult Index()
        {
            CustomModule.DataState = (int)DataState.Browse;
            CustomModule.ModuleType = ModuleType.Browse;
            return View(CustomModule);
        }

        // GET: Order/Online       
        public ActionResult List()
        {
            return View();
        }
        


        // GET: Order/Online/Create
        public ActionResult Create()
        {
            return RedirectToAction("Detail", "Online", new { id = Guid.Empty,ds = (int)DataState.New });
        }
 
         

        /// <summary>
        /// 编辑订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Order/Online/Edit/5
        //[HttpGet]
        //[Obsolete]
        //public ActionResult Edit(string id)
        //{
        //    var key = $"{typeof(OnlineController).FullName}_Edit";
        //    //var key = $"{Session.SessionID}_Edit";
        //  //  Session[key] = null;
        //    LocalCache[key] = null;
        //    //GetCache().Remove(key);
        //    using (var service = GetService<ISalesOrderService>())
        //    {
        //        VD_SalesOrder entity = new VD_SalesOrder();
        //        entity.Id = Guid.Parse(id);
        //        entity = service.GetOrder(entity);
        //        List<VD_SalesOrderDetail> list = service.GetOrderDetail(entity);
        //        if (list.Count() > 0)
        //        {
        //            //foreach (VD_SalesOrderDetail item in list)
        //            //{ 
        //            //}
        //           // Session[key] = list;

        //            LocalCache[key] = list;
        //        }
        //        entity.OrderItems = list;

        //        return View("LayerEdit",entity);
        //    }

        //}

        /// <summary>
        /// 编辑订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Order/Online/Edit/5
        [HttpGet]
        public ActionResult Detail(string id, int ds)
        {
            var key = $"{typeof(OnlineController).FullName}_Edit";
            //LocalCache[key] = null;
            GetSessionCache()[key] = null;

            var service = GetService<ISalesOrderService>();
            VD_SalesOrder entity = new VD_SalesOrder();
            entity.Id = Guid.Parse(id);
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.OrderDate = DateTime.Now;
                entity.AluminumPriceDate = DateTime.Now;
                entity.AcceptDate = DateTime.Now.AddDays(20); 
            }
            else
            {
                entity = service.GetOrder(entity);
            }
            List<VD_SalesOrderDetail> list = service.GetOrderDetail(entity);
            if (list.Count() > 0)
            {
                //LocalCache[key] = list;
                GetSessionCache()[key] = list;
            }
            entity.OrderItems = list;
            CustomModule.DataState = ds;// DataState.Browse;
            CustomModule.ModuleType = ModuleType.Edit;
            ViewData["CustomModule"] = CustomModule;
            return View(entity);

        }


        /// <summary>
        /// 显示单个明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditItem(string id)
        {
            var key = $"{typeof(OnlineController).FullName}_Edit";
            var list = GetSessionCache()[key] as List<VD_SalesOrderDetail>; // ?? new List<VD_SalesOrderDetail>();
            var entity = list.FirstOrDefault(w => w.Id.ToString() == id);
            entity = entity ?? new VD_SalesOrderDetail();
            return View(entity);
        }
        /// <summary>
        /// 添加订单明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateItem()
        {
            var entity = new VD_SalesOrderDetail();
            entity.SalesOrderTraceCode = NewItemMark;
            entity.Id = Guid.NewGuid();
            return View("EditItem", entity);
        }



        
    }
}
