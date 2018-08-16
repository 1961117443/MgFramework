using Mg.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class VD_SectionBar:VD_Base
    {
        #region Model  
        public int RowNo { get; set; }
        
        /// 
        /// </summary>
        public Guid? SectionBarCategoryID { get; set; }
        /// <summary>
		/// 
		/// </summary>
		public string SectionBarCategoryID_SectionBarCategoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SectionBarCategoryID_SectionBarCategoryName { get; set; }
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
        public string CustomerCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public decimal? Theoreticalweight { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string WallThickness { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public Guid? CustomerID { get; set; }

        public string CustomerID_Code { get; set; }
        public string CustomerID_Name { get; set; }


        public string HeatInsulationList { get; set; }
        #endregion
    }
}
