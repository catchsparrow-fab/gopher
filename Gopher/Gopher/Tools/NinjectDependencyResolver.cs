using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;

namespace Gopher.Tools
{
    public class NinjectDependencyResolver : IDependencyResolver//, System.Web.Http.Dependencies.IDependencyResolver
    {
        private IKernel kernel = new StandardKernel();

        public void Load(params INinjectModule[] modules)
        {
            kernel.Load(modules);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        //public IDependencyScope BeginScope()
        //{
        //    return this;
        //}

        //public void Dispose()
        //{
        //}
    }
}