﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//     Website: http://ITdos.com/Dos/ORM/Index.html
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Chloe.Entity;
using Mg.Framework;
namespace RepositoryModel
{
    /// <summary>
    /// 实体类PackingCategory。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableAttribute("PackingCategory")]
    [Serializable]
    public partial class PackingCategory:BaseModel
    {
       #region Model 
		/// <summary>
		/// 
		/// </summary>
		public int RowNo{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Name{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Code{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ParentID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Level{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsStop{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Mender{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public long AutoID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string BillType{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string CloseUser{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CloseDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Maker{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MakeDate{get;set;}
		#endregion

}
}