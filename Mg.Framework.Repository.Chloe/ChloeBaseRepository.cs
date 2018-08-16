using Chloe;
using Mg.Framework.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.Repository.Chloe
{
    public class ChloeBaseRepository: ChloeBase, IBaseRepository
    {
        #region 增
        public T Add<T>(T entity) where T : BaseModel
        {
            return DbContext.Insert<T>(entity);
        }
        #endregion

        #region 删
        public int Delete<T>(T entity) where T : BaseModel
        {
            return DbContext.Delete(entity);
        }

        public int DeleteByCondition<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel
        {
            return DbContext.Delete(whereLambda);
        }

        public IDbContext GetDbContext<T>() where T : BaseModel
        {
            return DbContext;
        }
        #endregion

        #region 查
        public IList<T> GetList<T>() where T : BaseModel
        {
            return this.GetList<T>(null);
        }

        public IList<T> GetList<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel
        {
            IQuery<T> query = DbContext.Query<T>();
            if (whereLambda != null)
            {
                query = query.Where(whereLambda);
            }
            return query.ToList();
        }

        public IList<T> GetList<T, TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false) where T : BaseModel
        {
            IQuery<T> query = DbContext.Query<T>();
            if (whereLambda != null)
            {
                query = query.Where(whereLambda);
            }
            if (orderLambda != null)
            {
                if (isDesc)
                {
                    query = query.OrderByDesc(orderLambda);
                }
                else
                {
                    query = query.OrderBy(orderLambda);
                }
            }
            return query.ToList();
        }

        public IList<T> GetPageList<T, TKey>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false) where T : BaseModel
        {
            IQuery<T> query = DbContext.Query<T>(whereLambda);
            totalCount = query.Select(a => Sql.Count()).First();
            if (isDesc)
            {
                query = query.OrderByDesc(orderLambda);
            }
            else
            {
                query = query.OrderBy(orderLambda);
            }
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            if (pageSize == 0)
            {
                pageSize = 1;
            }
            return query.TakePage(pageIndex, pageSize).ToList();
        }

        public T GetSingle<T>(object keyVal) where T : BaseModel
        {
            return DbContext.Query<T>().FirstOrDefault(w => w.Id.Equals(keyVal));
        }

        public T GetSingle<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel
        {

            return DbContext.Query<T>(whereLambda).FirstOrDefault();
        }
        #endregion

        #region 改
        public int Update<T>(T entity, params string[] proNames) where T : BaseModel
        {
            if (proNames != null && proNames.Length > 0)
            {
                return DbContext.UpdateOnly(entity, proNames);
            }
            return DbContext.Update(entity);
        }
        #endregion
    }
}
