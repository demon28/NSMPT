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
    public class TimerSender : FacadeBase, ISender
    {
        object obj = new object();
        public bool Send()
        {
            //防止并发加锁
            lock (obj)
            {

                Log.Info("=====开始发送定时邮件=====");
                DataAccess.Tnsmtp_EmailCollection tnsmtp_EmailCollection = new DataAccess.Tnsmtp_EmailCollection();


                if (!tnsmtp_EmailCollection.ListSendByFlagStatus((int)EmailFlagStatus.定时邮件))
                {
                    Log.Info("查询定时邮件失败");
                    Alert("查询定时邮件失败！");
                    return false;
                }

                if (tnsmtp_EmailCollection.DataTable.Rows.Count == 0)
                {
                    Log.Info("没有定时邮件");
                    Alert("没有定时邮件");
                    return true;
                }

                Log.Info("需要发送邮件数量：" + tnsmtp_EmailCollection.DataTable.Rows.Count);

                foreach (DataRow dr in tnsmtp_EmailCollection.DataTable.Rows)
                {
                    DateTime sendtime = new DateTime();
                    if (!DateTime.TryParse(dr[Tnsmtp_Email._SENDDATE].ToString(), out sendtime))
                    {
                        Log.Info("发送时间为空");
                        continue;
                    }

                    int mailid = int.Parse(dr[Tnsmtp_Email._MAIL_ID].ToString());

                    Log.Info("发送时间" + sendtime + "***");

                    if (sendtime < DateTime.Now)
                    {
                        continue;
                    }

                    Log.Info("准备发送邮件：" + mailid + "***");


                    DataAccess.Tnsmtp_Email tnsmtp_Email = new Tnsmtp_Email();
                    SendFacade send = new SendFacade();
                    if (!send.SendEmail(dr))
                    {
                        tnsmtp_Email.FlagStatus = (int)EmailFlagStatus.发送失败;
                        tnsmtp_Email.Senddate = DateTime.Now;
                        if (!tnsmtp_Email.Update())
                        {
                            Log.Info("修改发送状态失败");
                            Alert("修改发送状态失败!");
                            return false;
                        }

                        continue;
                    }

                    if (!tnsmtp_Email.SelectByPK(mailid))
                    {
                        Log.Info("异常，邮件不存在！");
                        Alert("邮件不存在");
                        return false;
                    }

                    tnsmtp_Email.FlagStatus = (int)EmailFlagStatus.已发送;
                    tnsmtp_Email.Senddate = DateTime.Now;
                    if (!tnsmtp_Email.Update())
                    {
                        Log.Info("修改发送状态失败");
                        Alert("修改发送状态失败!");
                        return false;
                    }



                }

                Log.Info("=====结束发送定时邮件=====");
                return true;
            }

        }


    }
}
