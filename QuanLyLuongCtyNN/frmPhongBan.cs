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
using System.Xml.Linq;
using QuanLyLuongCtyNN.Data_Access_Object;

namespace QuanLyLuongCtyNN
{
    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }
        private void fillData()
        {
            dgvPhongBan.DataSource = DaoPhongBan.getAllPhongBan();
        }
        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            //Khoi tao form
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            fillData();

            //Doi header dgv
            ArrayList dgvHeader = new ArrayList() { "Mã Phòng ban", "Tên Phòng ban", "Số ĐT"};
            for (int i = 0; i < dgvHeader.Count; i++)
            {
                dgvPhongBan.Columns[i].HeaderText = dgvHeader[i].ToString();
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
            txtMaPB.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaPB.Text;
            if (MessageBox.Show("Xóa phòng ban " + id + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DaoPhongBan.deletePhongBan(id) == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }
        private void clearInput()
        {
            txtMaPB.Text = "";
            txtTenPB.Text = "";
            txtSDT.Text = "";
        }
        private void refresh()
        {
            clearInput();
            gbThongTin.Enabled = false;
            fillData();
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            txtMaPB.ReadOnly = false;
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
            if (txtMaPB.Text.Trim() == "")
            {
                MessageBox.Show("Mã phòng ban không được để trống!");
                return false;
            }
            if (txtTenPB.Text.Trim() == "")
            {
                MessageBox.Show("Tên phòng ban không được để trống!");
                return false;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được để trống!");
                return false;
            }
            int number = 0;
            if (int.TryParse(txtSDT.Text, out number) != true)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return false;
            }
            return true;
        }
        private bool duplicate()
        {
            string noti_MaPB = "Đã tồn tại mã phòng ban này!";
            string query_MaPB = "Select MaPhong from PhongBan where MaPhong = @check";
            string noti_TenPB = "Tên phòng ban trùng lặp!";
            string query_TenPB = "Select TenPhong from PhongBan where TenPhong = @check";
            string noti_SDT = "Đã tồn tại số điện thoại này!";
            string query_SDT = "Select SDT from PhongBan where SDT = @check";

            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_MaPB, query_MaPB, txtMaPB.Text.Trim()) == false) return false;
            if (btnSua.Enabled == true && String.Equals(txtTenPB.Text, dgvPhongBan.SelectedRows[0].Cells[1].Value.ToString()) == false && DaoNhanVien.checkDuplicate(noti_TenPB, query_TenPB, txtTenPB.Text.Trim()) == false) return false;
            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_TenPB, query_TenPB, txtTenPB.Text.Trim()) == false) return false;
            if (btnThem.Enabled == true && DaoNhanVien.checkDuplicate(noti_SDT, query_SDT, txtSDT.Text.Trim()) == false) return false;
            if (btnSua.Enabled == true && String.Equals(txtSDT.Text, dgvPhongBan.SelectedRows[0].Cells[2].Value.ToString()) == false && DaoNhanVien.checkDuplicate(noti_SDT, query_SDT, txtSDT.Text.Trim()) == false) return false;
                    
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaPB.Text;
            string name = txtTenPB.Text;
            string sdt = txtSDT.Text;

            if (btnThem.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Thêm phòng ban " + id + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, name, sdt};
                    if (DaoPhongBan.addPhongBan(list) == 1)
                    {
                        MessageBox.Show("Đã thêm phòng ban " + id, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Thêm thất bại!");
                }
            if (btnSua.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Sửa phòng ban " + dgvPhongBan.SelectedRows[0].Cells[0].Value.ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArrayList list = new ArrayList() { id, name, sdt};
                    if (DaoPhongBan.updatePhongBan(list) == 1)
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

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gbThongTin.Enabled == false && btnThem.Enabled == true)
                StateBtnThemSuaXoa(true);
            txtMaPB.Text = dgvPhongBan.SelectedRows[0].Cells[0].Value.ToString();
            txtTenPB.Text = dgvPhongBan.SelectedRows[0].Cells[1].Value.ToString();
            txtSDT.Text = dgvPhongBan.SelectedRows[0].Cells[2].Value.ToString();
        }

    }
}
