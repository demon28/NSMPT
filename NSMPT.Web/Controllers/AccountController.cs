using NSMPT.Entites;
using NSMPT.Entites.Model;
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
    public class AccountController :TopControllerBase
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


     
        public ActionResult LoadMailType()
        {
            NSMPT.DataAccess.Tnsmtp_MailtypeCollection tnsmtp_MailtypeCollection = new DataAccess.Tnsmtp_MailtypeCollection();
            if (tnsmtp_MailtypeCollection.ListMailtype())
            {
                var list = MapProvider.Map<Mailtype>(tnsmtp_MailtypeCollection.DataTable);
                return SuccessResultList(list, tnsmtp_MailtypeCollection.ChangePage);
            }
            return FailResult("加载邮箱类型失败！");
      
        }

 
        [HttpPost]
        public ActionResult ListAccount() {
        
            DataAccess.Tnsmtp_AccountCollection tnsmtp_AccountCollection = new DataAccess.Tnsmtp_AccountCollection();
            if (!tnsmtp_AccountCollection.ListByUserId(SysUser.UserId))
            {
                return FailResult("获取账户失败！");
            }

            var list = MapProvider.Map<AccountListModel>(tnsmtp_AccountCollection.DataTable);
            return SuccessResultList(list, tnsmtp_AccountCollection.ChangePage);
        }


        [HttpPost]
        public ActionResult AddAccount(AccountModel model) {


            DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();
            tnsmtp_Account.Account = model.Account;
            tnsmtp_Account.Password = model.Password;

            DataAccess.Tnsmtp_AccountCollection tnsmtp_AccountCollection = new DataAccess.Tnsmtp_AccountCollection();
            tnsmtp_AccountCollection.ListByUserId(SysUser.UserId);

            if (tnsmtp_AccountCollection.DataTable.Rows.Count>0)
            {
                tnsmtp_Account.Isdefault = 0;
            }
            else
            {
                tnsmtp_Account.Isdefault = 1;
            }

            tnsmtp_Account.MailType = model.Mail_Type;
            tnsmtp_Account.Status = 0;
            tnsmtp_Account.Userid = SysUser.UserId;

            if (!tnsmtp_Account.Insert())
            {
                return FailResult("添加失败！");
            }

            return SuccessResult("添加成功！");

        }
   
        [HttpPost]
        public ActionResult DeleteAccount(int aid) {

            DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();
            if (!tnsmtp_Account.SelectByPK(aid))
            {
                return FailResult("删除失败！");
            }

            if (!tnsmtp_Account.Delete())
            {
                return FailResult("删除失败！");
            }
          

            return SuccessResult("删除成功！");
        }
  
        [HttpPost]
        public ActionResult SetDefault(int aid)
        {
            DataAccess.Tnsmtp_Account tnsmtp_Account1 = new DataAccess.Tnsmtp_Account();

            if (tnsmtp_Account1.SelectByDefault(1))
            {
                tnsmtp_Account1.Isdefault = 0;
                if (!tnsmtp_Account1.Update())
                {
                    return FailResult("设置失败！");
                }
               
            }

            DataAccess.Tnsmtp_Account tnsmtp_Account2 = new DataAccess.Tnsmtp_Account();
            if (!tnsmtp_Account2.SelectByPK(aid))
            {
                return FailResult("设置失败！");
            }

            tnsmtp_Account2.Isdefault = 1;

            if (!tnsmtp_Account2.Update())
            {
                return FailResult("设置失败！");
            }

            return SuccessResult("设置成功！");
        }

        [HttpPost]
        public ActionResult UpdateAccount(AccountModel model) {

            DataAccess.Tnsmtp_Account tnsmtp_Account = new DataAccess.Tnsmtp_Account();
            if (!tnsmtp_Account.SelectByPK(model.Aid))
            {
                return FailResult("修改失败！");
            }
            tnsmtp_Account.Account = model.Account;
            tnsmtp_Account.Password = model.Password;
            tnsmtp_Account.MailType = model.Mail_Type;

            if (!tnsmtp_Account.Update())
            {
                return FailResult("修改失败！");
            }

            return SuccessResult("修改失败！");
        }


    }
}