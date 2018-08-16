using Mg.Encrypt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.DB.Untility
{
    public sealed class ConnectionManager
    {
        /// <summary>
        /// 业务数据库链接字符串
        /// </summary>
        public static string ModelDbConnString { get; private set; }
        /// <summary>
        /// 配置数据库链接字符串
        /// </summary>
        public static string MetaDbConnString { get; private set; }
        /// <summary>
        /// 文件数据库连接字符串
        /// </summary>
        public static string FileDbConnString { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public static string SysDbConnString { get; private set; }


        static ConnectionManager()
        {
            ModelDbConnString = DesEncrypt.Decrypt(ConfigurationManager.ConnectionStrings["MangoGreenContext"].ConnectionString);
           // MetaDbConnString = DesEncrypt.Decrypt(ConfigurationManager.ConnectionStrings["MetaDbContext"].ConnectionString);
        }



    }
}
