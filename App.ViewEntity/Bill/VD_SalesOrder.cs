using Mg.Framework;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public partial class VD_SalesOrder : VD_Base
    {
        #region Model  
        /// <summary>
        /// 订单号
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? OrderDate { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public Guid? CustomerID { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerID_Code { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerID_Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string DeliveryMethod { get; set; }
        /// <summary>
        /// 预交日期
        /// </summary>
        public DateTime? AcceptDate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Guid? PackingID { get; set; }
        /// <summary>
		/// 
		/// </summary>
		public string PackingID_PackingCode { get; set; }
        /// <summary>
        /// 包装方式
        /// </summary>
        public string PackingID_PackingName { get; set; }
        /// <summary>
        /// 所属工程
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        /// 订单等级
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 客户PO
        /// </summary>
        public string CustomerPO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public DateTime? ApprovalDate { get; set; }

        /// <summary>
        /// 铝锭价日期
        /// </summary>
        public DateTime? AluminumPriceDate { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Audit { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AuditDate { get; set; }


        public string Maker { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MakeDate { get; set; }
        #endregion
    }

    public partial class VD_SalesOrder
    {
        /// <summary>
        /// 订单明细
        /// </summary>
        public IEnumerable<VD_SalesOrderDetail> OrderItems { get; set; }
    }

   

}
