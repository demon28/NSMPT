namespace NSMPT.ImpDate
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_insert = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.btn_file = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(619, 19);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 23);
            this.btn_insert.TabIndex = 0;
            this.btn_insert.Text = "开始导入";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.Btn_insert_Click);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(49, 75);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_log.Size = new System.Drawing.Size(645, 304);
            this.tb_log.TabIndex = 1;
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(49, 21);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(437, 21);
            this.tb_url.TabIndex = 2;
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(512, 19);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(75, 23);
            this.btn_file.TabIndex = 3;
            this.btn_file.Text = "选择文件";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.Btn_file_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 410);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.btn_insert);
            this.Name = "Form1";
            this.Text = "导入数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.Button btn_file;
    }
}

