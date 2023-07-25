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
    public partial class restoreDaTa : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        DB db = new DB();
        public restoreDaTa()
        {
            InitializeComponent();
        }

        private void restoreDaTa_Load(object sender, EventArgs e)
        {
            showdgv();
        }
        private void showdgv() {
            string sql = "select* from tblThongTin_NV where TrangThai='off'";
            conn = db.OpenDB();
            conn.Open();
            dataGridView1.DataSource = DB.GetDataTable(sql);
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtma.Text == null) {
                MessageBox.Show("Dường như hiệu ứng click ko thành công, bạn vui lòng click lại");
            }
            else
            {
                string sql = "update tblThongTin_NV set  TrangThai='on' where manv='" + txtma.Text + "'";
                conn = db.OpenDB();
                conn.Open();
                DB.Excute(sql);
                conn.Close();
                showdgv();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int i = dataGridView1.CurrentRow.Index;
            txtma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
