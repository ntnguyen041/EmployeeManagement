using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace QUANLYNHANSU2022
{
    public partial class inthongtinnv : Form
    {
        DB db = new DB();
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt = new DataTable();

        private string manva;



        public inthongtinnv(string manv) : this()
        {
            this.manva = manv;
            ///
        }
        public inthongtinnv()
        {
            InitializeComponent();
        }

        private void inthongtinnv_Load(object sender, EventArgs e)
        {
            loadingInfor();
        }
        private string layhinhanhcopy(string url)
        {
            int vt = url.LastIndexOf("\\");
            string ten = url.Substring(vt + 1);
            File.Copy(url, "img\\" + ten, true);
            return ten;
        }
        private string layhinhanh(string url)
        {
            int vt = url.LastIndexOf("\\");
            string ten = url.Substring(vt + 1);
            return ten;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                open.Filter = "(*.jpg;*.jpeg;*.bmp|*.jpg;*.jpeg;*.bmp)";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string file = null;
                    file = open.FileName;
                    p.Image = Image.FromFile(open.FileName);
                    txtanh.Text = layhinhanh(file);
                }
            }
        }

        private void btnin_Click(object sender, EventArgs e)
        {

        }
        private void loadingInfor()
        {
            conn = db.OpenDB();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select MaNV,HoTen,GioiTinh,NgaySinh,TenPhong,CapBat,SDT,Email,diachi,trangthai,anh from tblThongTin_NV,tblphongban where mapb=MPB and manv=@manv", conn);
            cmd.Parameters.AddWithValue("@manv", manva);
            if (manva == null)
                MessageBox.Show("ko lay dc mnv ");
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            txtten.Text = dt.Rows[0]["hoten"].ToString();
            //txtgioitinh.Text = dt.Rows[0]["gioitinh"].ToString();
            dateTimeSinh.Text = dt.Rows[0]["ngaysinh"].ToString();
            //txtphong.Text = dt.Rows[0]["TenPhong"].ToString();
            //txtcapbat.Text = dt.Rows[0]["CapBat"].ToString();
            txtSDT.Text = dt.Rows[0]["SDT"].ToString();
            txtemail.Text = dt.Rows[0]["Email"].ToString();
            txtdiachi.Text = dt.Rows[0]["diachi"].ToString();
            //txttrangthai.Text = dt.Rows[0]["trangthai"].ToString();
            //dua anh vao 
            string hinh = dt.Rows[0]["anh"].ToString();
            pictureBox1.Image = Image.FromFile("img\\" + hinh);
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn=db.OpenDB();
            conn.Open();
            string sql = "update tblThongTin_NV set hoten=@hoten,gioitinh=@gioitinh,ngaysinh=@ngaysinh,sdt=@sdt,email=@email,diachi=@diachi,anh=@anh where MaNV=@manv";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@hoten", txtten.Text);
            string gioitinh = null;
            if (rdonam.Checked == true)
                gioitinh = "Nữ";
            else
                gioitinh = "Nam";
            cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
            cmd.Parameters.AddWithValue("@ngaysinh", dateTimeSinh.Value);
            cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
            cmd.Parameters.AddWithValue("@anh", txtanh.Text);
            cmd.Parameters.AddWithValue("@manv", manva);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đã cập nhật thông tin thành công");
            conn.Close();
        }
    }
}
