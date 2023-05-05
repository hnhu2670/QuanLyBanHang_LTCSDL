using NghiepVu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;

namespace GiaDien_GUI_
{
    public partial class fmHDBanHang : Form
    {
        HDBanHang_BUS bus = new HDBanHang_BUS();
        Load_BUS load = new Load_BUS();
        public fmHDBanHang()
        {
            InitializeComponent();
        }

        void TextBox_Load()
        {
            txtMaHD.Clear();
            
            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtTimMa.Clear();
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor =  btnXoa.BackColor = Color.FromArgb(116, 139, 184);
            dateNgayXuat.Enabled = true;
            dateNgayXuat.Value = DateTime.Now;

            txtMaHD.Enabled = true;
            cmbTenKH.Enabled = true;
            cmbTenNV.Enabled = true;
        }
        private void background_Form()
        {
            label1.ForeColor = label2.ForeColor =
            label3.ForeColor = label5.ForeColor =  label7.ForeColor = Color.White;
            rdbTimMa.ForeColor =  Color.White;
            groupBox1.ForeColor = groupBox2.ForeColor = Color.White;


            dgvThongTin.ForeColor = Color.Black;

            txtMaHD.ForeColor  = Color.DarkBlue;

        }
        private void Combobox_Load()
        {
            
            try
            {
                cmbTenNV.DataSource = load.BUS_LoadNhanVien();
                //giá trị hiển thị
                cmbTenNV.DisplayMember = "TenNhanVien";
                //giá trị lưu trữ
                cmbTenNV.ValueMember = "MaNhanVien";

                cmbTenKH.DataSource = load.BUS_LoadKhachHang();
                cmbTenKH.DisplayMember = "TenKhachHang";
                cmbTenKH.ValueMember = "MaKhachHang";
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //cmbMaNV.ValueMember = bus.BUS_LoadCombobox().ToString
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            background_Form();
            Combobox_Load();
            dgvThongTin.DataSource = bus.BUS_LoadHoaDonBan();
            dgvThongTin.Columns[0].Width = 150;
            dgvThongTin.Columns[1].Width = dgvThongTin.Columns[2].Width = dgvThongTin.Columns[3].Width = 350;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            txtTimMa.Enabled = false;
            btnLuu.Enabled = false;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor  = btnXoa.BackColor = Color.FromArgb(116, 139, 184);
        }

        private void dgvThongTin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMaHD.Enabled = false;
            cmbTenKH.Enabled = false;
            cmbTenNV.Enabled = false;
            dateNgayXuat.Enabled = false;
            int i;
            //truy cập vào hàng hiện tại
            i = dgvThongTin.CurrentRow.Index;
            txtMaHD.Text = dgvThongTin.Rows[i].Cells[0].Value.ToString();
            cmbTenNV.Text = dgvThongTin.Rows[i].Cells[1].Value.ToString();
            dateNgayXuat.Text = dgvThongTin.Rows[i].Cells[2].Value.ToString();
            cmbTenKH.Text = dgvThongTin.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHD.Enabled = true;
            cmbTenKH.Enabled = true;
            cmbTenNV.Enabled = true;
            dateNgayXuat.Enabled = true;
            dateNgayXuat.Value = DateTime.Now;
            txtMaHD.Clear();
            
            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(116, 139, 184);
            btnThem.Enabled = false;

             btnXoa.Enabled = false;
             btnXoa.BackColor = btnThem.BackColor = Color.FromArgb(226, 228, 233);
            txtMaHD.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            HoaDon_DTO hd = new HoaDon_DTO();
            hd.MaHD = txtMaHD.Text;
            hd.NgayXuatHD = dateNgayXuat.Value;
            hd.MaNV = cmbTenNV.SelectedValue.ToString();
            hd.MaKH = cmbTenKH.SelectedValue.ToString();

            try
            {
                if (txtMaHD.Text.Trim() == string.Empty)
                {
                    throw new Exception("Chưa nhập mã hóa đơn");
                }

                else
                {
                    string str = txtMaHD.Text.Trim();
                    if (str.Length >= 3 && str.Contains("B"))
                    {
                        bus.BUS_ThemHD(hd);
                        dgvThongTin.DataSource = bus.BUS_LoadHoaDonBan();

                        MessageBox.Show("Thêm hóa đơn thành công");
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThem.BackColor = Color.Green;
                        btnXoa.BackColor = Color.Blue;
                        TextBox_Load();

                    }
                    else MessageBox.Show("Mã hóa đơn chưa đúng định dạng");
                }    
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon_DTO hd = new HoaDon_DTO();
                hd.MaHD = txtMaHD.Text;
                hd.NgayXuatHD = dateNgayXuat.Value;
                hd.MaNV = cmbTenNV.SelectedValue.ToString();
                hd.MaKH = cmbTenKH.SelectedValue.ToString();
                if (txtMaHD.Text != String.Empty)
                {
                    bus.BUS_XoaHD(hd);
                    dgvThongTin.DataSource = bus.BUS_LoadHoaDonBan();
                    MessageBox.Show("Xóa thành công");
                    TextBox_Load();
                }
                else 
                    MessageBox.Show("Chọn hàng cần xóa");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                MessageBox.Show("Không thể xóa hóa đơn này");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvThongTin.DataSource = bus.BUS_LoadHoaDonBan();
            Combobox_Load();
            TextBox_Load();
        }

        private void dgvThongTin_DoubleClick(object sender, EventArgs e)
        {
            //lấy mã hóa đơn từ form CT Hoa don
            string ma;
            ma = dgvThongTin.CurrentRow.Cells[0].Value.ToString();
            //truyền qua CT hoa don
            fmChiTietHD chiTietHD = new fmChiTietHD();
            chiTietHD.maHDBan = ma;
            chiTietHD.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbTimMa.Checked == true)
            {
                if(txtTimMa.Text.Trim() != string.Empty)
                    dgvThongTin.DataSource = load.BUS_MaHD(txtTimMa.Text.Trim());
                else MessageBox.Show("Nhập mã hóa đơn cần tìm");
            }
        }

        private void rdbTimMa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTimMa.Checked == true)
            {
                txtTimMa.Enabled = true;
            }
            else txtTimMa.Enabled = false;
        }

        private void fmHDBanHang_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(2, 10, 87), Color.FromArgb(242, 243, 245), 40f);
            g.FillRectangle(brush, gradient_rectangle);
        }
    }
}
