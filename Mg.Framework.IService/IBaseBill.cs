using App.ViewModel;
using Mg.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.IService
{
 
    public interface IBaseBill<T, V> //: IDisposable 
        where T : VD_Base
        where V : VD_Base
    {
        /// <summary>
        /// 定义日志类
        /// </summary>
        //protected ILogger log = Log.Instance(typeof(T));

        /// <summary>
        /// 保存单据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        bool Save(T entity, List<V> list);

        ///// <summary>
        ///// 创建单据
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //string Create(T entity, List<V> list);

        /// <summary>
        /// 取消单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        string Cancel(T entity);

        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Audite(T entity);
        /// <summary>
        /// 反审单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UnAudite(T entity);

        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        string Print(T entity);

        /// <summary>
        /// 查询单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T GetOrder(T entity);

        /// <summary>
        /// 获得单据详细信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<V> GetOrderDetail(T entity);

        /// <summary>
        /// 查询单据分页
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        List<T> GetList(Expression<Func<T, bool>> where, ref PageInfo pageInfo);

        /// <summary>
        /// 查询单据详细数据分页
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        List<V> GetDetailList(V entity, ref PageInfo pageInfo);

        /// <summary>
        /// 编辑单据信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       // bool Edit(T entity);

        /// <summary>
        /// 编辑单据详细信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
      //  string EditDetail(V entity);

        /// <summary>
        /// 编辑入库单
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        //string EditOrder(T entity, List<V> list);

        /// <summary>
        /// 获得订单数量
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int GetCount(T entity);

        /// <summary>
        /// 获得打印单据的数据源
        /// </summary>
        /// <param name="argOrderNum"></param>
        /// <returns></returns>
        System.Data.DataSet GetPrint(string argOrderNum);
    }
}
