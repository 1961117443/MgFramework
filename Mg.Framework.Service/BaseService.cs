using Mg.Framework.IRepository;
using Mg.Framework.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Mg.Framework.Service
{
    public class BaseService : IBaseService
    {

        protected IBaseRepository<T> GetRepository<T>() where T : BaseModel
        {
            return RepositoryFactory.CreateService<T>();
        }

        //public IQuery<T> Query<T>() where T : BaseModel
        //{
        //    return GetRepository<T>().DbContext.Query<T>();
        //}

        public T Add<T>(T entity) where T : BaseModel
        {
            return GetRepository<T>().Add(entity);
        }

        public int Delete<T>(T entity) where T : BaseModel
        {
            return GetRepository<T>().Delete(entity);
        }

        public int DeleteByCondition<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel
        {
            return GetRepository<T>().DeleteByCondition(whereLambda);
        }

        public IList<T> GetList<T>() where T : BaseModel
        {
            return GetRepository<T>().GetList();
        }

        public IList<T> GetList<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel
        {
            return GetRepository<T>().GetList(whereLambda);
        }

        public IList<T> GetList<T, TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false) where T : BaseModel
        {
            return GetRepository<T>().GetList<TKey>(whereLambda, orderLambda, isDesc);
        }

        public IList<T> GetPageList<T, TKey>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isDesc = false) where T : BaseModel
        {
            return GetRepository<T>().GetPageList(pageIndex, pageSize, out totalCount, whereLambda, orderLambda, isDesc);
        }

        public T GetSingle<T>(object keyVal) where T : BaseModel
        {
            return GetRepository<T>().GetSingle(keyVal);
        }

        public T GetSingle<T>(Expression<Func<T, bool>> whereLambda) where T : BaseModel
        {
            return GetRepository<T>().GetSingle(whereLambda);
        }

        public int Update<T>(T entity, params string[] proNames) where T : BaseModel
        {
            return GetRepository<T>().Update(entity, proNames);
        }

        //public IDbContext GetDbContext<T>() where T : BaseModel
        //{
        //    return GetRepository<T>().DbContext;
        //}

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~AppService() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }


        #endregion

        #region IUnitOfWork
        List<Action> insertAction = new List<Action>();
        List<Action> updateAction = new List<Action>();
        List<Action> deleteAction = new List<Action>();
        public void InsertBatch<T>(T entity) where T : BaseModel
        {
            insertAction.Add(() => this.Add<T>(entity));
        }

        public void UpdateBatch<T>(T entity, params string[] proNames) where T : BaseModel
        {
            updateAction.Add(() => this.Update<T>(entity, proNames));
        }

        public void DeleteBatch<T>(T entity) where T : BaseModel
        {
            deleteAction.Add(() => this.Delete<T>(entity));
        }

        public void Commit()
        {
            using (TransactionScope tranScope = new TransactionScope())
            {
                insertAction.ForEach(a => a());
                updateAction.ForEach(a => a());
                deleteAction.ForEach(a => a());
                tranScope.Complete();
            }
        }



        #endregion
    }
}
