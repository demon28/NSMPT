using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;

namespace NSMPT.Web
{
    /// <summary>
    /// HandlerImageUpload 的摘要说明
    /// </summary>
    public class HandlerImageUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}