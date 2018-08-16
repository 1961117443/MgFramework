using Mg.Framework;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    
    public class VD_SalesOrderDetail : VD_Base
    {
        #region Model 
        public Guid MainID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string MainID { get; set; } 
        [UIDescription(uiclass = "textbox", caption = "转入Id", hidden = true)]
        public Guid? InID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [UIDescription(uiclass = "textbox",caption = "订单跟踪号",hidden =true)]
        public string SalesOrderTraceCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
       [UIDescription(uiclass = "textbox", caption = "型材Id", hidden = true)]
        public Guid? SectionBarID { get; set; }
        [UIDescription(uiclass = "textbox", caption = "型材型号",required =true, icons = "[{iconCls:'bill-browse',handler:com.ShowChooseBox,param:{url:'/BaseData/SectionBar/ShowDialog',ok:onlineEdit.setSectionBarData}}]")]
        public string SectionBarID_Code { get; set; }
        [UIDescription(uiclass = "textbox", caption = "型材名称", icons = "[{iconCls:'bill-browse',handler:com.ShowChooseBox,param:{url:'/BaseData/SectionBar/ShowDialog',ok:onlineEdit.setSectionBarData}}]")]
        public string SectionBarID_Name { get; set; }


        [UIDescription(uiclass = "numberspinner", caption = "订单数", required = true)]
        public int? TotalQuantity { get; set; }
        [UIDescription(uiclass = "textbox", caption = "壁厚")]
        public string WallThickness { get; set; }
        [UIDescription(uiclass = "textbox", caption = "膜厚")]
        public string FilmThickness { get; set; }
        [UIDescription(uiclass = "numberspinner", caption = "理论米重",precision =3)]
        public decimal? TheoryMeter { get; set; }
        //[UIDescription(uiclass = "numberspinner", caption = "理论米重", precision = 3)]
        public decimal? Theory6Meter { get; set; }
        //[UIDescription(uiclass = "numberspinner", caption = "理论米重", precision = 3)]
        public decimal? TheoryWeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [UIDescription(uiclass = "textbox", caption = "表面Id", hidden = true)]
        public Guid? SurfaceID { get; set; }
        [UIDescription(uiclass = "textbox", caption = "表面名称", icons = "[{iconCls:'bill-browse',handler:com.ShowChooseBox,param:{url:'/BaseData/Surface/ShowDialog',ok:onlineEdit.setSurfaceData}}]")] 
        public string SurfaceID_Name { get; set; }
        [UIDescription(uiclass = "textbox", caption = "包装Id", hidden = true)]
        public Guid? PackingID { get; set; }
        //public string PackingID_PackingCode { get; set; }
        [UIDescription(uiclass = "textbox", caption = "包装方式",icons = "[{iconCls:'bill-browse',handler:com.ShowChooseBox,param:{url:'/BaseData/Packing/ShowDialog',ok:onlineEdit.setPackData}}]")]
        public string PackingID_PackingName { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string Sort { get; set; }
        [UIDescription(uiclass = "textbox", caption = "订单等级")]
        public string OrderLevel { get; set; }

        [UIDescription(uiclass = "textbox", caption = "订单长度")]
        public string OrderLength { get; set; }

        [UIDescription(uiclass = "textbox", caption = "备注")]
        public string Remark { get; set; }

        public int RowNo { get; set; }

        #endregion
    }
}
