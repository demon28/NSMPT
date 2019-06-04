using NSMPT.DataAccess;
using NSMPT.Entites;
using NSMPT.Facade.Sender;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;

namespace NSMPT.Facade
{
    /// <summary>
    /// 群发邮件
    /// </summary>
    public class GroupSender : FacadeBase, ISender
    {

        public bool Send()
        {


            Log.Info("=====开始发送群发邮件=====");
            DataAccess.Tnsmtp_EmailCollection tnsmtp_EmailCollection = new DataAccess.Tnsmtp_EmailCollection();

            Log.Info("开始查询群发数据");
            if (!tnsmtp_EmailCollection.ListSendByFlagStatus((int)EmailFlagStatus.群发))
            {
                Log.Info("查询群发件失败");
                Alert("查询群发件失败！");
                return false;
            }
            int sendcount = tnsmtp_EmailCollection.DataTable.Rows.Count;
            Log.Info("群发邮件数量：" + sendcount);
            if (sendcount == 0)
            {
                Log.Info("没有群发邮件");
                Alert("没有群发邮件");
                return true;
            }


            Log.Info("开始遍历数据");

            foreach (DataRow dr in tnsmtp_EmailCollection.DataTable.Rows)
            {
                int mailid = int.Parse(dr[Tnsmtp_Email._MAIL_ID].ToString());

                DataAccess.Tnsmtp_Email tnsmtp_Email = new Tnsmtp_Email();
                Log.Info("开始查询邮件内容！");
                if (!tnsmtp_Email.SelectByPK(mailid))
                {
                    Log.Info("异常，邮件不存在！");
                    Alert("邮件不存在");
                    return false;
                }
                Log.Info("创建发送对象！");
                GroupSendFacade send = new GroupSendFacade();
                if (!send.SendEmail(dr))
                {
                    Log.Info("SendFacade 发送失败，修改发送状态");
                    tnsmtp_Email.FlagStatus = (int)EmailFlagStatus.发送失败;
                    tnsmtp_Email.Senddate = DateTime.Now;
                    tnsmtp_Email.Remarks = send.PromptInfo.Message;

                    if (!tnsmtp_Email.Update())
                    {
                        Log.Info("修改发送状态失败");
                        Alert("修改发送状态失败!");
                        return false;
                    }
                    continue;
                }

                Log.Info("SendFacade发送成功！，开始修改发送状态");

                tnsmtp_Email.FlagStatus = (int)EmailFlagStatus.已发送;
                tnsmtp_Email.Senddate = DateTime.Now;
                if (!tnsmtp_Email.Update())
                {
                    Log.Info("修改发送状态失败");
                    Alert("修改发送状态失败!");
                    return false;
                }



            }

            Log.Info("=====结束发送群发邮件=====");
            return true;



        }


    }
}
