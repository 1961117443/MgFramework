using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{

    public class TextBoxIcon
    {
        public string iconCls { get; set; }
        public string handler { get; set; }
        public IconOptions param { get; set; }
    }

    public class IconOptions
    {
        public string url { get; set; }
    }
}
