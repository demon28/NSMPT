using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace NSMPT.Entites.Tool
{
   public static class GetUrl
    {

        public static string GetSiteUrl()
        {
            string fullUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            string querystring = HttpContext.Current.Request.Url.PathAndQuery;
            string url = fullUrl.Replace(querystring, "");
            return url;
        }

    }
}
