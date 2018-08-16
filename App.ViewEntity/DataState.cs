using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace App.ViewModel
{
    /// <summary>
    /// 单据状态
    /// </summary>
    [Flags]
    public enum DataState
    {
        [Description("空")]
        Empty =1,
        [Description("浏览")]
        Browse = 2,
        [Description("新增")]
        New = 4,
        [Description("修改")]
        Edit =8,
        [Description("审核")]
        Audit = 16
    }

    /// <summary>
    /// 模块页面类型
    /// </summary>
    [Flags]
    public enum ModuleType
    {
        [Description("浏览页面")]
        Browse =1,
        [Description("编辑页面")]
        Edit =2
    }
}
