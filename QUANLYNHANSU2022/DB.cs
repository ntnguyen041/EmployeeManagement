using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU2022
{
    internal class DB
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;

        public SqlConnection OpenDB() { 
            conn = new SqlConnection(@"Data Source =TANNGUYEN\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True");
            return conn;
        }
        public static void OpenConnection() {
            string sql = @"Data Source = TANNGUYEN\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            try {
                conn = new SqlConnection(sql);
                conn.Open();
            }
            catch (SqlException err) { 
            }
        }
        public static void CloseConnection() { 
         /// dong ket noi
         conn.Close();
        // ngat ket noi
        conn.Dispose();
        conn= null;
        }

        // tao ban luu co so du lieu
        public static DataTable GetDataTable(string sql) { 
        // khoi tao 1 sqlcommand de tro toi du lieu trong database
             cmd = new SqlCommand(sql,conn);
        // khoi tao 1 sqlatapter de luu tru du lieu tu database
           SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand =cmd; 
        // tao 1 databsetable de hien thi du lieu
            DataTable table = new DataTable(); 
            da.Fill(table);
            da.Dispose();
            cmd.Dispose();
            return table;
        }

        public static void Excute(string sql)
        { 

            cmd=new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
        }
    }
}
