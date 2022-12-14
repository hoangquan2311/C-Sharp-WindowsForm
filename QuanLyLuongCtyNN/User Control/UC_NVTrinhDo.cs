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
    public partial class UC_NVTrinhDo : UserControl
    {
        public UC_NVTrinhDo()
        {
            InitializeComponent();
        }
        public void loadForm()
        {
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;

            cbTrinhDo.DataSource = DaoTrinhDo.getAllTrinhDo();
            cbTrinhDo.DisplayMember = "TenTrinhDo";
            cbTrinhDo.ValueMember = "MaTrinhDo";
            cbTrinhDo.SelectedItem = null;
        }
        private void fillData()
        {
            dgvNVTrinhDo.DataSource = DaoTrinhDo.getAllNVTrinhDo();
            ArrayList dgvHeader = new ArrayList() { "Mã NV", "Tên NV", "Mã trình độ", "Tên trình độ", "Ngày áp dụng", "Phụ cấp trình độ" };
            for (int i = 0; i < dgvHeader.Count; i++)
            {
                dgvNVTrinhDo.Columns[i].HeaderText = dgvHeader[i].ToString();
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
            txtTenNV.Text = DaoTrinhDo.getTenNV(txtMaNV.Text);
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
            if (MessageBox.Show("Xóa trình độ của nhân viên " + txtTenNV.Text + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DaoTrinhDo.deleteNVTrinhDo(id) == 1)
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
            cbTrinhDo.SelectedItem = null;
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
            if (cbTrinhDo.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trình độ!");
                return false;
            }
            if (txtTenNV.Text.Trim() != "")
            {
                if (dtpApDung.Value < DaoTrinhDo.getNgayVaoCty(txtMaNV.Text))
                {
                    MessageBox.Show("Ngày áp dụng không được nhỏ hơn ngày vào công ty!");
                    return false;
                }
            }
            return true;
        }
        private bool duplicate()
        {
            string noti_MaNV = "Nhân viên " + txtTenNV.Text + " đã tồn tại trình độ!";
            string query_MaNV = "Select MaNV from NhanVienTrinhDo where MaNV = @check";
            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_MaNV, query_MaNV, txtMaNV.Text.Trim()) == false) return false;
            return true;
        }

        public void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text;
            string name = txtTenNV.Text;
            string date = dtpApDung.Value.ToString();
            if (btnThem.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Thêm trình độ cho nhân viên " + name + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string macv = cbTrinhDo.SelectedValue.ToString();
                    ArrayList list = new ArrayList() { id, macv, date };
                    if (DaoTrinhDo.addNVTrinhDo(list) == 1)
                    {
                        MessageBox.Show("Đã thêm trình độ cho nhân viên!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Thêm thất bại!");
                }
            if (btnSua.Enabled == true)
                if (validate() && MessageBox.Show("Sửa trình độ cho nhân viên " + name + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string macv = cbTrinhDo.SelectedValue.ToString();
                    ArrayList list = new ArrayList() { id, macv, date };
                    if (DaoTrinhDo.updateNVTrinhDo(list) == 1)
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
        private void dgvNVTrinhDo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gbThongTin.Enabled == false && btnThem.Enabled == true)
                StateBtnThemSuaXoa(true);
            txtMaNV.Text = dgvNVTrinhDo.SelectedRows[0].Cells[0].Value.ToString();
            cbTrinhDo.SelectedValue = dgvNVTrinhDo.SelectedRows[0].Cells[2].Value.ToString();
            dtpApDung.Value = DateTime.Parse(dgvNVTrinhDo.SelectedRows[0].Cells[4].Value.ToString());
        }
    }
}
