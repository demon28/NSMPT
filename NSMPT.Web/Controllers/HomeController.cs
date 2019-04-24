using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using NSMPT.Facade;
namespace NSMPT.Web.Controllers
{
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




      
    }
}