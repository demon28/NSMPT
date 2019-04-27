using Javirs.Common.Json;
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
            ProviderManager.RegisterLoginProvider(new OAuthLoginProvider("nsmtp", "247aaae1be104bf4bf988708f2112e32", "basic_api", "f97c0202b0394f228643dad86da155e5", new OAuthUserTokenResolver("247aaae1be104bf4bf988708f2112e32", "f97c0202b0394f228643dad86da155e5")));
            
        }
    }


    public class OAuthUserTokenResolver : IUserTokenResolver
    {
        private string _uuidkey, _secret;
        public OAuthUserTokenResolver(string secret, string uuidkey)
        {
            this._uuidkey = uuidkey;
            this._secret = secret;
        }
        public int GetUserId(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return -1;
            }
            DefaultUserTokenResolver resolver = new DefaultUserTokenResolver(this._secret, this._uuidkey);
            int userid = resolver.GetUserId(json);
            if (userid <= 0)
            {
                return userid;
            }
            JsonObject JObject = JsonObject.Parse(json);
            JsonObject JContent = JObject.GetObject("Content");
            string token = JContent.GetString("Token");
            HttpContext.Current.Session["token_" + userid] = token;
            return userid;
        }
    }

}
