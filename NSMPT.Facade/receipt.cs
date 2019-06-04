using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSMPT.Facade
{
   public class Receipt
    {
        /// <summary>
        /// 添加回执功能
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string SetReceipt(string context, int mid)
        {

            string src = Entites.Tool.GetUrl.GetSiteUrl() + "/SendEmail/Receipt?mid=" + mid;

            string img = "<img src='" + src + "' alt='' style='display: inline - block; width: 0; height: 0' />";

            return context += "<br/><br/><br/>" + img;

        }

    }
}
