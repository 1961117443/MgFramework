using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mg.Framework;
using RepositoryModel;

namespace App.ViewModel
{
   public  class BaseModule : IModule
    {
        public Guid ID { get;protected set; }
        public List<Sys_Button> Buttons { get; set; } 
        public ICacheProvider Cache { get; set; }
        public int DataState { get; set; }
        public ModuleType ModuleType { get; set; }
        public BaseModule(Guid Id)
        {
            ID = Id;
        }
         
    }
}
