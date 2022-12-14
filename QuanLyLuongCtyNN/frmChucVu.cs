using QuanLyLuongCtyNN.Data_Access_Object;
using QuanLyLuongCtyNN.User_Control;
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
    public partial class frmChucVu : Form
    {
        public frmChucVu()
        {
            InitializeComponent();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            UC_NVChucVu uc = new UC_NVChucVu();
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
            UC_NVChucVu uc = new UC_NVChucVu();
            addUserControl(uc);
            uc.loadForm();
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            UC_ChucVu uc = new UC_ChucVu();
            addUserControl(uc);
            uc.loadForm();
        }
    }
}
