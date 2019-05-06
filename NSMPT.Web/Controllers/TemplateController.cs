using NSMPT.DataAccess;
using NSMPT.Entites;
using System.Web.Mvc;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;
namespace NSMPT.Web.Controllers
{

    [AuthLogin]
    public class TemplateController : TopControllerBase
    {
        // GET: Template
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult ListMark() {

            DataAccess.Tnsmtp_RaplcemarkCollection collection = new DataAccess.Tnsmtp_RaplcemarkCollection();

            if (!collection.ListByUser(SysUser.UserId))
            {
                return FailResult("查询失败");
            }
            var list = MapProvider.Map<Entites.Tnsmtp_RaplcemarkMap>(collection.DataTable);
            return SuccessResultList(list, collection.ChangePage);

        }


        [HttpPost]
        public ActionResult ListTemp()
        {

            DataAccess.Tnsmtp_MailtemplateCollection collection = new DataAccess.Tnsmtp_MailtemplateCollection();
            collection.ChangePage = this.ChangePage();
            if (!collection.ListByUserid(SysUser.UserId))
            {
                return FailResult("查询失败");
            }
            var list = MapProvider.Map<Entites.Tnsmtp_MailtemplateMap>(collection.DataTable);
            return SuccessResultList(list, collection.ChangePage);

        }

        [HttpPost]
        public ActionResult AddTemp(Entites.Tnsmtp_MailtemplateMap model)
        {
            DataAccess.Tnsmtp_Mailtemplate tnsmtp_Mailtemplate = new DataAccess.Tnsmtp_Mailtemplate();
            tnsmtp_Mailtemplate.TempName = model.TempName;
            tnsmtp_Mailtemplate.TempContent = model.TempContent;
            tnsmtp_Mailtemplate.Userid = SysUser.UserId;

            if (tnsmtp_Mailtemplate.Insert())
            {
                return FailResult("添加失败");
            }
            return SuccessResult();
        }

        [HttpPost]
        public ActionResult DelTemp(int mtid) {
            Tnsmtp_Mailtemplate tnsmtp_Mailtemplate =new DataAccess.Tnsmtp_Mailtemplate();
            if (!tnsmtp_Mailtemplate.SelectByUserid(SysUser.UserId, mtid))
            {
                return FailResult("删除失败");
            }

            if (!tnsmtp_Mailtemplate.Delete())
            {
                return FailResult("删除失败");
            }
            return SuccessResult();

        }

        [HttpPost]
        public ActionResult UpdateTemp(Tnsmtp_MailtemplateMap model) {

            DataAccess.Tnsmtp_Mailtemplate tnsmtp_Mailtemplate = new DataAccess.Tnsmtp_Mailtemplate();

            if (!tnsmtp_Mailtemplate.SelectByPK(model.MtId))
            {
                return FailResult("修改失败");
            }

            tnsmtp_Mailtemplate.TempName = model.TempName;
            tnsmtp_Mailtemplate.TempContent = model.TempContent;
            
            if (tnsmtp_Mailtemplate.Update())
            {
                return FailResult("修改失败");
            }
            return SuccessResult();

        }



    }
}