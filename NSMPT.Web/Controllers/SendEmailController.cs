using NSMPT.Entites;
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
    public class SendEmailController : TopControllerBase
    {
        // GET: SendEmail
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult List(string keywords)
        {
            DataAccess.Tnsmtp_EmailCollection tnsmtp_EmailCollection = new DataAccess.Tnsmtp_EmailCollection();
            tnsmtp_EmailCollection.ChangePage = this.ChangePage();

            if (!tnsmtp_EmailCollection.ListSendByUserid(SysUser.UserId, keywords))
            {
                return FailResult("查询失败！");
            }
            var list = MapProvider.Map<Tnsmtp_EmailMap>(tnsmtp_EmailCollection.DataTable);
            return SuccessResultList(list, tnsmtp_EmailCollection.ChangePage);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Entites.Tnsmtp_EmailMap model)
        {

            DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
            tnsmtp_Email.Bcc = model.Bcc;
            tnsmtp_Email.AccountId = model.AccountId;
            tnsmtp_Email.Userid=SysUser.UserId;
            tnsmtp_Email.Content = model.Content;
            tnsmtp_Email.Tomail = model.Tomail;
            tnsmtp_Email.Inmail = model.Inmail;
            tnsmtp_Email.Subject = model.Subject;
            tnsmtp_Email.Wcc = model.Wcc;
            tnsmtp_Email.Status = 1;

            if (!tnsmtp_Email.Insert())
            {
                return FailResult("发送失败！");
            }
            return SuccessResult("发送成功！");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Tnsmtp_EmailMap model)
        {

            DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
            if (!tnsmtp_Email.SelectDraftByUserid(SysUser.UserId, model.MailId))
            {
                return FailResult("修改失败！");
            }
            tnsmtp_Email.Bcc = model.Bcc;
            tnsmtp_Email.AccountId = model.AccountId;
            tnsmtp_Email.Userid = SysUser.UserId;
            tnsmtp_Email.Content = model.Content;
            tnsmtp_Email.Tomail = model.Tomail;
            tnsmtp_Email.Inmail = model.Inmail;
            tnsmtp_Email.Subject = model.Subject;
            tnsmtp_Email.Wcc = model.Wcc;
            tnsmtp_Email.Status = 1;

            if (!tnsmtp_Email.Insert())
            {
                return FailResult("保存失败！");
            }
            return SuccessResult("保持成功！");


        }

        [HttpPost]

        public ActionResult Delete(int mailid)
        {

            DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
            if (!tnsmtp_Email.SelectDraftByUserid(SysUser.UserId, mailid))
            {
                return FailResult("删除失败！");
            }
            if (!tnsmtp_Email.Delete())
            {
                return FailResult("删除失败！");
            }
            return SuccessResult("删除成功！");


        }

       
        public ActionResult Receipt() {

            if (string.IsNullOrEmpty(Request.QueryString["mid"]))
            {
                return View();
            }

            int mid= Convert.ToInt32(Request.QueryString["mid"]);

            DataAccess.Tnsmtp_Email  tnsmtp_Email= new DataAccess.Tnsmtp_Email();

            if (!tnsmtp_Email.SelectByPK(mid))
            {
                return View();
            }
            tnsmtp_Email.FlagRead = 1;
            tnsmtp_Email.Update();
            
            return View();

        }

    }
}