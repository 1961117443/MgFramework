using App.ViewModel;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.IService
{
   public  interface ISysModuleService
    {
        List<Sys_Button> GetButton(IModule module);

        Task<List<Sys_Button>> GetButtonAsync(IModule module);
    }
}
