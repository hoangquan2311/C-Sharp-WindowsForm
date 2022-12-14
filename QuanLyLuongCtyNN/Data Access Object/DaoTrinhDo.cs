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
    internal class DaoTrinhDo : Connection
    {
        public static DataTable getAllTrinhDo()
        {
            return table("select * from TrinhDo");
        }
        public static DataTable getAllNVTrinhDo()
        {
            return table("Select NhanVien.MaNV, NhanVien.TenNV, NhanVienTrinhDo.MaTrinhDo, TrinhDo.TenTrinhDo, NhanVienTrinhDo.NgayApDung, TrinhDo.PhuCap from NhanVien, NhanVienTrinhDo , TrinhDo where NhanVien.MaNV = NhanVienTrinhDo.MaNV AND NhanVienTrinhDo.MaTrinhDo = TrinhDo.MaTrinhDo");
        }

        //Ham them trinh do vao database
        public static int addTrinhDo(ArrayList list)
        {
            string query = $"Insert into TrinhDo values('{list[0]}',N'{list[1]}','{list[2]}')";
            return Execute(query);
        }
        //Ham them nhan vien trinh do vao database
        public static int addNVTrinhDo(ArrayList list)
        {
            string query = $"Insert into NhanVienTrinhDo values('{list[0]}','{list[1]}','{list[2]}')";
            return Execute(query);
        }
        //Ham Update trinh do vao database
        public static int updateTrinhDo(ArrayList list)
        {
            string query = $"Update TrinhDo set TenTrinhDo = N'{list[1]}',PhuCap = '{list[2]}' where MaTrinhDo = '{list[0]}'";
            return Execute(query);
        }
        //Ham Update nhan vien trinh do vao database
        public static int updateNVTrinhDo(ArrayList list)
        {
            string query = $"Update NhanVienTrinhDo set MaTrinhDo = '{list[1]}',NgayApDung = '{list[2]}' where MaNV = '{list[0]}'";
            return Execute(query);
        }

        //Xoa trinh do khoi database
        public static int deleteTrinhDo(string ma)
        {
            string query = $"delete from TrinhDo where MaTrinhDo = '{ma}'";
            return Execute(query);
        }
        //Xoa nhan vien trinh do khoi database
        public static int deleteNVTrinhDo(string ma)
        {
            string query = $"delete from NhanVienTrinhDo where MaNV = '{ma}'";
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
