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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace QuanLyLuongCtyNN.Data_Access_Object
{
    internal class DaoChucVu : Connection
    {
        public static DataTable getAllChucVu()
        {
            return table("select * from ChucVu");
        }
        public static DataTable getAllNVChucVu()
        {
            return table("Select NhanVien.MaNV, NhanVien.TenNV, NhanVienChucVu.MaChucVu, ChucVu.TenChucVu, NhanVienChucVu.NgayApDung, ChucVu.PhuCapCV from NhanVien, NhanVienChucVu , ChucVu where NhanVien.MaNV = NhanVienChucVu.MaNV AND NhanVienChucVu.MaChucVu = ChucVu.MaChucVu");
        }

        //Ham them chuc vu vao database
        public static int addChucVu(ArrayList list)
        {
            string query = $"Insert into ChucVu values('{list[0]}',N'{list[1]}','{list[2]}')";
            return Execute(query);
        }
        //Ham them nhan vien chuc vu vao database
        public static int addNVChucVu(ArrayList list)
        {
            string query = $"Insert into NhanVienChucVu values('{list[0]}','{list[1]}','{list[2]}')";
            return Execute(query);
        }
        //Ham Update chuc vu vao database
        public static int updateChucVu(ArrayList list)
        {
            string query = $"Update ChucVu set TenChucVu = N'{list[1]}',PhuCapCV = '{list[2]}' where MaChucVu = '{list[0]}'";
            return Execute(query);
        }
        //Ham Update nhan vien chuc vu vao database
        public static int updateNVChucVu(ArrayList list)
        {
            string query = $"Update NhanVienChucVu set MaChucVu = '{list[1]}',NgayApDung = '{list[2]}' where MaNV = '{list[0]}'";
            return Execute(query);
        }

        //Xoa chuc vu khoi database
        public static int deleteChucVu(string ma)
        {
            string query = $"delete from ChucVu where MaChucVu = '{ma}'";
            return Execute(query);
        }
        //Xoa nhan vien chuc vu khoi database
        public static int deleteNVChucVu(string ma)
        {
            string query = $"delete from NhanVienChucVu where MaNV = '{ma}'";
            return Execute(query);
        }

        public static string getTenNV(string id)
        {
            string name="";
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                cmd = new SqlCommand("select TenNV from NhanVien where MaNV = @MaNV", con);
                cmd.Parameters.AddWithValue("@MaNV", id);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                    name = rd.GetString(0);
                con.Close();
            }
            return name;
        }
        public static DateTime getNgayVaoCty(string id)
        {
            DateTime date = new DateTime();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                cmd = new SqlCommand("select NgayVaoCty from NhanVien where MaNV = @MaNV", con);
                cmd.Parameters.AddWithValue("@MaNV", id);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                    date = rd.GetDateTime(0);
                con.Close();
            }
            return date;
        }
    }
}
