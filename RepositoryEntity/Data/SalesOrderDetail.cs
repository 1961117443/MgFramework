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
    /// 实体类SalesOrderDetail。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableAttribute("SalesOrderDetail")]
    [Serializable]
    public partial class SalesOrderDetail:BaseModel
    {
       #region Model 
		/// <summary>
		/// 
		/// </summary>
		public Guid MainID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int RowNo{get;set;}
		
        [Chloe.Entity.AutoIncrement]
		public long AutoID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? InID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string SalesOrderTraceCode{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? SectionBarID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? Bundle{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? QuantityEveryBundle{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? ScatterQuantity{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? TotalQuantity{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string WallThickness{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string FilmThickness{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TheoryMeter{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Theory6Meter{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TheoryWeight{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? SurfaceID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? AvailableMouldCount{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? PackingID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? TextureID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Sort{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string OrderLevel{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string PriceType{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SurfaceArea{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? FinishedProductWareHouseID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? AgingTemperature{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Remark{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ProcessingCharge{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Money{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string OrderLength{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string ProductionMode{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FinishDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string FinishOper{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ProductionEndDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string ProductionEndOper{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerCode{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Perimeter{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string HeatInsulationList{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NearEstimatedLength{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ProductionLength{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductionQuantity{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string ElectricPole{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? theorysupporting{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerProductName{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? Times{get;set;}
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
		public decimal? TheoryArea{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string OrderNumberLineItem{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string DetailCustomerPO{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string ProductCategory{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Theory6MeterRange{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string PageNumber{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AssessmentWeight{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string SpecialRequirementsRemark{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Assessment{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo1{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo2{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo3{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo4{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo5{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo6{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo7{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo8{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo9{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string memo10{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? number1{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? number2{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? number3{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? number4{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? number5{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? number6{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? number7{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? number8{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string SprayPowderCode{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BootCharge{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MechanicalProcessingCharge{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string RubberStrip{get;set;}
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
		public string Currency{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string HeatInsulationSurface{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string Hardness{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? AdvancePound{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? CombinationListFileDetailID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? CombinationListFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SinglePrice{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string OutRubberStrip{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string BillingCategory{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ProductionCraftID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? OxidationProductionLineFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? SprayProductionLineFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? FluorocarbonProductionLineFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? WoodProductionLineFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? HeatInsulationProductionLineFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? DeepProductionLineFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? PackingProductionLineFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? PrimaryMachineDataID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string WoodGrainPaperNo{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? AdvanceWeight{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ProductionDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CustomerDeliveryPeriod{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PackingnPrice{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? PlasticInjection{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? LimitedProductionQuantity{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ExtrusionEndDate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string ExtrusionEndOper{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? SerialNumber{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string ChangeReason{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string WithTax{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? ifinvoice{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? ifmax{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string HeatInsulationSurfaceCategory{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OrderWeight{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsAdd{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsOrderCancel{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsOrderSuspend{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsAutoFinish{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalPackingSectionArea{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CostCharge{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? CustomerSurfaceFileID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? SurfaceID1{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? LabelDefinitionID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? NeedDeepProductionProcess{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? DeepProductionProcessNameID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string MouldSpec{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldDiameter{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ProductID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? HeatLength{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string PartitionList{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? AllowOverQty{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsOutsourcing{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string InsulationStripManufacturers{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string MouldSpecs{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? AllowFewerQty{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string PaperSize{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string WoodPaperLength{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public int? OldInventoryUtilization{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string ExtrudingMachineName{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerBillCodeDetail{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public Guid? WebOrderDetailID{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TaxRate{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? WithTaxPrice{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? WithTaxMoney{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? StandardPrice{get;set;}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PriceTimes{get;set;}
		#endregion

}
}