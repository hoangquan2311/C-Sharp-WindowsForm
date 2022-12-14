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
    internal class DaoLogin : Connection
    {
        public static bool checkAdmin(string tk, string mk)
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand($"select TaiKhoan, MatKhau from TaiKhoan where TaiKhoan = '{tk}' and MatKhau = '{mk}' and Quyen = N'Quản trị'", con);
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read()==false)
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
        public static bool checkMember(string tk, string mk)
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand($"select TaiKhoan, MatKhau from TaiKhoan where TaiKhoan = '{tk}' and MatKhau = '{mk}' and Quyen = N'Nhân viên'", con);
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read() == false)
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
    }
}
