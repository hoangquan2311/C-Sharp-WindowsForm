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
    internal class DaoPhongBan : Connection
    {
        public static DataTable getAllPhongBan()
        {
            return table("select * from PhongBan");
        }

        //Ham them phong ban vao database
        public static int addPhongBan(ArrayList list)
        {
            string query = $"Insert into PhongBan values('{list[0]}',N'{list[1]}','{list[2]}')";
            return Execute(query);
        }

        //Ham Update phong ban vao database
        public static int updatePhongBan(ArrayList list)
        {
            string query = $"Update PhongBan set TenPhong = N'{list[1]}',SDT = '{list[2]}' where MaPhong = '{list[0]}'";
            return Execute(query);
        }

        //Xoa phong ban khoi database
        public static int deletePhongBan(string ma)
        {
            string query = $"delete from PhongBan where MaPhong = '{ma}'";
            return Execute(query);
        }
    }
}
