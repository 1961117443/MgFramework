using App.Controllers;
using App.ViewModel;
using Mg.Core;
using Mg.Framework;
using Mg.Framework.IService;
using Mg.IOSerialize.Serialize;
using Mg.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace App.Areas.Sys.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Sys/Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit", "Menu", new { id = Guid.Empty });
        }
        public ActionResult Edit(string id)
        {
            using (var service = GetService<ISys_MenuService>())
            {
                VD_Sys_Menu entity = null;
                Guid ID = Guid.Empty;
                Guid.TryParse(id, out ID);
                if (ID == Guid.Empty)
                {
                    entity = new VD_Sys_Menu();
                    entity.Enabled = 1;
                    entity.MenuType = 2;
                    entity.ButtonMode = 1;
                    entity.Url = "#"; 
                }
                else
                {
                    entity = service.GetMenu(ID);
                } 
                return View(entity);
            } 
        }

        public ActionResult ShowDialog()
        {
            //IBillViewModel model = new BillViewModel();
            ////model.ToolBarHtml = "<a id=\"btn_ok\" href=\"#\" class=\"easyui-linkbutton\" data-options=\"iconCls:'bill-ok'\">确定</a>";
            //model.ColumnsHtml =
            // "<th hidden=\"hidden\" data-options=\"field:'Id'\"></th>"
            //+ "<th data-options=\"field:'MenuCode'\">菜单代码</th>"
            //+ "<th data-options=\"field:'MenuName'\">菜单名称</th>";

            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("<div data-options=\"name: 'MenuCode', selected: true\">菜单代码</div>");
            //stringBuilder.Append("<div data-options=\"name: 'MenuName'\">菜单名称</div>"); 
            //model.QuickSearchItemHtml = stringBuilder.ToString();
            //model.PageSize = 10;
            //model.GetListUrl = "/Sys/Menu/GetList";

            IBillViewModel model = new BillViewModel();
            //model.ToolBarHtml = "<a id=\"btn_ok\" href=\"#\" class=\"easyui-linkbutton\" data-options=\"iconCls:'bill-ok'\">确定</a>";
            model.ColumnsHtml =
             "<th hidden=\"hidden\" data-options=\"field:'Id'\"></th>"
            + "<th data-options=\"field:'MenuCode'\">菜单代码</th>"
            + "<th data-options=\"field:'MenuName'\">菜单名称</th>";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<div data-options=\"name: 'MenuCode', selected: true\">菜单代码</div>");
            stringBuilder.Append("<div data-options=\"name: 'MenuName'\">菜单名称</div>"); 
            model.QuickSearchItemHtml = stringBuilder.ToString();
            model.PageSize = 10;
            model.GetListUrl = "/Sys/Menu/GetList";
            return View("ShowChooseList", model);
            //return View("~/Areas/BaseData/Views/Shared/ShowChooseList.cshtml", model);
        } 


        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Order/Online/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            if (!collection.HasKeys())
            {
                return JsonNet(CommandResult.Instance_Error);
            }
            try
            {
                var js = JsonHelper.ToJson(collection.ToDictionary());

                var entity = JsonHelper.ToObject<VD_Sys_Menu>(js); 
                // TODO: Add update logic here 

                using (var service = GetService<ISys_MenuService>())
                {
                    if (!service.SaveMenu(entity))
                    {
                        return JsonNet(CommandResult.Instance_Error);
                    }
                }
                return JsonNet(CommandResult.Instance_Succeed);
            }
            catch
            {
                return JsonNet(CommandResult.Instance_Error);
            }
        }
        
        public ActionResult GetList()
        {
            Expression<Func<VD_Sys_Menu, bool>> where = null;
            using (var service = GetService<ISys_MenuService>())
            { 
                var list = service.GetMenus(where);
                return JsonNet(CreateJsonData_DataGrid(list.Count, list));
            }
        }
    }
}