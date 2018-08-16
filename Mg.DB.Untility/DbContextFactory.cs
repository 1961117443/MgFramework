using Chloe;
using Chloe.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Mg.DB.Untility
{
    /// <summary>
    /// Chloe的IDbContext工厂
    /// </summary>
    public class DbContextFactory
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        protected static string ConnectionString { get; private set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        protected static DatabaseType DbType { get; set; }


        static DbContextFactory()
        {
            ConnectionString = ConnectionManager.ModelDbConnString;
            DbType = DatabaseType.SqlServer;
        }

        #region CreateContext
        public static IDbContext CreateContext()
        {

            IDbContext dbContext = CreateContext(ConnectionString);
            return dbContext;
        }

        public static IDbContext CreateContext(string connString)
        {
            IDbContext dbContext = CreateContext(DbType,connString);
            return dbContext; 
        }

        /// <summary>
        /// 最终调用创建IDbContext的方法
        /// 使用CallContext缓存起来
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static IDbContext CreateContext(DatabaseType dbType, string connString)
        { 
            var key = $"{typeof(DbContextFactory).Name}_{dbType.ToString()}_{connString}";
            key = Encrypt.MD5Encrypt.Encrypt(key);
            IDbContext dbContext = CallContext.GetData(key) as IDbContext;
            if (dbContext==null )
            {
                switch (dbType)
                {
                    case DatabaseType.SqlServer:
                        dbContext = CreateSqlServerContext(connString);
                        break;
                    case DatabaseType.SqlLite:
                        dbContext = CreateSqlLiteContext(connString);
                        break;
                    case DatabaseType.MySql:
                        dbContext = CreateMySqlContext(connString);
                        break;
                    case DatabaseType.Oracle:
                        dbContext = CreateOracleContext(connString);
                        break;
                    default:
                        dbContext = CreateSqlServerContext(connString);
                        break;
                }
                CallContext.SetData(key, dbContext);
            } 
            return dbContext;
        } 
        #endregion

        #region RealContext
        private static IDbContext CreateOracleContext(string connString)
        {
            throw new NotImplementedException();
        }

        private static IDbContext CreateMySqlContext(string connString)
        {
            throw new NotImplementedException();
        }

        private static IDbContext CreateSqlLiteContext(string connString)
        {
            throw new NotImplementedException();
        }

        private static IDbContext CreateSqlServerContext(string connString)
        {
            MsSqlContext context = new MsSqlContext(connString);
            context.PagingMode = PagingMode.OFFSET_FETCH; 
            return context;
        } 
        #endregion
    }

     
}
