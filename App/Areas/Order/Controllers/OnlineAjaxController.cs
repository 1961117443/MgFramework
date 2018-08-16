using App.Controllers;
using Mg.Framework.IService;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using App.ViewModel;
using Chloe;
using Mg.Untility;
using Mg.DB.Untility;
using Mg.IOSerialize.Serialize;
using Mg.Core;
using Mg.Untility.Extensions;
using Newtonsoft.Json.Linq;
using Mg.Framework;

namespace App.Areas.Order
{
    public partial class OnlineController
    {

        /// <summary>
        /// 获取订单列表数据
        /// </summary>
        /// <returns></returns>
       // [HttpGet]
        //public ActionResult GetList()
        //{ 
        //    using (var service = GetService<ISalesOrderService>())
        //    {
        //        Expression<Func<VD_SalesOrder, bool>> where = null;
        //        if (!Request.QueryString["keyword"].IsEmpty())
        //        {
        //            var qs = JsonHelper.ToObject<List<QuickSearch>>(Request.QueryString["keyword"]);
        //            var props = typeof(VD_SalesOrder).GetPropertiesEx();
        //            foreach (var q in qs)
        //            {
        //                if (!q.SearchValue.IsEmpty())
        //                {
        //                    var p = props.FirstOrDefault(w => w.Name == q.FieldName);
        //                    if (p != null)
        //                    {
        //                        if (p.Name == "BillCode")
        //                        {
        //                            where = where.And(w => w.BillCode == q.SearchValue);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        var pageinfo = new PageInfo()
        //        {
        //            PageIndex = Request.QueryString["page"].IsEmpty() ? 1 : int.Parse(Request.QueryString["page"]),
        //            PageSize = Request.QueryString["rows"].IsEmpty() ? 20 : int.Parse(Request.QueryString["rows"])
        //        };
        //        var list = service.GetList(where, ref pageinfo);
        //        return JsonNet(CreateJsonData_DataGrid(pageinfo.RowCount, list));
        //    }
        //}

        /// <summary>
        /// 获取订单列表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetList()
        {
            var service = GetService<ISalesOrderService>();
            Expression<Func<VD_SalesOrder, bool>> where = null;
            if (!Request.QueryString["keyword"].IsEmpty())
            {
                var qs = JsonHelper.ToObject<List<QuickSearch>>(Request.QueryString["keyword"]);
                var props = typeof(VD_SalesOrder).GetPropertiesEx();
                foreach (var q in qs)
                {
                    if (!q.SearchValue.IsEmpty())
                    {
                        var p = props.FirstOrDefault(w => w.Name == q.FieldName);
                        if (p != null)
                        {
                            if (p.Name == "BillCode")
                            {
                                where = where.And(w => w.BillCode == q.SearchValue);
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
            var list = service.GetList(where, ref pageinfo);
            return JsonNet(CreateJsonData_DataTable(pageinfo.RowCount, list));
        }

        /// <summary>
        /// 显示订单从表信息(列表)
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderItem()
        {
           
            var key = $"{typeof(OnlineController).FullName}_Edit"; 
            var list = GetSessionCache().TryGet(key, () => new List<VD_SalesOrderDetail>());
            //显示合计行
            JArray jArray = new JArray();
            JObject jObject = new JObject();
            jObject.Add("Id", "合计");
            jObject.Add("TotalQuantity", list.Sum(w => w.TotalQuantity));
            jObject.Add("TheoryWeight", list.Sum(w => w.TheoryWeight));
            jArray.Add(jObject);
            return JsonNet(CreateJsonData_DataTable(list.Count(),list));
            //return JsonNet(CreateJsonData_DataGrid(list.Count(), list, jArray));
        }

        /// <summary>
        /// 修改订单明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditItem(string id, FormCollection collection)
        {
            if (!collection.HasKeys())
            {
                return JsonNet(CommandResult.Instance_Error);
            }
            var js = JsonHelper.ToJson(collection.ToDictionary());
            var entity = JsonHelper.ToObject<VD_SalesOrderDetail>(js);
            if (entity != null)
            {
                if (entity.SurfaceID_Name.IsEmpty())
                {
                    entity.SurfaceID = Guid.Empty;
                }
                if (entity.SectionBarID_Code.IsEmpty())
                {
                    entity.SectionBarID = Guid.Empty;
                }
                if (entity.PackingID_PackingName.IsEmpty())
                {
                    entity.PackingID = Guid.Empty;
                }


                var items = new List<VD_SalesOrderDetail>();
                items.Add(entity);
                //获取session中从表的数据
                 var key = $"{typeof(OnlineController).FullName}_Edit";
                var list = GetSessionCache().TryGet(key, () => new List<VD_SalesOrderDetail>());// Session[key] as List<VD_SalesOrderDetail> ?? new List<VD_SalesOrderDetail>();

                //获取子材
                using (var app = GetService<ISectionBarService>())
                {
                    var childList = app.GetHeatInsulationList(entity.SectionBarID);
                    for (int i = 0; i < childList.Count; i++)
                    {
                        var newItem = entity.CopyObject(); 
                        newItem.SalesOrderTraceCode = $"{newItem.SalesOrderTraceCode}-{(i + 1).ToString().PadLeft(2, '0')}";
                        newItem.SectionBarID = childList[i].Id;
                        newItem.SectionBarID_Code = childList[i].Code;
                        newItem.SectionBarID_Name = childList[i].Name;
                        newItem.WallThickness = childList[i].WallThickness;
                        newItem.TheoryMeter = childList[i].Theoreticalweight;
                        newItem.InID = entity.Id;
                        items.Add(newItem);
                    }
                }

                foreach (var item in items)
                {
                    decimal l = 0;
                    if (!item.OrderLength.IsEmpty())
                    {
                        if (decimal.TryParse(item.OrderLength, out l))
                        {
                            item.OrderLength = l.ToString("#.####");
                        }
                    }
                    item.Theory6Meter = Math.Round(item.TheoryMeter.HasValue ? item.TheoryMeter.Value * l : 0, 3);
                    item.TheoryWeight = item.Theory6Meter * item.TotalQuantity;
                    if (item.TheoryWeight.HasValue)
                    {
                        item.TheoryWeight = Math.Round(item.TheoryWeight.Value, 3);
                    }

                    var old = list.FirstOrDefault(w => w.Id == item.Id);
                    if (old != null)
                    {
                        old.ObjectExtend(item);
                    }
                    else
                    {
                        list.Add(item);
                    }
                }
                GetSessionCache()[key] = list;
                //Session[key] = list; 
                var r = CommandResult.Instance_Succeed;
                //r.ResultUrl = "http://www.baidu.com/";
                return JsonNet(r);
            }
            return JsonNet(CommandResult.Instance_Error);
        }
        /// <summary>
        /// 保存订单
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
            var js = JsonHelper.ToJson(collection.ToDictionary());

            var entity = JsonHelper.ToObject<VD_SalesOrder>(js);
            entity.ExtendedProperties.Add(ConstantSetting.TraceFieldCollection, collection.AllKeys);
            var key = $"{typeof(OnlineController).FullName}_Edit";
            var list = GetSessionCache().TryGet(key, () => new List<VD_SalesOrderDetail>());// Session[key] as List<VD_SalesOrderDetail> ?? new List<VD_SalesOrderDetail>();
            // TODO: Add update logic here
            //处理新的记录
            if (entity.BillCode.Equals(NewItemMark) || entity.BillCode.IsEmpty())
            {
                entity.BillCode = DateTime.Now.ToString("yyMMddhhmmss");
            }
            entity.Maker = entity.Maker ?? "admin";
            entity.MakeDate = entity.MakeDate.HasValue ? entity.MakeDate : DateTime.Now;

            if (entity.CustomerID_Code.IsEmpty())
            {
                entity.CustomerID = Guid.Empty;
            }

            int i = 0;
            int j = 0;
            foreach (var item in list)
            {
                i++;
                item.RowNo = i;
                item.MainID = entity.Id;
                //子材
                if (item.InID.HasValue && !item.InID.Value.IsEmpty())
                {
                    var parent = list.FirstOrDefault(w => w.Id == item.InID.Value);
                    var index = item.SalesOrderTraceCode.IndexOf('-') + 1;
                    item.SalesOrderTraceCode = $"{parent.SalesOrderTraceCode}-{item.SalesOrderTraceCode.Substring(index).PadLeft(2, '0')}";
                }
                else
                {
                    j++;
                    item.SalesOrderTraceCode = $"{entity.BillCode}{j.PadLeft(3)}";
                }
            } 
            if (GetService<ISalesOrderService>().Save(entity, list))
            {
                return JsonNet(CommandResult.Instance_Succeed);
            }
            return JsonNet(CommandResult.Instance_Error);
        }



        /// <summary>
        /// 删除订单明细
        /// </summary>
        // GET: Order/Online/Delete/5
        public ActionResult DeleteItem(string id)
        {
            var key = $"{typeof(OnlineController).FullName}_Edit";
            var list = GetSessionCache().TryGet(key, () => new List<VD_SalesOrderDetail>());// Session[key] as List<VD_SalesOrderDetail> ?? new List<VD_SalesOrderDetail>();
            var entity = list.FirstOrDefault(w => w.Id.ToString() == id);
            if (entity != null)
            {
                list.Remove(entity);
                return JsonNet(CommandResult.Instance_Succeed);
            }
            return JsonNet(CommandResult.Instance_Error);
        }

        /// <summary>
        /// 复制明细行
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CopyItem(string id)
        {
            var key = $"{typeof(OnlineController).FullName}_Edit";
            var list = GetSessionCache().TryGet(key, () => new List<VD_SalesOrderDetail>());// Session[key] as List<VD_SalesOrderDetail> ?? new List<VD_SalesOrderDetail>();

            if (list != null)
            {
                var old = list.FirstOrDefault(w => w.Id.ToString() == id);
                if (old != null)
                {
                    var newObj = new VD_SalesOrderDetail();// JsonHelper.CopyObject(old);
                    newObj.ObjectExtend(old);
                    newObj.SalesOrderTraceCode = NewItemMark;
                    newObj.Id = Guid.NewGuid();
                    list.Add(newObj);

                    int i = 0;
                    foreach (var item in list.Where(w=>w.InID==old.Id).ToList())
                    {
                        i++;
                        var newItem = item.CopyObject();
                        newItem.SalesOrderTraceCode = $"{NewItemMark}-{i.PadLeft()}";
                        newItem.InID = newObj.Id;
                        list.Add(newItem);
                    }
                }

                return JsonNet(CommandResult.Instance_Succeed);
            }
            return JsonNet(CommandResult.Instance_Error);

        }

        /// <summary>
        /// 删除订单
        /// </summary>
        // POST: Order/Online/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            Guid ID = Guid.Empty;
            if (Guid.TryParse(id, out ID))
            {
                var service = GetService<ISalesOrderService>();
                bool r = service.Delete(new VD_SalesOrder() { Id = ID });
                if (r)
                {
                    return JsonNet(CommandResult.Instance_Succeed);
                }
            }
            return JsonNet(CommandResult.Instance_Error);
        }
        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Audit(string id)
        {
            //var id = data.Value<Guid>("id");
            var ID = Guid.Empty;
            if (Guid.TryParse(id,out ID) && !ID.Equals(Guid.Empty))
            {
                var entity = new VD_SalesOrder()
                {
                    Id = ID,
                    Audit = CurrentBaseLoginer.UserName,
                    AuditDate = DateTime.Now
                };
                var service = GetService<ISalesOrderService>();
                int r = service.Audite(entity);
                if (r==1)
                {
                    entity = service.GetOrder(entity);
                    return JsonNet(CommandResult.Instance_Succeed.Set("审核成功").Set(entity));
                }
                else
                {
                    switch (r)
                    {
                        case -1:
                            return JsonNet(CommandResult.Instance_Error.Set("单据不存在"));
                        case 0:
                            return JsonNet(CommandResult.Instance_Error.Set("单据已审核"));
                        default:
                            break;
                    }
                }
            }
            return JsonNet(CommandResult.Instance_Error);
        }

        /// <summary>
        /// 反审订单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UnAudit(string id)
        {
            var ID = Guid.Empty;
            if (Guid.TryParse(id, out ID) && !ID.Equals(Guid.Empty))
            {
                var entity = new VD_SalesOrder()
                {
                    Id = ID
                };
                var service = GetService<ISalesOrderService>();
                int r = service.UnAudite(entity);
                if (r == 1)
                {
                    entity = service.GetOrder(entity);
                    return JsonNet(CommandResult.Instance_Succeed.Set("反审成功").Set(entity));
                }
                else
                {
                    switch (r)
                    {
                        case -1:
                            return JsonNet(CommandResult.Instance_Error.Set("单据不存在"));
                        case 0:
                            return JsonNet(CommandResult.Instance_Error.Set("单据已反审"));
                        default:
                            break;
                    }
                }
            }
            return JsonNet(CommandResult.Instance_Error);
        }


        public ActionResult CheckOrder(string id,int ds)
        {
            var r = CommandResult.Instance_Succeed;
            r.ResultMsg = "";
            r.ResultUrl = $"/Order/Online/Detail?id={id}&ds={ds}";
            return JsonNet(r);
        }
    }
} 