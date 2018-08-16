
using Mg.Core;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.IService
{
    public interface ISys_UserService : IAppService<Sys_User>
    {
        IResult Login(Sys_User sysUser);
    }
}
