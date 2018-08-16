using Mg.DB.Untility;
using Mg.Framework.IService;
using App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryModel;
using Chloe;

namespace Mg.Framework.Service
{
    public class SysModuleService: ISysModuleService
    {
        public List<Sys_Button> GetButton(IModule module)
        {

            var list = DbContextFactory.CreateContext().Query<Sys_Button>().Where(w => w.SysMenuId == module.ID && w.Enabled != 0).OrderBy(w => w.Sort).ToList();
            return list;
        }

        public async Task<List<Sys_Button>> GetButtonAsync(IModule module)
        {

            var list = await DbContextFactory.CreateContext().Query<Sys_Button>().Where(w => w.SysMenuId == module.ID && w.Enabled != 0).OrderBy(w => w.Sort).ToListAsync();
            return list;
        }
    }
}
