using Mg.Core;
using Mg.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mg.HttpModule
{
    public class LocalCacheModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += Context_PreRequestHandlerExecute;
        }

        private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //var app = sender as HttpApplication;
            //if (app != null)
            //{
            //    var xhr = app.Context.Request.Headers["X-Requested-With"];
            //    if (xhr!=null)
            //    {
            //        return;
            //    }
            //    if (!app.Context.Items.Contains(ConstantSetting.UserCacheName))
            //    {
            //        try
            //        {

            //            app.Context.Items[ConstantSetting.UserCacheName] = CacheProviderHelper.GetCacheProvider(app.Session.SessionID);
            //        }
            //        catch (Exception)
            //        {
                         
            //        }
            //    }
            //}
        }
    }
}
