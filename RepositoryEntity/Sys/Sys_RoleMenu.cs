 

using System;
using Chloe.Entity;
using Mg.Framework;
namespace RepositoryModel
{
    /// <summary>
    /// 实体类Sys_RoleMenu。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableAttribute("Sys_RoleMenu")]
    [Serializable]
    public partial class Sys_RoleMenu:BaseModel
    {
        [NotMapped]
        public override Guid Id { get  ; set  ; }
        #region Model
        /// <summary>
        /// 角色代码
        /// </summary>
        [ColumnAttribute(IsPrimaryKey = true)]
		public string RoleCode{get;set;}
		/// <summary>
		/// 菜单代码
		/// </summary>
		[ColumnAttribute(IsPrimaryKey = true)]
		public string MenuCode{get;set;}
		#endregion

}
}