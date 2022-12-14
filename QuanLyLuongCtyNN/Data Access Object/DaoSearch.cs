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
    internal class DaoSearch : Connection
    {
        public static DataTable getNhanVienTen(string name)
        {  
            return table("select * from NhanVien where TenNV = N'" + name +"'");
        }
        public static DataTable getNhanVienCM(string cm)
        {
            return table("select * from NhanVien where MaChuyenMon = '"+ cm +"'");
        }
        public static DataTable getNhanVienTD(string td)
        {
            return table("select NhanVien.* from NhanVien,NhanVienTrinhDo " +
                "where NhanVien.MaNV = NhanVienTrinhDo.MaNV and NhanVienTrinhDo.MaTrinhDo = '"+td+"'");
        }
        public static DataTable getNhanVienHSL(string ma)
        {
            return table("select NhanVien.* from NhanVien,NhanVienHSL " +
                "where NhanVien.MaNV = NhanVienHSL.MaNV and NhanVienHSL.MaHSL = N'" + ma + "'");
        }
    }
}
