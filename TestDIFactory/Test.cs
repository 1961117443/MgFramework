using Mg.Cache;
using Mg.Core.IOC;
using Mg.Framework;
using Mg.Framework.IRepository;
using Mg.Framework.IService;
using Mg.Framework.Repository.Chloe;
using Mg.Framework.Service;
using Unity;
using Unity.Injection;

namespace TestDIFactory
{
    public  class Test
    {
        public static void Init()
        { 
            DIFactory.Instance.RegisterType(typeof(IBaseRepository<>), typeof(ChloeBaseRepository<>));
            DIFactory.Instance.RegisterType(typeof(IBaseRepository), typeof(ChloeBaseRepository));
            DIFactory.Instance.RegisterType(typeof(IAppService<>), typeof(AppService<>));
            DIFactory.Instance.RegisterType(typeof(IBaseService), typeof(BaseService));
            DIFactory.Instance.RegisterType(typeof(ISalesOrderService), typeof(SalesOrderService));
            DIFactory.Instance.RegisterType(typeof(ICustomerService), typeof(CustomerService));
            DIFactory.Instance.RegisterType(typeof(IPackingService), typeof(PackingService));
            DIFactory.Instance.RegisterType(typeof(ISurfaceService), typeof(SurfaceService));
            DIFactory.Instance.RegisterType(typeof(ISectionBarService), typeof(SectionBarService));
            DIFactory.Instance.RegisterType(typeof(ISys_MenuService), typeof(Sys_MenuService));
            DIFactory.Instance.RegisterType(typeof(ICacheProvider), typeof(CustomCache));
            DIFactory.Instance.RegisterType(typeof(ISysModuleService), typeof(SysModuleService));
            DIFactory.Instance.RegisterType(typeof(ISys_UserService), typeof(Sys_UserService));
             
        }
    }
}
