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
    public class DraftController : TopControllerBase
    {
        // GET: Draft
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select(int mailid) {
            DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
            if (!tnsmtp_Email.SelectDraftByUserid(SysUser.UserId, mailid))
            {
                return FailResult("查询失败！");
            }

            Entites.Tnsmtp_EmailMap model = new Tnsmtp_EmailMap();

            model.Bcc = tnsmtp_Email.Bcc;
            model.AccountId = tnsmtp_Email.AccountId;
            model.Content = tnsmtp_Email.Content;
            model.Tomail = tnsmtp_Email.Tomail;
            model.Inmail = tnsmtp_Email.Inmail;
            model.Subject = tnsmtp_Email.Subject;
            model.Wcc = tnsmtp_Email.Wcc;
            model.Status = tnsmtp_Email.Status;
           

            return SuccessResult(model);
        }


        [HttpPost]
        public ActionResult List(string keywords) {
            DataAccess.Tnsmtp_EmailCollection tnsmtp_EmailCollection = new DataAccess.Tnsmtp_EmailCollection();
            tnsmtp_EmailCollection.ChangePage = this.ChangePage();

            if (!tnsmtp_EmailCollection.ListDraftByUserid(SysUser.UserId,keywords))
            {
                return FailResult("查询失败！");
            }
            var list = MapProvider.Map<Tnsmtp_EmailMap>(tnsmtp_EmailCollection.DataTable);
            return SuccessResultList(list, tnsmtp_EmailCollection.ChangePage);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Entites.Tnsmtp_EmailMap model) {

            DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
            tnsmtp_Email.Bcc = model.Bcc;
            tnsmtp_Email.AccountId =model.AccountId;
            tnsmtp_Email.Userid = SysUser.UserId;
            tnsmtp_Email.Content = model.Content;
            tnsmtp_Email.Tomail = model.Tomail;
            tnsmtp_Email.Inmail = model.Inmail;
            tnsmtp_Email.Subject = model.Subject;
            tnsmtp_Email.Wcc = model.Wcc;
            tnsmtp_Email.Status = 2;

            if (!tnsmtp_Email.Insert())
            {
                return FailResult("保存草稿失败！");
            }
            return SuccessResult("保持草稿成功！");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Tnsmtp_EmailMap model) {

            DataAccess.Tnsmtp_Email tnsmtp_Email = new DataAccess.Tnsmtp_Email();
            if (!tnsmtp_Email.SelectDraftByUserid(SysUser.UserId, model.MailId))
            {
                return FailResult("修改失败！");
            }
            tnsmtp_Email.Bcc = model.Bcc;
            tnsmtp_Email.AccountId = model.AccountId;
            tnsmtp_Email.Content = model.Content;
            tnsmtp_Email.Tomail = model.Tomail;
            tnsmtp_Email.Inmail = model.Inmail;
            tnsmtp_Email.Subject = model.Subject;
            tnsmtp_Email.Wcc = model.Wcc;
            tnsmtp_Email.Status = 2;

            if (!tnsmtp_Email.Update())
            {
                return FailResult("保存草稿失败！");
            }
            return SuccessResult("保持草稿成功！");


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

    }
}