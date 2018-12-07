namespace WorkOvertime
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProjectPath = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProduce = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnProjectPath
            // 
            this.btnProjectPath.Location = new System.Drawing.Point(473, 18);
            this.btnProjectPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProjectPath.Name = "btnProjectPath";
            this.btnProjectPath.Size = new System.Drawing.Size(75, 28);
            this.btnProjectPath.TabIndex = 24;
            this.btnProjectPath.Text = "选择文件";
            this.btnProjectPath.UseVisualStyleBackColor = true;
            this.btnProjectPath.Click += new System.EventHandler(this.btnProjectPath_Click);
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(134, 21);
            this.txtExcelPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(327, 25);
            this.txtExcelPath.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Excel文件路径";
            // 
            // btnProduce
            // 
            this.btnProduce.Location = new System.Drawing.Point(576, 20);
            this.btnProduce.Name = "btnProduce";
            this.btnProduce.Size = new System.Drawing.Size(86, 26);
            this.btnProduce.TabIndex = 25;
            this.btnProduce.Text = "生成";
            this.btnProduce.UseVisualStyleBackColor = true;
            this.btnProduce.Click += new System.EventHandler(this.btnProduce_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(636, 535);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 623);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnProduce);
            this.Controls.Add(this.btnProjectPath);
            this.Controls.Add(this.txtExcelPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "加班餐补统计";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProjectPath;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProduce;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

