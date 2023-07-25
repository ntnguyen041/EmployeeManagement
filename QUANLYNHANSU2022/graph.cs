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

namespace QUANLYNHANSU2022
{
    public partial class graph : Form
    {
        SqlConnection conn;
        DB db = new DB();
        public graph()
        {
            InitializeComponent();
        }

        private void graph_Load(object sender, EventArgs e)
        {
            loadingSD();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chart1.Visible == true)
            {
                MessageBox.Show(" bieu do dang duoc chay vui long ko click tiep");
            }

            else {
                chart1.Visible = true;
                if (chart2.Visible == true || chart3.Visible == true) {
                    chart2.Visible = false;
                    chart3.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chart2.Visible == true)
            {
                MessageBox.Show(" bieu do dang duoc chay vui long ko click tiep");
            }
            else
            {
                if (chart3.Visible == true || chart1.Visible == true) {
                    chart3.Visible = false;
                    chart1.Visible = false;
                }
                chart2.Visible = true;

            }
        }
        private void loadingSD()
        {
            chart1.Visible = true;
            conn = db.OpenDB();
            conn.Open();



            string sql = "select TenPhong,COUNT(MaNV)as'Nhanvien' from tblThongTin_NV,tblPhongBan where tblThongTin_NV.MaPB=tblPhongBan.MPB and TrangThai='on' group by TenPhong";
            chart1.DataSource = DB.GetDataTable(sql);
            chart1.Series["nhanvien"].XValueMember = "TenPhong";
            chart1.Series["nhanvien"].YValueMembers = "Nhanvien";
            chart1.Titles.Add("Nhân Viên Phòng");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
           
            
            
            
            string sql1 = "select top 5 (tblChamCong.luong),tblThongTin_NV.HoTen from tblThongTin_NV,tblChamCong where tblThongTin_NV.MaCC=tblChamCong.MaCC and TrangThai='on'";
            chart2.DataSource = DB.GetDataTable(sql1);
            chart2.Series["luongtop"].XValueMember = "HoTen";
            chart2.Series["luongtop"].YValueMembers = "luong";
            chart2.Titles.Add("Top 5 ky luc lương");


            string sql2 = "select TenPhong,sum(luong)as'luong' from ((tblThongTin_NV inner join tblChamCong on tblChamCong.MaCC=tblThongTin_NV.MaCC)inner join tblPhongBan on tblThongTin_NV.MaPB=tblPhongBan.MPB) group by TenPhong";
            chart3.DataSource = DB.GetDataTable(sql2);
            chart3.Series["luongphong"].XValueMember = "TenPhong";
            chart3.Series["luongphong"].YValueMembers = "luong";
            chart3.Titles.Add("Lương của từng Phòng ");

            conn.Close();
        }

        private void btnCT_Click(object sender, EventArgs e)
        {

            if (chart3.Visible == true)
            {
                MessageBox.Show(" bieu do dang duoc chay vui long ko click tiep");
            }

            else
            {
                chart3.Visible = true;
                if (chart1.Visible == true || chart2.Visible == true)
                {
                    chart1.Visible = false;
                    chart2.Visible = false;
                }
            }
        }

        private void btnThoatlon_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
    
}
