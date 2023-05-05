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
using NghiepVu;
using DTO;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Drawing.Drawing2D;

namespace GiaDien_GUI_
{
    public partial class fmNhaCungCap : Form
    {
        NhaCungCap_BUS ncc = new NhaCungCap_BUS();
        
        public fmNhaCungCap()
        {
            InitializeComponent();
        }
       
        public void TextBox_Load()
        {
            txtmaNCC.Clear();
            txtmaNCC.Focus();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtTimMa.Clear();
            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = true;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);
        }
        private void dgvThongTin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtmaNCC.Enabled = false;
            int i;
            i = dgvThongTin.CurrentRow.Index;
            txtmaNCC.Text = dgvThongTin.Rows[i].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvThongTin.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvThongTin.Rows[i].Cells[2].Value.ToString();
            txtDienThoai.Text = dgvThongTin.Rows[i].Cells[3].Value.ToString();
        }
        private void background_Form()
        {
            label1.ForeColor = label2.ForeColor =
            label3.ForeColor = label4.ForeColor =
            label5.ForeColor =  Color.White;
            rdbTimMa.ForeColor = Color.White;
            groupBox1.ForeColor = groupBox2.ForeColor = Color.White;


            dgvThongTin.ForeColor = Color.Black;

            txtmaNCC.ForeColor=txtTenNCC.ForeColor=txtDiaChi.ForeColor=txtDienThoai.ForeColor=Color.DarkBlue;

        }
        private void fmNhaCungCap_Load(object sender, EventArgs e)
        {
            background_Form();
            dgvThongTin.DataSource = ncc.BUS_LoadNCC();

            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            txtTimMa.Enabled = false;
            btnLuu.Enabled = false;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            txtmaNCC.Enabled = true;
            txtmaNCC.Clear();
            txtTenNCC.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();  
            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(116, 139, 184);
            btnThem.Enabled = false;

            btnSua.Enabled = btnXoa.Enabled = false;
            btnSua.BackColor = btnXoa.BackColor = btnThem.BackColor = Color.FromArgb(226, 228, 233);
            txtmaNCC.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmaNCC.Text.Trim() == String.Empty)
                {
                    throw new Exception("Chưa nhập mã khách hàng");
                }
                else
                {
                    string str = txtmaNCC.Text.Trim();
                    //MessageBox.Show(str.Length.ToString());
                    if (str.Length >= 5 && str.Contains("NCC"))
                    {
                        if (txtDiaChi.Text.Trim() == string.Empty || txtDienThoai.Text.Trim() == string.Empty || txtTenNCC.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Nhập chưa đủ thông tin!!!!!!!!!!!!!!!!!!");
                        }
                        else
                        {
                            NhaCungCap_DTO n = new NhaCungCap_DTO(txtmaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim());
                            ncc.BUS_ThemNCC(n);

                            dgvThongTin.DataSource = ncc.BUS_LoadNCC();
                            MessageBox.Show("Thêm nhà cung cấp thành công");
                            TextBox_Load();
                        }
                    }
                    else MessageBox.Show("Mã nhà cung cấp chưa đúng định dạng");
                }    
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmaNCC.Text.Trim() != String.Empty)
                {
                    if (txtDiaChi.Text.Trim() == string.Empty || txtDienThoai.Text.Trim() == string.Empty || txtTenNCC.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Nhập chưa đủ thông tin!!!!!!!!!!!!!!!!!!");
                    }
                    else
                    {
                        NhaCungCap_DTO n = new NhaCungCap_DTO(txtmaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text);
                        ncc.BUS_SuaNCC(n);
                        dgvThongTin.DataSource = ncc.BUS_LoadNCC();
                        MessageBox.Show("Sửa thông tin NCC thành công");
                    }
                }
                else MessageBox.Show("Chọn hàng cần sửa");
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Error");
                MessageBox.Show("Kiểu dữ liệu chưa chính xác");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                NhaCungCap_DTO n = new NhaCungCap_DTO(txtmaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtDienThoai.Text);
                if (txtmaNCC.Text != String.Empty)
                {
                    ncc.BUS_XoaNCC(n);
                    dgvThongTin.DataSource = ncc.BUS_LoadNCC();
                    MessageBox.Show("Xóa thành công");
                    TextBox_Load();
                }
                else MessageBox.Show("Chọn hàng cần xóa");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                MessageBox.Show("Không thể xóa NCC");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvThongTin.DataSource = ncc.BUS_LoadNCC();
            TextBox_Load();
        }

        private void rdbTimMa_CheckedChanged(object sender, EventArgs e)
        {
            txtTimMa.Enabled = true;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbTimMa.Checked == true)
                {
                    if(txtTimMa.Text != string.Empty)
                        dgvThongTin.DataSource = ncc.BUS_TimMaNCC(txtTimMa.Text);
                    else MessageBox.Show("Nhập mã NCC cần tìm");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fmNhaCungCap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(2, 10, 87), Color.FromArgb(242, 243, 245), 40f);
            g.FillRectangle(brush, gradient_rectangle);
        }

        
    }
}
