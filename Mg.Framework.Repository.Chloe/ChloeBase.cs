using Chloe;
using Mg.DB.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.Repository.Chloe
{
   public  class ChloeBase: IDisposable
    {

        private IDbContext _dbContext;
        public IDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = DbContextFactory.CreateContext();
                }
                return _dbContext;
            }
            set
            {
                _dbContext = value;
            }
        }

        public Task DoAsync(Action<IDbContext> action, bool? startTransaction = null)
        {
            return Task.Run(() =>
            {
                using (var dbContext = DbContextFactory.CreateContext())
                {
                    if (startTransaction.HasValue && startTransaction.Value)
                    {
                        dbContext.DoWithTransaction(() =>
                        {
                            action(dbContext);
                        });
                    }
                    else
                    {
                        action(dbContext);
                    }
                }
            });
        }

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
        // ~Base() {
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
    }
}
