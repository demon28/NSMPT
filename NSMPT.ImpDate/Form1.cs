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
        public Form1()
        {
            InitializeComponent();
        }

        StringBuilder stringBuilder = new StringBuilder();
        static int count = 0;
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
            string path = this.tb_url.Text;

            DataTable excelTable = new DataTable();
            excelTable = ImportExcel.GetExcelDataTable(path);

            Thread thread = new Thread(new ThreadStart(delegate
            {
                if (!Import(excelTable))
                {
                    MessageBox.Show("导入失败！");
                }
            }));
            thread.IsBackground = true;
            thread.Start();
        }


        public bool Import(DataTable dt)
        {

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("没有数据！");
                return false;
            }
            RemoveEmpty(dt);
     

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                count = i;
                string email= dt.Rows[i]["Email"].ToString();
                DataAccess.Tnsmtp_Spidermail spidermailexist = new DataAccess.Tnsmtp_Spidermail();

                if (spidermailexist.SelectByEmail(email))
                {
                    stringBuilder.AppendLine(count + "==已存在：" + email);
                    this.tb_log.Text = stringBuilder.ToString();
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
        
                //if (!spidermail.Insert())
                //{
                //    stringBuilder.AppendLine(count + "==添加失败：" + email);
                //    this.tb_log.Text = stringBuilder.ToString();
                //    return false;
                //}
                stringBuilder.AppendLine(count + "==添加成功：" + email);
                this.tb_log.Text = stringBuilder.ToString();
            }


            return true;
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
