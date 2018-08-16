using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.IService
{
    
    public interface IBaseService
    {
        //IDbContext GetDbContext<T>() where T : BaseModel;
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add<T>(T entity) where T : BaseModel;
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="proNames"></param>
        /// <returns></returns>
        int Update<T>(T entity, params string[] proNames) where T : BaseModel;
        /// <summary>
        /// 根据实体进行删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete<T>(T entity) where T : BaseModel;
        /// <summary>
        /// 根据lambda表达式进行删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        int DeleteByCondition<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel;

        /// <summary>
        /// 根据Id 进行获取单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyVal"></param>
        /// <returns></returns>
        T GetSingle<T>(object keyVal) where T : BaseModel;
        /// <summary>
        /// 根据lambda表达式获取单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        T GetSingle<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel;

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<T> GetList<T>() where T : BaseModel;
        /// <summary>
        /// 根据lambda表达式获取实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IList<T> GetList<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel;
        /// <summary>
        /// 根据lambda表达式获取实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IList<T> GetList<T, TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false) where T : BaseModel;
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        IList<T> GetPageList<T, TKey>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false) where T : BaseModel;

    }
}
