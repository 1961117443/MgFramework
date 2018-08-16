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
    public class PackingService : Bill<VD_Packing>, IPackingService
    {
        public override string Audite(VD_Packing entity)
        {
            throw new NotImplementedException();
        }

        public override string Cancel(VD_Packing entity)
        {
            throw new NotImplementedException();
        }

        public override string Create(VD_Packing entity)
        {
            throw new NotImplementedException();
        }

        public override string Delete(VD_Packing entity)
        {
            throw new NotImplementedException();
        }

        public override string EditOrder(VD_Packing entity)
        {
            throw new NotImplementedException();
        }

        public override List<VD_Packing> GetList(Expression<Func<VD_Packing, bool>> where, ref PageInfo pageInfo)
        {
            var query =
               ObjectContext.Query<Packing>().
               Select(s =>
               new VD_Packing()
               {
                   Id = s.Id,
                   AutoID = s.AutoID,
                    PackingCode = s.PackingCode,
                    PackingName = s.PackingName
               });

            if (where != null)
            {
                query = query.Where(where);
            }

            pageInfo.RowCount = query.Count();
            var list = query.OrderBy(w => w.PackingCode).TakePage(pageInfo.PageIndex, pageInfo.PageSize).ToList();
            return list;
        }

        public override VD_Packing GetOrder(VD_Packing entity)
        {
            throw new NotImplementedException();
        }

        public override DataSet GetPrint(string argOrderNum)
        {
            throw new NotImplementedException();
        }

        public override string Print(VD_Packing entity)
        {
            throw new NotImplementedException();
        }

        public override string Save(VD_Packing entity)
        {
            throw new NotImplementedException();
        }
    }
}
