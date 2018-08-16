using Mg.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class BillViewModel : IBillViewModel
    {
        public string ToolBarHtml { get; set; }
        public string QuickSearchItemHtml { get; set; }
        public int PageSize { get ; set ; }
        public string ColumnsHtml { get; set; }
        public string GetListUrl { get; set; }
    }
}
