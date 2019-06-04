using NSMPT.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;

namespace NSMPT.Facade
{
    public class ReplaceMark : FacadeBase
    {

        /// <summary>
        /// 标签替换
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userid"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public bool Replace(Tnsmtp_EmailMap model, int userid, out string replace)
        {

            string value = string.Empty;

            DataAccess.Tnsmtp_RaplcemarkCollection tnsmtp_Raplcemark = new DataAccess.Tnsmtp_RaplcemarkCollection();

            if (!tnsmtp_Raplcemark.ListByUser(userid))
            {
                replace = model.Content;
                Alert("获取模板信息失败！");
                return false;
            }


            for (int i = 0; i < tnsmtp_Raplcemark.DataTable.Rows.Count; i++)
            {
                MarkKey markKey = (MarkKey)int.Parse(tnsmtp_Raplcemark.DataTable.Rows[i]["rid"].ToString());
                string markvalue = tnsmtp_Raplcemark.DataTable.Rows[i]["mark_value"].ToString();

                switch (markKey)
                {
                    case MarkKey.收件人名称:

                        ReplacceContactName(model, markvalue, out value);
                        model.Content = value;
                        break;
                    case MarkKey.收件人邮箱:
                        ReplacceContactEmailSingle(model, markvalue, out value);
                        model.Content = value;
                        break;
                    case MarkKey.收件人电话:
                        break;
                }


            }
            replace = value;

            return true;

        }


        /// <summary>
        /// 系统标签替换收件人姓名
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mark"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        private bool ReplacceContactName(Tnsmtp_EmailMap model, string mark, out string replace)
        {


            if (!model.Content.Contains(mark))
            {
                replace = model.Content;
                return false;
            }

            replace = model.Content.Replace(mark, model.Inmail);
            return true;

        }

        /// <summary>
        /// 系统标签替换收件人邮箱(普通邮件)，没有收件人名字
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mark"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        private bool ReplacceContactEmailSingle(Tnsmtp_EmailMap model, string mark, out string replace)
        {

            if (!model.Content.Contains(mark))
            {
                replace = model.Content;
                return false;
            }

            replace = model.Content.Replace(mark, model.Inmail);
            return true;

        }

    }
}
