using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ViewModel;
using Mg.Framework.IService;
using Chloe;
using System.Reflection;
using Mg.Untility;
using System.Linq.Expressions;
using Mg.Logger;
using Mg.Untility.Logger;

namespace Mg.Framework.Service
{
    public abstract partial class BaseBill<T, V> :  IBaseBill<T,V>
        where T : VD_Base
        where V : VD_Base
    { 
        /// <summary>
        /// 数据库上下文
        /// </summary>
        protected virtual IDbContext ObjectContext
        {
            get
            {
                
                return DB.Untility.DbContextFactory.CreateContext();
            }
        }
        /// <summary>
        /// 批量数据库操作
        /// </summary>
        private DbActionBag actionBag;
        protected DbActionBag ActionBag
        {
            get
            {
                if (actionBag==null)
                {
                    actionBag = ObjectContext.CreateActionBag();
                }
                return actionBag;
            }
            set
            {
                actionBag = value;
            }
        }

        /// <summary>
        /// 启用事务保存数据
        /// </summary>
        /// <returns></returns>
        protected virtual int SaveChanges()
        {
            int result = 0;

            ObjectContext.Session.BeginTransaction();
            try
            {
                //foreach (var act in DbActions)
                //{
                //    act.Invoke();
                //}
                result = ActionBag.ExecuteActions();
                ObjectContext.Session.CommitTransaction();
            }
            catch (Exception ex)
            {
                ObjectContext.Session.RollbackTransaction();
                throw ex;
            }
            return result;
        }
         

        public BaseBill()
        { 
        }

        public abstract void DefaultQuery(Action<IQuery<T>> action);
        public abstract void DefaultQuery(Action<IQuery<V>> action);



        /// <summary>
        /// 定义日志类
        /// </summary>
        protected ILogger log = new LoggerBase(typeof(T));


        /// <summary>
        /// 统一的保存操作 保存单据 存在则更新，否则新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public abstract bool Save(T entity, List<V> list);

        /// <summary>
        /// 创建单据  
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        protected abstract bool Create(T entity, List<V> list);

        /// <summary>
        /// 取消单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract string Cancel(T entity);

        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool Delete(T entity);

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract int Audite(T entity);
        /// <summary>
        /// 反审单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract int UnAudite(T entity);

        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract string Print(T entity);

        /// <summary>
        /// 查询单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract T GetOrder(T entity);

        /// <summary>
        /// 获得单据详细信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract List<V> GetOrderDetail(T entity);

        /// <summary>
        /// 查询单据分页
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public abstract List<T> GetList(Expression<Func<T,bool>> where, ref PageInfo pageInfo);

        /// <summary>
        /// 查询单据详细数据分页
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public abstract List<V> GetDetailList(V entity, ref PageInfo pageInfo);

        /// <summary>
        /// 编辑单据信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract bool Edit(T entity);

        /// <summary>
        /// 编辑单据详细信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract string EditDetail(V entity);

        /// <summary>
        /// 编辑入库单
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        protected abstract bool Edit(T entity, List<V> list);

        /// <summary>
        /// 获得订单明细数量
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract int GetCount(T entity);

        /// <summary>
        /// 获得打印单据的数据源
        /// </summary>
        /// <param name="argOrderNum"></param>
        /// <returns></returns>
        public abstract DataSet GetPrint(string argOrderNum);

        public void Dispose()
        {

            if (actionBag != null)
            { 
                actionBag = null;
            }
            //if (ObjectContext!=null)
            //{
            //    ObjectContext.Dispose();
            //}
        }
    }
}
