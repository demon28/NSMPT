using NSMPT.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;

namespace NSMPT.Web.Controllers
{
    [AuthLogin]
    public class ReceiveEmailController : TopControllerBase
    {

    
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult List(int? accountid,string keywords)
        {

            if (!accountid.HasValue)
            {
                DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();
                tnsmtp_Account.SelecByUserDefault(SysUser.UserId);
                accountid = tnsmtp_Account.Aid;
            }


            DataAccess.Tnsmtp_RecmailCollection recmailCollection = new DataAccess.Tnsmtp_RecmailCollection();
            recmailCollection.ChangePage = this.ChangePage();

            if (!recmailCollection.ListByAccount(accountid.Value, SysUser.UserId, keywords))
            {
                return FailResult("查询失败！");
            }
            var list = MapProvider.Map<Tnsmtp_RecmailMap>(recmailCollection.DataTable);
            return SuccessResultList(list, recmailCollection.ChangePage);

        }


        [HttpPost]
        public ActionResult IsRead(int status,int rid) {

            DataAccess.Tnsmtp_Recmail tnsmtp_Recmail = new DataAccess.Tnsmtp_Recmail();

            if (!tnsmtp_Recmail.SelectByPK(rid))
            {
                return FailResult("网络连接故障！");

            }
            tnsmtp_Recmail.FlagRead = status==1?0:1;

            if (!tnsmtp_Recmail.Update())
            {
                return FailResult("修改失败！");
            }

            return SuccessResult("修改成功！");
        }

        [HttpPost]
        public ActionResult IsStar(int status, int rid)
        {

            DataAccess.Tnsmtp_Recmail tnsmtp_Recmail = new DataAccess.Tnsmtp_Recmail();

            if (!tnsmtp_Recmail.SelectByPK(rid))
            {
                return FailResult("网络连接故障！");
            }
            tnsmtp_Recmail.FlagStatus = status == 1 ? 0 : 1;

            if (!tnsmtp_Recmail.Update())
            {
                return FailResult("修改失败！");
            }

            return SuccessResult("修改成功！");
        }


    }
}