using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLuongCtyNN.Data_Access_Object;

namespace QuanLyLuongCtyNN.User_Control
{
    public partial class UC_ChucVu : UserControl
    {
        public UC_ChucVu()
        {
            InitializeComponent();
        }
        public void loadForm()
        {
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            txtLuongCB.Text = Convert.ToString(Connection.getLuongCB());
        }
        private void fillData()
        {
            dgvChucVu.DataSource = DaoChucVu.getAllChucVu();
            ArrayList dgvHeader = new ArrayList() {"Mã chức vụ", "Tên chức vụ", "Phụ cấp chức vụ" };
            for (int i = 0; i < dgvHeader.Count; i++)
            {
                dgvChucVu.Columns[i].HeaderText = dgvHeader[i].ToString();
            }
        }
        public void StateBtnThemSuaXoa(bool type)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            gbThongTin.Enabled = true;
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            clearInput();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            gbThongTin.Enabled = true;
            StateBtnThemSuaXoa(false);
            btnSua.Enabled = true;
            txtMaCV.ReadOnly = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaCV.Text;
            if (MessageBox.Show("Xóa chức vụ " + txtTenCV.Text + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DaoChucVu.deleteChucVu(id) == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }
        private void clearInput()
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            txtPCCV.Text = "";
            txtHeSo.Text = "";
        }
        private void refresh()
        {
            clearInput();
            gbThongTin.Enabled = false;
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            txtMaCV.ReadOnly = false;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form frm = this.ParentForm;
            frm.Dispose();
        }
        private bool validate()
        {
            if (txtMaCV.Text.Trim() == "")
            {
                MessageBox.Show("Mã chức vụ không được để trống!");
                return false;
            }
            if (txtTenCV.Text.Trim() == "")
            {
                MessageBox.Show("Tên chức vụ không được để trống!");
                return false;
            }
            if (txtHeSo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập hệ số phụ cấp!");
                return false;
            }
            if (txtPCCV.Text.Trim() == "")
            {
                MessageBox.Show("Hệ số phụ cấp không đúng!");
                return false;
            }
            return true;
        }
        private bool duplicate()
        {
            string noti_MaCV = "Đã tồn tại mã chức vụ này!";
            string query_MaCV = "Select MaChucVu from ChucVu where MaChucVu = @check";
            string noti_TenCV = "Tên chức vụ trùng lặp!";
            string query_TenCV = "Select TenChucVu from ChucVu where TenChucVu = @check";

            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_MaCV, query_MaCV, txtMaCV.Text.Trim()) == false) return false;
            if (btnSua.Enabled == true && String.Equals(txtTenCV.Text, dgvChucVu.SelectedRows[0].Cells[1].Value.ToString()) == false && DaoNhanVien.checkDuplicate(noti_TenCV, query_TenCV, txtTenCV.Text.Trim()) == false) return false;
            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_TenCV, query_TenCV, txtTenCV.Text.Trim()) == false) return false;

            return true;
        }
        public void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaCV.Text;
            string name = txtTenCV.Text;
            string pccv = txtPCCV.Text;
            if (btnThem.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Thêm chức vụ " + name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, name, pccv };
                    if (DaoChucVu.addChucVu(list) == 1)
                    {
                        MessageBox.Show("Đã thêm chức vụ mới!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Thêm thất bại!");
                }
            if (btnSua.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Sửa chức vụ " + id + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, name, pccv };
                    if (DaoChucVu.updateChucVu(list) == 1)
                    {
                        MessageBox.Show("Sửa thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Sửa thất bại!");
                }

        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gbThongTin.Enabled == false && btnThem.Enabled == true)
                StateBtnThemSuaXoa(true);
            txtMaCV.Text = dgvChucVu.SelectedRows[0].Cells[0].Value.ToString();
            txtTenCV.Text = dgvChucVu.SelectedRows[0].Cells[1].Value.ToString();
            txtPCCV.Text = dgvChucVu.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void txtHeSo_TextChanged(object sender, EventArgs e)
        {
            float number = 0F;
            if (float.TryParse(txtHeSo.Text, out number))
            {
                txtPCCV.Text = Convert.ToString(float.Parse(txtHeSo.Text) * float.Parse(txtLuongCB.Text));
            }
            else
                txtPCCV.Text = "";
        }
    }
}
