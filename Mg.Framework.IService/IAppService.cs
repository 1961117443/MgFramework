using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.IService
{
    public interface IAppService<T>:IDisposable where T:BaseModel
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="proNames"></param>
        /// <returns></returns>
        int Update(T entity, params string[] proNames);
        /// <summary>
        /// 根据实体进行删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(T entity);
        /// <summary>
        /// 根据lambda表达式进行删除
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        int DeleteByCondition(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Save(T entity);
        /// <summary>
        /// 根据lambda表达式获取单个对象
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        T GetSingle(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 根据Id 进行获取单个对象
        /// </summary>
        /// <param name="keyVal"></param>
        /// <returns></returns>
        T GetSingle(object keyVal);
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <returns></returns>
        IList<T> GetList();
        /// <summary>
        /// 根据lambda表达式获取实体集合
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IList<T> GetList(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 根据lambda表达式获取实体集合
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        IList<T> GetList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        IList<T> GetPageList<TKey>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false);
 
    }
}
