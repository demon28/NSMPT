using NSMPT.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;

namespace NSMPT.Web.Controllers
{
    public class SpiderController : TopControllerBase
    {
        // GET: Spider
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List() {

            DataAccess.Tnsmtp_SpidermailCollection tnsmtp_SpidermailCollection = new DataAccess.Tnsmtp_SpidermailCollection();
            tnsmtp_SpidermailCollection.ChangePage = this.ChangePage();

            if (!tnsmtp_SpidermailCollection.ListAll())
            {
                return FailResult("查询失败！");
            }
            var list = MapProvider.Map<Tnsmtp_SpidermailMap>(tnsmtp_SpidermailCollection.DataTable);
            return SuccessResultList(list, tnsmtp_SpidermailCollection.ChangePage);


        }
    }
}