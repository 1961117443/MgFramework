using App.ViewModel;
using Chloe;
using Mg.Framework.IService;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.Service
{
    public abstract class Bill<T>:IBill<T> where T:VD_Base
    {
        protected virtual IDbContext ObjectContext
        {
            get
            {
                return DB.Untility.DbContextFactory.CreateContext();
            }
        }

        protected IList<Action> DbActions { get; set; }

        public Bill()
        {
            DbActions = new List<Action>();
        }

        public void Dispose()
        {
            if (ObjectContext != null)
            {
                ObjectContext.Dispose();
            }
            if (DbActions != null)
            {
                DbActions.Clear();
                DbActions = null;
            }
        }

        /// <summary>
        /// 定义日志类
        /// </summary>
        // protected Log log = Log.Instance(typeof(T));

        /// <summary>
        /// 保存单据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public abstract  string Save(T entity);

        /// <summary>
        /// 创建单据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public abstract string Create(T entity);

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
        public abstract string Delete(T entity);

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract string Audite(T entity);

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
        /// 查询单据分页
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public abstract List<T> GetList(Expression<Func<T, bool>> where, ref PageInfo pageInfo);


        /// <summary>
        /// 编辑单据信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract string EditOrder(T entity);

        /// <summary>
        /// 获得打印单据的数据源
        /// </summary>
        /// <param name="argOrderNum"></param>
        /// <returns></returns>
        public abstract System.Data.DataSet GetPrint(string argOrderNum);

        
    }

}
