using QuanLyLuongCtyNN.Data_Access_Object;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        private bool validate()
        {
            if(txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                return false;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return false;
            }
            return true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (DaoLogin.checkAdmin(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain frm = new frmMain();
                    frm.Show();
                    frm.txtWelcome.Text = "Xin chào " + txtTaiKhoan.Text + "!";
                    this.Hide();
                }
                else if (DaoLogin.checkMember(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain frm = new frmMain();
                    frm.Show();
                    frm.tsQuanLyTK.Enabled = false;
                    frm.tsQuanLy.Enabled = false;
                    frm.tsKTKL.Enabled = false;
                    frm.txtWelcome.Text = "Xin chào " + txtTaiKhoan.Text + "!";
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Text = "";
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
