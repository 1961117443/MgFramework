using Mg.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
   public  class VD_Sys_Menu:VD_Base
   { 
        #region Model
        public Guid ParentId { get; set; }
        /// <summary>
        /// 菜单代码
        /// </summary> 
        public string MenuCode { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 父级菜单代码
        /// </summary>
        public string ParentCode { get; set; }
        /// <summary>
        /// 父级菜单代码
        /// </summary>
        public string ParentId_Code { get; set; }
        /// <summary>
        /// 菜单类型：0=未定义 1=目录 2=页面 7=备用1 8=备用2 9=备用3
        /// </summary>
        public int MenuType { get; set; }
        /// <summary>
        /// 按钮模式：0=未定义 1=动态按钮 2=静态按钮 3=无按钮
        /// </summary>
        public int ButtonMode { get; set; }
        /// <summary>
        /// 菜单导航URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图标class
        /// </summary>
        public string IconClass { get; set; }
        /// <summary>
        /// 图标Url
        /// </summary>
        public string IconUrl { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int Enabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        
        #endregion
        //    public string ButtonCode { get; set; }
        //    public string ButtonName { get; set; }
        //    public string Sort { get; set; }
        //    public string ButtonType { get; set; }
        //    public string IconClass { get; set; }
        //    public string JsEvent { get; set; }

    }
}
