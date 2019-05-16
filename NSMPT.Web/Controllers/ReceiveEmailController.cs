using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NSMPT.Web.Controllers
{
    public class ReceiveEmailController : Controller
    {
        // GET: ReceiveEmail
        public ActionResult Index()
        {
            NSMPT.Facade.ImapEmail imapEmail = new Facade.ImapEmail();
            imapEmail.GetMail(37);
            return View();
        }
    }
}