using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class ViewColumnProperty
    {
        public string field { get; set; }
        public string title { get; set; }
        public int width { get; set; }
        public bool checkbox { get; set; }
        public bool _fixed { get; set; }
        public bool sort { get; set; }

        public ViewColumnProperty(string field)
        {
            this.field = field;  
        }
    }
}
