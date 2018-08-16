 

using System;
using Chloe.Entity;
using Mg.Framework;
namespace RepositoryModel
{
    /// <summary>
    /// 实体类HeatInsulationListFile。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableAttribute("HeatInsulationListFile")]
    [Serializable]
    public partial class HeatInsulationListFile : BaseModel
    {
        #region Model 
        /// <summary>
        /// 
        /// </summary>
        public int RowNo { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public string BillType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Maker { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MakeDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Audit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FirstAuditDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AuditDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? States { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Mender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? HeatSectionBarID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HeatInsulationList { get; set; }
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
        public bool? IsStop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? Heat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? MeterTakeChild { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? ProductID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PartitionList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StopDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StopOper { get; set; }
        #endregion

    }
}