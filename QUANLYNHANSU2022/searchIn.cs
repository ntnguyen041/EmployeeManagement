using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace QUANLYNHANSU2022
{
    public partial class searchIn : Form
    {
        SqlConnection conn;
        DB db =new DB();
        public searchIn()
        {
            InitializeComponent();
        }

        private void searchIn_Load(object sender, EventArgs e)
        {
             
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTV_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "Donthoiviec.rdlc";
            reportViewer1.RefreshReport();
        }
        private void btnCV_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "CV.rdlc";
            reportViewer1.RefreshReport();
        }
         

        private void btnthongtin_Click(object sender, EventArgs e)
        {
            conn = db.OpenDB();
            conn.Open();
            string sql = "SELECT HoTen,GioiTinh,NgaySinh,CapBat,NgayVao,SDT,Email,TenPhong FROM tblThongTin_NV, tblPhongBan where tblThongTin_NV.MaPB = tblPhongBan.MPB and TrangThai = 'on'";
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", DB.GetDataTable(sql));
            reportViewer1.LocalReport.ReportPath = "SNon.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            conn.Close();
        }

        private void btnnvN_Click(object sender, EventArgs e)
        {
            conn = db.OpenDB();
            conn.Open();
            string sql = "SELECT HoTen,GioiTinh,NgaySinh,CapBat,NgayVao,SDT,Email,TenPhong FROM tblThongTin_NV, tblPhongBan where tblThongTin_NV.MaPB = tblPhongBan.MPB and TrangThai = 'off'";
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", DB.GetDataTable(sql));
            reportViewer1.LocalReport.ReportPath = "SNoff.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            conn.Close();
        }

      

        private void btnluong_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
