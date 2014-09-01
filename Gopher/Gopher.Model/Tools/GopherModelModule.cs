using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using Gopher.Model.Repositories;
using Ninject.Modules;

namespace Gopher.Model.Tools
{
    /// <summary>
    /// Contains dependencies related to Model.
    /// </summary>
    public class GopherModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}
