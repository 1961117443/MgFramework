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
    public class CustomerController : BaseController
    {
        


        // GET: BaseData/Customer
        public ActionResult List()
        { 
            return View();
        }

        public ActionResult GetList()
        {
            using (ICustomerService server = GetService<ICustomerService>())
            {
                Expression<Func<VD_Customer, bool>> where = null; 
                if (!Request.QueryString["keyword"].IsEmpty())
                {
                    var qs = JsonHelper.ToObject<List<QuickSearch>>(Request.QueryString["keyword"]);
                    var props = typeof(VD_Customer).GetPropertiesEx();
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
                    PageSize = Request.QueryString["rows"].IsEmpty() ? Request.QueryString["limit"].IsEmpty() ? 20 : int.Parse(Request.QueryString["limit"]):int.Parse(Request.QueryString["rows"])
                };
                var list= server.GetList(where, ref pageinfo);
                return JsonNet(CreateJsonData_DataTable(pageinfo.RowCount, list));
                //return JsonNet(CreateJsonData_DataGrid(pageinfo.RowCount, list));
            }
        }

        public ActionResult ShowDialog()
        {
            IBillViewModel model = new BillViewModel();
            //model.ToolBarHtml = "<a id=\"btn_ok\" href=\"#\" class=\"easyui-linkbutton\" data-options=\"iconCls:'bill-ok'\">确定</a>";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<div data-options=\"name: 'Code', selected: true\">客户编号</div>");
            stringBuilder.Append("<div data-options=\"name: 'Name'\">客户名称</div>");
            model.QuickSearchItemHtml = stringBuilder.ToString();
            model.PageSize = 10;
            return View("List",model);
        }

        public ActionResult Dialog()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<option value='Code', selected= true\">客户编号</option>");
            stringBuilder.Append("<option value='Name'\">客户名称</option>");
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
            ColumnProerty.Add("field", "Code");
            ColumnProerty.Add("title", "客户编号");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            // 型材名称
            ColumnProerty = new Dictionary<string, object>();
            ColumnProerty.Add("field", "Name");
            ColumnProerty.Add("title", "客户名称");
            ColumnProerty.Add("sort", true);
            columns.Add(ColumnProerty);
            ViewData["ViewColumn"] = columns;
            ViewData["DataUrl"] = "/BaseData/Customer/GetList";

            return View();
        }
    }
}