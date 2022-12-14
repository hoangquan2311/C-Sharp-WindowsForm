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
using QuanLyLuongCtyNN.User_Control;

namespace QuanLyLuongCtyNN
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }
        private void frmSearch_Load(object sender, EventArgs e)
        {
            fillData();
            cbChuyenMon.DataSource = DaoChuyenMon.getAllChuyenMon();
            cbChuyenMon.DisplayMember = "TenChuyenMon";
            cbChuyenMon.ValueMember = "MaChuyenMon";
            cbChuyenMon.SelectedItem = null;

            cbTrinhDo.DataSource = DaoTrinhDo.getAllTrinhDo();
            cbTrinhDo.DisplayMember = "TenTrinhDo";
            cbTrinhDo.ValueMember = "MaTrinhDo";
            cbTrinhDo.SelectedItem = null;

            cbHSL.DataSource = DaoHeSoLuong.getAllHeSoLuong();
            cbHSL.DisplayMember = "MaHSL";
            cbHSL.SelectedItem = null;
        }
        private void fillData()
        {
            dgvSearch.DataSource = DaoNhanVien.getAllNhanVien();
            ArrayList dgvHeader = new ArrayList() { "Mã NV", "Tên NV", "Giới tính", "Ngày sinh", "Ngày vào Cty", "Dân tộc", "Phòng ban", "Chuyên môn", "Số ĐT", "Địa chỉ" };
            for (int i = 0; i < dgvHeader.Count; i++)
            {
                dgvSearch.Columns[i].HeaderText = dgvHeader[i].ToString();
            }
        }
        private bool validateTen()
        {
            if(txtTen.Text == "")
            {
                MessageBox.Show("Vui lòng điền họ tên");
                return false;
            }
            return true;
        }
        private void btnSearchTen_Click(object sender, EventArgs e)
        {
            if (validateTen() && DaoNhanVien.checkDuplicate("Đã tìm thấy nhân viên "+txtTen.Text+"!", "Select TenNV from NhanVien where TenNV = @check", txtTen.Text.Trim())==false)
            {
                    dgvSearch.DataSource = DaoSearch.getNhanVienTen(txtTen.Text);
            }
            else MessageBox.Show("Nhân viên " + txtTen.Text +" không tồn tại!");
        }

        private void btnSearchCM_Click(object sender, EventArgs e)
        {
            if (cbChuyenMon.SelectedItem != null)
            {
                dgvSearch.DataSource = DaoSearch.getNhanVienCM(cbChuyenMon.SelectedValue.ToString());
                MessageBox.Show("Đã hiển thị các nhân viên có chuyên môn: " + cbChuyenMon.GetItemText(cbChuyenMon.SelectedItem));
            }
            else MessageBox.Show("Vui lòng chọn chuyên môn!");
        }
        private void btnSearchTD_Click(object sender, EventArgs e)
        {
            if(cbTrinhDo.SelectedItem != null)
            {
                dgvSearch.DataSource = DaoSearch.getNhanVienTD(cbTrinhDo.SelectedValue.ToString());
                MessageBox.Show("Đã hiển thị các nhân viên có trình độ " + cbTrinhDo.GetItemText(cbTrinhDo.SelectedItem));
            }    
            else MessageBox.Show("Vui lòng chọn trình độ!");
        }

        private void btnSearchHSL_Click(object sender, EventArgs e)
        {
            if (cbHSL.SelectedItem != null)
            {
                dgvSearch.DataSource = DaoSearch.getNhanVienHSL(cbHSL.GetItemText(cbHSL.SelectedItem));
                MessageBox.Show("Đã hiển thị các nhân viên có hệ số lương " + cbHSL.GetItemText(cbHSL.SelectedItem));
            }
            else MessageBox.Show("Vui lòng chọn hệ số lương!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillData();
            txtTen.Text = "";
            cbChuyenMon.SelectedItem = null;
            cbHSL.SelectedItem = null;
            cbTrinhDo.SelectedItem = null;
        }
    }
}
