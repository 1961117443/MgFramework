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
    /// 实体类SectionBar。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableAttribute("SectionBar")]
    [Serializable]
    public partial class SectionBar:BaseModel
    {
       #region Model 
		/// <summary>
		/// 
		/// </summary>
		public int RowNo{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DrawingDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string DrawingModel{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string WallThickness{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Venner{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Theoreticalweight{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Perimeter{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PrimaryVenner{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OverRate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ExcessMaterialLength{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? HeadTailLength{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? Amout{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SectionalArea{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public byte[] PackingPicture{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? SectionBarCategoryID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Code{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Name{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Sort{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Diagram{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string complexmethod{get;set;}
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
		public Guid? TextureID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerCode{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public long AutoID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? MachineID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? MachineDataID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? MachineID1{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? MachineDataID1{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string BillType{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? PlasticInjection{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? theorysupporting{get;set;}
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
		public decimal? Singlearea{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Walltheorysupporting{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? LastExtrudingMachineID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? HighTemperaturePaperWidth{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TransferPaperWidth{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string WallThicknessdistinguish{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? AllowSpraying{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string PriceCategory{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SectionParameters{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string WallThicknessUpperLimit{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string WallThicknessLowerLimit{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string ExtrusionModel{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Remark{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ExtrusionModelID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Circumcircle{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TheoryMeterUpperLimit{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TheoryMeterLowerLimit{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TearingOpening{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TheoryMeterBeforeTearing{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? CustomerID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? PlasticInjectionBeforeCodeID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CutAluSectionalArea{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AluDensity{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CutAluMeter{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PlasticInjectionSectionArea{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? InjectionDensity{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PlasticInjectionMeter{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? NotchCodeID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? Internal{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? InternalDecimal{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? Abroad{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AbroadDecimal{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? SectionalAreaMM{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SupportTolerance{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsOutSide{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string TearingType{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SectionLength{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SectionWidth{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Fluorocarbonarea{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string SectionBarPurpose{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StopDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string StopOper{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MoldRiceWeight{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ControlMeterWeight{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Maker{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MakeDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? LastMachineDataID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? MouldSetLastMachineDataID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? AvailableMouldCount{get;set;}
		#endregion

}
}