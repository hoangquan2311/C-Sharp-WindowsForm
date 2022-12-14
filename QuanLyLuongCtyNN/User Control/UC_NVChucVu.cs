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
    public partial class UC_NVChucVu : UserControl
    {
        public UC_NVChucVu()
        {
            InitializeComponent();
        }

        public void loadForm()
        {
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;

            cbChucVu.DataSource = DaoChucVu.getAllChucVu();
            cbChucVu.DisplayMember = "TenChucVu";
            cbChucVu.ValueMember = "MaChucVu";
            cbChucVu.SelectedItem = null;
        }
        private void fillData()
        {
            dgvNVChucVu.DataSource = DaoChucVu.getAllNVChucVu();
            ArrayList dgvHeader = new ArrayList() { "Mã NV", "Tên NV", "Mã chức vụ", "Tên chức vụ", "Ngày áp dụng", "Phụ cấp chức vụ" };
            for (int i = 0; i < dgvHeader.Count; i++)
            {
                dgvNVChucVu.Columns[i].HeaderText = dgvHeader[i].ToString();
            }
        }
        public void StateBtnThemSuaXoa(bool type)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = DaoChucVu.getTenNV(txtMaNV.Text);
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
            txtMaNV.ReadOnly = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text;
            if (MessageBox.Show("Xóa chức vụ của nhân viên " + txtTenNV.Text + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DaoChucVu.deleteNVChucVu(id) == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }
        private void clearInput()
        {
            txtMaNV.Text = "";
            cbChucVu.SelectedItem = null;
            dtpApDung.Value = DateTime.Now;
        }
        private void refresh()
        {
            clearInput();
            gbThongTin.Enabled = false;
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            txtMaNV.ReadOnly = false;
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
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống!");
                return false;
            }
            if (txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Không tồn tại mã nhân viên này!");
                return false;
            }
            if (cbChucVu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!");
                return false;
            }
            if(txtTenNV.Text.Trim() != "")
            {
                if (dtpApDung.Value < DaoChucVu.getNgayVaoCty(txtMaNV.Text))
                {
                    MessageBox.Show("Ngày áp dụng không được nhỏ hơn ngày vào công ty!");
                    return false;
                }
            }
            return true;
        }
        private bool duplicate()
        {
            string noti_MaNV = "Nhân viên " + txtTenNV.Text +" đã tồn tại chức vụ!";
            string query_MaNV = "Select MaNV from NhanVienChucVu where MaNV = @check";
            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_MaNV, query_MaNV, txtMaNV.Text.Trim()) == false) return false;
            return true;
        }

        public void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text;
            string name = txtTenNV.Text;
            string date = dtpApDung.Value.ToString();
            if (btnThem.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Thêm chức vụ cho nhân viên " + name + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string macv = cbChucVu.SelectedValue.ToString();
                    ArrayList list = new ArrayList() { id, macv, date };
                    if (DaoChucVu.addNVChucVu(list) == 1)
                    {
                        MessageBox.Show("Đã thêm chức vụ cho nhân viên!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Thêm thất bại!");
                }
            if (btnSua.Enabled == true)
                if (validate() && MessageBox.Show("Sửa chức vụ cho nhân viên " + name + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string macv = cbChucVu.SelectedValue.ToString();
                    ArrayList list = new ArrayList() { id, macv, date };
                    if (DaoChucVu.updateNVChucVu(list) == 1)
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
        private void dgvNVChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gbThongTin.Enabled == false && btnThem.Enabled == true)
                StateBtnThemSuaXoa(true);
            txtMaNV.Text = dgvNVChucVu.SelectedRows[0].Cells[0].Value.ToString();
            cbChucVu.SelectedValue = dgvNVChucVu.SelectedRows[0].Cells[2].Value.ToString();
            dtpApDung.Value = DateTime.Parse(dgvNVChucVu.SelectedRows[0].Cells[4].Value.ToString());
        }
    }
}
