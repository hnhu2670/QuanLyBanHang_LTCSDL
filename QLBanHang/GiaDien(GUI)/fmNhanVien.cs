using DTO;
using NghiepVu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaDien_GUI_
{
    public partial class fmNhanVien : Form
    {
        Load_BUS bus = new Load_BUS();
        ChucNang_BUS ch = new ChucNang_BUS();
        public fmNhanVien()
        {
            InitializeComponent();
        }

        void TextBox_Load()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTimTen.Clear();
            txtTimMa.Clear();
            dateNS.Value = DateTime.Now;
            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = true;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);
        }
        private void background_Form()
        {
            label1.ForeColor = label2.ForeColor =
            label3.ForeColor = label4.ForeColor =
            label5.ForeColor = label6.ForeColor =  Color.White;
            rdbTimMa.ForeColor = rdbTimTen.ForeColor = Color.White;
            groupBox1.ForeColor = groupBox2.ForeColor = Color.White;


            dgvThongTin.ForeColor = Color.Black;

            dateNS.CalendarForeColor=txtMaNV.ForeColor =  txtTenNV.ForeColor = txtDiaChi.ForeColor=txtDienThoai.ForeColor= Color.DarkBlue;

        }
        //private void dgvThongTin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    int i;
        //    i = dgvThongTin.CurrentRow.Index;
        //    txtMaNV.Text = dgvThongTin.Rows[i].Cells[0].Value.ToString();
        //    txtTenNV.Text = dgvThongTin.Rows[i].Cells[1].Value.ToString();
        //    dateNS.Text = dgvThongTin.Rows[i].Cells[2].Value.ToString();
        //    txtDiaChi.Text = dgvThongTin.Rows[i].Cells[3].Value.ToString();
        //    txtDienThoai.Text = dgvThongTin.Rows[i].Cells[4].Value.ToString();
        //    txtMaNV.Enabled=false;
        //}
        private void NhanVien_Load(object sender, EventArgs e)
        {
            background_Form();

            dgvThongTin.DataSource = bus.BUS_LoadNhanVien();

            txtTimMa.Enabled = false;
            txtTimTen.Enabled = false;
            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvThongTin.DataSource = bus.BUS_LoadNhanVien();
            TextBox_Load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtMaNV.Enabled = true;
            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(116, 139, 184);
            btnThem.Enabled = false;
            dateNS.Value=DateTime.Now;

            btnSua.Enabled = btnXoa.Enabled = false;
            btnSua.BackColor = btnXoa.BackColor = btnThem.BackColor = Color.FromArgb(226, 228, 233);
            txtMaNV.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text.Trim() == String.Empty)
                {
                    throw new Exception("Chưa nhập mã nhân viên");
                }
                else
                {
                    string str = txtMaNV.Text.Trim();
                    //MessageBox.Show(str.Length.ToString());
                    if (str.Length >= 4 && str.Contains("NV"))
                    {
                        if (txtDiaChi.Text.Trim() == string.Empty || txtDienThoai.Text.Trim() == string.Empty || txtTenNV.Text.Trim() == string.Empty )
                        {
                            MessageBox.Show("Nhập chưa đủ thông tin !!!!!!!!!!!!!!!!!!");
                        }
                        else
                        {   
                            NhanVien_DTO n = new NhanVien_DTO(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), DateTime.Parse(dateNS.Text));
                            ch.ThemNV(n);
                            dgvThongTin.DataSource = bus.BUS_LoadNhanVien();
                            MessageBox.Show("Thêm nhân viên thành công");
                            TextBox_Load();
                        }
                    }
                    else MessageBox.Show("Mã nhân viên chưa đúng định định dạng");
                }    
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Thông tin chưa đúng kiểu dữ liệu");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien_DTO n = new NhanVien_DTO(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(),txtDiaChi.Text.Trim(),txtDienThoai.Text.Trim(),DateTime.Parse(dateNS.Text));
                if (txtMaNV.Text.Trim() != string.Empty)
                {
                    if (txtDiaChi.Text.Trim() == string.Empty || txtDienThoai.Text.Trim() == string.Empty || txtTenNV.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Nhập chưa đủ thông tin !!!!!!!!!!!!!!!!!!");
                    }
                    else
                    {
                        ch.SuaNV(n);
                        dgvThongTin.DataSource = bus.BUS_LoadNhanVien();
                        MessageBox.Show("Sửa thông tin nhân viên thành công");
                        TextBox_Load();
                    }    
                    
                }
                else
                    MessageBox.Show("Chọn hàng cần sửa");
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                MessageBox.Show("Lỗi !!!!!!!!!!!!!!!!!!!!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //dgvThongTin.MultiSelect = true;

                NhanVien_DTO n = new NhanVien_DTO(txtMaNV.Text, txtTenNV.Text,txtDiaChi.Text, txtDienThoai.Text, DateTime.Parse(dateNS.Text));
                if (txtMaNV.Text != string.Empty)

                {
                    ch.XoaNV(n);
                    dgvThongTin.DataSource = bus.BUS_LoadNhanVien();
                    MessageBox.Show("Xóa thành công");
                    TextBox_Load();
                }
                else
                    MessageBox.Show("Chọn hàng cần xóa");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa thông tin nhân viên này");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbTimMa.Checked == true)
                {
                    if(txtTimMa.Text.Trim() != string.Empty)
                        dgvThongTin.DataSource = bus.BUS_TimMaNhanVien(txtTimMa.Text.Trim());
                    else MessageBox.Show("Nhập mã nhân viên cần tìm");

                }
                if (rdbTimTen.Checked == true)
                {
                    if(txtTimTen.Text.Trim() != string.Empty)
                        dgvThongTin.DataSource = bus.BUS_TimTenNhanVien(txtTimTen.Text.Trim());
                    else MessageBox.Show("Nhập tên nhân viên cần tìm");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdbTimMa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTimMa.Checked == true)
            {
                txtTimMa.Enabled = true;
                txtTimTen.Clear();
            }
            else txtTimMa.Enabled = false;
        }

        private void rdbTimTen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTimTen.Checked == true)
            {
                txtTimTen.Enabled = true;
                txtTimMa.Clear();
            }
            else txtTimTen.Enabled = false;
        }

        private void fmNhanVien_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(2, 10, 87), Color.FromArgb(242, 243, 245), 40f);
            g.FillRectangle(brush, gradient_rectangle);
        }

        private void dgvThongTin_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try

            {
                txtMaNV.Enabled = false;
                int i;
                i = dgvThongTin.CurrentRow.Index;
                txtMaNV.Text = dgvThongTin.Rows[i].Cells[0].Value.ToString();
                txtTenNV.Text = dgvThongTin.Rows[i].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvThongTin.Rows[i].Cells[2].Value.ToString();
                txtDienThoai.Text = dgvThongTin.Rows[i].Cells[3].Value.ToString();
                dateNS.Text = dgvThongTin.Rows[i].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
           


        }
    }
}
