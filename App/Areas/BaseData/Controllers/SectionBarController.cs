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
    public class SectionBarController : BaseController
    {
        // GET: BaseData/SectionBar
        [HttpGet]
        public ActionResult GetList()
        {
            using (ISectionBarService server = GetService<ISectionBarService>())
            {
                Expression<Func<VD_SectionBar, bool>> where = null;
                if (!Request.QueryString["keyword"].IsEmpty())
                {
                    var qs = JsonHelper.ToObject<List<QuickSearch>>(Request.QueryString["keyword"]);
                    var props = typeof(VD_SectionBar).GetPropertiesEx();
                    foreach (var q in qs)
                    {
                        if (!q.SearchValue.IsEmpty())
                        {
                            var p = props.FirstOrDefault(w => w.Name == q.FieldName);
                            if (p != null)
                            {
                                switch (p.Name)
                                {
                                    case "Code":
                                        where = where.And(w => w.Code.Contains(q.SearchValue));
                                        break;
                                    case "Name":
                                        where = where.And(w => w.Name.Contains(q.SearchValue));
                                        break;
                                    case "CustomerCode":
                                        where = where.And(w => w.CustomerCode.Contains(q.SearchValue));
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
                    PageSize = Request.QueryString["limit"].IsEmpty() ? 20 : int.Parse(Request.QueryString["limit"])
                };
               var list = server.GetList(where, ref pageinfo);
                return JsonNet(CreateJsonData_DataTable(pageinfo.RowCount, list));
              //  return JsonNet(CreateJsonData_DataGrid(pageinfo.RowCount, list));
            }
        }

        public ActionResult ShowDialog()
        {
            IBillViewModel model = new BillViewModel();
            //model.ToolBarHtml = "<a id=\"btn_ok\" href=\"#\" class=\"easyui-linkbutton\" data-options=\"iconCls:'bill-ok'\">确定</a>";
            model.ColumnsHtml =
             "<th hidden=\"hidden\" data-options=\"field:'Id'\"></th>"
            + "<th data-options=\"field:'Code'\">型材型号</th>"
            + "<th data-options=\"field:'Name'\">型材名称</th>"
            + "<th data-options=\"field:'SectionBarCategoryID_SectionBarCategoryName'\">型材类别</th>"
            + "<th data-options=\"field:'CustomerCode'\">客户型号</th>"
            + "<th data-options=\"field:'WallThickness'\">壁厚</th>"
            + "<th data-options=\"field:'Theoreticalweight'\">理论米重</th>"
            + "<th data-options=\"field:'HeatInsulationList'\">隔热料清单</th>";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<div data-options=\"name: 'Code', selected: true\">型材型号</div>");
            stringBuilder.Append("<div data-options=\"name: 'Name'\">型材名称</div>");
            stringBuilder.Append("<div data-options=\"name: 'CustomerCode'\">客户型号</div>");
            model.QuickSearchItemHtml = stringBuilder.ToString();
            model.PageSize = 10;
            model.GetListUrl = "/BaseData/SectionBar/GetList";
            return View("ShowChooseList", model);
        }


        public ActionResult Dialog()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<option value='Code', selected: true\">型材型号</option>");
            stringBuilder.Append("<option value='Name'\">型材名称</option>");
            stringBuilder.Append("<option value='CustomerCode'\">客户型号</option>");
            ViewData["QuickSearchColumn"] = stringBuilder.ToString();

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
            ColumnProerty.Add("field", "Code");
            ColumnProerty.Add("title", "型材型号");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 型材名称
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "Name");
            ColumnProerty.Add("title", "型材名称");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 客户型号
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "CustomerCode");
            ColumnProerty.Add("title", "客户型号");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 型材类别
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "SectionBarCategoryID_SectionBarCategoryName");
            ColumnProerty.Add("title", "型材类别");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 壁厚
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "WallThickness");
            ColumnProerty.Add("title", "壁厚");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 型材类别
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "Theoreticalweight");
            ColumnProerty.Add("title", "理论米重");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 壁厚
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "HeatInsulationList");
            ColumnProerty.Add("title", "隔热料清单");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            ViewData["ViewColumn"] = columns;
            ViewData["DataUrl"] = "/BaseData/SectionBar/GetList";
            return View();
        }
        
    }
}