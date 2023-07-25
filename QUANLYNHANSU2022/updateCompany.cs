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
using System.Timers;
 
using System.Windows.Forms;

namespace QUANLYNHANSU2022
{
    public partial class updateCompany : Form
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmdT = new SqlCommand();
        SqlCommand cmdC = new SqlCommand();
        DataTable dt = new DataTable();
        DB db = new DB();
        private string manva;
        private int quyen;



        public updateCompany(string manv,int quyen) : this()
        {
            this.manva = manv;
            this.quyen = quyen;
            ///
        }

        /// funtion 

        private void displayShowView()
        {
            if (quyen == 3)
            {
                string sql = "select* from tblThongTin_NV,tblPhongBan where tblThongTin_NV.MaPB=tblPhongBan.MPB and trangthai='on'";
                dgv.DataSource = DB.GetDataTable(sql);

            }
            else if (quyen == 2)
            {
                string sql = "select * from tblThongTin_NV,tblPhongBan where tblThongTin_NV.MaPB=tblPhongBan.MPB and MaPB=(select MaPB from tblThongTin_NV where MaNV='" + manva + "') and trangthai='on'";
                dgv.DataSource = DB.GetDataTable(sql);
            }
        }
        private void layphongcobobox()
        {
            cbxphong.Items.Add("Phòng Nhân Sự");
            cbxphong.Items.Add("Phòng Công Nghệ Thông Tin");
            cbxphong.Items.Add("Phòng Maketing");
            cbxphong.Items.Add("Phòng kế Toán");
        }


        private string doima(string a)
        {
            if (a == "Phòng Nhân Sự")
                return a = "snNS";
            if (a == "Phòng Công Nghệ Thông Tin")
                return a = "snIT";
            if (a == "Phòng Maketing")
                return a = "snMKT";
            if (a == "Phòng kế Toán")
                return a = "snKT";
            return a;
        }
        private string doiphong(string a)
        {
            if (a == "snNS")
                return a = "Phòng Nhân Sự";
            if (a == "snIT")
                return a = "Phòng Công Nghệ Thông Tin";
            if (a == "snMKT")
                return a = "Phòng Maketing";
            if (a == "snKT")
                return a = "Phòng kế Toán";
            return a;
        }
        private void capbat()
        {
            cbxcapbat.Items.Add(1);
            cbxcapbat.Items.Add(2);
            if (quyen == 3)
            {
                cbxcapbat.Items.Add(3);
            }
        }

        private float hsl(int a)
        {
            float b;
            if (a == 2)
                 b = (float)1.5;
            else if (a == 1)
                 b = (float)1.2;
            else
                b = (float)1.8;
            return b;
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

        private string laymanhan()
        {
            conn = db.OpenDB();
            conn.Open();
            cmd = new SqlCommand("select COUNT(MaNV)+1 from tblThongTin_NV", conn);
            cmd.ExecuteNonQuery();
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt.Rows[0][0].ToString();
            }
            catch (Exception err)
            {
                throw;
            }
        }

        //private void copyanh(string url) {
        //    File.Copy(url, "img\\");
        //}

        /// </summary>

        public updateCompany()
        {
            InitializeComponent();

        }

        private void updateCompany_Load(object sender, EventArgs e)
        {
            displayShowView();
            layphongcobobox();
            capbat();
            cbxcapbat.SelectedIndex = 0;
            cbxphong.SelectedIndex = 0;
        }
        private void hidepan1() {
            btnthem.Visible = false;
            btnThoatlon.Visible = false;
            panel1.Visible = true;
            btnSuaNV.Visible = true;
            btnXoaNV.Visible = true;
            clear.Visible = true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string giotinh = null;
            int i = dgv.CurrentRow.Index;
            hidepan1();
            btnThemNV.Visible = false;
            txtma.Text = dgv.Rows[i].Cells[0].Value.ToString();
            txtma.Enabled = false;
            txtten.Text = dgv.Rows[i].Cells[1].Value.ToString();
            giotinh = dgv.Rows[i].Cells[2].Value.ToString();
            if (giotinh == "Nam")
            {
                rdoNam.Checked = true;
                radioNu.Enabled = false;
            }
            else if(giotinh=="Nữ")
            {
                rdoNam.Checked = false;
                radioNu.Checked = true;
            }
            dateTimeSinh.Text = dgv.Rows[i].Cells[3].Value.ToString();
            cbxphong.Text = doiphong(dgv.Rows[i].Cells[4].Value.ToString());
            cbxcapbat.Text = dgv.Rows[i].Cells[5].Value.ToString();
            dateTimengayvao.Text = dgv.Rows[i].Cells[6].Value.ToString();
            txtsdt.Text = dgv.Rows[i].Cells[7].Value.ToString();
            txtmail.Text = dgv.Rows[i].Cells[8].Value.ToString();
            txtdc.Text = dgv.Rows[i].Cells[9].Value.ToString();

            string anhD = dgv.Rows[i].Cells["anh"].Value.ToString();
            txtanh.Text = anhD;
            pictureBox1.Image = Image.FromFile("img\\" + anhD);
            
            

            if (quyen == int.Parse(cbxcapbat.Text)&&manva==txtma.Text)
            {
                txtma.Enabled = false;
                txtten.Enabled = true;
                radioNu.Enabled = true;
                rdoNam.Enabled = true;
                dateTimeSinh.Enabled = true;
                cbxphong.Enabled=false;
                cbxcapbat.Enabled= false;
                dateTimeSinh.Enabled = true;
                dateTimengayvao.Enabled = false;
                txtsdt.Enabled = true;
                txtmail.Enabled = true;
                txtdc.Enabled = true;
                pictureBox1.Enabled = true;
                txtanh.Enabled=true;
                //
                clear.Enabled = false;
                btnSuaNV.Enabled = true;
                btnXoaNV.Enabled = false;
            }
            if (quyen >= int.Parse(cbxcapbat.Text) && manva != txtma.Text)
            {
                txtma.Enabled = false;
                txtten.Enabled = false;
                radioNu.Enabled = false;
                rdoNam.Enabled = false;
                dateTimeSinh.Enabled = false;
                cbxphong.Enabled = false;
                cbxcapbat.Enabled = false;
                dateTimeSinh.Enabled = false;
                dateTimengayvao.Enabled = false;
                txtsdt.Enabled = false;
                txtmail.Enabled = false;
                txtdc.Enabled = false;
                pictureBox1.Enabled = false;
                txtanh.Enabled = false;

                //
                clear.Enabled = false;
                btnSuaNV.Enabled = false;
                btnXoaNV.Enabled=false;
            }
            if (quyen > int.Parse(cbxcapbat.Text))
            {
                txtma.Enabled = false;
                txtten.Enabled = true;
                radioNu.Enabled = true;
                rdoNam.Enabled = true;
                dateTimeSinh.Enabled = true;
                cbxphong.Enabled = true;
                cbxcapbat.Enabled = true;
                dateTimeSinh.Enabled = true;
                dateTimengayvao.Enabled = true;
                txtsdt.Enabled = true;
                txtmail.Enabled = true;
                txtdc.Enabled = true;
                pictureBox1.Enabled = true;
                txtanh.Enabled = true;

                //
                clear.Enabled = true;
                btnSuaNV.Enabled = true;
                btnXoaNV.Enabled = true;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (quyen == 2 && cbxcapbat.Text == "3" || txtma.Text!=manva && cbxcapbat.Text == "2")
            {
                MessageBox.Show("cấp bật của bạn hiện tại ko thể làm điều này");
            }
            else
            {
                txtdc.Text = "";
                txtmail.Text = "";
                txtsdt.Text = "";
                txtten.Text = "";
                dateTimeSinh.Text = "";
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoatnho_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dgv.Show();
            btnThoatlon.Show();
            btnthem.Show();
        }



        private void btnThemNV_Click(object sender, EventArgs e)
        {

            int nam = int.Parse(DateTime.Now.Year.ToString());
            int dtp = int.Parse(dateTimeSinh.Value.Year.ToString());
            int tuoi = nam - dtp;

            if (tuoi < 18)
                MessageBox.Show("Nhỏ hơn số tuổi quy định ko thể thêm vào danh sách nhân sự");
            else if (txtten.Text == "" || txtsdt.Text == "" || txtmail.Text == "" || txtdc.Text == "")
            {
                MessageBox.Show("Vui lòng cập nhật đủ thông tin !");
            }
            else
            {
                string trangthai = "on";
                conn = db.OpenDB();
                conn.Open();
                txtma.Text = "sn" + laymanhan();
                ///them vao ban nhan vien
                cmd = new SqlCommand("insert into tblThongTin_NV(MaNV,HoTen,GioiTinh,NgaySinh,MaPB,CapBat,NgayVao,SDT,Email,DiaChi,MaCC,TrangThai,anh) values(@MaNV,@HoTen,@GioiTinh,@NgaySinh,@MaPB,@CapBat,@NgayVao,@SDT,@Email,@DiaChi,@MaCC,@TrangThai,@anh)", conn);
                cmd.Parameters.AddWithValue("@Manv", txtma.Text);
                cmd.Parameters.AddWithValue("@hoTen", txtten.Text);
                string gioitinh = null;
                if (radioNu.Checked == true)
                    gioitinh = "Nữ";
                else
                    gioitinh = "Nam";
                cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                cmd.Parameters.AddWithValue("@NgaySinh", dateTimeSinh.Value);
                string phong = doima(cbxphong.Text);
                cmd.Parameters.AddWithValue("@MaPB", phong);
                cmd.Parameters.AddWithValue("@CapBat", cbxcapbat.Text);
                cmd.Parameters.AddWithValue("@NgayVao", dateTimengayvao.Value);
                cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
                cmd.Parameters.AddWithValue("@Email", txtmail.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtten.Text);
                cmd.Parameters.AddWithValue("@MaCC", txtma.Text);
                cmd.Parameters.AddWithValue("@TrangThai", trangthai);
                string anhD;
                if (txtanh.Text == null)
                    anhD = "snIT.jpg";
                else
                    anhD = layhinhanh(txtanh.Text);
                cmd.Parameters.AddWithValue("@anh", anhD);
                /// them vao ban tai khoản
                string sqlT = "insert into tblUser(ID,UserName,Password,Quyen,Name) values (@ID,@UserName,@Password,@Quyen,@Name)";

                cmdT = new SqlCommand(sqlT, conn);
                cmdT.Parameters.AddWithValue("@ID", txtma.Text);
                cmdT.Parameters.AddWithValue("@UserName", txtma.Text + "sn");
                cmdT.Parameters.AddWithValue("@Password", "123");
                cmdT.Parameters.AddWithValue("@Quyen", cbxcapbat.Text);
                cmdT.Parameters.AddWithValue("@Name", txtten.Text);

                /// them vao ban chấm công
                string sqlC = "insert into tblChamCong(MaCC,Thang,Nam,HSL,Ngaylam,Ngaynghi,Tienthuong,Tienphat,Tamung,luong)values(@MaCC, 5, 2022, @HSL, 28, 0, 0, 0, 0,(28-0)*200000*@HSL+0-0-0)";
                //string sqlC = "insert into tblChamCong(MaCC,HSL)values(@MaCC,@HSL)";
                cmdC = new SqlCommand(sqlC, conn);
                cmdC.Parameters.AddWithValue("@MaCC", txtma.Text);

                cmdC.Parameters.AddWithValue("@HSL", hsl(int.Parse(cbxcapbat.Text)));
                ///
                cmd.ExecuteNonQuery();
                cmdT.ExecuteNonQuery();
                cmdC.ExecuteNonQuery();
                //
                conn.Close();
                panel1.Visible = false;
                btnthem.Show();
                dgv.Show();
                btnThoatlon.Show();
                displayShowView();
                MessageBox.Show("Đã thêm một nhân viên thành công");

            }

           
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            dgv.Hide();
            btnThoatlon.Hide();
            btnthem.Hide();
            btnThemNV.Show();
            btnThemNV.Enabled = true;
            panel1.Visible = true;
            txtma.Text = "sn" + laymanhan();
            btnXoaNV.Visible = false;
            btnSuaNV.Visible = false;
            //
            txtma.Enabled = false;
            txtten.Enabled = true;
            radioNu.Enabled = true;
            rdoNam.Enabled = true;
            dateTimeSinh.Enabled = true;
            cbxphong.Enabled = true;
            cbxcapbat.Enabled = true;
            dateTimeSinh.Enabled = true;
            dateTimengayvao.Enabled = true;
            txtsdt.Enabled = true;
            txtmail.Enabled = true;
            txtdc.Enabled = true;
            pictureBox1.Enabled = true;
            txtanh.Enabled = true;

            //
            clear.Enabled = true;
        }

       

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdT = new SqlCommand();
            SqlCommand cmdC = new SqlCommand();
            conn = db.OpenDB();
            conn.Open();
            ///them vao ban nhan vien
            cmd = new SqlCommand("update tblThongTin_NV set MaNV=@Manv,HoTen=@hoTen,GioiTinh=@GioiTinh,NgaySinh=@NgaySinh,MaPB=@MaPB,CapBat=@CapBat,NgayVao=@NgayVao,SDT=@SDT,Email=@Email,DiaChi=@DiaChi,MaCC=@MaCC,anh=@anh where MaNV=@Manv", conn);
            cmd.Parameters.AddWithValue("@Manv", txtma.Text);
            cmd.Parameters.AddWithValue("@hoTen", txtten.Text);
            string gioitinh = null;
            if (radioNu.Checked == true)
                gioitinh = "Nữ";
            else
                gioitinh = "Nam";
            cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
            cmd.Parameters.AddWithValue("@NgaySinh", dateTimeSinh.Value);
            string phong = doima(cbxphong.Text);
            cmd.Parameters.AddWithValue("@MaPB", phong);
            cmd.Parameters.AddWithValue("@CapBat", cbxcapbat.Text);
            cmd.Parameters.AddWithValue("@NgayVao", dateTimengayvao.Value);
            cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
            cmd.Parameters.AddWithValue("@Email", txtmail.Text);
            cmd.Parameters.AddWithValue("@DiaChi",txtdc.Text);
            cmd.Parameters.AddWithValue("@MaCC", txtma.Text);
           
            string anhD;
            if (txtanh.Text == null)
                anhD = "snIT.jpg";
            else
                anhD = layhinhanh(txtanh.Text);
            cmd.Parameters.AddWithValue("@anh", anhD);
            //update table taif khaonr
           
            string sqlT = "update tblUser set Quyen=@Quyen where ID='"+txtma.Text+"' ";
            cmdT = new SqlCommand(sqlT, conn);
            cmdT.Parameters.AddWithValue("@Quyen",cbxcapbat.Text);
            cmdT.ExecuteNonQuery();

            //cmdT.Parameters.AddWithValue("@ID", txtma.Text);

            // update tble cham cong
            string sqlC = "update tblChamCong set HSL=@HSL  where MaCC=@MaCC";
            cmdC = new SqlCommand(sqlC, conn);
            cmdC.Parameters.AddWithValue("@MaCC", txtma.Text);
            cmdC.Parameters.AddWithValue("@HSL", hsl(int.Parse(cbxcapbat.Text)));
            cmdC.ExecuteNonQuery();
            //

            cmd.ExecuteNonQuery();
           
            if (cmd.ExecuteNonQuery() >0)
                MessageBox.Show("thanh cong");
            else
            MessageBox.Show("ko thanh cong");
            conn.Close();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (quyen == 2 && cbxcapbat.Text=="2" || cbxcapbat.Text == "3")
            {
                MessageBox.Show("bạn không thể xóa người cùng cấp bật hoặt lớn hơn");
            }
            else
            {
                conn = db.OpenDB();
                conn.Open();
                string sql = "update tblThongTin_NV set TrangThai='off' where MaNV=@manv";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", txtma.Text);
                cmd.ExecuteNonQuery();
                panel1.Visible = false;
                btnthem.Show();
                dgv.Show();
                btnThoatlon.Show();
                displayShowView();
                MessageBox.Show("Đã xóa một viên thành công");
                conn.Close();
            }

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
                    file= open.FileName;
                    p.Image = Image.FromFile(open.FileName);
                    txtanh.Text = layhinhanh(file);
                }
            }
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
