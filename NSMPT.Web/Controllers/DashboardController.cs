using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC;
using Javirs.Common;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;
namespace NSMPT.Web.Controllers
{

    [AuthLogin]
    public class DashboardController : TopControllerBase
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Statistics()
        {
            DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();

            if (!tnsmtp_Email.SelectByTotal(SysUser.UserId))
            {
                return FailResult("查询失败！");
            }

            int total = Convert.ToInt32(tnsmtp_Email.DataRow["total"]);
            int sending = Convert.ToInt32(tnsmtp_Email.DataRow["sending"]);
            int completed = Convert.ToInt32(tnsmtp_Email.DataRow["completed"]);
            int Faileds = Convert.ToInt32(tnsmtp_Email.DataRow["Faileds"]);

            return JsonResult(tnsmtp_Email.DataRow.ToDynamic());

        }

    }
}