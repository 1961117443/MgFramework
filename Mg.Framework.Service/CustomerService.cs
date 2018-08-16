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
    public class CustomerService : Bill<VD_Customer>, ICustomerService
    {
        public override string Audite(VD_Customer entity)
        {
            throw new NotImplementedException();
        }

        public override string Cancel(VD_Customer entity)
        {
            throw new NotImplementedException();
        }

        public override string Create(VD_Customer entity)
        {
            throw new NotImplementedException();
        }

        public override string Delete(VD_Customer entity)
        {
            throw new NotImplementedException();
        }

        public override string EditOrder(VD_Customer entity)
        {
            throw new NotImplementedException();
        }

        public override List<VD_Customer> GetList(Expression<Func<VD_Customer, bool>> where, ref PageInfo pageInfo)
        {
            var query =
               ObjectContext.Query<Customer>(). 
               Select(s =>
               new VD_Customer()
               {
                   Id = s.Id,
                   AutoID = s.AutoID,
                   Code = s.Code,
                   Name = s.Name
               });

            if (where != null)
            {
                query = query.Where(where);
            }

            pageInfo.RowCount = query.Count();
            var list = query.OrderBy(w => w.Code).TakePage(pageInfo.PageIndex, pageInfo.PageSize).ToList();
            return list;
        }

        public override VD_Customer GetOrder(VD_Customer entity)
        {
            throw new NotImplementedException();
        }

        public override DataSet GetPrint(string argOrderNum)
        {
            throw new NotImplementedException();
        }

        public override string Print(VD_Customer entity)
        {
            throw new NotImplementedException();
        }

        public override string Save(VD_Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
