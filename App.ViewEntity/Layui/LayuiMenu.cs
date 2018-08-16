using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class LayuiMenu
    {
        public string code { get; set; }
        public string title { get; set; }
        public string icon { get; set; }

        public string href { get; set; }
        public bool spread { get; set; }
        public string target { get; set; }
        public LayuiMenu[] children { get; set; }
        public LayuiMenu()
        {
            this.code = code;
        }
        public LayuiMenu(string code)
        {
            this.code = code;
        }
    } 
}
