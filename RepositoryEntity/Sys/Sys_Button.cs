 

using System;
using Chloe.Entity;
using Mg.Framework;
namespace RepositoryModel
{
    /// <summary>
    /// 实体类Sys_Button。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableAttribute("Sys_Button")]
    [Serializable]
    public partial class Sys_Button : BaseModel
    {
        #region Model

        public Guid SysMenuId { get; set; }
        /// <summary>
        /// 按钮名称
        /// </summary>
        public string ButtonName { get; set; }
        /// <summary>
        /// 可用状态
        /// </summary>
        public int EnableState { get; set; }
        /// <summary>
        /// 按钮类型
        /// </summary>
        public int ButtonType { get; set; } 
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
        /// js事件方法
        /// </summary>
        public string JsEvent { get; set; }
        /// <summary>
        /// 是否分隔符
        /// </summary>
        public int Split { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int Enabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string AddBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? AddOn { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        public string EditBy { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? EditOn { get; set; }
        #endregion

    }
}