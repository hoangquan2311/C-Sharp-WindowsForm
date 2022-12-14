using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuongCtyNN
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void tsNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }

        private void tsPhongBan_Click(object sender, EventArgs e)
        {
            frmPhongBan frm = new frmPhongBan();
            frm.Show();
        }

        private void tsChucVu_Click(object sender, EventArgs e)
        {
            frmChucVu frm = new frmChucVu();
            frm.Show();
        }

        private void tsTrinhDo_Click(object sender, EventArgs e)
        {
            frmTrinhDo frm = new frmTrinhDo();
            frm.Show();
        }

        private void tsChuyenMon_Click(object sender, EventArgs e)
        {
            frmChuyenMon frm = new frmChuyenMon();
            frm.Show();
        }

        private void tsHeSoLuong_Click(object sender, EventArgs e)
        {
            frmHeSoLuong frm = new frmHeSoLuong();
            frm.Show();
        }

        private void tsCaNhan_Click(object sender, EventArgs e)
        {

        }

        private void tsBangLuong_Click(object sender, EventArgs e)
        {
            frmBangLuong frm = new frmBangLuong();
            frm.Show();
        }

        private void tsSearch_Click(object sender, EventArgs e)
        {
            frmSearch frm = new frmSearch();
            frm.Show();
        }

        private void tsDoiMK_Click(object sender, EventArgs e)
        {

        }
        private void dangXuat()
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }

        private void tsDangXuat_Click(object sender, EventArgs e)
        {
            dangXuat();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            dangXuat();
        }
    }
}
