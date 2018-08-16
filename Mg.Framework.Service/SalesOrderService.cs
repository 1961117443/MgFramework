using Mg.Framework.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ViewModel;
using Mg.DB.Untility;
using RepositoryModel;
using System.Data;
using Chloe;
using System.Reflection;
using Mg.Untility;
using System.Linq.Expressions; 

namespace Mg.Framework.Service
{
    
    public class SalesOrderService : BaseBill<VD_SalesOrder, VD_SalesOrderDetail>, ISalesOrderService
    {


        /// <summary>
        ///审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>0：单据已审核 -1:单据不存在 </returns>
        public override int Audite(VD_SalesOrder entity)
        { 
            var order = ObjectContext.Query<SalesOrder>().FirstOrDefault(w => w.Id == entity.Id);
            if (order==null)
            {
                return -1; // 单据不存在
            }
            if (order.AuditDate.HasValue)
            {
                return 0; //单据已审核
            }
            ObjectContext.TrackEntity(order);
            order.Audit = entity.Audit;
            order.AuditDate = entity.AuditDate;
            if (!order.FirstAuditDate.HasValue)
            {
                order.FirstAuditDate = entity.AuditDate;
            }
            return ObjectContext.Update(order); 
        }

        public override string Cancel(VD_SalesOrder entity)
        {
            throw new NotImplementedException();
        }

        protected Map<VD_SalesOrder, SalesOrder> mapMain = new Map<VD_SalesOrder, SalesOrder>();
        protected Map<VD_SalesOrderDetail, SalesOrderDetail> mapDetail = new Map<VD_SalesOrderDetail, SalesOrderDetail>();




        protected override bool Create(VD_SalesOrder entity, List<VD_SalesOrderDetail> list)
        {
            var Tentity  = mapMain.Resolve(entity); 
            Tentity.Id = Guid.NewGuid();
            Tentity.Maker = entity.Maker;
            Tentity.MakeDate = entity.MakeDate ?? DateTime.Now;
            ActionBag.PushInsert(Tentity); 
            foreach (var item in list)
            {
                //新增的明细
                var detail = new SalesOrderDetail();
                detail = mapDetail.Resolve(item, detail);
                detail.MainID = Tentity.Id;
                ActionBag.PushInsert(detail);
            }
            var r = SaveChanges()>0;
            if (r)
            {
                entity.Id = Tentity.Id;
            }
            return r;
        }

        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool Delete(VD_SalesOrder entity)
        { 
            ActionBag.PushDelete<SalesOrder>(w=> w.Id == entity.Id);
            ActionBag.PushDelete<SalesOrderDetail>(w => w.MainID == entity.Id);
            //DbActions.Add(() => ObjectContext.Delete<SalesOrder>(w => w.Id == entity.Id));
            //DbActions.Add(() => ObjectContext.Delete<SalesOrderDetail>(w => w.MainID == entity.Id));
            return SaveChanges()>0;
        }

        public override string EditDetail(VD_SalesOrderDetail entity)
        {
            var Tentity = ObjectContext.Query<SalesOrderDetail>().FirstOrDefault(w => w.Id == entity.Id);
            int r = 0;
            if (Tentity!=null)
            {
                ObjectContext.TrackEntity(Tentity);
                Tentity = mapDetail.Resolve(entity, Tentity);
                r= ObjectContext.Update(Tentity);
            } 
            return r > 0 ? "100" : "-1";
        }

        protected override bool Edit(VD_SalesOrder entity)
        {
            var Tentity = ObjectContext.Query<SalesOrder>().FirstOrDefault(w => w.Id == entity.Id);
            int r = 0;
            if (Tentity != null)
            {
                ObjectContext.TrackEntity(Tentity);
                Tentity = mapMain.Resolve(entity, Tentity); 
                r = ObjectContext.Update(Tentity);
            }
            return r > 0;
        }

        protected override bool Edit(VD_SalesOrder entity, List<VD_SalesOrderDetail> list)
        { 
            var Tentity = ObjectContext.Query<SalesOrder>().FirstOrDefault(w => w.Id == entity.Id);
            ObjectContext.TrackEntity(Tentity);
            Tentity = mapMain.Resolve(entity, Tentity); 
            ActionBag.PushUpdate(Tentity);

            List<SalesOrderDetail> sourceItems = ObjectContext.Query<SalesOrderDetail>().Where(w => w.MainID.Equals(Tentity.Id)).ToList(); 
            foreach (var item in list)
            {
                bool isnew = true;
                var sourceItem = sourceItems.FirstOrDefault(w => w.Id.Equals(item.Id));
                //原来就存在
                if (sourceItem != null)
                {
                    ObjectContext.TrackEntity(sourceItem);
                    isnew = false;
                }
                else
                {
                    //新增的明细
                    sourceItem = new SalesOrderDetail();
                    if (item.Id.Equals(Guid.Empty))
                    {
                        item.Id = Guid.NewGuid();
                    }
                }
                sourceItem.MainID = Tentity.Id;
                if (mapDetail.Compare(item, sourceItem))
                {
                    sourceItem = mapDetail.Model;
                    if (isnew)
                    {
                        ActionBag.PushInsert(sourceItem);
                    }
                    else
                    {
                        ActionBag.PushUpdate(sourceItem);
                    }
                } 
                sourceItems.Remove(sourceItem);
            }
            //剩下的是删除的数据
            if (sourceItems.Count() > 0)
            {
                foreach (var item in sourceItems)
                {
                    ActionBag.PushDelete(item);
                   // DbActions.Add(() => ObjectContext.Delete(item));
                }
            } 
            return SaveChanges()>0;
        }

        public override int GetCount(VD_SalesOrder entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException("entity");
            }
           return ObjectContext.Query<SalesOrderDetail>(w => w.MainID == entity.Id).Count();
        }

        public override List<VD_SalesOrderDetail> GetDetailList(VD_SalesOrderDetail entity, ref PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取主表数据
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public override List<VD_SalesOrder> GetList(Expression<Func<VD_SalesOrder, bool>> where, ref PageInfo pageInfo)
        { 
            PageInfo page = new PageInfo(pageInfo);
            List<VD_SalesOrder> list = null;
            DefaultQuery(q =>
            {
                if (where != null)
                {
                    q = q.Where(where);
                }
                page.RowCount = q.Count();
                list = q.OrderByDesc(w => w.OrderDate).TakePage(page.PageIndex, page.PageSize).ToList();
            });
            pageInfo.RowCount = page.RowCount;
            return list;



        }

        /// <summary>
        /// 获取单个订单的数据不包含从表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override VD_SalesOrder GetOrder(VD_SalesOrder entity)
        {
            DefaultQuery(q => entity = q.Where(w => w.Id.Equals(entity.Id)).FirstOrDefault()); 
             entity = entity ?? new VD_SalesOrder();
             return entity;

        }
        /// <summary>
        /// 获取从表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override List<VD_SalesOrderDetail> GetOrderDetail(VD_SalesOrder entity)
        {
            List<VD_SalesOrderDetail> list = null;
            DefaultQuery(q => list = q.Where(w => w.MainID == entity.Id).OrderBy(w => w.RowNo).ToList());
            //var list = query.OrderBy(w=>w.RowNo).ToList();
            return list ?? new List<VD_SalesOrderDetail>();

        }

        public override DataSet GetPrint(string argOrderNum)
        {
            throw new NotImplementedException();
        }

        public override string Print(VD_SalesOrder entity)
        {
            throw new NotImplementedException();
        }

        public override bool Save(VD_SalesOrder entity, List<VD_SalesOrderDetail> list)
        { 
            if (entity.Id.Equals(Guid.Empty))
            {
                //新增 
                return Create(entity, list);
            }
            else
            {
                return Edit(entity, list);
            }
        }

        public override void DefaultQuery(Action<IQuery<VD_SalesOrder>> action)
        {
           var query=  ObjectContext.Query<SalesOrder>().
                LeftJoin<Customer>((w1, w2) => w1.CustomerID == w2.Id).
                LeftJoin<Packing>((w1, w2, w3) => w1.PackingID == w3.Id).
                Select((s, c, p) =>
                new VD_SalesOrder()
                {
                    Id = s.Id,
                    AutoID = s.AutoID,
                    BillCode = s.BillCode,
                    OrderDate = s.OrderDate,
                    CustomerID = s.CustomerID,
                    CustomerID_Code = c.Code,
                    CustomerID_Name = c.Name,
                    // DeliveryMethod = s.DeliveryMethod,
                    AcceptDate = s.AcceptDate,
                    PackingID = s.PackingID,
                    PackingID_PackingCode = p.PackingCode,
                    PackingID_PackingName = p.PackingName,
                    Project = s.Project,
                    OrderType = s.OrderType,
                    Remark = s.Remark,
                    CustomerPO = s.CustomerPO,
                    // ApprovalDate = s.ApprovalDate,
                    AluminumPriceDate = s.AluminumPriceDate,
                    Audit = s.Audit,
                    AuditDate = s.AuditDate ,
                    Maker = s.Maker,
                    MakeDate = s.MakeDate
                });
            action.Invoke(query);
        }

        public override void DefaultQuery(Action<IQuery<VD_SalesOrderDetail>> action)
        {
            var query =
                ObjectContext.Query<SalesOrderDetail>().
                LeftJoin<SectionBar>((w1, w2) => w1.SectionBarID == w2.Id).
                LeftJoin<Surface>((w1, w2, w3) => w1.SurfaceID == w3.Id).
                LeftJoin<Packing>((w1, w2, w3, w4) => w1.PackingID == w4.Id).
                Select((w1, w2, w3, w4) =>
                new VD_SalesOrderDetail()
                {
                    Id = w1.Id,
                    AutoID = w1.AutoID,
                    InID = w1.InID,
                    MainID = w1.MainID,
                    SalesOrderTraceCode = w1.SalesOrderTraceCode,
                    SectionBarID = w1.SectionBarID,
                    SectionBarID_Code = w2.Code,
                    SectionBarID_Name = w2.Name,
                    TotalQuantity = w1.TotalQuantity,
                    WallThickness = w1.WallThickness,
                    FilmThickness = w1.FilmThickness,
                    TheoryMeter = w1.TheoryMeter,
                    Theory6Meter = w1.Theory6Meter,
                    TheoryWeight = w1.TheoryWeight,
                    SurfaceID = w1.SurfaceID,
                    SurfaceID_Name = w3.SurfaceName,
                    PackingID = w1.PackingID,
                    PackingID_PackingName = w4.PackingName,
                    Sort = w1.Sort,
                    OrderLevel = w1.OrderLevel,
                    Remark = w1.Remark,
                    OrderLength = w1.OrderLength,
                    RowNo = w1.RowNo
                });
            action.Invoke(query);
        }

        /// <summary>
        ///反审单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>0：单据已反审 -1:单据不存在 </returns>
        public override int UnAudite(VD_SalesOrder entity)
        {
            var order = ObjectContext.Query<SalesOrder>().FirstOrDefault(w => w.Id == entity.Id);
            if (order == null)
            {
                return -1; // 单据不存在
            }
            if (!order.AuditDate.HasValue)
            {
                return 0; //单据已反审
            }
            ObjectContext.TrackEntity(order);
            order.Audit = "";
            order.AuditDate = null;  
            return ObjectContext.Update(order);
        }
    }
}
