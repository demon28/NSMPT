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
using System.IO;

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

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TimerSendMail(Entites.Tnsmtp_EmailMap model)
        {
            model.Userid = SysUser.UserId;

            SendFacade sendFacade = new SendFacade();

            if (!sendFacade.SingleTimerSend(model))
            {
                return FailResult(sendFacade.PromptInfo.Message);
            }
            return SuccessResult("添加成功");

        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult GroupSendMail(Entites.Tnsmtp_EmailMap model,int Gid)
        {
            model.Userid = SysUser.UserId;

            SendFacade sendFacade = new SendFacade();

            if (!sendFacade.GroupSend(model,Gid))
            {
                return FailResult(sendFacade.PromptInfo.Message);
            }
            return SuccessResult("添加成功");

        }



        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TimerGroupSendMail(Entites.Tnsmtp_EmailMap model, int Gid)
        {
            model.Userid = SysUser.UserId;

            SendFacade sendFacade = new SendFacade();

            if (!sendFacade.GroupTimerSend(model, Gid))
            {
                return FailResult(sendFacade.PromptInfo.Message);
            }
            return SuccessResult("添加成功");

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


        [HttpPost]
        public ActionResult UploadAttachment()
        {

           
            string filepath = "/File/UserFile/" + SysUser.UserId + "/Attachment/";

            if (Request.Files.Count <= 0)
            {
                return FailResult("请选择要上传的文件");
            }
            HttpPostedFileBase uploadFile = Request.Files[0] as HttpPostedFileBase;
            string filename = uploadFile.FileName.Remove(uploadFile.FileName.LastIndexOf('.')) +"("+DateTime.Now.ToString("yyyyMMddHHmmss")+")"+Path.GetExtension(uploadFile.FileName);
            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                if (Directory.Exists(Server.MapPath(filepath)) == false)
                {
                    Directory.CreateDirectory(Server.MapPath(filepath));
                }
              
                filepath = Path.Combine(filepath, filename);
                uploadFile.SaveAs(Server.MapPath(filepath));
            }
            string url = GetSiteUrl() + filepath;
        
            return SuccessResult(url);
        }

        public string GetSiteUrl()
        {
            string fullUrl = Request.Url.AbsoluteUri;
            string querystring = Request.Url.PathAndQuery;
            string url = fullUrl.Replace(querystring, "");
            return url;
        }

    }
}