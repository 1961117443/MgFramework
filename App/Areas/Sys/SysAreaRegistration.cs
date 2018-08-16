using System.Web.Mvc;

namespace App.Areas.Sys
{
    public class SysAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Sys";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
              name: this.AreaName+ "_default",
               url: this.AreaName + "/{controller}/{action}/{id}",
               defaults: new { area=this.AreaName, action = "Index", id = UrlParameter.Optional } 
            );
        }
    }
}