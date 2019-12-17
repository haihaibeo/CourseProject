﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace NewPizzaManager
{
    public class ContainerConfig : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<BLL.IDBDataOperation>().To<BLL.DBDataOperation>();
        }
    }
}
