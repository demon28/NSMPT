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
        public ActionResult SendMail(Entites.Tnsmtp_EmailMap model)
        {
            model.Userid = SysUser.UserId;

            SendFacade sendFacade = new SendFacade();

            if (!sendFacade.SingleSend(model))
            {
                return FailResult(sendFacade.PromptInfo.Message);
            }
            return SuccessResult("发送成功");

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