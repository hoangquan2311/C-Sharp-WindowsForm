using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongCtyNN.Data_Access_Object
{
    internal class DaoHeSoLuong : Connection
    {
        public static DataTable getAllHeSoLuong()
        {
            return table("select * from HeSoLuong");
        }
        public static DataTable getAllNVHeSoLuong()
        {
            return table("Select NhanVien.MaNV, NhanVien.TenNV, NhanVienHSL.MaHSL, HeSoLuong.HeSoLuong, NhanVienHSL.NgayApDung from NhanVien, NhanVienHSL , HeSoLuong where NhanVien.MaNV = NhanVienHSL.MaNV AND NhanVienHSL.MaHSL = HeSoLuong.MaHSL");
        }

        //Ham them trinh do vao database
        public static int addHeSoLuong(ArrayList list)
        {
            string query = $"Insert into HeSoLuong values(N'{list[0]}','{list[1]}')";
            return Execute(query);
        }
        //Ham them nhan vien trinh do vao database
        public static int addNVHeSoLuong(ArrayList list)
        {
            string query = $"Insert into NhanVienHSL values('{list[0]}',N'{list[1]}','{list[2]}')";
            return Execute(query);
        }
        //Ham Update trinh do vao database
        public static int updateHeSoLuong(ArrayList list)
        {
            string query = $"Update HeSoLuong set HeSoLuong = '{list[1]}' where MaHSL = N'{list[0]}'";
            return Execute(query);
        }
        //Ham Update nhan vien trinh do vao database
        public static int updateNVHeSoLuong(ArrayList list)
        {
            string query = $"Update NhanVienHSL set MaHSL = N'{list[1]}',NgayApDung = '{list[2]}' where MaNV = '{list[0]}'";
            return Execute(query);
        }

        //Xoa trinh do khoi database
        public static int deleteHeSoLuong(string ma)
        {
            string query = $"delete from HeSoLuong where MaHSL = N'{ma}'";
            return Execute(query);
        }
        //Xoa nhan vien trinh do khoi database
        public static int deleteNVHeSoLuong(string ma)
        {
            string query = $"delete from NhanVienHSL where MaNV = '{ma}'";
            return Execute(query);
        }

        public static string getTenNV(string id)
        {
            string name = "";
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
