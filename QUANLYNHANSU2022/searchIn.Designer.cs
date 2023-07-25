namespace QUANLYNHANSU2022
{
    partial class searchIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTV = new System.Windows.Forms.Button();
            this.btnCV = new System.Windows.Forms.Button();
            this.btnthongtin = new System.Windows.Forms.Button();
            this.btnnvN = new System.Windows.Forms.Button();
            this.btnluong = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QUANLYNHANSU2022.IN.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 93);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(814, 319);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng hợp văn bản ";
            // 
            // btnTV
            // 
            this.btnTV.Location = new System.Drawing.Point(586, 36);
            this.btnTV.Name = "btnTV";
            this.btnTV.Size = new System.Drawing.Size(97, 54);
            this.btnTV.TabIndex = 2;
            this.btnTV.Text = "Đơn xin thôi việc";
            this.btnTV.UseVisualStyleBackColor = true;
            this.btnTV.Click += new System.EventHandler(this.btnTV_Click);
            // 
            // btnCV
            // 
            this.btnCV.Location = new System.Drawing.Point(483, 36);
            this.btnCV.Name = "btnCV";
            this.btnCV.Size = new System.Drawing.Size(97, 54);
            this.btnCV.TabIndex = 2;
            this.btnCV.Text = "Đơn xin thôi việc";
            this.btnCV.UseVisualStyleBackColor = true;
            this.btnCV.Click += new System.EventHandler(this.btnCV_Click);
            // 
            // btnthongtin
            // 
            this.btnthongtin.Location = new System.Drawing.Point(380, 36);
            this.btnthongtin.Name = "btnthongtin";
            this.btnthongtin.Size = new System.Drawing.Size(97, 54);
            this.btnthongtin.TabIndex = 3;
            this.btnthongtin.Text = "Danh sách nhân viên";
            this.btnthongtin.UseVisualStyleBackColor = true;
            this.btnthongtin.Click += new System.EventHandler(this.btnthongtin_Click);
            // 
            // btnnvN
            // 
            this.btnnvN.Location = new System.Drawing.Point(277, 36);
            this.btnnvN.Name = "btnnvN";
            this.btnnvN.Size = new System.Drawing.Size(97, 54);
            this.btnnvN.TabIndex = 4;
            this.btnnvN.Text = "Danh sách nghĩ việc";
            this.btnnvN.UseVisualStyleBackColor = true;
            this.btnnvN.Click += new System.EventHandler(this.btnnvN_Click);
            // 
            // btnluong
            // 
            this.btnluong.Location = new System.Drawing.Point(12, 36);
            this.btnluong.Name = "btnluong";
            this.btnluong.Size = new System.Drawing.Size(68, 54);
            this.btnluong.TabIndex = 6;
            this.btnluong.Text = "Thống kê lương";
            this.btnluong.UseVisualStyleBackColor = true;
            this.btnluong.Click += new System.EventHandler(this.btnluong_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(53, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::QUANLYNHANSU2022.Properties.Resources.ps3;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(718, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 36);
            this.button2.TabIndex = 51;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 412);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnluong);
            this.Controls.Add(this.btnnvN);
            this.Controls.Add(this.btnthongtin);
            this.Controls.Add(this.btnCV);
            this.Controls.Add(this.btnTV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "searchIn";
            this.Text = "searchIn";
            this.Load += new System.EventHandler(this.searchIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTV;
        private System.Windows.Forms.Button btnCV;
        private System.Windows.Forms.Button btnthongtin;
        private System.Windows.Forms.Button btnnvN;
        private System.Windows.Forms.Button btnluong;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
    }
}