using Mg.Framework;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public interface IModule
    {
        /// <summary>
        /// 模块id
        /// </summary>
        Guid ID { get;  }
        /// <summary>
        /// 按钮列表
        /// </summary>
        List<Sys_Button> Buttons { get; set; }

        ICacheProvider Cache { get; set; }  

        int DataState { get; set; }

        ModuleType ModuleType { get; set; }

       // VD_Base ViewData { get; set; }
    }
}
