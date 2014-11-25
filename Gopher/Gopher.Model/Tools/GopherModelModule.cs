using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;
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
            Bind<ITranslationRepository>().To<TranslationRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            //Bind<IPrefectureRepository>().To<PrefectureRepository>();
            Bind<IPrefectureRepository>().To<HardCodedPrefectureRepository>();
            Bind<IShopRepository>().To<ShopRepository>();
        }
    }
}
