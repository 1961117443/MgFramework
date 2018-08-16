using App.ViewModel;
using Mg.Framework.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;
using RepositoryModel;
using Chloe;
using Mg.Untility;

namespace Mg.Framework.Service
{
    public class SectionBarService : Bill<VD_SectionBar>, ISectionBarService
    {
        public override string Audite(VD_SectionBar entity)
        {
            throw new NotImplementedException();
        }

        public override string Cancel(VD_SectionBar entity)
        {
            throw new NotImplementedException();
        }

        public override string Create(VD_SectionBar entity)
        {
            throw new NotImplementedException();
        }

        public override string Delete(VD_SectionBar entity)
        {
            throw new NotImplementedException();
        }

        public override string EditOrder(VD_SectionBar entity)
        {
            throw new NotImplementedException();
        }

        public List<VD_SectionBar> GetHeatInsulationList(Guid? parentId)
        {
            List<VD_SectionBar> result = new List<VD_SectionBar>();
            if (parentId.HasValue)
            {
                var query1 = ObjectContext.Query<HeatInsulationListFileDetail>().InnerJoin<HeatInsulationListFile>((d, m) => d.MainID == m.Id).Where((d, m) => m.HeatSectionBarID == parentId).Select((d, m) => new { d.SonSectionBarID });

                Expression<Func<VD_SectionBar, bool>> where = a => query1.Where(q => q.SonSectionBarID == a.Id).Any();
                var page = new PageInfo() { PageIndex = 1, PageSize = 100 };
                result = GetList(where, ref page); 
            }
            return result; 
        }

        public override List<VD_SectionBar> GetList(Expression<Func<VD_SectionBar, bool>> where, ref PageInfo pageInfo)
        {
            var query =
               ObjectContext.Query<SectionBar>().
               LeftJoin<SectionBarCategory>((s1, s2) => s1.SectionBarCategoryID == s2.Id).
               LeftJoin<Customer>((s1, s2, s3) => s1.CustomerID == s3.Id).
               LeftJoin<HeatInsulationListFile>((s1, s2, s3, s4) => s1.Id == s4.HeatSectionBarID).
               Select((s1, s2, s3, s4) =>
               new VD_SectionBar()
               {
                   Id = s1.Id,
                   AutoID = s1.AutoID,
                   Code = s1.Code,
                   CustomerID = s1.CustomerID,
                   SectionBarCategoryID = s1.SectionBarCategoryID,
                   CustomerCode = s1.CustomerCode,
                   CustomerID_Code = s3.Code,
                   CustomerID_Name = s3.Name,
                   Name = s1.Name,
                   RowNo = s1.RowNo,
                   SectionBarCategoryID_SectionBarCategoryID = s2.SectionBarCategoryID,
                   SectionBarCategoryID_SectionBarCategoryName = s2.SectionBarCategoryName,
                   Theoreticalweight = s1.Theoreticalweight,
                   WallThickness = s1.WallThickness,
                   HeatInsulationList = s4.HeatInsulationList
               });
            if (where != null)
            {
                query = query.Where(where);
            }
            pageInfo.RowCount = query.Count();
            var list = query.OrderBy(w => w.AutoID).TakePage(pageInfo.PageIndex, pageInfo.PageSize).ToList();
            return list;
        }
       


        public override VD_SectionBar GetOrder(VD_SectionBar entity)
        {
            throw new NotImplementedException();
        }

        public override DataSet GetPrint(string argOrderNum)
        {
            throw new NotImplementedException();
        }

        public override string Print(VD_SectionBar entity)
        {
            throw new NotImplementedException();
        }

        public override string Save(VD_SectionBar entity)
        {
            throw new NotImplementedException();
        }
    }
}
