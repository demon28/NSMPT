using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSMPT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NSMPT.Facade.SendFacade send = new Facade.SendFacade();

            send.SingleSend("274733956@qq.com", "jelly", "jelly2019@clearandfresh.net", "Near", "jelly2019@clearandfresh.net", "Aa654321@", "测试邮件", "<span syle='color:red'>发送一个测试邮件</span>", "smtp.exmail.qq.com");
        }
    }
}
