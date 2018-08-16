using Mg.Framework.IService;
using Mg.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.Service
{
    public class AppService<T> : BaseService, IAppService<T> where T : BaseModel
    {
        //public IQuery<T> Query
        //{
        //    get
        //    {
        //        return base.Query<T>();
        //    }
        //}

        public T Add(T entity)
        {
            return base.Add<T>(entity);
        }

        public int Delete(T entity)
        {
            return base.Delete<T>(entity);
        }

        public int DeleteByCondition(Expression<Func<T, bool>> whereLambda)
        {
            return base.DeleteByCondition<T>(whereLambda);
        }

        public IList<T> GetList()
        {
            return base.GetList<T>();
        }

        public IList<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return base.GetList<T>(whereLambda);
        }

        public IList<T> GetList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false)
        {
            return base.GetList<T, TKey>(whereLambda, orderLambda, isDesc);
        }

        public IList<T> GetPageList<TKey>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false)
        {
            return GetPageList<T, TKey>(pageIndex, pageSize, out totalCount, whereLambda, orderLambda, isDesc);
        }

        public T GetSingle(Expression<Func<T, bool>> whereLambda)
        {
            return base.GetSingle<T>(whereLambda);
        }

        public T GetSingle(object keyVal)
        {
            return base.GetSingle<T>(keyVal);
        }

        public T Save(T entity)
        {
            if (entity.Id.IsEmpty())
            {
                entity.Id = Guid.NewGuid();
                return Add(entity);
            }
            Update(entity);
            return entity;
        }

        public int Update(T entity, params string[] proNames)
        {
            return base.Update<T>(entity, proNames);
        }
    }
}
