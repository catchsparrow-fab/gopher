using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gopher.Model.Tools;
using Gopher.Tools;

namespace Gopher
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectDependencyResolver resolver = new NinjectDependencyResolver();
            resolver.Load(new DefaultGopherModule(), new GopherModelModule());
            DependencyResolver.SetResolver(resolver);

        }
    }
}
