using AH.Encrypt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Untility
{
    public sealed class ConnectionManager
    {
        /// <summary>
        /// 业务数据库
        /// </summary>
        public static string ModelDbConnString { get; private set; }
        /// <summary>
        /// 配置数据库
        /// </summary>
        public static string MetaDbConnString { get; private set; }
        /// <summary>
        /// w
        /// </summary>

        public static string FileDbConnString { get; private set; }
        public static string SysDbConnString { get; private set; }
         
      
        static ConnectionManager()
        {
            ModelDbConnString = DesEncrypt.Decrypt(ConfigurationManager.ConnectionStrings["ModelDbConnString"].ConnectionString);
            MetaDbConnString = DesEncrypt.Decrypt(ConfigurationManager.ConnectionStrings["MetaDbContext"].ConnectionString);
        }

        

    }
}
