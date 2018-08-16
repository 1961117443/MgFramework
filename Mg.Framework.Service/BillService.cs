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

namespace Mg.Framework.Service
{
    public abstract partial class BillService<T, V> :  IBillService<T,V>
        where T : VD_Base
        where V : VD_Base
    {
        protected virtual IDbContext Db
        {
            get
            {
                return DB.Untility.DbContextFactory.CreateContext();
            }
        }

        protected IList<Action> DbActions { get; set; }

        public BillService()
        {
            DbActions = new List<Action>();
        }

        private static PropertyInfo[] _Tinfo;
        protected PropertyInfo[] MainInfo
        {
            get
            {
                return _Tinfo;
            }
        }

        private static PropertyInfo[] _Vinfo;
        protected PropertyInfo[] DetailInfo
        {
            get
            {
                return _Vinfo;
            }
        }

        static BillService()
        {
            _Tinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            _Vinfo = typeof(V).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        protected virtual TA MapTo<TA, TD>(TA target, TD data)
        {
            var targetProps = typeof(TA).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in typeof(TD).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var tp = targetProps.FirstOrDefault(w => w.Name == p.Name);
                if (tp != null)
                {
                    var ov = tp.GetValue(target, null);
                    var nv = p.GetValue(data, null);
                    if (!ov.DbEqual(nv))
                    {
                        tp.SetValue(target, nv);
                    }
                }
            }
            return target;
        }


        /// <summary>
        /// 定义日志类
        /// </summary>
        //  protected Log log = Log.Instance(typeof(T));


        /// <summary>
        /// 保存单据 存在则更新，否则新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public abstract string Save(T entity, List<V> list);

        /// <summary>
        /// 创建单据  
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public abstract string Create(T entity, List<V> list);

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
        public abstract List<T> GetList(ref PageInfo pageInfo);

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
        public abstract string EditOrder(T entity);

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
        public abstract string EditOrder(T entity, List<V> list);

        /// <summary>
        /// 获得订单数量
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
            if (Db!=null)
            {
                Db.Dispose();
            }
            if (DbActions!=null)
            {
                DbActions.Clear();
                DbActions = null;
            }
        }
    }
}
