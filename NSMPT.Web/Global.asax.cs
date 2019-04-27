using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Providers.Behavior;
using Winner.Platform.MVC.Provider;

namespace NSMPT.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ProviderManager.RegisterAccountProvider(new UserAccountProvider());
            ProviderManager.RegisterLoginProvider(new OAuthLoginProvider("admin.shop", "bb54708175854cac960ba606ddb8966e", "basic_api", "8B242CD4B2CA4B77BB3811DBFF0D2B99", null));
            
        }
    }
}
