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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void fillData()
        {
            dgvNhanVien.DataSource = DaoNhanVien.getAllNhanVien();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            StateBtnThemSuaXoa(false);
            btnThem.Enabled = true;
            fillData();
            //Do du lieu Phong ban vao combobox
            cbPhongBan.DataSource = DaoPhongBan.getAllPhongBan();
            cbPhongBan.DisplayMember = "TenPhong";
            cbPhongBan.ValueMember = "MaPhong";
            cbPhongBan.SelectedItem= null;

            //Do du lieu Chuyen mon vao combobox
            cbChuyenMon.DataSource = DaoNhanVien.getChuyenMon();
            cbChuyenMon.DisplayMember = "TenChuyenMon";
            cbChuyenMon.ValueMember = "MaChuyenMon";
            cbChuyenMon.SelectedItem = null;

            //Doi header dgv
            ArrayList dgvHeader = new ArrayList() { "Mã NV", "Tên NV", "Giới tính", "Ngày sinh", "Ngày vào Cty", "Dân tộc", "Phòng ban", "Chuyên môn", "Số ĐT", "Địa chỉ" };
            for(int i=0; i<dgvHeader.Count;i++)
            {
                dgvNhanVien.Columns[i].HeaderText = dgvHeader[i].ToString();
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
            gbThongTin.Enabled= true;
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
            string name = txtTenNV.Text;
            if(MessageBox.Show("Xóa nhân viên "+name+" ?", "",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(DaoNhanVien.deleteNhanVien(id) == 1)
                {
                    MessageBox.Show("Xóa nhân viên "+ name+" thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }

        private void clearInput()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            radioNam.Checked = true;
            radioNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoCty.Value = DateTime.Now;
            txtDanToc.Text = "";
            cbPhongBan.SelectedItem = null;
            cbChuyenMon.SelectedItem = null;
            txtSDT.Text = "";
            txtDiaChi.Text = "";
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            refresh();
        }
        //Ham rang buoc du lieu
        private bool validate()
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống!");
                return false;
            }
            if (txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống!");
                return false;
            }
            TimeSpan diff = DateTime.Now.Subtract(dtpNgaySinh.Value);
            if (diff.TotalDays < 6570)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi!");
                return false;
            }
            if (dtpNgayVaoCty.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày vào công ty lớn hơn ngày hôm nay!");
                return false;
            }
            if (txtDanToc.Text.Trim() == "")
            {
                MessageBox.Show("Dân tộc không được để trống!");
                return false;
            }
            if (cbPhongBan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban!");
                return false;
            }
            if (cbChuyenMon.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chuyên môn!");
                return false;
            }
            int number = 0;
            if (int.TryParse(txtSDT.Text, out number) != true)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được để trống!");
                return false;
            }
            return true;
        }

        private bool duplicate()
        {
            string noti_MaNV = "Đã tồn tại mã nhân viên này!";
            string query_MaNV = "Select MaNV from NhanVien where MaNV = @check";
            string noti_SDT = "Đã tồn tại số điện thoại này!";
            string query_SDT = "Select SDT from NhanVien where SDT = @check";
            if (btnSua.Enabled == false && DaoNhanVien.checkDuplicate(noti_MaNV, query_MaNV, txtMaNV.Text.Trim()) == false) return false;
            if (String.Equals(txtSDT.Text,dgvNhanVien.SelectedRows[0].Cells[8].Value.ToString()) == false && DaoNhanVien.checkDuplicate(noti_SDT, query_SDT, txtSDT.Text.Trim()) == false) return false;
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text;
            string name = txtTenNV.Text;
            string gender;
            string birth = dtpNgaySinh.Value.ToString();
            string join = dtpNgayVaoCty.Value.ToString();
            string dantoc = txtDanToc.Text;
            string sdt = txtSDT.Text;
            string diachi = txtDiaChi.Text;

            if (radioNam.Checked == true)
                gender = "Nam";
            else gender = "Nữ";

            if (btnThem.Enabled == true)
                if(validate() && duplicate() && MessageBox.Show("Thêm nhân viên "+name+" ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string phongban = cbPhongBan.SelectedValue.ToString();
                    string chuyenmon = cbChuyenMon.SelectedValue.ToString();
                    ArrayList list = new ArrayList() { id, name, gender, birth, join, dantoc, phongban, chuyenmon, sdt, diachi };
                    if(DaoNhanVien.addNhanVien(list)==1)
                    {
                        MessageBox.Show("Đã thêm nhân viên! ","Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Thêm thất bại!");
                }
            if (btnSua.Enabled == true)
                if (validate() && duplicate() && MessageBox.Show("Sửa nhân viên " + dgvNhanVien.SelectedRows[0].Cells[1].Value.ToString() + " ?" , "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string phongban = cbPhongBan.SelectedValue.ToString();
                    string chuyenmon = cbChuyenMon.SelectedValue.ToString();
                    ArrayList list = new ArrayList() { id, name, gender, birth, join, dantoc, phongban, chuyenmon, sdt, diachi };
                    if (DaoNhanVien.updateNhanVien(list) == 1)
                    {
                        MessageBox.Show("Sửa thành công", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else MessageBox.Show("Sửa thất bại!");
                }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gbThongTin.Enabled == false && btnThem.Enabled == true)
                StateBtnThemSuaXoa(true);
            txtMaNV.Text = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.SelectedRows[0].Cells[1].Value.ToString();

            if(dgvNhanVien.SelectedRows[0].Cells[2].Value.ToString() == "Nam")
                radioNam.Checked = true;
            else radioNu.Checked = true;

            dtpNgaySinh.Value = DateTime.Parse(dgvNhanVien.SelectedRows[0].Cells[3].Value.ToString());
            dtpNgayVaoCty.Value = DateTime.Parse(dgvNhanVien.SelectedRows[0].Cells[4].Value.ToString());
            txtDanToc.Text = dgvNhanVien.SelectedRows[0].Cells[5].Value.ToString();
            cbPhongBan.SelectedValue = dgvNhanVien.SelectedRows[0].Cells[6].Value.ToString();
            cbChuyenMon.SelectedValue = dgvNhanVien.SelectedRows[0].Cells[7].Value.ToString();
            txtSDT.Text = dgvNhanVien.SelectedRows[0].Cells[8].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.SelectedRows[0].Cells[9].Value.ToString();
        }
    }
}
