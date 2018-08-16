using Mg.Framework.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.Repository.Chloe
{
    /// <summary>
    /// 泛型数据访问层
    /// T 必须是继承BaseModel的实体类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChloeBaseRepository<T> : ChloeBaseRepository, IBaseRepository<T> where T : BaseModel
    {
        #region 增
        public T Add(T entity)
        {
            return this.Add<T>(entity);
        }
        #endregion

        #region 删
        public int Delete(T entity)
        {
            return this.Delete<T>(entity);
        }

        public int DeleteByCondition(Expression<Func<T, bool>> whereLambda)
        {
            return this.DeleteByCondition<T>(whereLambda);
        }


        #endregion

        #region 查
        public IList<T> GetList()
        {
            return this.GetList<T>(null);
        }

        public IList<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return this.GetList<T>(whereLambda);
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
            return GetSingle<T>(whereLambda);
        }

        public T GetSingle(object keyVal)
        {
            return GetSingle<T>(keyVal);
        }
        #endregion

        #region 改
        public int Update(T entity, params string[] proNames)
        {
            return Update<T>(entity, proNames);
        }
        #endregion
    }
}
