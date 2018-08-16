using Mg.Core.IOC;
using Mg.Framework.IRepository;
using Mg.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.Service
{
    public class RepositoryFactory
    {
        public static IBaseRepository CreateService(Type type)
        {
            var server = CallContext.GetData(type.FullName) as IBaseRepository;
            if (server == null)
            {
                server = DIFactory.GetService<IBaseRepository>();
                CallContext.SetData(type.FullName, server);
            }
            return server; 
        }


        public static IBaseRepository<T> CreateService<T>() where T : BaseModel
        {
            var key = typeof(T).FullName;
            var server = CallContext.GetData(key) as IBaseRepository<T>;
            if (server == null)
            {
                Type type = typeof(IBaseRepository<>).GetTypeEx<T>();
                server = DIFactory.GetService(type) as IBaseRepository<T>;
                CallContext.SetData(key, server);
            }
            return server;
        }
    }
}
