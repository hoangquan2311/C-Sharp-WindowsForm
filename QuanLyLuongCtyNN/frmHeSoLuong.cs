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
    public partial class frmHeSoLuong : Form
    {
        public frmHeSoLuong()
        {
            InitializeComponent();
        }

        private void frmHeSoLuong_Load(object sender, EventArgs e)
        {
            UC_NVHSL uc = new UC_NVHSL();
            addUserControl(uc);
            uc.loadForm();
        }
        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UC_NVHSL uc = new UC_NVHSL();
            addUserControl(uc);
            uc.loadForm();
        }

        private void btnHeSoLuong_Click(object sender, EventArgs e)
        {
            UC_HeSoLuong uc = new UC_HeSoLuong();
            addUserControl(uc);
            uc.loadForm();
        }
    }
}
