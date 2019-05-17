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
                DataAccess.Tnsmtp_AccountCollection tnsmtp_Account = new DataAccess.Tnsmtp_AccountCollection();
                tnsmtp_Account.ListByUserId(SysUser.UserId);
                var accountlist = MapProvider.Map<AccountModel>(tnsmtp_Account.DataTable);

                foreach (var item in accountlist)
                {
                    if (item.Isdefault==1)
                    {
                        accountid = item.Aid;
                    }
                }

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


    }
}