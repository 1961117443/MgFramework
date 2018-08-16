using System.Web.Mvc;

namespace App.Areas.BaseData
{
    public class BaseDataAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BaseData";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               this.AreaName+ "_default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { area= this.AreaName,action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}