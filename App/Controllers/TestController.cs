using Mg.Core.IOC;
using Mg.Framework.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            var service = DIFactory.GetService<IBaseService>();
            return "123";// View();
        }
    }
}