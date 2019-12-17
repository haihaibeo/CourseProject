using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Ninject;

namespace BLL.Utilitites
{
    public class ServiceModule : Ninject.Modules.NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<DAL.IDatabaseRepository>().To<DAL.DatabaseRepository>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
