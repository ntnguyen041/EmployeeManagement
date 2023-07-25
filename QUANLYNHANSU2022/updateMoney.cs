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
    public partial class updateMoney : Form
    {
        DB db = new DB();
        SqlConnection conn;
        SqlCommand cmd;
        public string manva;
        public int quyen;
        public updateMoney()
        {
            InitializeComponent();
        }
        public updateMoney(string ma, int quyen) : this()
        {
            this.manva = ma;
            this.quyen = quyen;
        }

        private void updateMoney_Load(object sender, EventArgs e)
        {
            loadview();
            loadingThang();
            
            
        }
        private void loadview()
        {
            string sql = null;
            conn = db.OpenDB();
            conn.Open();
            if (quyen == 3)
            {
                sql = "select MaNV,HoTen,TenPhong,Ngaylam,Ngaynghi,HSL,Tienthuong,Tienphat,Tamung,luong from ((tblThongTin_NV inner join tblChamCong on tblChamCong.MaCC=tblThongTin_NV.MaCC)inner join tblPhongBan on tblThongTin_NV.MaPB=tblPhongBan.MPB)where trangthai='on' and thang='" + cbbthang.Text + "'ORDER BY manv ASC";

                //sql = "select MaNV,HoTen,TenPhong,Ngaylam,Ngaynghi,HSL,Tienthuong,Tienphat,Tamung,luong from ((tblThongTin_NV inner join tblChamCong on tblChamCong.MaCC=tblThongTin_NV.MaCC)inner join tblPhongBan on tblThongTin_NV.MaPB=tblPhongBan.MPB)) where trangthai='on'";
                dataGV(sql);

            }
            else if (quyen == 2)
            {
                sql = "select MaNV,HoTen,TenPhong,Ngaylam,Ngaynghi,HSL,Tienthuong,Tienphat,Tamung,luong from ((tblThongTin_NV inner join tblChamCong on tblChamCong.MaCC=tblThongTin_NV.MaCC)inner join tblPhongBan on tblThongTin_NV.MaPB=tblPhongBan.MPB)where MaPB=(select MaPB from tblThongTin_NV where MaNV='" + manva + "') and trangthai='on' and thang='" + cbbthang.Text + "'ORDER BY manv ASC";
                dataGV(sql);
            }
            conn.Close();
        }

        private void dataGV(string sql)
        {
            dataGridView.DataSource = DB.GetDataTable(sql);

        }
        private void Capnhatthang()
        {
            if (quyen == 3)
            {
                string sql = "select DISTINCT MaNV,HoTen,TenPhong from tblPhongBan,tblThongTin_NV where tblThongTin_NV.MaPB=tblPhongBan.MPB";
                dgv.DataSource = DB.GetDataTable(sql);

            }
            else if (quyen == 2)
            {
                string sql = "select DISTINCT MaNV,HoTen,TenPhong from tblPhongBan,tblThongTin_NV where tblThongTin_NV.MaPB=tblPhongBan.MPB and MaPB=(select MaPB from tblThongTin_NV where MaNV='" + manva + "')";
                dgv.DataSource = DB.GetDataTable(sql);
            }

        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView.CurrentRow.Index;
            txtma.Text = dataGridView.Rows[i].Cells[0].Value.ToString();
            txthsl.Text = dataGridView.Rows[i].Cells[5].Value.ToString();
            txtten.Text = dataGridView.Rows[i].Cells[1].Value.ToString();
            txtPhong.Text = dataGridView.Rows[i].Cells[2].Value.ToString();
            txtNL.Text = dataGridView.Rows[i].Cells[3].Value.ToString();
            txtNN.Text = dataGridView.Rows[i].Cells[4].Value.ToString();
            txtTT.Text = dataGridView.Rows[i].Cells[6].Value.ToString();
            txtTP.Text = dataGridView.Rows[i].Cells[7].Value.ToString();
            txtTU.Text = dataGridView.Rows[i].Cells[8].Value.ToString();

        }


        private void btnCT_Click(object sender, EventArgs e)
        {
            conn = db.OpenDB();
            conn.Open();
            string sqlC = "update tblChamCong set Ngaylam=@Ngaylam,Ngaynghi=@Ngaynghi,Tienthuong=@Tienthuong,Tienphat=@Tienphat,Tamung=@Tamung,luong=((@Ngaylam-@Ngaynghi)*200000*@HSL+@Tienthuong-@Tienphat-@Tamung) where MaCC=@MaCC and thang='" + cbbthang.Text + "'";
            cmd = new SqlCommand(sqlC, conn);
            cmd.Parameters.AddWithValue("@MaCC", txtma.Text);
            cmd.Parameters.AddWithValue("@HSL", float.Parse(txthsl.Text));
            cmd.Parameters.AddWithValue("@Ngaylam", int.Parse(txtNL.Text));
            cmd.Parameters.AddWithValue("@Ngaynghi", int.Parse(txtNN.Text));
            cmd.Parameters.AddWithValue("@Tienthuong", int.Parse(txtTT.Text));
            cmd.Parameters.AddWithValue("@Tienphat", int.Parse(txtTP.Text));
            cmd.Parameters.AddWithValue("@Tamung", int.Parse(txtTU.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đã thêm lương nhân viên thành công");
            conn.Close();
            loadview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelD.Visible = true;
            panelD.Size = panelD.MaximumSize = panelD.MinimumSize = new Size(814, 412);
            string sql = "";
            if (quyen > 2)
            {
                sql = "select MaNV,HoTen,gioitinh,capbat,TenPhong,sdt from tblPhongBan,tblThongTin_NV where tblThongTin_NV.MaPB=tblPhongBan.MPB";
            }
            else
            {
                sql = "select MaNV,HoTen,gioitinh,capbat,TenPhong,sdt from tblPhongBan,tblThongTin_NV where MaPB=(select MaPB from tblThongTin_NV where MaNV='" + manva + "')";
            }
            dgvD.DataSource = DB.GetDataTable(sql);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelD.Visible = false;
        }

        private void dgvD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvD.CurrentRow.Index;
            txtmaD.Text = dgvD.Rows[i].Cells[0].Value.ToString();
            txttenD.Text = dgvD.Rows[i].Cells[1].Value.ToString();
            txtCBD.Text = dgvD.Rows[i].Cells[3].Value.ToString();
        }
        private void loadingThang()
        {
            for (int i = 1; i < 13; i++)
            {
                cbbThangD.Items.Add(i);
                cbbthang.Items.Add(i);
            }
            cbbThangD.SelectedIndex = 0;
            cbbthang.SelectedIndex = 0;
            cbbThangD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbbthang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = db.OpenDB();
            conn.Open();
            string sql = "delete tblChamCong where Thang ='" + cbbthang.Text + "' and MaCC ='" + txtma.Text + "'";
            DB.Excute(sql);
            MessageBox.Show("Đã đưuọc xóa");
            conn.Close();
            loadview();
        }

        private int kiemtra(string ma, string thang)
        {
            conn = db.OpenDB();
            conn.Open();
            //
            string sql = "select * from tblthongtin_nv,tblChamCong where MaNV='" + ma + "' and thang='" + thang + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            //
            if (dta.Read() == true)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (txtmaD.Text != "null" && kiemtra(txtmaD.Text, cbbThangD.Text) == 0)
            {
                conn = db.OpenDB();
                conn.Open();
                string sqlC = "insert into tblChamCong(MaCC,Thang,Nam,HSL)values('" + txtmaD.Text + "','" + cbbThangD.Text + "', 2022,'" + hsl(txtCBD.Text) + "')";
                DB.Excute(sqlC);
                MessageBox.Show("Đã them thang luong");
                conn.Close();
            }
            else if (txtmaD.Text == "null")
            {
                MessageBox.Show("hieu ung clict chua nhan duoc thong tin");
            }
            else if (kiemtra(txtmaD.Text, cbbThangD.Text) == 1)
            {
                MessageBox.Show("Nhân viên đã được cập nhật lương tháng này");
            }

        }
        private float hsl(string a)
        {
            float b;
            if (a == "2")
                b = (float)1.5;
            else if (a == "1")
                b = (float)1.2;
            else
                b = (float)1.8;
            return b;
        }


        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadview();
        }

        private void txtNL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtNN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtNL_TextChanged(object sender, EventArgs e)
        {
            if (txtNL.Text != "")
            {
                try
                {
                    int u = Int32.Parse(txtNL.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(" ko duoc nhap chu~ cai' ban oi ;)) ");
                    txtNL.Text = "28";
                    txtNL.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show(" ko duoc de chong ban oi ;)) ");
                txtNL.Text = "0";
            }
            if (int.Parse(txtNL.Text) > 28)
            {
                MessageBox.Show(" vui lòng không thực hiên động tác nhập sai dữ liệu ;)) ");
                txtNL.Text = "28";
            }
        }

        private void txtTT_TextChanged(object sender, EventArgs e)
        {
            if (txtTT.Text != "")
            {
                try
                {
                    int u = Int32.Parse(txtTT.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(" ko duoc nhap chu~ cai' ban oi ;)) ");
                    txtTT.Text = "0";
                    txtTT.Focus();
                    return;
                }
            }
            else {
                MessageBox.Show(" ko duoc de chong ban oi ;)) ");
                txtTT.Text = "0";
            }
            if (int.Parse(txtTT.Text) > 2000000) {
                MessageBox.Show(" thưởng tối đa 2.000.000 ;)) ");
                txtTT.Text = "2000000";
            }
        }

        private void txtNN_TextChanged(object sender, EventArgs e)
        {
            if (txtNN.Text != "")
            {
                try
                {
                    int u = Int32.Parse(txtNN.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(" ko duoc nhap chu~ cai' ban oi ;)) ");
                    txtNN.Text = "0";
                    txtNN.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show(" ko duoc de chong ban oi ;)) ");
                txtNN.Text = "0";
            }
            if (int.Parse(txtNN.Text) >= 27)
            {
                MessageBox.Show("Có vẽ như nhân viên đã thôi việc");
                txtNL.Text = "0";
                txtNN.Text = "0";
                txtTP.Text = "0";
                txtTU.Text = "0";
                txtTT.Text = "0";
            }
            if (int.Parse(txtNN.Text) >= 10)
            {
                MessageBox.Show("Có vẽ như nhân viên nghĩ quá nhiều sẽ phạt bị phạt vui lòng ko nhập số tiền bé hơn số tiền bị phạt");
                txtTP.Text = "2000000";
               
            }
            if ((int.Parse(txtNN.Text) ==5 ||int.Parse(txtNN.Text) == 6|| int.Parse(txtNN.Text) == 7 || int.Parse(txtNN.Text) == 8||int.Parse(txtNN.Text) == 9)&& int.Parse(txtTP.Text) <1000000)
            {
                MessageBox.Show("Có vẽ như nhân viên nghĩ quá nhiều sẽ phạt bị phạt vui lòng ko nhập số tiền bé hơn số tiền bị phạt");
                txtTP.Text = "1000000";
                

            }
        }

        
        private void txtTP_TextChanged(object sender, EventArgs e)
        {
            if (txtTP.Text != "")
            {
                try
                {
                    int u = Int32.Parse(txtTP.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(" ko duoc nhap chu~ cai' ban oi ;)) ");
                    txtTP.Text = "0";
                    txtTP.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show(" ko duoc de chong ban oi ;)) ");
                txtTP.Text = "0";
            }
                         
        }

        private void txtTU_TextChanged(object sender, EventArgs e)
        {
            if (txtTU.Text != "")
            {
                try
                {
                    int u = Int32.Parse(txtTP.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(" ko duoc nhap chu~ cai' ban oi ;)) ");
                    txtTU.Text = "0";
                    txtTU.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show(" ko duoc de chong ban oi ;)) ");
                txtTU.Text = "0";
            }
        }

        

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
