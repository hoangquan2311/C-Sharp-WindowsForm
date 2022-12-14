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
    internal class DaoChuyenMon : Connection
    {
        public static DataTable getAllChuyenMon()
        {
            return table("select * from ChuyenMon");
        }

        //Ham them chuyen mon vao database
        public static int addChuyenMon(ArrayList list)
        {
            string query = $"Insert into ChuyenMon values('{list[0]}',N'{list[1]}')";
            return Execute(query);
        }

        //Ham Update chuyen mon vao database
        public static int updateChuyenMon(ArrayList list)
        {
            string query = $"Update ChuyenMon set TenChuyenMon = N'{list[1]}' where MaChuyenMon = '{list[0]}'";
            return Execute(query);
        }

        //Xoa chuyenmon khoi database
        public static int deleteChuyenMon(string ma)
        {
            string query = $"delete from ChuyenMon where MaChuyenMon = '{ma}'";
            return Execute(query);
        }
    }
}
