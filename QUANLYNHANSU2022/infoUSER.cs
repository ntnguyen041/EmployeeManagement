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
    public partial class infoUSER : Form
    {
        DB db = new DB();
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        
        private string manva;



        public infoUSER(string manv) : this()
        {
             this.manva = manv;
            ///
        }

        public infoUSER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void infoUSER_Load(object sender, EventArgs e)
        {
            loadingInfor();
        }
        
        private void loadingInfor()
        {
            conn = db.OpenDB();
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select MaNV,HoTen,GioiTinh,NgaySinh,TenPhong,CapBat,SDT,Email,diachi,trangthai,anh from tblThongTin_NV,tblphongban where mapb=MPB and manv=@manv", conn);
            cmd.Parameters.AddWithValue("@manv",manva);
            if (manva == null)
                MessageBox.Show("ko lay dc mnv ");
           
            
            SqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            txtmanv.Text = dt.Rows[0]["MaNV"].ToString();
            txthovaten.Text = dt.Rows[0]["hoten"].ToString();
            txtgioitinh.Text = dt.Rows[0]["gioitinh"].ToString();
            txtngaysinh.Text = dt.Rows[0]["ngaysinh"].ToString();
            txtphong.Text = dt.Rows[0]["TenPhong"].ToString();
            txtcapbat.Text = dt.Rows[0]["CapBat"].ToString();
            txtsdt.Text = dt.Rows[0]["SDT"].ToString();
            txtmail.Text = dt.Rows[0]["Email"].ToString();
            txtdiachi.Text = dt.Rows[0]["diachi"].ToString();
            txttrangthai.Text = dt.Rows[0]["trangthai"].ToString();
            //dua anh vao 
            string hinh = dt.Rows[0]["anh"].ToString();
            pictureBox1.Image = Image.FromFile("img\\" + hinh);
            conn.Close();
        }

    
    }
}
