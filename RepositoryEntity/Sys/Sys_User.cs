

using System;
using Chloe.Entity;
using Mg.Framework;
namespace RepositoryModel
{
    /// <summary>
    /// 实体类Sys_User。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableAttribute("Sys_User")]
    [Serializable]
    public partial class Sys_User : BaseModel
    {
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDisable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Explain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool EnableData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EMail { get; set; }
        #endregion

    }
}