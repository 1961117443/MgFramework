using Mg.Framework.IService;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ViewModel;
using Mg.DB.Untility;
using System.Linq.Expressions;
using Chloe;
using Mg.Core;

namespace Mg.Framework.Service
{ 
    public class Sys_MenuService : AppService<Sys_Menu>, ISys_MenuService
    {
       

        protected Map<VD_Sys_Menu, Sys_Menu> Map = new Map<VD_Sys_Menu, Sys_Menu>();
        public List<VD_Sys_Menu> GetMenus(Expression<Func<VD_Sys_Menu, bool>> where = null)
        {
           return  DefaultQuery(q =>
            {
                if (where != null)
                {
                     q = q.Where(where);
                }
                return q.ToList();
            });
        }

        public void DefaultQuery(Action<IQuery<VD_Sys_Menu>> action)
        {
            using (var db = DbContextFactory.CreateContext())
            {
                var query = db.Query<Sys_Menu>().LeftJoin<Sys_Menu>((q, p) => q.ParentId == p.Id).
                    Select((q, p) => new VD_Sys_Menu()
                    {
                        Id = q.Id,
                        //AutoID = 0,
                        ButtonMode = q.ButtonMode,
                        Enabled = q.Enabled,
                        IconClass = q.IconClass,
                        IconUrl = q.IconUrl,
                        MenuCode = q.MenuCode,
                        MenuName = q.MenuName,
                        MenuType = q.MenuType,
                        ParentId = q.ParentId,
                        ParentId_Code = p.MenuCode,
                        Sort = q.Sort,
                        Url = q.Url,
                        Remark = q.Remark
                    });
                action?.Invoke(query);
                //return query.FirstOrDefault();
            }
        }
        public T DefaultQuery<T>(Func<IQuery<VD_Sys_Menu>,T> func)
        {
            T t = default(T);
            DefaultQuery(q => { t = func.Invoke(q); });
            return t;
        }

        public VD_Sys_Menu GetMenu(Guid Id)
        {
            VD_Sys_Menu entity = null;
            DefaultQuery(q => entity=q.Where(w => w.Id == Id).FirstOrDefault());
            return entity;
        }

        public bool SaveMenu(VD_Sys_Menu entity)
        {
            Sys_Menu menu = Map.Resolve(entity);
            if (entity.Id.Equals(Guid.Empty))
            {
                //新增 
                menu.Id = Guid.NewGuid();
                menu.ParentCode = "";
                menu = base.Add(menu);  
            }
            else
            {
                menu = base.Save(menu); 
            }
            return menu != null;
        }

        public List<VD_Sys_Menu> GetUserMenus(BaseLoginer baseLoginer)
        {
            return MenuList;
        } 

        public List<LayuiMenu> GetUserMenu()
        {

            return listNavs;
        }

        public LayuiMenu[] GetChildMenus(string code)
        {
            var menu = listNavs.FirstOrDefault(w => w.code == code) ?? new LayuiMenu();
            if (menu.children == null)
            {
                menu.children = new LayuiMenu[0];
            }
            return menu.children;
            //return listNavs.ToArray();
        }

        private static  List<VD_Sys_Menu> MenuList = new List<VD_Sys_Menu>();
        private static List<LayuiMenu> listNavs = new List<LayuiMenu>();
        static Sys_MenuService()
        {
            #region List<VD_Sys_Menu>
            VD_Sys_Menu menu = new VD_Sys_Menu()
            {
                MenuCode = "OrderOnline",
                MenuName = "在线下单",
                ParentCode = "Order",
                MenuType = 2,
                ButtonMode = 1,
                Url = "/Order/Online/Index",
                IconClass = "",
                IconUrl = "",
                Sort = 1,
                Enabled = 1
            };
            MenuList.Add(menu);
            menu = new VD_Sys_Menu()
            {
                MenuCode = "Order",
                MenuName = "网上订单",
                ParentCode = "",
                MenuType = 2,
                ButtonMode = 1,
                Url = "#",
                IconClass = "",
                IconUrl = "",
                Sort = 2,
                Enabled = 1
            };
            MenuList.Add(menu);
            menu = new VD_Sys_Menu()
            {
                MenuCode = "Basic",
                MenuName = "基础资料",
                ParentCode = "",
                MenuType = 2,
                ButtonMode = 1,
                Url = "#",
                IconClass = "",
                IconUrl = "",
                Sort = 1,
                Enabled = 1
            };
            MenuList.Add(menu);
            menu = new VD_Sys_Menu()
            {
                MenuCode = "SectionBar",
                MenuName = "型材型号",
                ParentCode = "Basic",
                MenuType = 2,
                ButtonMode = 1,
                Url = "/BaseData/SectionBar/List",
                IconClass = "",
                IconUrl = "",
                Sort = 1,
                Enabled = 1
            };
            MenuList.Add(menu);
            menu = new VD_Sys_Menu()
            {
                MenuCode = "Packing",
                MenuName = "包装方式",
                ParentCode = "Basic",
                MenuType = 2,
                ButtonMode = 1,
                Url = "/BaseData/Packing/List",
                IconClass = "",
                IconUrl = "",
                Sort = 1,
                Enabled = 1
            };
            MenuList.Add(menu);
            menu = new VD_Sys_Menu()
            {
                MenuCode = "System",
                MenuName = "系统设置",
                ParentCode = "",
                MenuType = 2,
                ButtonMode = 1,
                Url = "#",
                IconClass = "",
                IconUrl = "",
                Sort = 0,
                Enabled = 1
            };
            MenuList.Add(menu);
            menu = new VD_Sys_Menu()
            {
                MenuCode = "Menu",
                MenuName = "菜单管理",
                ParentCode = "System",
                MenuType = 2,
                ButtonMode = 1,
                Url = "/Sys/Menu/Index",
                IconClass = "",
                IconUrl = "",
                Sort = 1,
                Enabled = 1
            };
            MenuList.Add(menu);
            #endregion

            #region List<LayuiMenu>
            listNavs.AddRange(
                new LayuiMenu[] {
                new LayuiMenu("contentManagement")
                {
                    title = "系统设置",
                    icon = "icon-text",
                    href = "#",
                    spread = false,
                    children = new LayuiMenu[]
                    {
                        new LayuiMenu("01")
                        {
                            title = "菜单管理",
                            icon = "icon-text",
                            href = "/Sys/Menu/Index",
                            spread = false
                        },
                        new LayuiMenu("01")
                        {
                            title = "图片管理",
                            icon = "&#xe634;",
                            href = "page/img/images.html",
                            spread = false
                        },
                        new LayuiMenu("01")
                        {
                            title = "其他页面",
                            icon = "&#xe630;",
                            href = "",
                            spread = false,
                            children = new LayuiMenu[]
                            {
                                new LayuiMenu("01")
                                {
                                    title = "404页面",
                                    icon = "&#xe61c;",
                                    href = "page/404.html",
                                    spread = false
                                },
                                new LayuiMenu("01")
                                {
                                    title = "登录",
                                    icon = "&#xe609;",
                                    href = "page/login/login.html",
                                    spread = false,
                                    target = "_blank"
                                }
                            }
                        }
                    }
                },
                new LayuiMenu("memberCenter")
                {
                    title = "基础资料",
                    icon = "icon-text",
                    href = "#",
                    spread = false,
                    children = new LayuiMenu[]
                    {
                        new LayuiMenu("01")
                        {
                            title = "型材型号",
                            icon = "&#xe61c;",
                            href = "/BaseData/SectionBar/List",
                            spread = false
                        },
                        new LayuiMenu("01")
                        {
                            title = "包装方式",
                            icon = "&#xe61c;",
                            href = "/BaseData/Packing/List",
                            spread = false
                        },
                        new LayuiMenu("01")
                        {
                            title = "表面方式",
                            icon = "&#xe61c;",
                            href = "page/404.html",
                            spread = false
                        }
                    }
                },
                new LayuiMenu("systemeSttings")
                {
                    title = "订单管理",
                    icon = "icon-text",
                    href = "#",
                    spread = false,
                    children = new LayuiMenu[]
                    {
                       new LayuiMenu("01")
                       {
                        title = "网上订单",
                        icon = "&#xe61c;",
                        href = "/Order/Online/Index",
                        spread = false
                        }
                    }
                },
                new LayuiMenu("seraphApi")
                {
                    title = "微信管理",
                    icon = "icon-text",
                    href = "#",
                    spread = false
                }
                });
            #endregion
        }
        
    }
}
