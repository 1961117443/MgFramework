using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class PageInfo
    { 


        public int PageCount
        {
            get
            {
                if (PageSize>0)
                {
                    return RowCount / PageSize;
                }
                return 0;
            }
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public PageInfo()
        {
            PageIndex = 1;
            PageSize = 20;
        }
        public PageInfo(PageInfo page)
        {
            PageIndex = page.PageIndex;
            PageSize = page.PageSize;
        }
    }
}
