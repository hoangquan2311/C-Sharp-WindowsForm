using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;

namespace QuanLyLuongCtyNN.Data_Access_Object
{
    internal class DaoNhanVien : Connection
    {
        //Ham get tat ca nhan vien
        public static DataTable getAllNhanVien()
        {
            return table("select * from NhanVien");
        }

        public static DataTable getChuyenMon()
        {
            return table("select * from ChuyenMon");
        }

        //Ham kiem tra du lieu bi trung trong Database
        public static bool checkDuplicate(string noti, string query, string textbox)
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("check", textbox);
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show(noti, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }

        //Ham them nhan vien vao database
        public static int addNhanVien(ArrayList list)
        {
            string query = $"Insert into NhanVien values('{list[0]}',N'{list[1]}',N'{list[2]}','{list[3]}','{list[4]}',N'{list[5]}','{list[6]}','{list[7]}','{list[8]}',N'{list[9]}')";
            return Execute(query);
        }

        //Ham Update nhan vien vao database
        public static int updateNhanVien(ArrayList list)
        {
            string query = $"Update NhanVien set TenNV = N'{list[1]}',GioiTinh = N'{list[2]}',NgaySinh = '{list[3]}',NgayVaoCty = '{list[4]}',DanToc = N'{list[5]}',MaPhong = '{list[6]}',MaChuyenMon = '{list[7]}',SDT = '{list[8]}',DiaChi = N'{list[9]}' where MaNV = '{list[0]}'";
            return Execute(query);
        }

        //Xoa nhan vien khoi database
        public static int deleteNhanVien(string ma)
        {
            string query = $"delete from NhanVien where MaNV = '{ma}'";
            return Execute(query);
        }
    }
}
