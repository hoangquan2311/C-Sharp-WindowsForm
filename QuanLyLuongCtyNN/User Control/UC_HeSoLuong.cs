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
    public partial class UC_HeSoLuong : UserControl
    {
        public UC_HeSoLuong()
        {
            InitializeComponent();
        }
        public void loadForm()
        {
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
        }
        private void fillData()
        {
            dgvHeSoLuong.DataSource = DaoHeSoLuong.getAllHeSoLuong();
            ArrayList dgvHeader = new ArrayList() { "Mã hệ số lương", "Hệ số lương" };
            for (int i = 0; i < dgvHeader.Count; i++)
            {
                dgvHeSoLuong.Columns[i].HeaderText = dgvHeader[i].ToString();
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
            txtMaHSL.ReadOnly = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaHSL.Text;
            if (MessageBox.Show("Xóa " + id + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DaoHeSoLuong.deleteHeSoLuong(id) == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }
        private void clearInput()
        {
            txtMaHSL.Text = "";
            txtHeSoLuong.Text = "";
        }
        private void refresh()
        {
            clearInput();
            gbThongTin.Enabled = false;
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            txtMaHSL.ReadOnly = false;
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
            if (txtMaHSL.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã hệ số lương!");
                return false;
            }
            if (txtHeSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập hệ số lương!");
                return false;
            }
            float number = 0F;
            if (float.TryParse(txtHeSoLuong.Text, out number) == false)
            {
                MessageBox.Show("Hệ số lương phải là số thực!");
                return false;
            }
            return true;
        }
        private bool duplicate()
        {
            string noti_MaCV = "Đã tồn tại mã hệ số lương này!";
            string query_MaCV = "Select MaHSL from HeSoLuong where MaHSL = @check";
            string noti_TenCV = "Hệ số lương trùng lặp!";
            string query_TenCV = "Select HeSoLuong from HeSoLuong where HeSoLuong = @check";

            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_MaCV, query_MaCV, txtMaHSL.Text.Trim()) == false) return false;
            if (btnSua.Enabled == true && String.Equals(txtHeSoLuong.Text, dgvHeSoLuong.SelectedRows[0].Cells[1].Value.ToString()) == false && DaoNhanVien.checkDuplicate(noti_TenCV, query_TenCV, txtHeSoLuong.Text.Trim()) == false) return false;
            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_TenCV, query_TenCV, txtHeSoLuong.Text.Trim()) == false) return false;

            return true;
        }
        public void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaHSL.Text;
            string hsl = txtHeSoLuong.Text;
            if (btnThem.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Thêm hệ số lương " + id + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, hsl };
                    if (DaoHeSoLuong.addHeSoLuong(list) == 1)
                    {
                        MessageBox.Show("Thêm thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Thêm thất bại!");
                }
            if (btnSua.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Sửa hệ số lương " + id + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, hsl };
                    if (DaoHeSoLuong.updateHeSoLuong(list) == 1)
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
        private void dgvHeSoLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gbThongTin.Enabled == false && btnThem.Enabled == true)
                StateBtnThemSuaXoa(true);
            txtMaHSL.Text = dgvHeSoLuong.SelectedRows[0].Cells[0].Value.ToString();
            txtHeSoLuong.Text = dgvHeSoLuong.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
