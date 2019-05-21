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
        public static string ChangeLan(string text)
        {
            byte[] bs = Encoding.GetEncoding("UTF-8").GetBytes(text);
            bs = Encoding.Convert(Encoding.GetEncoding("UTF-8"), Encoding.GetEncoding("GB2312"), bs);
            return Encoding.GetEncoding("GB2312").GetString(bs);

        }

    }
}
