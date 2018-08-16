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

namespace Mg.Framework.Service
{
    public class SurfaceService : Bill<VD_Surface>, ISurfaceService
    {
        public override string Audite(VD_Surface entity)
        {
            throw new NotImplementedException();
        }

        public override string Cancel(VD_Surface entity)
        {
            throw new NotImplementedException();
        }

        public override string Create(VD_Surface entity)
        {
            throw new NotImplementedException();
        }

        public override string Delete(VD_Surface entity)
        {
            throw new NotImplementedException();
        }

        public override string EditOrder(VD_Surface entity)
        {
            throw new NotImplementedException();
        }

        public override List<VD_Surface> GetList(Expression<Func<VD_Surface, bool>> where, ref PageInfo pageInfo)
        {
            var query =
               ObjectContext.Query<Surface>().LeftJoin<SurfaceCategory>((s1,s2)=> s1.SurfaceCategoryID==s2.Id). 
               Select((s,sc) =>
               new VD_Surface()
               {
                   Id = s.Id,
                   AutoID = s.AutoID,
                   SurfaceCode = s.SurfaceCode,
                   SurfaceName = s.SurfaceName,
                   SurfaceCategoryID_Name = sc.Name
               });

            if (where != null)
            {
                query = query.Where(where);
            }

            pageInfo.RowCount = query.Count();
            var list = query.OrderBy(w => w.AutoID).TakePage(pageInfo.PageIndex, pageInfo.PageSize).ToList();
            return list;
        }

        public override VD_Surface GetOrder(VD_Surface entity)
        {
            throw new NotImplementedException();
        }

        public override DataSet GetPrint(string argOrderNum)
        {
            throw new NotImplementedException();
        }

        public override string Print(VD_Surface entity)
        {
            throw new NotImplementedException();
        }

        public override string Save(VD_Surface entity)
        {
            throw new NotImplementedException();
        }
    }
}
