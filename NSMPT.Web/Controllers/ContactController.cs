﻿using NSMPT.Entites;
using NSMPT.Entites.Tool;
using NSMPT.Facade;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            if (model.Gid==0)
            {
                return FailResult("请先添加小组！");
            }

            DataAccess.Tnsmtp_Contact tnsmtp = new DataAccess.Tnsmtp_Contact();
            if (tnsmtp.SelectIsExtByEmail(SysUser.UserId,model.Email,model.Gid.Value))
            {
                return FailResult("该联系人已存在！");
            }

            DataAccess.Tnsmtp_ContactCollection tnsmtp_ContactCollection = new DataAccess.Tnsmtp_ContactCollection();
            tnsmtp_ContactCollection.ListCount(SysUser.UserId, model.Gid.Value);
            if (tnsmtp_ContactCollection.DataTable.Rows.Count>2000)
            {
                return FailResult("该小组已超过2000条邮箱！");
            }
                

            DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
            tnsmtp_Contact.ContactName = model.ContactName;
            tnsmtp_Contact.Email = model.Email;
             tnsmtp_Contact.Gid = model.Gid;
            tnsmtp_Contact.Status = 0;
            tnsmtp_Contact.UserId = SysUser.UserId;

            if (!tnsmtp_Contact.Insert())
            {
                return FailResult("添加失败！");
            }
            return SuccessResult("添加成功！");
        }
        [HttpPost]
        public ActionResult ListContact(string keyword,int? Gid)
        {
            DataAccess.Tnsmtp_ContactCollection tnsmtp_ContactgroupCollection = new DataAccess.Tnsmtp_ContactCollection();
            tnsmtp_ContactgroupCollection.ChangePage = this.ChangePage();
            if (!tnsmtp_ContactgroupCollection.ListByUserid(SysUser.UserId, keyword,Gid))
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
        public ActionResult DeleteAllContact(int[] ContactId)
        {
            if (ContactId.Length<=0)
            {
                return FailResult("请选择联系人");
            }

            DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
            if (!tnsmtp_Contact.DeleteAllByUserId(SysUser.UserId, ContactId))
            {
                return FailResult();
            }
            return SuccessResult();
        }


        [HttpPost]
        public ActionResult UpdateGroupAllContact(int gid,int[] ContactId)
        {
            if (ContactId.Length <= 0)
            {
                return FailResult("请选择联系人");
            }

            DataAccess.Tnsmtp_Contact tnsmtp_Contact = new DataAccess.Tnsmtp_Contact();
            if (!tnsmtp_Contact.UpdateGroupAllByUserId(SysUser.UserId, gid, ContactId))
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
        public ActionResult AddGroup(string Groupname) {
            DataAccess.Tnsmtp_Contactgroup tnsmtp_Contactgroup = new DataAccess.Tnsmtp_Contactgroup();
            tnsmtp_Contactgroup.Groupname = Groupname;
            tnsmtp_Contactgroup.Userid = SysUser.UserId;
            tnsmtp_Contactgroup.Status = (int)Entites.Status.正常;
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
                return FailResult("删除失败！");
            }

            tnsmtp_Contactgroup.Status = 1;
          
            if (!tnsmtp_Contactgroup.Update())
            {
                return FailResult("删除失败！");
            }
            return SuccessResult();
        }


        [HttpPost]
        public ActionResult UpdateGroup(int Gid,string Groupname)
        {

    

            DataAccess.Tnsmtp_Contactgroup tnsmtp_Contactgroup = new DataAccess.Tnsmtp_Contactgroup();

            if (!tnsmtp_Contactgroup.SelecByUserid(SysUser.UserId, Gid))
            {
                return FailResult("查询失败！");
            }

            tnsmtp_Contactgroup.Groupname = Groupname;

            if (!tnsmtp_Contactgroup.Update())
            {
                return FailResult("修改失败！");
            }
            return SuccessResult("修改成功");
        }



        [HttpPost]
        public ActionResult ListGroup() {
            DataAccess.Tnsmtp_ContactgroupCollection collection = new DataAccess.Tnsmtp_ContactgroupCollection();
            collection.ChangePage= this.ChangePage();

            if (!collection.ListByUserid(SysUser.UserId))
            {
                return FailResult("获取列表信息失败！ ");
            }
         
            var list = MapProvider.Map<Tnsmtp_ContactgroupMap>(collection.DataTable);
            return SuccessResultList(list, collection.ChangePage);

        }

        [HttpPost]
        public ActionResult ExpExcelContact(string url) {
            string filename = SysUser.UserId+"_"+Guid.NewGuid().ToString();
            var path = string.Empty;

            if (Request.Files.Count > 0)
            {

                HttpPostedFileBase uploadFile = Request.Files[0] as HttpPostedFileBase;
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    if (Path.GetExtension(uploadFile.FileName)!= ".xls" && Path.GetExtension(uploadFile.FileName) != ".xlsx")
                    {
                            return FailResult("请上传excel文件！");
                    }
                    if (Directory.Exists(Server.MapPath("/File/UserFile/" + SysUser.UserId+"/")) == false)
                    {
                        Directory.CreateDirectory(Server.MapPath("/File/UserFile/" + SysUser.UserId + "/"));
                    }
                    filename += Path.GetExtension(uploadFile.FileName);
                    path = Path.Combine("/File/UserFile/" + SysUser.UserId + "/", filename);
                    uploadFile.SaveAs(Server.MapPath(path));
                }

            }


            return SuccessResult(filename);



        }

      
        [HttpPost]
        public ActionResult ImportContact(string filename)
        {

            string path = Server.MapPath("/File/UserFile/" + SysUser.UserId + "/") + filename;
            DataTable excelTable = new DataTable();
            excelTable =  ImportExcel.GetExcelDataTable(path);

            ImportContactFacade import = new ImportContactFacade();
            if (!import.Import(excelTable, SysUser.UserId))
            {
                return FailResult(import.PromptInfo.Message);
            }
            return SuccessResult("导入成功！");

        }


    }
}