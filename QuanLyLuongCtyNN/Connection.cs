using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyLuongCtyNN
{
    internal class Connection
    {
        protected static string strcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Desktop\QuanLyLuongCtyNN\QuanLyLuongCtyNN\Database.mdf;Integrated Security=True";
        protected private static SqlDataAdapter da;
        protected private static SqlCommand cmd;

        public static DataTable table(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                con.Close();
            }
            return dt;
        }
        public static int Execute(string query)
        {
            int result;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                result = cmd.ExecuteNonQuery();
                con.Close();
            }
            return result;
        }
        public static int getLuongCB()
        {
            int luong = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                cmd = new SqlCommand("select LuongCB from LuongCoBan", con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                    luong = rd.GetInt32(0);
                con.Close();
            }
            return luong;
        }
    }
}
