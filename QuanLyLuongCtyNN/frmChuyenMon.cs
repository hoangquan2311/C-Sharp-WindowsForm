using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLuongCtyNN.Data_Access_Object;

namespace QuanLyLuongCtyNN
{
    public partial class frmChuyenMon : Form
    {
        public frmChuyenMon()
        {
            InitializeComponent();
        }
        private void fillData()
        {
            dgvChuyenMon.DataSource = DaoChuyenMon.getAllChuyenMon();
        }
        private void frmChuyenMon_Load(object sender, EventArgs e)
        {
            //Khoi tao form
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            fillData();

            //Doi header dgv
            ArrayList dgvHeader = new ArrayList() { "Mã Chuyên môn", "Tên Chuyên môn"};
            for (int i = 0; i < dgvHeader.Count; i++)
            {
                dgvChuyenMon.Columns[i].HeaderText = dgvHeader[i].ToString();
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
            txtMaCM.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaCM.Text;
            if (MessageBox.Show("Xóa " + txtTenCM.Text + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DaoChuyenMon.deleteChuyenMon(id) == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }
        private void clearInput()
        {
            txtMaCM.Text = "";
            txtTenCM.Text = "";
        }
        private void refresh()
        {
            clearInput();
            gbThongTin.Enabled = false;
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            txtMaCM.ReadOnly = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool validate()
        {
            if (txtMaCM.Text.Trim() == "")
            {
                MessageBox.Show("Mã phòng ban không được để trống!");
                return false;
            }
            if (txtTenCM.Text.Trim() == "")
            {
                MessageBox.Show("Tên phòng ban không được để trống!");
                return false;
            }
            return true;
        }
        private bool duplicate()
        {
            string noti_MaCM = "Đã tồn tại mã chuyên môn này!";
            string query_MaCM = "Select MaChuyenMon from ChuyenMon where MaChuyenMon = @check";
            string noti_TenCM = "Tên chuyên môn trùng lặp!";
            string query_TenCM = "Select TenChuyenMon from ChuyenMon where TenChuyenMon = @check";

            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_MaCM, query_MaCM, txtMaCM.Text.Trim()) == false) return false;
            if (btnSua.Enabled == true && String.Equals(txtTenCM.Text, dgvChuyenMon.SelectedRows[0].Cells[1].Value.ToString()) == false && DaoNhanVien.checkDuplicate(noti_TenCM, query_TenCM, txtTenCM.Text.Trim()) == false) return false;
            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_TenCM, query_TenCM, txtTenCM.Text.Trim()) == false) return false;

            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaCM.Text;
            string name = txtTenCM.Text;

            if (btnThem.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Thêm chuyên môn " + id + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, name };
                    if (DaoChuyenMon.addChuyenMon(list) == 1)
                    {
                        MessageBox.Show("Đã thêm chuyên môn " + id, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Thêm thất bại!");
                }
            if (btnSua.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Sửa chuyên môn " + dgvChuyenMon.SelectedRows[0].Cells[0].Value.ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, name };
                    if (DaoChuyenMon.updateChuyenMon(list) == 1)
                    {
                        MessageBox.Show("Sửa thành công", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Sửa thất bại!");
                }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void dgvChuyenMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gbThongTin.Enabled == false && btnThem.Enabled == true)
                StateBtnThemSuaXoa(true);
            txtMaCM.Text = dgvChuyenMon.SelectedRows[0].Cells[0].Value.ToString();
            txtTenCM.Text = dgvChuyenMon.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
