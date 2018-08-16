using Mg.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class VD_Surface : VD_Base
    {
        /// <summary>
        /// 表面方式
        /// </summary>
        public string SurfaceCode { get; set; } 
        /// <summary>
        /// 表面名称
        /// </summary>
        public string SurfaceName { get; set; }
        /// <summary>
        /// 表面类别
        /// </summary>
        public string SurfaceCategoryID_Name { get; set; }
    }
}
