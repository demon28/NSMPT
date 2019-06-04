using NSMPT.DataAccess;
using NSMPT.Entites;
using NSMPT.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;

namespace NSMPT.Web.Controllers
{
    [AuthLogin]
    public class SpiderController : TopControllerBase
    {
        // GET: Spider
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List() {

            DataAccess.Tnsmtp_SpidermailCollection tnsmtp_SpidermailCollection = new DataAccess.Tnsmtp_SpidermailCollection();
            tnsmtp_SpidermailCollection.ChangePage = this.ChangePage();

            if (!tnsmtp_SpidermailCollection.ListByAllSp())
            {
                return FailResult("查询失败！");
            }
            var list = MapProvider.Map<Tnsmtp_SpidermailMap>(tnsmtp_SpidermailCollection.DataTable);
            return SuccessResultList(list, tnsmtp_SpidermailCollection.ChangePage);


        }

        [HttpPost]
        public ActionResult BatchInsert(List<int> spids,int gid) {

            Spider2Contact spider = new Spider2Contact();
            if (!spider.Enter(spids,gid,SysUser.UserId))
            {
                return FailResult(spider.PromptInfo.CustomMessage);
            }
            return SuccessResult("添加成功！");
        }




    }
}