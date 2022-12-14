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
    public partial class UC_TrinhDo : UserControl
    {
        public UC_TrinhDo()
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
            dgvTrinhDo.DataSource = DaoTrinhDo.getAllTrinhDo();
            ArrayList dgvHeader = new ArrayList() { "Mã trình độ", "Tên trình độ", "Phụ cấp trình độ" };
            for (int i = 0; i < dgvHeader.Count; i++)
            {
                dgvTrinhDo.Columns[i].HeaderText = dgvHeader[i].ToString();
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
            txtMaTD.ReadOnly = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaTD.Text;
            if (MessageBox.Show("Xóa trình độ " + txtTenTD.Text + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DaoTrinhDo.deleteTrinhDo(id) == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }
        private void clearInput()
        {
            txtMaTD.Text = "";
            txtTenTD.Text = "";
            txtHeSo.Text = "";
            txtPC.Text = "";
        }
        private void refresh()
        {
            clearInput();
            gbThongTin.Enabled = false;
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            txtMaTD.ReadOnly = false;
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
            if (txtMaTD.Text.Trim() == "")
            {
                MessageBox.Show("Mã trình độ không được để trống!");
                return false;
            }
            if (txtTenTD.Text.Trim() == "")
            {
                MessageBox.Show("Tên trình độ không được để trống!");
                return false;
            }
            if (txtHeSo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập hệ số phụ cấp!");
                return false;
            }
            if (txtPC.Text.Trim() == "")
            {
                MessageBox.Show("Hệ số phụ cấp không đúng!");
                return false;
            }
            return true;
        }
        private bool duplicate()
        {
            string noti_MaTD = "Đã tồn tại mã trình độ này!";
            string query_MaTD = "Select MaTrinhDo from TrinhDo where MaTrinhDo = @check";
            string noti_TenTD = "Tên trình độ trùng lặp!";
            string query_TenTD = "Select TenTrinhDo from TrinhDo where TenTrinhDo = @check";

            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_MaTD, query_MaTD, txtMaTD.Text.Trim()) == false) return false;
            if (btnSua.Enabled == true && String.Equals(txtTenTD.Text, dgvTrinhDo.SelectedRows[0].Cells[1].Value.ToString()) == false && DaoNhanVien.checkDuplicate(noti_TenTD, query_TenTD, txtTenTD.Text.Trim()) == false) return false;
            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_TenTD, query_TenTD, txtTenTD.Text.Trim()) == false) return false;

            return true;
        }
        public void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaTD.Text;
            string name = txtTenTD.Text;
            string pc = txtPC.Text;
            if (btnThem.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Thêm trình độ " + name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, name, pc };
                    if (DaoTrinhDo.addTrinhDo(list) == 1)
                    {
                        MessageBox.Show("Đã thêm trình độ mới!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Thêm thất bại!");
                }
            if (btnSua.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Sửa trình độ " + id + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, name, pc };
                    if (DaoTrinhDo.updateTrinhDo(list) == 1)
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
        private void dgvTrinhDo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gbThongTin.Enabled == false && btnThem.Enabled == true)
                StateBtnThemSuaXoa(true);
            txtMaTD.Text = dgvTrinhDo.SelectedRows[0].Cells[0].Value.ToString();
            txtTenTD.Text = dgvTrinhDo.SelectedRows[0].Cells[1].Value.ToString();
            txtPC.Text = dgvTrinhDo.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void txtHeSo_TextChanged(object sender, EventArgs e)
        {
            float number = 0F;
            if (float.TryParse(txtHeSo.Text, out number))
            {
                txtPC.Text = Convert.ToString(float.Parse(txtHeSo.Text) * float.Parse(txtLuongCB.Text));
            }
            else
                txtPC.Text = "";
        }
    }
}
