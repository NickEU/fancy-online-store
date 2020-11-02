﻿using BusinessLayer;
using DIContainerConfigurator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;

namespace FancyOnlineStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HookupAutofacDI();
        }

        private void HookupAutofacDI()
        {
            var builder = DIConfig.SetupContainer(EnvironmentContext.Production);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            DIConfig.FinalizeConfig();
        }
    }
}
