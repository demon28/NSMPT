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
    public class ContactController : TopControllerBase
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Tnsmtp_ContactMap model)
        {
            DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
            tnsmtp_Contact.ContactName = model.ContactName;
            tnsmtp_Contact.Email = model.Email;
            tnsmtp_Contact.Gid = model.Gid;
            tnsmtp_Contact.Status = 0;
            tnsmtp_Contact.UserId = SysUser.UserId;

            if (!tnsmtp_Contact.Insert())
            {
                return FailResult();
            }
            return SuccessResult();
        }
        [HttpPost]
        public ActionResult ListContact()
        {
            DataAccess.Tnsmtp_ContactCollection tnsmtp_ContactgroupCollection = new DataAccess.Tnsmtp_ContactCollection();
            if (!tnsmtp_ContactgroupCollection.ListByUserid(SysUser.UserId))
            {
                return FailResult();
            }
            var list = MapProvider.Map<Tnsmtp_ContactMap>(tnsmtp_ContactgroupCollection.DataTable);
            return SuccessResultList(list, tnsmtp_ContactgroupCollection.ChangePage);
        }

        [HttpPost]
        public ActionResult DeleteContact(int ContactId) {

            DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
            if (!tnsmtp_Contact.SelectByUserId(SysUser.UserId,ContactId))
            {
                return FailResult();
            }

            tnsmtp_Contact.Status = (int)Status.删除;

            if (!tnsmtp_Contact.Update())
            {
                return FailResult();
            }
            return SuccessResult();
        }

        [HttpPost]
        public ActionResult UpdateContact(Tnsmtp_ContactMap model)
        {

            DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
            if (!tnsmtp_Contact.SelectByUserId(SysUser.UserId, model.ContactId))
            {
                return FailResult();
            }
            tnsmtp_Contact.Email = model.Email;
            tnsmtp_Contact.ContactName = model.ContactName;
            tnsmtp_Contact.Gid = model.Gid;
          
            tnsmtp_Contact.Status = (int)Status.正常;

            if (!tnsmtp_Contact.Update())
            {
                return FailResult();
            }
            return SuccessResult();
        }




        [HttpPost]
        public ActionResult AddGroup(Tnsmtp_ContactgroupMap model) {
            DataAccess.Tnsmtp_Contactgroup tnsmtp_Contactgroup = new DataAccess.Tnsmtp_Contactgroup();
            tnsmtp_Contactgroup.Groupname = model.Groupname;
            tnsmtp_Contactgroup.Userid = SysUser.UserId;
            if (!tnsmtp_Contactgroup.Insert())
            {
                return FailResult();
            }
            return SuccessResult();
        }
        [HttpPost]
        public ActionResult DeleteGroup(int Gid)
        {
            DataAccess.Tnsmtp_Contactgroup tnsmtp_Contactgroup = new DataAccess.Tnsmtp_Contactgroup();

            if (!tnsmtp_Contactgroup.SelecByUserid(SysUser.UserId, Gid))
            {
                return FailResult();
            }

            tnsmtp_Contactgroup.Status = 1;
          
            if (!tnsmtp_Contactgroup.Update())
            {
                return FailResult();
            }
            return SuccessResult();
        }



        [HttpPost]
        public ActionResult ListGroup() {
            DataAccess.Tnsmtp_ContactgroupCollection collection = new DataAccess.Tnsmtp_ContactgroupCollection();
            if (!collection.ListByUserid(SysUser.UserId))
            {
                return FailResult("获取列表信息失败！ ");
            }
            var list = MapProvider.Map<Tnsmtp_ContactgroupMap>(collection.DataTable);
            return SuccessResultList(list, collection.ChangePage);

        }
    }
}