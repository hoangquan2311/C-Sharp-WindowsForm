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
    internal class DaoLuong : Connection
    {
        public static DataTable getAllLuong(string query)
        {
            return table(query);
        }
    }
}
