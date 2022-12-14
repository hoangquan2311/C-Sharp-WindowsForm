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
    public partial class frmTrinhDo : Form
    {
        public frmTrinhDo()
        {
            InitializeComponent();
        }

        private void frmTrinhDo_Load(object sender, EventArgs e)
        {
            UC_NVTrinhDo uc = new UC_NVTrinhDo();
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
            UC_NVTrinhDo uc = new UC_NVTrinhDo();
            addUserControl(uc);
            uc.loadForm();
        }

        private void btnTrinhDo_Click(object sender, EventArgs e)
        {
            UC_TrinhDo uc = new UC_TrinhDo();
            addUserControl(uc);
            uc.loadForm();
        }
    }
}
