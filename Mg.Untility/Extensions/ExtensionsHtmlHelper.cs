using Mg.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mg.Untility
{
    public static partial class MangoGreenExtensions
    {
        public static MvcHtmlString EasyUIControl<T>(this HtmlHelper htmlHelper, T model) where T:VD_Base
        {
            List<string> dictionary = new List<string>();
            foreach (var p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            { 
                var attr = p.GetCustomAttribute<UIDescriptionAttribute>(false);
                if (attr != null)
                {
                    dictionary.Add(EasyUIControlString(htmlHelper, model, p, attr, true));
                }
            }
            var str = string.Join("", dictionary.ToArray());
            return new MvcHtmlString(str);  
        }
        public static MvcHtmlString EasyUIControl(this HtmlHelper htmlHelper,object model,PropertyInfo property,bool withDiv= true)
        {
            string str = ""; 
            var attr = property.GetCustomAttribute<UIDescriptionAttribute>(false);
            if (attr!=null)
            {
                str = EasyUIControlString(htmlHelper, model, property, attr, withDiv);
                //var html = GetControlType(attr.uiclass);
                //str = $"<{html} id=\"{property.Name}\" name=\"{property.Name}\" class=\"user-edit easyui-{attr.uiclass}\" style = \"width:100%;\" data-options=\"label: '{attr.caption}',labelPosition:'{attr.labelPosition}', prompt:'{attr.prompt}'";

                //#region data-options
                //if (attr.required)
                //{
                //    str += $",required:true";
                //}

                //if (attr.precision > 0)
                //{
                //    str += $",precision:{attr.precision}";
                //}

                //if (!attr.morebuttonhandler.IsEmpty())
                //{
                //    str += $",icons:[{{iconCls:'bill-browse',handler:{attr.morebuttonhandler}}}]";
                //}
                //#endregion

                //str += $"\" value = \"{property.GetValue(model, null)}\"/>"; 

                //if (withDiv)
                //{
                //    str = string.Format("<div {0} class=\"control-group\"> <div class=\"controls\">{1}<span class=\"help-block\"></span></div> </div>", attr.hidden ? "hidden=\"hidden\"" : "",str);
                //}
            }  
            return new MvcHtmlString(str);
        }

        public static string EasyUIControlString(this HtmlHelper htmlHelper, object model, PropertyInfo property, UIDescriptionAttribute attr, bool withDiv = true)
        {
            string str = "";
            var html = GetControlType(attr.uiclass);
            str = $"<{html} id=\"{property.Name}\" name=\"{property.Name}\" class=\"user-edit easyui-{attr.uiclass}\" style = \"width:100%;\" data-options=\"label: '{attr.caption}',labelPosition:'{attr.labelPosition}', prompt:'{attr.prompt}'";

            #region data-options
            if (attr.required)
            {
                str += $",required:true";
            }

            if (attr.precision > 0)
            {
                str += $",precision:{attr.precision}";
            }

            if (!attr.icons.IsEmpty())
            {
                str += $",icons:{attr.icons}";
            }
            #endregion

            str += $"\" value = \"{property.GetValue(model, null)}\"/>";

            if (withDiv)
            {
                str = string.Format("<div {0} class=\"control-group\"> <div class=\"controls\">{1}<span class=\"help-block\"></span></div> </div>", attr.hidden ? "hidden=\"hidden\"" : "", str);
            }
            return str;
        }



        private static string GetControlType(string uiclass)
        {
            string easyuiclass = uiclass;// "textbox";
            string uihtml = "input";
            //foreach (var item in uiclass.Split(' '))
            //{
            //    if (item.IndexOf("easyui-")>-1)
            //    {
            //        easyuiclass = item.Split('-')[1];
            //        break;
            //    }
            //}
            switch (easyuiclass)
            {
                case "":
                    uihtml = "";
                    break;
            }
            return uihtml;
        }


 
    }
}
