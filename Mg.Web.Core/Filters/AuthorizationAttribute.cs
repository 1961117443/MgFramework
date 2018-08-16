using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mg.Web.Core.Filters
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            if (!FormsAuth.IsAuthenticated)
            {
                //  filterContext.Controller. 
                filterContext.Result = new RedirectResult("/Account/Index");
            }
            //base.OnAuthorization(filterContext);
        }
    }
}
