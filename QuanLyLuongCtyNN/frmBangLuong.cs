using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLuongCtyNN.Data_Access_Object;
using QuanLyLuongCtyNN.User_Control;

namespace QuanLyLuongCtyNN
{
    public partial class frmBangLuong : Form
    {
        public frmBangLuong()
        {
            InitializeComponent();
        }

        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            //dgvLuong.DataSource;
            insertLuong();
        }

        private void insertLuong()
        {
            string MaLuong, MaPhong, MaNV, MaKTKL;
            int Thang, Nam, Luong, PhuCap, BHYT, BHXH, ThucLinh;
            DataTable table = DaoLuong.table("Select * from TinhLuong()");
            MaNV = table.Columns[0].ToString();
            MessageBox.Show(MaNV);
        }

    }
}
