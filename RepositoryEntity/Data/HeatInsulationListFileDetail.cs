

using System;
using Chloe.Entity;
using Mg.Framework;
namespace RepositoryModel
{
    /// <summary>
    /// 实体类HeatInsulationListFileDetail。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableAttribute("HeatInsulationListFileDetail")]
    [Serializable]
    public partial class HeatInsulationListFileDetail : BaseModel
    {
        #region Model 
        /// <summary>
        /// 
        /// </summary>
        public Guid MainID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RowNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? SonSectionBarID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Dosage { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public Guid? InID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CloseUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CloseDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? RubberStrip { get; set; }
        #endregion

    }
}