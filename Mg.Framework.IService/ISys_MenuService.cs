using App.ViewModel;
using Mg.Core;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework.IService
{
    public interface ISys_MenuService:IAppService<Sys_Menu>
    {
        VD_Sys_Menu GetMenu(Guid Id);
        List<VD_Sys_Menu> GetMenus(Expression<Func<VD_Sys_Menu,bool>> where =null);

        bool SaveMenu(VD_Sys_Menu entity); 
         List<VD_Sys_Menu> GetUserMenus(BaseLoginer baseLoginer);
        List<LayuiMenu> GetUserMenu();

        LayuiMenu[] GetChildMenus(string code);
    }
}
