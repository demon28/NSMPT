using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using NSMPT.Facade;
using Winner.Framework.MVC;
using Winner.Framework.Utils;
using NSMPT.Entites;

namespace NSMPT.Web.Controllers
{
    [AuthLogin]
    public class HomeController : TopControllerBase
    {

   
        public ActionResult Index()
        {
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult SendMail()
        {
            SendFacade sendFacade = new SendFacade();

            string sendermail= Request.Form["sendermail"];
            string senderpwd = Request.Form["senderpwd"];
            string recivermail = Request.Form["recivermail"];
            string content = Request.Form["content"];
            string mailtitile = Request.Form["mailtitile"];

            if (!sendFacade.SingleSend(recivermail, recivermail, sendermail, sendermail, sendermail, senderpwd, mailtitile, content, "smtp.exmail.qq.com"))
            {
                return SuccessResult();
            } 

            return FailResult();

        }


        [HttpPost]
        public ActionResult LoadAccount() {

            DataAccess.Tnsmtp_AccountCollection tnsmtp_AccountCollection = new DataAccess.Tnsmtp_AccountCollection();
            if (!tnsmtp_AccountCollection.ListByUserId(SysUser.UserId))
            {
                return FailResult("获取账户失败！");
            }

            var list = MapProvider.Map<AccountModel>(tnsmtp_AccountCollection.DataTable);
            return SuccessResultList(list, tnsmtp_AccountCollection.ChangePage);
        }





    }
}