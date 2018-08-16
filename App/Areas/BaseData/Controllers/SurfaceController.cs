using App.Controllers;
using App.ViewModel;
using Mg.Framework;
using Mg.Framework.IService;
using Mg.IOSerialize.Serialize;
using Mg.Untility;
using Mg.Untility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace App.Areas.BaseData.Controllers
{
    public class SurfaceController : BaseController
    {
        // GET: BaseData/Surface 
       

        [HttpGet]
        public ActionResult GetList()
        {
            using (ISurfaceService server = GetService<ISurfaceService>())
            {
                Expression<Func<VD_Surface, bool>> where = null;
                if (!Request.QueryString["keyword"].IsEmpty())
                {
                    var qs = JsonHelper.ToObject<List<QuickSearch>>(Request.QueryString["keyword"]);
                    var props = typeof(VD_Surface).GetPropertiesEx();
                    foreach (var q in qs)
                    {
                        if (!q.SearchValue.IsEmpty())
                        {
                            var p = props.FirstOrDefault(w => w.Name == q.FieldName);
                            if (p != null)
                            {
                                switch (p.Name)
                                {
                                    case "SurfaceCode":
                                        where = where.And(w => w.SurfaceCode.Contains(q.SearchValue));
                                        break;
                                    case "SurfaceName":
                                        where = where.And(w => w.SurfaceName.Contains(q.SearchValue));
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                var pageinfo = new PageInfo()
                {
                    PageIndex = Request.QueryString["page"].IsEmpty() ? 1 : int.Parse(Request.QueryString["page"]),
                    PageSize = Request.QueryString["rows"].IsEmpty() ? 20 : int.Parse(Request.QueryString["rows"])
                };
                var list = server.GetList(where, ref pageinfo);
                return JsonNet(CreateJsonData_DataTable(pageinfo.RowCount, list));
            }
        }

        public ActionResult ShowDialog()
        {
            IBillViewModel model = new BillViewModel();
            //model.ToolBarHtml = "<a id=\"btn_ok\" href=\"#\" class=\"easyui-linkbutton\" data-options=\"iconCls:'bill-ok'\">确定</a>";
            model.ColumnsHtml= 
             "<th hidden=\"hidden\" data-options=\"field:'Id'\"></th>"
            +"<th data-options=\"field:'SurfaceCode'\">表面方式编码</th>"
            + "<th data-options=\"field:'SurfaceName'\">表面方式名称</th>"
            + "<th data-options=\"field:'SurfaceCategoryID_Name'\">表面类别</th>";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<option value='SurfaceCode', selected: true\">编号</option>");
            stringBuilder.Append("<option value='SurfaceName'\">名称</option>");
            stringBuilder.Append("<option value='SurfaceCategoryID_Name'\">类别</option>");
            model.QuickSearchItemHtml = stringBuilder.ToString();
            model.PageSize = 10;
            model.GetListUrl = "/BaseData/Surface/GetList";
            return View("ShowChooseList", model);
        }

        public ActionResult Dialog()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<option value='SurfaceCode', selected: true\">编号</option>");
            stringBuilder.Append("<option value='SurfaceName'\">名称</option>");
            stringBuilder.Append("<option value='SurfaceCategoryID_Name'\">类别</option>");
            ViewData["QuickSearchColumn"] = stringBuilder.ToString();

            // dynamic ColumnProerty = new { field= "Id", title="ID", width= 40, checkbox= true, "fixed"= true }
            List<object> columns = new List<object>();
            Dictionary<string, object> ColumnProerty = null;
            //Id
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "Id");
            ColumnProerty.Add("width", 40);
            ColumnProerty.Add("checkbox", true);
            ColumnProerty.Add("fixed", true);
            columns.Add(ColumnProerty);
            // 型材型号
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "SurfaceCode");
            ColumnProerty.Add("title", "表面编号");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 型材名称
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "SurfaceName");
            ColumnProerty.Add("title", "表面名称");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 型材名称
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "SurfaceCategoryID_Name");
            ColumnProerty.Add("title", "表面类别");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            ViewData["ViewColumn"] = columns;
            ViewData["DataUrl"] = "/BaseData/Surface/GetList";
            return View();
        }
    }
}