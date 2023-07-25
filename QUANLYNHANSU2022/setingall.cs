using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU2022
{
    public partial class setingall : Form
    {
        private int _quyen;
        private string manva;
        public setingall()
        {
            InitializeComponent();
            submenu();
             
        }
        public setingall(int quyen,string manv) : this() {
            _quyen = quyen;
            manva = manv;
            string a3 = "Admin";
            string a2 = "Trưởng Phòng";
            string a1 = "Nhân Viên";
            if (_quyen == 1)
                label1.Text = a1;
            if (_quyen == 2)
                label1.Text = a2;
            if (_quyen == 3)
                label1.Text = a3;
        }

        private void setingall_Load(object sender, EventArgs e)
        {
            
        }

        private void submenu() {
            panelThongTin.Visible = false;
            panelCapNhat.Visible = false;
            panelCaiDat.Visible = false;
        }
        private void hidesubMenu() {
            if (panelThongTin.Visible == true)
                panelThongTin.Visible = false;

            if (panelCapNhat.Visible == true)
                panelCapNhat.Visible = false;

            if (panelCaiDat.Visible == true)
                panelCaiDat.Visible = false;
        }
        private void showsubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hidesubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        private Form actionForm = null;
        private void moForm(Form chillForm) {
            if (actionForm != null) {
                actionForm.Close();
            }
            actionForm = chillForm;
            chillForm.TopLevel = false;
            chillForm.FormBorderStyle = FormBorderStyle.None;
            chillForm.Dock = DockStyle.Fill;
            panelChilForm.Controls.Add(chillForm);
            panelChilForm.Tag = chillForm;
            chillForm.BringToFront();
            chillForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            showsubmenu(panelThongTin);
           
        }
        private void btnthongtinNV_Click(object sender, EventArgs e)
        {
            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                moForm(new infoUSER(manva));
                hidesubMenu();
            }
           
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //
            // 
            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                panelChilForm.Show();
                moForm(new slieshowCT());
                hidesubMenu();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //
            //
            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                moForm(new moneyUert(manva));
                hidesubMenu();
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                moForm(new graph());
                hidesubMenu();
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showsubmenu(panelCapNhat);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //
            //
            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                if (_quyen >= 2)
                    moForm(new updateCompany(manva, _quyen));
                else
                    moForm(new inthongtinnv(manva));
                hidesubMenu();
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //
            //
            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                if (_quyen >= 2)
                {
                    moForm(new updateMoney(manva, _quyen));
                }
                else
                    MessageBox.Show("chức năng này không dành cho bạn!");
                hidesubMenu();
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                moForm(new searchIn());
                hidesubMenu();
            }
           
        }

        

        private void button11_Click(object sender, EventArgs e)
        {
            showsubmenu(panelCaiDat);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //
            //
            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                this.Hide();
                login lg = new login();
                lg.ShowDialog();
                //moForm(new login());
            }



        }

       
        /// CHAY CHỮ 
        string quyen3 = "Thật vui khi được giám đốc ghé thăm :))";
        string quyen2 = "App sẽ cùng bạn quản lý công ty tốt hơn nhé :))";
        string quyen1 = "Chúc một tuần làm việt hiệu quả nhé !";
        int x = 0;int y=56; int a = 1;
        Random random = new Random();

        

        private void Timechaychu_Tick(object sender, EventArgs e)
        {
            if (_quyen == 1)
                txtchay_chu.Text = quyen1;
            if (_quyen == 2)
                txtchay_chu.Text = quyen2;
            if (_quyen == 3)
                txtchay_chu.Text = quyen3;

            //
            try
            {
                x += a;
                txtchay_chu.Location = new Point(x, y);
                if (x > 700)
                {
                    x = -60;
                    txtchay_chu.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                }
            }
            catch (Exception err)
            { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btnThemNV_Click(object sender, EventArgs e)
        //{
        //    panel2.Visible = false;
        //    hidesubMenu();

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (panelgiaodien.Visible == true)
                MessageBox.Show("Vui long nhan vao thoat nhe");
            else
            {
                if (_quyen > 2)
                {
                    moForm(new restoreDaTa());
                }
                else
                    MessageBox.Show("chức năng này không dành cho bạn!");
                hidesubMenu();
            }
           

        }




        private void button14_Click(object sender, EventArgs e)
        {
             
            showsubmenu(panelgiaodien);
            hidesubMenu();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnThemNV.ForeColor = Color.Aqua;
            button3.ForeColor = Color.Aqua;
            btnMoLuong.ForeColor = Color.Aqua;
            button7.ForeColor = Color.Aqua;
            btncapnhatluong.ForeColor = Color.Aqua;
            button2.ForeColor = Color.Aqua;
            button5.ForeColor = Color.Aqua;
            button9.ForeColor = Color.Aqua;
            button15.ForeColor = Color.Aqua;
            button14.ForeColor = Color.Aqua;
            label4.ForeColor = Color.Orange;
            label3.ForeColor = Color.Orange;
            button1.ForeColor = Color.Orange;
            button6.ForeColor = Color.Orange;
            button11.ForeColor = Color.Orange;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnthongtinNV.ForeColor = Color.Red;
            button3.ForeColor = Color.Red;
            btnMoLuong.ForeColor = Color.Red;
            button7.ForeColor = Color.Red;
            btncapnhatluong.ForeColor = Color.Red;
            button2.ForeColor = Color.Red;
            button5.ForeColor = Color.Red;
            button9.ForeColor = Color.Red;
            button15.ForeColor = Color.Red;
            button14.ForeColor = Color.Red;
            label4.ForeColor = Color.Lime;
            label3.ForeColor = Color.Lime;
            button1.ForeColor = Color.Lime;
            button6.ForeColor = Color.Lime;
            button11.ForeColor = Color.Lime;
        }
 
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnthongtinNV.ForeColor = Color.DeepPink;
            button3.ForeColor = Color.DeepPink;
            btnMoLuong.ForeColor = Color.DeepPink;
            button7.ForeColor = Color.DeepPink;
            btncapnhatluong.ForeColor = Color.DeepPink;
            button2.ForeColor = Color.DeepPink;
            button5.ForeColor = Color.DeepPink;
            button9.ForeColor = Color.DeepPink;
            button15.ForeColor = Color.DeepPink;
            button14.ForeColor = Color.DeepPink;
            label4.ForeColor = Color.DarkViolet;
            label3.ForeColor = Color.DarkViolet;
            button1.ForeColor = Color.DarkViolet;
            button6.ForeColor = Color.DarkViolet;
            button11.ForeColor = Color.DarkViolet;
        }

        private void btnThoatgiaodien_Click(object sender, EventArgs e)
        {
            panelgiaodien.Visible = false;
            panelChilForm.Show();
        }

        private void panelgiaodien_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
