using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Framework
{
 


    public class UIDescriptionAttribute:Attribute
    {
        //<input type="text" id="SectionBarID_Code" name="SectionBarID_Code" class="user-edit easyui-textbox" 
        //style="width:100%;" data-options="required:true,label:'型材型号',labelPosition:'left',prompt:''" value="@Model.SectionBarID_Code" />
        public string uiclass { get; set; }
        protected string uistyle { get; set; }

        public bool required { get; set; }
        public string caption { get; set; }
        public string labelPosition { get; set; }
        public string prompt { get; set; }
        protected string value { get; set; }
        public bool hidden { get; set; }
        public int precision { get; set; }

        //public string morebuttonhandler { get; set; }

        public int order { get; set; }

        public string icons { get; set; }
        public UIDescriptionAttribute()
        {
            hidden = false;
            required = false;
            uistyle = "width:100%;";
            prompt = "";
            labelPosition = "left";
        }
       
    }
}
