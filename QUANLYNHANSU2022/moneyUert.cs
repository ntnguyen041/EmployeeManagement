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
    public partial class moneyUert : Form
    {
        DB db=new DB();
        SqlConnection conn;
        SqlCommand cmd;

       
        private string manva;

        public moneyUert(string manva) :this()
        {
            this.manva = manva;
        }
        public moneyUert()
        {
            InitializeComponent();
           
        }
        public void shothang() {
            conn = db.OpenDB();
            conn.Open();
            string sql = "select * from tblChamCong where MaCC='" + manva + "'";
            cmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cbThang.DataSource = dt;
            cbThang.DisplayMember = "Thang";
            cbThang.ValueMember = "Thang";
            conn.Close();
            cbThang.SelectedIndex = 0;
            cbThang.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;  

        }

        int x = 350; int y = -6; int a = 3;
        int x2 = 350;int y2 = 355;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            y += a;
            txtsochay.Location=new Point(x,y);
            if (y > 379)
            {
                y = -340;
                
            }
        }

        private void moneyUert_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            shothang();
             
            
            //xemthang(manva);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            y2 += a;
            txtchayso2.Location = new Point(x2, y2);
           
            if (y2 > 379)
            {
                y2 = -340;
            }
        }
        //public void xemthang(string ma) {
        //    // SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-2MI7RNL\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True");
        //    DataTable dt = new DataTable();
            
        //    conn.Open();
        //    string sql = "select * from tblChamCong where MaCC='"+ma+"'";
        //    cmd = new SqlCommand(sql, conn);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    da.Fill(dt);
        //    cbThang.DataSource = dt;
        //    cbThang.DisplayMember = "Thang";
        //    cbThang.ValueMember = "Thang";
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            loadluong(int.Parse(cbThang.Text),manva);
        }
        private void loadluong(int thang, string ma) {
            conn = db.OpenDB();
            conn.Open();
            string sql = "select HoTen,Ngaylam,Ngaynghi,Tienthuong,Tienphat,luong from tblChamCong,tblThongTin_NV where tblChamCong.MaCC=tblThongTin_NV.MaCC and Thang='" + thang + "' and MaNV='" + ma + "'";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            txtten.Text = dt.Rows[0][0].ToString();
            txtngaylam.Text = dt.Rows[0][1].ToString();
            txtngaynghi.Text = dt.Rows[0][2].ToString();
            txttienthuong.Text = dt.Rows[0][3].ToString();
            txttienphat.Text = dt.Rows[0][4].ToString();
            txtluong.Text = dt.Rows[0][5].ToString();
           
            conn.Close();
            chuyendoi();
        }
        private void chuyendoi()
        {
            if (txtluong.Text == "")
            {
                txtluong.Text = "tháng lương này hiện tại chua được nhập";
            }
            else if (int.Parse(txtluong.Text) < 0)
            {
                txtnopphat.Text = "Nộp Phạt :";
                int a = int.Parse(txtluong.Text) * -1;
                txtluong.Text = a.ToString() + " phòng kế toán";
            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
