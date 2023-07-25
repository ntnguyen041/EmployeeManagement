using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;




namespace QUANLYNHANSU2022
{

 
    public partial class login : Form
    {
        DB db=new DB();
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        private int quyen;
        private string manv;


        public int Quyen { get { return quyen; } set { quyen = value; } }

        public string Manv { get => manv; set => manv = value; }

        public login()
        {
            InitializeComponent();
        }



        private void login_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
            //displayShowView();
        }
        public int layquyen(string tk, string mk) {
             
            conn=db.OpenDB();
            conn.Open();
            string sql = "select * from tbluser where username='" + tk + "' and password='" + mk + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                conn.Close();
                return (int)dt.Rows[0]["quyen"];
            }
            catch (Exception err) {
                throw;
            }

        }
        public string layma(string tk, string mk)
        {
            conn=db.OpenDB();
            conn.Open();
            string sql = "select * from tbluser where username='" + tk + "' and password='" + mk + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                conn.Close();
                return dt.Rows[0]["ID"].ToString();
            }
            catch (Exception err)
            {
                throw;
            }

        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            conn = db.OpenDB();
            conn.Open();
                //
                string tk = txtTaiKhoan.Text;
                string mk = txtMatKhau.Text;
                string sql = "select * from tbluser,tblthongtin_nv where username='" + tk + "' and password='" + mk + "'and id=manv and trangthai='on'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
            //
            if (dta.Read() == true)
            {
                quyen = layquyen(tk, mk);
                manv = layma(tk, mk);
                setingall st = new setingall(quyen, manv);
                this.Hide();
                st.ShowDialog();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Tài Khoản của bạn ko đúng hoặt đã bị xóa");
            }
                conn.Close();
            
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        



        private void btntthoat_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            if (sosanh(txtmkmA.Text, txtmkmB.Text) != 1)
            {
                MessageBox.Show("Mật Khau mới khong khơp");
            }
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Vui Long quay lai login chúng tôi muốn biết tài khoản của bạn");
            }    
            else if(txtmkcu.Text!=""){
                try
                {
                    conn = db.OpenDB();
                    cmd = new SqlCommand("update tblUser set password=@mkmoi where username=@tk and password=@mk", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@mkmoi", txtmkmB.Text);
                    cmd.Parameters.AddWithValue("@tk", txtTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@mk", txtmkcu.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("doi thanh cong");
                    conn.Close();
                    panel1.Visible = false;

                }
                catch (Exception err) {
                    MessageBox.Show("doi ko thanh cong");
                }
            }
        }
        private int sosanh(string a, string b)
        {
            int kq;
            if (a == b)
            {
                 kq = 1;
            }
            else
            {
                 kq = 2;
            }
            return kq;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnThoatlon_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
