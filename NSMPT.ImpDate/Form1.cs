using NSMPT.Entites.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSMPT.ImpDate
{
    public partial class Form1 : Form
    {

        // <add name="Winner.Framework.Oracle.ConnectionStringV2" connectionString="Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 114.215.210.3 )(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED) (SERVICE_NAME = ORCL)));Persist Security Info=True;User ID=mykm;Password=mykm_test2018_mykm" />
        //    <add name="Winner.Framework.Oracle.ConnectionStringV2" connectionString="Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 112.124.14.124 )(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED) (SERVICE_NAME = STARK124)));Persist Security Info=True;User ID=mykm;Password=mykm_winner2018_MYKM" />

        StringBuilder stringBuilder = new StringBuilder();
        static int count = 0;
        SynchronizationContext m_SyncContext = null;

        public Form1()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void SetTextSafePost(object text)
        {
            this.tb_log.Text = text.ToString();
        }

        private void Btn_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
        
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tb_url.Text = fileDialog.FileName;
            }
           
        }



        private void Btn_insert_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("开始导入");
            this.tb_log.Text = stringBuilder.ToString();
          

            Thread thread = new Thread(new ThreadStart(this.Import));

            thread.Start();
        }


        public void Import()
        {
            string path = this.tb_url.Text;

            DataTable dt = new DataTable();
            dt = ImportExcel.GetExcelDataTable(path);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("没有数据！");
                return ;
            }
            RemoveEmpty(dt);
     

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Thread.Sleep(300);
              

                    count = i;
                string email= dt.Rows[i]["Email"].ToString();
                DataAccess.Tnsmtp_Spidermail spidermailexist = new DataAccess.Tnsmtp_Spidermail();

                if (spidermailexist.SelectByEmail(email))
                {
                    stringBuilder.AppendLine(count + "==已存在：" + email);
                    m_SyncContext.Post(SetTextSafePost, stringBuilder.ToString());
                    continue;
                } 


                DataAccess.Tnsmtp_Spidermail  spidermail   = new DataAccess.Tnsmtp_Spidermail();

                spidermail.Email = email;
                spidermail.Firstname = dt.Rows[i]["FirstName"].ToString();
                spidermail.Lastname = dt.Rows[i]["LastName"].ToString();
                spidermail.Address = dt.Rows[i]["Address"].ToString();
                spidermail.City = dt.Rows[i]["City"].ToString();
                spidermail.State = dt.Rows[i]["State"].ToString();
                spidermail.Zip = dt.Rows[i]["Zip"].ToString();
                spidermail.Homephone = dt.Rows[i]["Homephone"].ToString();
                spidermail.Source = dt.Rows[i]["Source"].ToString();
                spidermail.Ipaddress = dt.Rows[i]["IPAddress"].ToString();
                spidermail.Regdate = DateTime.Parse( dt.Rows[i]["Regdate1"].ToString());

                if (!spidermail.Insert())
                {
                    stringBuilder.AppendLine(count + "==添加失败：" + email);
                    m_SyncContext.Post(SetTextSafePost, stringBuilder.ToString());
                    return ;
                }
                stringBuilder.AppendLine(count + "==添加成功：" + email);
                m_SyncContext.Post(SetTextSafePost, stringBuilder.ToString());
                Thread.Sleep(100);
            }

            stringBuilder.AppendLine(count + "==导入结束：");
            m_SyncContext.Post(SetTextSafePost, stringBuilder.ToString());

        }
        protected void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }




  
    }
}
