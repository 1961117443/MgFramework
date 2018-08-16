using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework
{
    public interface IBillViewModel
    {
        /// <summary>
        /// 工具栏
        /// </summary>
        string ToolBarHtml { get; set; }
        /// <summary>
        /// 可搜索字段
        /// </summary>
        string QuickSearchItemHtml { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        string ColumnsHtml { get; set; }
        /// <summary>
        /// 获取数据的url
        /// </summary>
        string GetListUrl { get; set; }
    }
}
