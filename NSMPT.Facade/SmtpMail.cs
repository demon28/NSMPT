using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NSMPT.Facade
{
    class SmtpMail : ISmtpMail
    {
        #region private fields
        private const string enter = "\r\n";

        /// <summary>
        /// 设定语言代码,默认设定为GB2312,如不需要可设置为""
        /// </summary>
        private string _charset = "GB2312";

        /// <summary>
        /// 发件人地址
        /// </summary>
        private string _from = "";

        /// <summary>
        /// 发件人姓名
        /// </summary>
        private string _fromName = "";

        /// <summary>
        /// 回复邮件地址
        /// </summary>
        ///public string ReplyTo="";

        /// <summary>
        /// 收件人姓名
        /// </summary>	
        private string _recipientName = "";

        /// <summary>
        /// 收件人列表
        /// </summary>
        private Hashtable Recipient = new Hashtable();

        /// <summary>
        /// 邮件服务器域名
        /// </summary>	
        private string mailserver = "";

        /// <summary>
        /// 邮件服务器端口号
        /// </summary>	
        private int mailserverport = 25;

        /// <summary>
        /// SMTP认证时使用的用户名
        /// </summary>
        private string username = "";

        /// <summary>
        /// SMTP认证时使用的密码
        /// </summary>
        private string password = "";

        /// <summary>
        /// 是否需要SMTP验证
        /// </summary>		
        private bool ESmtp = false;

        /// <summary>
        /// 是否Html邮件
        /// </summary>		
        private bool _html = false;


        /// <summary>
        /// 邮件附件列表
        /// </summary>
        private IList Attachments;

        /// <summary>
        /// 邮件发送优先级,可设置为"High","Normal","Low"或"1","3","5"
        /// </summary>
        private string priority = "Normal";

        /// <summary>
        /// 邮件主题
        /// </summary>		
        private string _subject;

        /// <summary>
        /// 邮件正文
        /// </summary>		
        private string _body;

        /// <summary>
        /// 密送收件人列表
        /// </summary>
        ///private Hashtable RecipientBCC=new Hashtable();

        /// <summary>
        /// 收件人数量
        /// </summary>
        private int RecipientNum = 0;

        /// <summary>
        /// 最多收件人数量
        /// </summary>
        private int recipientmaxnum = 5;

        /// <summary>
        /// 密件收件人数量
        /// </summary>
        ///private int RecipientBCCNum=0;

        /// <summary>
        /// 错误消息反馈
        /// </summary>
        private string errmsg;

        /// <summary>
        /// TcpClient对象,用于连接服务器
        /// </summary>	
        private TcpClient tc;

        /// <summary>
        /// NetworkStream对象
        /// </summary>	
        private NetworkStream ns;

        /// <summary>
        /// 服务器交互记录
        /// </summary>
        private string logs = "";

        /// <summary>
        /// SMTP错误代码哈希表
        /// </summary>
        private Hashtable ErrCodeHT = new Hashtable();

        /// <summary>
        /// SMTP正确代码哈希表
        /// </summary>
        private Hashtable RightCodeHT = new Hashtable();
        #endregion





        #region Properties


        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject
        {
            get
            {
                return this._subject;
            }
            set
            {
                this._subject = value;
            }
        }

        /// <summary>
        /// 邮件正文
        /// </summary>
        public string Body
        {
            get
            {
                return this._body;
            }
            set
            {
                this._body = value;
            }
        }


        /// <summary>
        /// 发件人地址
        /// </summary>
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                this._from = value;
            }
        }

        /// <summary>
        /// 设定语言代码,默认设定为GB2312,如不需要可设置为""
        /// </summary>
        public string Charset
        {
            get
            {
                return this._charset;
            }
            set
            {
                this._charset = value;
            }
        }

        /// <summary>
        /// 发件人姓名
        /// </summary>
        public string FromName
        {
            get
            {
                return this._fromName;
            }
            set
            {
                this._fromName = value;
            }
        }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string RecipientName
        {
            get
            {
                return this._recipientName;
            }
            set
            {
                this._recipientName = value;
            }
        }

        /// <summary>
        /// 邮件服务器域名和验证信息
        /// 形如："user:pass@www.server.com:25",也可省略次要信息。如"user:pass@www.server.com"或"www.server.com"
        /// </summary>	
        public string MailDomain
        {
            set
            {
                string maidomain = value.Trim();
                int tempint;

                if (maidomain != "")
                {
                    tempint = maidomain.IndexOf("@");
                    if (tempint != -1)
                    {
                        string str = maidomain.Substring(0, tempint);
                        MailServerUserName = str.Substring(0, str.IndexOf(":"));
                        MailServerPassWord = str.Substring(str.IndexOf(":") + 1, str.Length - str.IndexOf(":") - 1);
                        maidomain = maidomain.Substring(tempint + 1, maidomain.Length - tempint - 1);
                    }

                    tempint = maidomain.IndexOf(":");
                    if (tempint != -1)
                    {
                        mailserver = maidomain.Substring(0, tempint);
                        mailserverport = System.Convert.ToInt32(maidomain.Substring(tempint + 1, maidomain.Length - tempint - 1));
                    }
                    else
                    {
                        mailserver = maidomain;

                    }


                }

            }
        }



        /// <summary>
        /// 邮件服务器端口号
        /// </summary>	
        public int MailDomainPort
        {
            set
            {
                mailserverport = value;
            }
        }



        /// <summary>
        /// SMTP认证时使用的用户名
        /// </summary>
        public string MailServerUserName
        {
            set
            {
                if (value.Trim() != "")
                {
                    username = value.Trim();
                    ESmtp = true;
                }
                else
                {
                    username = "";
                    ESmtp = false;
                }
            }
        }

        /// <summary>
        /// SMTP认证时使用的密码
        /// </summary>
        public string MailServerPassWord
        {
            set
            {
                password = value;
            }
        }


        public string ErrCodeHTMessage(string code)
        {
            return ErrCodeHT[code].ToString();
        }
        /// <summary>
        /// 邮件发送优先级,可设置为"High","Normal","Low"或"1","3","5"
        /// </summary>
        public string Priority
        {
            set
            {
                switch (value.ToLower())
                {
                    case "high":
                        priority = "High";
                        break;

                    case "1":
                        priority = "High";
                        break;

                    case "normal":
                        priority = "Normal";
                        break;

                    case "3":
                        priority = "Normal";
                        break;

                    case "low":
                        priority = "Low";
                        break;

                    case "5":
                        priority = "Low";
                        break;

                    default:
                        priority = "High";
                        break;
                }
            }
        }

        /// <summary>
        ///  是否Html邮件
        /// </summary>
        public bool Html
        {
            get
            {
                return this._html;
            }
            set
            {
                this._html = value;
            }
        }


        /// <summary>
        /// 错误消息反馈
        /// </summary>		
        public string ErrorMessage
        {
            get
            {
                return errmsg;
            }
        }

        /// <summary>
        /// 服务器交互记录
        /// </summary>
        public string Logs
        {
            get
            {
                return logs;
            }
        }

        /// <summary>
        /// 最多收件人数量
        /// </summary>
        public int RecipientMaxNum
        {
            set
            {
                recipientmaxnum = value;
            }
        }


        #endregion



        /// <summary>
        /// 添加一个收件人
        /// </summary>
        /// <param name="Recipients"></param>
        /// <returns></returns>
        private bool AddRecipient(string Recipients)
        {
            //修改等待邮件验证的用户重复发送的问题
            //Recipient.Clear();
            //RecipientNum = 0;
            if (RecipientNum < recipientmaxnum)
            {
                Recipient.Add(RecipientNum, Recipients);
                RecipientNum++;
                return true;
            }
            else
            {
                Dispose();
                throw (new ArgumentOutOfRangeException("Recipients", "收件人过多不可多于 " + recipientmaxnum + " 个"));
            }
        }

        private void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Send()
        {
            return false;
        }

        /// <summary>
        /// 添加多个收件人
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool AddRecipient(params string[] Recipients)
        {

            if (Recipient == null)
            {
                Dispose();
                throw (new ArgumentNullException("Recipients"));
            }
            for (int i = 0; i < Recipients.Length; i++)
            {
                string recipient = Recipients[i].Trim();
                if (recipient == String.Empty)
                {
                    Dispose();
                    throw new ArgumentNullException("Recipients[" + i + "]");
                }
                if (recipient.IndexOf("@") == -1)
                {
                    Dispose();
                    throw new ArgumentException("Recipients.IndexOf(\"@\")==-1", "Recipients");
                }
                if (!AddRecipient(recipient))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
